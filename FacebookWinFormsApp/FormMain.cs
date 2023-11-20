using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using MetaLogicManager;


namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private readonly Facade r_Facade;
        private readonly ICardDecorator r_CallingCardPanel;

        public FormMain(Facade i_FacadeMain)
        {
            r_Facade = i_FacadeMain;
            InitializeComponent();
            r_CallingCardPanel = new CardDecorator(new CalingCardPanel(this.panelCallingCard));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            new Thread(fetchAllInfo).Start();
        }

        private void fetchAllInfo()
        {
            showProfilePicture();
            new Thread(showAlbums).Start();
            new Thread(showGroups).Start();
            new Thread(showLikedPages).Start();
        }
        
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            r_Facade.Logout();
        }

        private void linkedLabelFetchPosts_LinkClicked(object sender, EventArgs e)
        {
            showPosts();
        }

        private void showProfilePicture()
        {
            pictureBoxProfilePic.LoadAsync(r_Facade.ProfilePictureURL);
        }

        private void showPosts()
        {
            listBoxPosts.Items.Clear();
            try
            {
                foreach (Post post in r_Facade.Posts)
                {
                    if (post.Message != null)
                    {
                        listBoxPosts.Items.Add(post.Message);
                    }
                    else if (post.Caption != null)
                    {
                        listBoxPosts.Items.Add(post.Caption);
                    }
                    else
                    {
                        listBoxPosts.Items.Add(string.Format("[{0}]", post.Type));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabelFetchAlbums_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showAlbums();
        }

        private void showAlbums()
        {
            setDataSource(albumBindingSource, r_Facade.Albums);
        }

        private void setDataSource(BindingSource i_BindingSource, object i_DataSource)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => i_BindingSource.DataSource = i_DataSource)); ;
            }
            else
            {
                i_BindingSource.DataSource = i_DataSource;
            }
        }

        private void linkLabelFetchGroups_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showGroups();
        }

        private void showGroups()
        {
            setDataSource(groupBindingSource, r_Facade.Groups);
        }

        private void linkLabelFetchLikedPages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showLikedPages();
        }

        private void showLikedPages()
        {
            setDataSource(pageBindingSource, r_Facade.LikedPages);
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBoxPostText.Text))
            {
                postNewStatus();
            }
            else
            {
                MessageBox.Show("Empty post.. :( try again");
            }
        }

        private void postNewStatus()
        {
            string postedStatusId;

            try
            {
                postedStatusId = r_Facade.PostStatus(richTextBoxPostText.Text);
                MessageBox.Show("Status Posted! ID: " + postedStatusId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void richTextBoxPostText_Enter(object sender, EventArgs e)
        {
            richTextBoxPostText.Clear();
        }

        private void buttonShowRiddle_Click(object sender, EventArgs e)
        {
            if (radioButtonDownSort.Checked == false && radioButtonUpSort.Checked == false)
            {
                MessageBox.Show("First choose how you like to see the riddles");
            }
            else
            {
                showRiddle();
            }
        }

        private void showRiddle()
        {
            labelRiddleAnswer.Text = "";
            labelRiddle.Text = r_Facade.GetRiddle();
        }

        private void buttonShowAnswer_Click(object sender, EventArgs e)
        {
            showRiddleAnswer();
        }

        private void showRiddleAnswer()
        {
            if (string.IsNullOrEmpty(labelRiddle.Text) == true)
            {
                MessageBox.Show("Pick a riddle first ..");
            }
            else
            {
                labelRiddleAnswer.Text = r_Facade.GetRiddleAnswer();
            }
        }

        private void buttonShowCallingCard_Click(object sender, EventArgs e)
        {
            showCallingCard();
        }

        private void showCallingCard()
        {
            setDataSource(userBindingSource, r_Facade.MetaUser.User);
            Invoke(new Action(() => labelGenderText.Text = r_Facade.Gender));
            Invoke(new Action(() => labelLocationText.Text = r_Facade.Location));
        }

        private void textBoxMoreInfo_TextChanged(object sender, EventArgs e)
        {
            labelMoreInfoText.Text = textBoxMoreInfo.Text;
        }

        private void radioButtonUpSort_CheckedChanged(object sender, EventArgs e)
        {
            r_Facade.SortSrategy = new UpSorter();
            if (radioButtonDownSort.Checked == true)
            {
                MessageBox.Show("Already sorted by down sorter");
            }
            else
            {
                radioButtonUpSort.Checked = true;
            }
        }

        private void radioButtonDownSort_CheckedChanged(object sender, EventArgs e)
        {
            r_Facade.SortSrategy = new DownSorter();
            if(radioButtonUpSort.Checked == true)
            {
                MessageBox.Show("Already sorted by up sorter");
            }
            else
            {
                radioButtonDownSort.Checked = true;
            }
       }
    }
}

