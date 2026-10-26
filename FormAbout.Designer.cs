namespace game_lật_thẻ_1._1
{
    partial class FormAbout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.tabContent = new System.Windows.Forms.TabControl();
            this.tabRules = new System.Windows.Forms.TabPage();
            this.txtRules = new System.Windows.Forms.RichTextBox();
            this.tabTeam = new System.Windows.Forms.TabPage();
            this.txtTeam = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlBanner.SuspendLayout();
            this.tabContent.SuspendLayout();
            this.tabRules.SuspendLayout();
            this.tabTeam.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBanner
            // 
            this.pnlBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlBanner.Controls.Add(this.lblHeaderSub);
            this.pnlBanner.Controls.Add(this.lblHeaderTitle);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(640, 85);
            this.pnlBanner.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(0, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(640, 32);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "🃏 HƯỚNG DẪN TRÒ CHƠI LẬT THẺ";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(0, 48);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(640, 22);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Rèn luyện trí nhớ và khả năng tập trung • Đồ án LTWIN";
            this.lblHeaderSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabContent
            // 
            this.tabContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabContent.Controls.Add(this.tabRules);
            this.tabContent.Controls.Add(this.tabTeam);
            this.tabContent.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.tabContent.Location = new System.Drawing.Point(20, 100);
            this.tabContent.Name = "tabContent";
            this.tabContent.SelectedIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(600, 365);
            this.tabContent.TabIndex = 1;
            // 
            // tabRules
            // 
            this.tabRules.Controls.Add(this.txtRules);
            this.tabRules.Location = new System.Drawing.Point(4, 26);
            this.tabRules.Name = "tabRules";
            this.tabRules.Padding = new System.Windows.Forms.Padding(10);
            this.tabRules.Size = new System.Drawing.Size(592, 335);
            this.tabRules.TabIndex = 0;
            this.tabRules.Text = "📖 Hướng Dẫn & Luật Chơi";
            this.tabRules.UseVisualStyleBackColor = true;
            // 
            // txtRules
            // 
            this.txtRules.BackColor = System.Drawing.Color.White;
            this.txtRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRules.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRules.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtRules.Location = new System.Drawing.Point(10, 10);
            this.txtRules.Name = "txtRules";
            this.txtRules.ReadOnly = true;
            this.txtRules.Size = new System.Drawing.Size(572, 315);
            this.txtRules.TabIndex = 0;
            this.txtRules.Text = "1. MỤC TIÊU TRÒ CHƠI\n" +
                "Tìm và lật mở toàn bộ các thẻ bài trên bàn chơi trước khi thời gian đếm ngược kết thúc.\n\n" +
                "2. CÁC CHẾ ĐỘ CHƠI\n" +
                "• Lật Thẻ Trí Nhớ (Memory Match):\n" +
                "   - Lật mở lần lượt 2 thẻ bài. Nếu 2 thẻ có cùng biểu tượng: cặp thẻ giữ nguyên và được +25 điểm.\n" +
                "   - Nếu 2 thẻ khác nhau: 2 thẻ sẽ tự động úp lại sau 0.6 giây và bị trừ 5 điểm (không âm).\n" +
                "   - Khi ghép thành công tất cả các cặp thẻ, bạn sẽ vượt qua màn chơi hiện tại và tiến lên cấp độ cao hơn.\n\n" +
                "• Lật Thẻ Theo Thứ Tự (Sequential Order):\n" +
                "   - Cần tìm và lật các thẻ số theo thứ tự tăng dần từ 1 đến N (ví dụ: 1 → 2 → 3 → ...).\n" +
                "   - Lật đúng số 1: +10 điểm; các số tiếp theo: +5 điểm; đúng liên tiếp: cộng thêm điểm combo thưởng!\n" +
                "   - Chế độ Thường: Lật sai sẽ bị trừ 3 điểm và bị phạt lùi lại 2 bước (úp lại 2 thẻ đã mở gần nhất).\n" +
                "   - Chế độ Hardcore: Lật sai 1 bước bất kỳ sẽ reset toàn bộ bàn chơi về số 1!\n\n" +
                "3. TÍNH NĂNG HỖ TRỢ\n" +
                "• 👁️ Xem trước (Preview): Cho phép bạn ghi nhớ vị trí toàn bộ thẻ bài trong 2 giây trước khi bắt đầu.\n" +
                "• ⏱️ Tùy chỉnh thời gian: Lựa chọn 30 giây, 1 phút, 2 phút, 3 phút hoặc Vô hạn thời gian.\n" +
                "• 🎨 Tùy chọn chủ đề: Động vật, Công nghệ, Trái cây & Đồ ăn, Ký hiệu học thuật, Biểu tượng vui vẻ.\n" +
                "• 🔊 Âm thanh sinh động: Nhạc nền và hiệu ứng âm thanh lật thẻ, đúng, sai, chiến thắng, hết giờ.\n" +
                "• 🏆 Bảng thành tích: Lưu tên, điểm số và thời gian còn lại của bạn vào bảng xếp hạng.";
            // 
            // tabTeam
            // 
            this.tabTeam.Controls.Add(this.txtTeam);
            this.tabTeam.Location = new System.Drawing.Point(4, 26);
            this.tabTeam.Name = "tabTeam";
            this.tabTeam.Padding = new System.Windows.Forms.Padding(10);
            this.tabTeam.Size = new System.Drawing.Size(592, 335);
            this.tabTeam.TabIndex = 1;
            this.tabTeam.Text = "👥 Thông Tin Nhóm Thực Hiện";
            this.tabTeam.UseVisualStyleBackColor = true;
            // 
            // txtTeam
            // 
            this.txtTeam.BackColor = System.Drawing.Color.White;
            this.txtTeam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTeam.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtTeam.Location = new System.Drawing.Point(10, 10);
            this.txtTeam.Name = "txtTeam";
            this.txtTeam.ReadOnly = true;
            this.txtTeam.Size = new System.Drawing.Size(572, 315);
            this.txtTeam.TabIndex = 0;
            this.txtTeam.Text = "ĐỒ ÁN PHÁT TRIỂN MINIGAME TRÊN MÔI TRƯỜNG WINDOWS\n" +
                "Môn học: Lập Trình Trên Môi Trường Windows (LTWIN)\n" +
                "Đề tài: MiniGame Lật Thẻ Trí Nhớ (Memory Card Game)\n\n" +
                "═══════════════════════════════════════════════════════════════\n" +
                "THÀNH VIÊN THỰC HIỆN:\n" +
                "═══════════════════════════════════════════════════════════════\n\n" +
                "1. Thành viên phụ trách Logic & Gameplay:\n" +
                "   • Nhiệm vụ: Xây dựng Game Engine, Thuật toán Fisher-Yates Shuffle, Đếm ngược, Cấu hình ma trận\n\n" +
                "2. Thành viên phụ trách UI, Âm thanh & Dữ liệu:\n" +
                "   • Nhiệm vụ: Bảng thành tích (System.IO), Hệ thống Âm thanh (SoundPlayer), Bẫy lỗi Exception Handling\n\n" +
                "═══════════════════════════════════════════════════════════════\n" +
                "CÔNG NGHỆ ÁP DỤNG:\n" +
                "• Ngôn ngữ: C# (.NET Framework 4.7.2)\n" +
                "• Nền tảng: Windows Forms Application\n" +
                "• Lưu trữ dữ liệu: System.IO (Đọc/ghi tệp tin thanhtichs.txt dạng UTF-8 append)\n" +
                "• Xử lý âm thanh: System.Media.SoundPlayer (.wav)\n" +
                "• Bẫy lỗi (Exception Handling - 1.0đ): try...catch toàn diện ở tất cả các tiến trình nhạy cảm (Đọc/ghi file thanhtichs.txt, load hình ảnh img/ và âm thanh bg/), tự động kích hoạt chế độ đồ họa & âm thanh dự phòng khi mất thư mục, đảm bảo game 100% không bị văng (crash).";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(56)))), ((int)(((byte)(202)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(500, 480);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đã Hiểu";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(640, 530);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabContent);
            this.Controls.Add(this.pnlBanner);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hướng Dẫn & Thông Tin Nhóm";
            this.pnlBanner.ResumeLayout(false);
            this.tabContent.ResumeLayout(false);
            this.tabRules.ResumeLayout(false);
            this.tabTeam.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.TabControl tabContent;
        private System.Windows.Forms.TabPage tabRules;
        private System.Windows.Forms.TabPage tabTeam;
        private System.Windows.Forms.RichTextBox txtRules;
        private System.Windows.Forms.RichTextBox txtTeam;
        private System.Windows.Forms.Button btnClose;
    }
}
