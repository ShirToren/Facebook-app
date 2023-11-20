using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace MetaLogicManager
{
    public class MetaConnectLogic
    {
        private const string k_AppID = "658415255785295";

        public LoginResult LoginResult { get; private set; }

        public bool IsLoggedIn
        {
            get
            {
                return LoginResult.LoggedInUser != null;
            }
        }

        public void Login()
        {
            LoginResult = FacebookService.Login(k_AppID,
                   "email",
                    "public_profile",
                    "user_age_range",
                    "user_birthday",
                    "user_events",
                    "user_friends",
                    "user_gender",
                    "user_hometown",
                    "user_likes",
                    "user_link",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_videos",
                    "groups_access_member_info");
        }

        public void Logout()
        {
            FacebookService.LogoutWithUI();
        }
    }
}
