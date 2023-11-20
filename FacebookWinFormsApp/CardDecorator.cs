using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BasicFacebookFeatures
{
    class CardDecorator : ICardDecorator
    {
        private readonly ICardDecorator r_Panel;

        public CardDecorator(ICardDecorator i_cardDecorator)
        {
            r_Panel = i_cardDecorator;
            SetBackgroundColor();
        }

        public Panel Panel
        {
            get
            {
                return r_Panel.Panel;
            }
        }

        public void SetBackgroundColor()
        {
            r_Panel.Panel.BackgroundImage = global::BasicFacebookFeatures.Properties.Resources.Purple;
        }
    }
}
