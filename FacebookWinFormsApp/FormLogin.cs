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
    public partial class FormLogin : Form
    {
        private readonly Facade r_Facade;

        public FormLogin(Facade i_Facade)
        {
            r_Facade = i_Facade;
            InitializeComponent();
        }

        public bool IsLoggedIn
        {
            get
            {
                return r_Facade.IsLoggedIn;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            r_Facade.Login();
            this.Close();
        }
    }
}
