using System;
using System.Drawing;
using System.Windows.Forms;

namespace game_lật_thẻ_1._1
{
    public partial class FormMenu : Form
    {
        private GameMode selectedMode;

        public FormMenu()
        {
            InitializeComponent();

            if (cboTheme.Items.Count > 0)
                cboTheme.SelectedIndex = 0;

            if (cboTimeLimit.Items.Count > 0)
                cboTimeLimit.SelectedIndex = 1; // Mặc định: 1 phút

            // Bước 1 hiển thị, bước 2 ẩn
            pnlStep1.Visible = true;
            pnlStep1.BringToFront();
            pnlStep2.Visible = false;
        }

        // ============================
        // BƯỚC 1: Chọn chế độ chơi
        // ============================

        private void btnModeMemory_Click(object sender, EventArgs e)
        {
            selectedMode = GameMode.MemoryMatch;
            GoToStep2();
        }

        private void btnModeSequence_Click(object sender, EventArgs e)
        {
            selectedMode = GameMode.SequentialOrder;
            GoToStep2();
        }

        private void GoToStep2()
        {
            // Cập nhật tiêu đề bước 2 theo chế độ đã chọn
            if (selectedMode == GameMode.MemoryMatch)
            {
                lblChosenMode.Text = "Chế độ: Lật Thẻ Trí Nhớ";
                chkHardcore.Enabled = false;
                chkHardcore.Checked = false;
                chkHardcore.Visible = false;

                // Hiện thanh chọn chủ đề cho game Trí nhớ
                lblTheme.Visible = true;
                cboTheme.Visible = true;

                // Đặt mặc định cho Memory (phải chẵn)
                numRows.Value = 4;
                numCols.Value = 4;
            }
            else
            {
                lblChosenMode.Text = "Chế độ: Lật Thẻ Theo Thứ Tự";
                chkHardcore.Enabled = true;
                chkHardcore.Visible = true;
                chkHardcore.Text = "Hardcore (sai 1 bước = reset về số 1)";

                // Ẩn thanh chọn chủ đề (game thứ tự chỉ hiện số, không cần theme)
                lblTheme.Visible = false;
                cboTheme.Visible = false;

                numRows.Value = 4;
                numCols.Value = 4;
            }

            UpdateValidationHint();

            // Chuyển sang bước 2
            pnlStep1.Visible = false;
            pnlStep2.Visible = true;
            pnlStep2.BringToFront();
        }

        // ============================
        // BƯỚC 2: Chọn độ khó & cấu hình
        // ============================

        private void btnEasy_Click(object sender, EventArgs e)
        {
            if (selectedMode == GameMode.MemoryMatch)
            {
                numRows.Value = 3;
                numCols.Value = 4; // 12 thẻ = 6 cặp (chẵn)
            }
            else
            {
                numRows.Value = 3;
                numCols.Value = 3;
            }
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            numRows.Value = 4;
            numCols.Value = 4;
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            numRows.Value = 6;
            numCols.Value = 6;
        }

        private void btnBackStep2_Click(object sender, EventArgs e)
        {
            // Quay lại bước 1
            pnlStep2.Visible = false;
            pnlStep1.Visible = true;
            pnlStep1.BringToFront();
        }

        private void numMatrix_ValueChanged(object sender, EventArgs e)
        {
            UpdateValidationHint();
        }

        private void UpdateValidationHint()
        {
            int rows = (int)numRows.Value;
            int cols = (int)numCols.Value;
            int total = rows * cols;

            if (selectedMode == GameMode.MemoryMatch)
            {
                if (total % 2 != 0)
                {
                    lblSizeNote.Text = $"⚠ {rows}×{cols}={total} (lẻ)";
                    lblSizeNote.ForeColor = Color.Red;
                }
                else
                {
                    lblSizeNote.Text = $"✓ {total} thẻ ({total / 2} cặp)";
                    lblSizeNote.ForeColor = Color.ForestGreen;
                }
            }
            else
            {
                lblSizeNote.Text = $"✓ Dãy 1 → {total}";
                lblSizeNote.ForeColor = Color.ForestGreen;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int rows = (int)numRows.Value;
            int cols = (int)numCols.Value;
            string selectedTheme = cboTheme.SelectedItem?.ToString() ?? "Động vật";
            bool enablePreview = chkPreview.Checked;
            bool isHardcore = chkHardcore.Checked && selectedMode == GameMode.SequentialOrder;

            // Lấy thời gian đã chọn (0 = vô hạn)
            int timeLimitSeconds = 60; // Mặc định 1 phút
            string timeChoice = cboTimeLimit.SelectedItem?.ToString() ?? "1 phút";
            switch (timeChoice)
            {
                case "30 giây": timeLimitSeconds = 30; break;
                case "1 phút": timeLimitSeconds = 60; break;
                case "2 phút": timeLimitSeconds = 120; break;
                case "3 phút": timeLimitSeconds = 180; break;
                case "Vô hạn": timeLimitSeconds = 0; break;
            }

            // Ràng buộc cho chế độ Trí nhớ: tổng phải chẵn
            if (selectedMode == GameMode.MemoryMatch && (rows * cols) % 2 != 0)
            {
                MessageBox.Show(
                    $"Chế độ Trí Nhớ yêu cầu tổng số thẻ phải là số chẵn!\nHiện tại: {rows} × {cols} = {rows * cols} (lẻ).\n\nHãy chỉnh lại kích thước.",
                    "Không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            FormGame frmGame = new FormGame(selectedMode, rows, cols, selectedTheme, enablePreview, isHardcore, timeLimitSeconds);
            this.Hide();
            frmGame.ShowDialog();
            this.Show();

            // Reset về bước 1 khi quay lại menu
            pnlStep2.Visible = false;
            pnlStep1.Visible = true;
            pnlStep1.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Vẽ hiệu ứng nổi 3D Arcade Playful cho các nút bấm trong Menu
        private void BtnArcade_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                Graphics g = e.Graphics;
                int w = btn.Width;
                int h = btn.Height;

                Color c = btn.BackColor;
                Color lightColor = ControlPaint.Light(c, 0.4f);
                Color darkColor = ControlPaint.Dark(c, 0.35f);

                // Đường viền sáng nổi bật phía trên & trái
                using (Pen lightPen = new Pen(lightColor, 3))
                {
                    g.DrawLine(lightPen, 0, 1, w - 1, 1);
                    g.DrawLine(lightPen, 1, 0, 1, h - 1);
                }

                // Đường bóng lún 3D đậm phía dưới & phải (tạo chiều sâu như phím Arcade)
                using (Pen darkPen = new Pen(darkColor, 4))
                {
                    g.DrawLine(darkPen, 0, h - 2, w - 1, h - 2);
                    g.DrawLine(darkPen, w - 2, 0, w - 2, h - 1);
                }
            }
        }
    }
}
