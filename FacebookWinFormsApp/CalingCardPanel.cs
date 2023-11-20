using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class CalingCardPanel : ICardDecorator
    {
        public CalingCardPanel(Panel i_Panel)
        {
            Panel = i_Panel;
        }

        public Panel Panel { get; }

        public void SetBackgroundColor()
        {
            Panel.BackColor = System.Drawing.Color.White;
        }
    }
}
