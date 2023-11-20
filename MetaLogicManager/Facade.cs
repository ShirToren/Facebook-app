using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace MetaLogicManager
{
    public class Facade
    {
        private readonly MetaLogic r_MetaLogic = MetaLogic.Instance;

        public ISortStrategy SortSrategy
        {
            set
            {
                r_MetaLogic.SortStrategy = value;
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return r_MetaLogic.IsLoggedIn;
            }
        }

        public string ProfilePictureURL 
        {
            get
            {
                return r_MetaLogic.User.ProfilePictureURL; 
            }
        }

        public FacebookObjectCollection<Post> Posts
        {
            get
            {
                return r_MetaLogic.User.Posts;
            }
        }

        public FacebookObjectCollection<Album> Albums
        {
            get
            {
                return r_MetaLogic.User.Albums;
            }
        }

        public FacebookObjectCollection<Page> LikedPages
        {
            get
            {
                return r_MetaLogic.User.LikedPages;
            }
        }

        public FacebookObjectCollection<Group> Groups
        {
            get
            {
                return r_MetaLogic.User.Groups;
            }
        }

        public UserCachingProxy MetaUser
        {
            get
            {
                return r_MetaLogic.User;
            }
        }

        public string Name
        {
            get
            {
                return r_MetaLogic.User.Name;
            }
        }

        public string Gender
        {
            get
            {
                return r_MetaLogic.User.Gender;
            }
        }

        public string Location
        {
            get
            {
                return r_MetaLogic.User.Location.Name;
            }
        }

        public string Email
        {
            get
            {
                return r_MetaLogic.User.Email;
            }
        }

        public void Login()
        {
            r_MetaLogic.Login();
        }

        public string PostStatus(string i_PostToShare)
        {
            return r_MetaLogic.PostStatus(i_PostToShare);
        }

        public string GetRiddle()
        {
            return r_MetaLogic.GetRiddle();
        }

        public string GetRiddleAnswer()
        {
            return r_MetaLogic.GetRiddleAnswer();
        }

        public void Logout()
        {
            r_MetaLogic.Logout();
        }
    }
}
