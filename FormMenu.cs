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

            try
            {
                // Khởi tạo hệ thống âm thanh ban đầu an toàn (có bẫy lỗi đầy đủ)
                SoundManager.InitializeSounds();
                SoundManager.PlayBgm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Cảnh báo bẫy lỗi (Exception Handling) khi nạp tài nguyên ban đầu:\n" + ex.Message,
                    "Thông Báo Khởi Tạo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            try
            {
                if (cboTheme.Items.Count > 0)
                    cboTheme.SelectedIndex = 0;

                if (cboTimeLimit.Items.Count > 0)
                    cboTimeLimit.SelectedIndex = 1; // Mặc định: 1 phút

                UpdateSoundButtonText();

                // Bước 1 hiển thị, bước 2 ẩn
                pnlStep1.Visible = true;
                pnlStep1.BringToFront();
                pnlStep2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thiết lập giao diện Menu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateSoundButtonText()
        {
            try
            {
                btnSoundMenu.Text = SoundManager.IsMuted ? "🔇  Âm thanh: Tắt" : "🔊  Âm thanh: Bật";
            }
            catch { }
        }

        private void btnSoundMenu_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.ToggleMute();
                UpdateSoundButtonText();
                if (!SoundManager.IsMuted)
                {
                    SoundManager.PlayBgm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi điều khiển âm thanh:\n" + ex.Message, "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLeaderboardMenu_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                FormLeaderboard frmLeaderboard = new FormLeaderboard();
                frmLeaderboard.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bẫy lỗi khi mở bảng thành tích:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAboutMenu_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                FormAbout frmAbout = new FormAbout();
                frmAbout.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bẫy lỗi khi mở bảng hướng dẫn:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        // BƯỚC 1: Chọn chế độ chơi
        // ============================

        private void btnModeMemory_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                selectedMode = GameMode.MemoryMatch;
                GoToStep2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn chế độ Trí Nhớ: " + ex.Message);
            }
        }

        private void btnModeSequence_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                selectedMode = GameMode.SequentialOrder;
                GoToStep2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn chế độ Thứ Tự: " + ex.Message);
            }
        }

        private void GoToStep2()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển màn hình cấu hình:\n" + ex.Message);
            }
        }

        // ============================
        // BƯỚC 2: Chọn độ khó & cấu hình
        // ============================

        private void btnEasy_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
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
            catch { }
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                numRows.Value = 4;
                numCols.Value = 4;
            }
            catch { }
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                numRows.Value = 6;
                numCols.Value = 6;
            }
            catch { }
        }

        private void btnBackStep2_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                pnlStep2.Visible = false;
                pnlStep1.Visible = true;
                pnlStep1.BringToFront();
            }
            catch { }
        }

        private void numMatrix_ValueChanged(object sender, EventArgs e)
        {
            UpdateValidationHint();
        }

        private void UpdateValidationHint()
        {
            try
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
            catch { }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();

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

                // Cập nhật lại nút âm thanh và tiếp tục phát nhạc nếu chưa tắt
                UpdateSoundButtonText();
                if (!SoundManager.IsMuted)
                {
                    SoundManager.PlayBgm();
                }

                // Reset về bước 1 khi quay lại menu
                pnlStep2.Visible = false;
                pnlStep1.Visible = true;
                pnlStep1.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Bẫy lỗi khi khởi chạy trò chơi (Exception Handling):\n" + ex.Message,
                    "Lỗi Khởi Chạy",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.StopBgm();
                Application.Exit();
            }
            catch
            {
                Application.Exit();
            }
        }

        // Vẽ hiệu ứng nổi 3D Arcade Playful cho các nút bấm trong Menu
        private void BtnArcade_Paint(object sender, PaintEventArgs e)
        {
            try
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
            catch { }
        }
    }
}
