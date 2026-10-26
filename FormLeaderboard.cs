using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace game_lật_thẻ_1._1
{
    public partial class FormLeaderboard : Form
    {
        public FormLeaderboard()
        {
            InitializeComponent();
            LoadLeaderboardData();
        }

        private void LoadLeaderboardData()
        {
            try
            {
                dgvLeaderboard.Rows.Clear();
                List<LeaderboardRecord> records = LeaderboardManager.LoadRecords();

                if (records.Count == 0)
                {
                    lblEmpty.Visible = true;
                    dgvLeaderboard.Visible = false;
                    return;
                }

                lblEmpty.Visible = false;
                dgvLeaderboard.Visible = true;

                int rank = 1;
                foreach (var r in records)
                {
                    string rankStr = rank.ToString();
                    if (rank == 1) rankStr = "🥇 1";
                    else if (rank == 2) rankStr = "🥈 2";
                    else if (rank == 3) rankStr = "🥉 3";

                    int rowIndex = dgvLeaderboard.Rows.Add(
                        rankStr,
                        r.Name,
                        r.Score.ToString("N0"),
                        r.TimeRemaining > 0 ? $"{r.TimeRemaining}s" : "Không tính",
                        r.Mode,
                        r.PlayedAt.ToString("dd/MM/yyyy HH:mm")
                    );

                    // Đổi màu nổi bật cho top 3
                    if (rank == 1)
                        dgvLeaderboard.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 249, 195);
                    else if (rank == 2)
                        dgvLeaderboard.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
                    else if (rank == 3)
                        dgvLeaderboard.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 237, 213);

                    rank++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi hiển thị bảng thành tích:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SoundManager.PlayFlip();
            LoadLeaderboardData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SoundManager.PlayFlip();
            DialogResult res = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa toàn bộ lịch sử thành tích không?",
                "Xác Nhận Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                if (LeaderboardManager.ClearRecords())
                {
                    MessageBox.Show("Đã làm trống bảng thành tích!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLeaderboardData();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SoundManager.PlayFlip();
            this.Close();
        }
    }
}
