using System;
using System.Windows.Forms;

namespace game_lật_thẻ_1._1
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SoundManager.PlayFlip();
            this.Close();
        }
    }
}
