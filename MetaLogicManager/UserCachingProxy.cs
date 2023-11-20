using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace MetaLogicManager
{
    public class UserCachingProxy
    {
        private FacebookObjectCollection<Post> m_Posts;
        private FacebookWrapper.ObjectModel.City m_Location;
        private FacebookObjectCollection<Album> m_Albums;
        private FacebookObjectCollection<Group> m_Groups;
        private FacebookObjectCollection<Page> m_LikedPages;
        private string m_ProfilePictureURL;
        private string m_Gender;
        private string m_Email;
        private string m_Name;

        public UserCachingProxy(User i_User)
        {
            User = i_User;
        }

        public User User { get; }

        public string ProfilePictureURL
        {
            get
            {
                if(m_ProfilePictureURL == null)
                {
                    m_ProfilePictureURL = User.PictureNormalURL;
                }

                return m_ProfilePictureURL;
            }
        }

        public string Gender
        {
            get
            {
                if (m_Gender == null)
                {
                    m_Gender = User.Gender.ToString();
                }

                return m_Gender;
            }
        }

        public string Email
        {
            get
            {
                if (m_Email == null)
                {
                    m_Email = User.Email;
                }

                return m_Email;
            }
        }

        public string Name
        {
            get
            {
                if (m_Name == null)
                {
                    m_Name = User.Name;
                }

                return m_Name;
            }
        }

        public FacebookObjectCollection<Post> Posts
        {
            get
            {
                if (m_Posts == null)
                {
                    m_Posts = User.Posts;
                }

                return m_Posts;
            }
        }

        public FacebookObjectCollection<Album> Albums
        {
            get
            {
                if (m_Albums == null)
                {
                    m_Albums = User.Albums;
                }

                return m_Albums;
            }
        }

        public FacebookObjectCollection<Group> Groups
        {
            get
            {
                if (m_Groups == null)
                {
                    m_Groups = User.Groups;
                }

                return m_Groups;
            }
        }

        public FacebookObjectCollection<Page> LikedPages
        {
            get
            {
                if (m_LikedPages == null)
                {
                    m_LikedPages = User.LikedPages;
                }

                return m_LikedPages;
            }
        }

        public FacebookWrapper.ObjectModel.City Location
        {
            get
            {
                if (m_Location == null)
                {
                    m_Location = User.Location;
                }

                return m_Location;
            }
        }

        public string PostStatus(string i_PostText)
        {
            return User.PostStatus(i_PostText).Id;
        }
    }
}
