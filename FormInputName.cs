using System;
using System.Drawing;
using System.Windows.Forms;

namespace game_lật_thẻ_1._1
{
    public partial class FormInputName : Form
    {
        public string PlayerName { get; private set; } = "Người chơi";

        public FormInputName(string title, string message, int finalScore)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblMessage.Text = message;
            lblFinalScore.Text = $"⭐ Điểm số đạt được: {finalScore}";
            txtName.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                PlayerName = name;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
