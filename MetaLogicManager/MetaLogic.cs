using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace MetaLogicManager
{
    public sealed class MetaLogic
    {
        private static MetaLogic s_Instance;
        private static readonly object sr_LockCreateInstance = new object();
        private readonly MetaConnectLogic r_ConnectLogic;
        private RiddleFeature m_RiddleFeature;
        private IEnumerator<RiddleSet> m_RiddleIterator;
        private bool m_FirstRiddle = true;

        private MetaLogic()
        {
            r_ConnectLogic = new MetaConnectLogic();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
        }

        public static MetaLogic Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (sr_LockCreateInstance)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new MetaLogic();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public ISortStrategy SortStrategy { get; set; }

        public bool IsLoggedIn
        {
            get
            {
                return r_ConnectLogic.IsLoggedIn;
            }
        }

        public UserCachingProxy User { get; private set; }

        public void Logout()
        {
            r_ConnectLogic.Logout();
        }

        public void Login()
        {
            r_ConnectLogic.Login();
            if(r_ConnectLogic.IsLoggedIn)
            {
                User = new UserCachingProxy(r_ConnectLogic.LoginResult.LoggedInUser);
            }
        }

        public string PostStatus(string i_Text)
        {
            return User.PostStatus(i_Text);
        }

        public string GetRiddle()
        {
            if (m_FirstRiddle == true)
            {
                m_RiddleFeature = new RiddleFeature(User);
                m_RiddleFeature.SortStratgey = SortStrategy;
                m_RiddleFeature.SortRiddles();
                m_RiddleIterator = m_RiddleFeature.GetEnumerator();
                m_FirstRiddle = false;
            }

            if (m_RiddleIterator.MoveNext() == false)
            {
                m_RiddleIterator = m_RiddleFeature.GetEnumerator();
                m_RiddleIterator.MoveNext();
            }

            return m_RiddleIterator.Current.Riddle;
        }

        public string GetRiddleAnswer()
        {
            return m_RiddleIterator.Current.Answer;
        }
    }
}
