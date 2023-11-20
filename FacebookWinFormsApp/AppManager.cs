using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaLogicManager;

namespace BasicFacebookFeatures
{
    public class AppManager
    {
        private readonly FormLogin r_FormLogin;
        private FormMain m_FormMain;
        private readonly Facade r_Facade;

        public AppManager()
        {
            r_Facade = new Facade();
            r_FormLogin = new FormLogin(r_Facade);
        }

        public void Run()
        {
            r_FormLogin.ShowDialog();
            if(r_FormLogin.IsLoggedIn)
            {
                m_FormMain = new FormMain(r_Facade);
                m_FormMain.ShowDialog();
            }
        }
    }
}
