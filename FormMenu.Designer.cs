namespace game_lật_thẻ_1._1
{
    partial class FormMenu
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
            // === BƯỚC 1: Chọn chế độ chơi ===
            this.pnlStep1 = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnModeMemory = new System.Windows.Forms.Button();
            this.btnModeSequence = new System.Windows.Forms.Button();
            this.btnLeaderboardMenu = new System.Windows.Forms.Button();
            this.btnAboutMenu = new System.Windows.Forms.Button();
            this.btnSoundMenu = new System.Windows.Forms.Button();
            this.btnExitStep1 = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();

            // === BƯỚC 2: Cấu hình màn chơi ===
            this.pnlStep2 = new System.Windows.Forms.Panel();
            this.lblStep2Title = new System.Windows.Forms.Label();
            this.lblChosenMode = new System.Windows.Forms.Label();

            this.lblDifficulty = new System.Windows.Forms.Label();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();

            this.lblCustomSize = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.lblX = new System.Windows.Forms.Label();
            this.numCols = new System.Windows.Forms.NumericUpDown();
            this.lblSizeNote = new System.Windows.Forms.Label();

            this.lblTimeLimit = new System.Windows.Forms.Label();
            this.cboTimeLimit = new System.Windows.Forms.ComboBox();
            this.lblTheme = new System.Windows.Forms.Label();
            this.cboTheme = new System.Windows.Forms.ComboBox();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.chkHardcore = new System.Windows.Forms.CheckBox();

            this.btnStart = new System.Windows.Forms.Button();
            this.btnBackStep2 = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).BeginInit();
            this.pnlStep1.SuspendLayout();
            this.pnlStep2.SuspendLayout();
            this.SuspendLayout();

            // =============================================
            // pnlStep1 — Màn hình chọn chế độ chơi
            // =============================================
            this.pnlStep1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlStep1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep1.Controls.Add(this.lblLogo);
            this.pnlStep1.Controls.Add(this.lblTitle);
            this.pnlStep1.Controls.Add(this.lblSubtitle);
            this.pnlStep1.Controls.Add(this.btnModeMemory);
            this.pnlStep1.Controls.Add(this.btnModeSequence);
            this.pnlStep1.Controls.Add(this.btnLeaderboardMenu);
            this.pnlStep1.Controls.Add(this.btnAboutMenu);
            this.pnlStep1.Controls.Add(this.btnSoundMenu);
            this.pnlStep1.Controls.Add(this.btnExitStep1);
            this.pnlStep1.Controls.Add(this.lblFooter);
            this.pnlStep1.Location = new System.Drawing.Point(0, 0);
            this.pnlStep1.Name = "pnlStep1";
            this.pnlStep1.Size = new System.Drawing.Size(500, 560);
            this.pnlStep1.TabIndex = 0;

            // lblLogo
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblLogo.Location = new System.Drawing.Point(0, 24);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(500, 55);
            this.lblLogo.Text = "";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(0, 78);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 42);
            this.lblTitle.Text = "GAME LẬT THẺ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblSubtitle
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(0, 122);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(500, 25);
            this.lblSubtitle.Text = "Rèn luyện trí nhớ và khả năng tập trung";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnModeMemory — Chế độ Trí nhớ
            this.btnModeMemory.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnModeMemory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModeMemory.FlatAppearance.BorderSize = 0;
            this.btnModeMemory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnModeMemory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModeMemory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnModeMemory.ForeColor = System.Drawing.Color.White;
            this.btnModeMemory.Location = new System.Drawing.Point(45, 156);
            this.btnModeMemory.Name = "btnModeMemory";
            this.btnModeMemory.Size = new System.Drawing.Size(410, 80);
            this.btnModeMemory.TabIndex = 0;
            this.btnModeMemory.Text = "LẬT THẺ TRÍ NHỚ\r\nTìm và ghép các cặp thẻ biểu tượng giống nhau";
            this.btnModeMemory.UseVisualStyleBackColor = false;
            this.btnModeMemory.Click += new System.EventHandler(this.btnModeMemory_Click);

            // btnModeSequence — Chế độ Thứ tự
            this.btnModeSequence.BackColor = System.Drawing.Color.FromArgb(5, 150, 105);
            this.btnModeSequence.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModeSequence.FlatAppearance.BorderSize = 0;
            this.btnModeSequence.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(4, 120, 87);
            this.btnModeSequence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModeSequence.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnModeSequence.ForeColor = System.Drawing.Color.White;
            this.btnModeSequence.Location = new System.Drawing.Point(45, 248);
            this.btnModeSequence.Name = "btnModeSequence";
            this.btnModeSequence.Size = new System.Drawing.Size(410, 80);
            this.btnModeSequence.TabIndex = 1;
            this.btnModeSequence.Text = "LẬT THẺ THEO THỨ TỰ\r\nTìm và lật các số tăng dần từ 1 → N";
            this.btnModeSequence.UseVisualStyleBackColor = false;
            this.btnModeSequence.Click += new System.EventHandler(this.btnModeSequence_Click);

            // btnLeaderboardMenu
            this.btnLeaderboardMenu.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            this.btnLeaderboardMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaderboardMenu.FlatAppearance.BorderSize = 0;
            this.btnLeaderboardMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(253, 230, 138);
            this.btnLeaderboardMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaderboardMenu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLeaderboardMenu.ForeColor = System.Drawing.Color.FromArgb(146, 64, 14);
            this.btnLeaderboardMenu.Location = new System.Drawing.Point(45, 340);
            this.btnLeaderboardMenu.Name = "btnLeaderboardMenu";
            this.btnLeaderboardMenu.Size = new System.Drawing.Size(200, 44);
            this.btnLeaderboardMenu.TabIndex = 2;
            this.btnLeaderboardMenu.Text = "🏆  Bảng thành tích";
            this.btnLeaderboardMenu.UseVisualStyleBackColor = false;
            this.btnLeaderboardMenu.Click += new System.EventHandler(this.btnLeaderboardMenu_Click);

            // btnAboutMenu
            this.btnAboutMenu.BackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            this.btnAboutMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAboutMenu.FlatAppearance.BorderSize = 0;
            this.btnAboutMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnAboutMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutMenu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAboutMenu.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnAboutMenu.Location = new System.Drawing.Point(255, 340);
            this.btnAboutMenu.Name = "btnAboutMenu";
            this.btnAboutMenu.Size = new System.Drawing.Size(200, 44);
            this.btnAboutMenu.TabIndex = 3;
            this.btnAboutMenu.Text = "📖  Hướng dẫn";
            this.btnAboutMenu.UseVisualStyleBackColor = false;
            this.btnAboutMenu.Click += new System.EventHandler(this.btnAboutMenu_Click);

            // btnSoundMenu
            this.btnSoundMenu.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnSoundMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoundMenu.FlatAppearance.BorderSize = 0;
            this.btnSoundMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnSoundMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoundMenu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSoundMenu.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnSoundMenu.Location = new System.Drawing.Point(45, 396);
            this.btnSoundMenu.Name = "btnSoundMenu";
            this.btnSoundMenu.Size = new System.Drawing.Size(200, 42);
            this.btnSoundMenu.TabIndex = 4;
            this.btnSoundMenu.Text = "🔊  Âm thanh: Bật";
            this.btnSoundMenu.UseVisualStyleBackColor = false;
            this.btnSoundMenu.Click += new System.EventHandler(this.btnSoundMenu_Click);

            // btnExitStep1
            this.btnExitStep1.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnExitStep1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExitStep1.FlatAppearance.BorderSize = 0;
            this.btnExitStep1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnExitStep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitStep1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExitStep1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnExitStep1.Location = new System.Drawing.Point(255, 396);
            this.btnExitStep1.Name = "btnExitStep1";
            this.btnExitStep1.Size = new System.Drawing.Size(200, 42);
            this.btnExitStep1.TabIndex = 5;
            this.btnExitStep1.Text = "✕  Thoát";
            this.btnExitStep1.UseVisualStyleBackColor = false;
            this.btnExitStep1.Click += new System.EventHandler(this.btnExit_Click);

            // lblFooter
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFooter.Location = new System.Drawing.Point(0, 480);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(500, 20);
            this.lblFooter.Text = "Phiên bản 1.1 • LTWin";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // =============================================
            // pnlStep2 — Màn hình cấu hình
            // =============================================
            this.pnlStep2.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlStep2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep2.Visible = false;
            this.pnlStep2.Controls.Add(this.lblStep2Title);
            this.pnlStep2.Controls.Add(this.lblChosenMode);
            this.pnlStep2.Controls.Add(this.lblDifficulty);
            this.pnlStep2.Controls.Add(this.btnEasy);
            this.pnlStep2.Controls.Add(this.btnMedium);
            this.pnlStep2.Controls.Add(this.btnHard);
            this.pnlStep2.Controls.Add(this.lblCustomSize);
            this.pnlStep2.Controls.Add(this.lblRows);
            this.pnlStep2.Controls.Add(this.numRows);
            this.pnlStep2.Controls.Add(this.lblX);
            this.pnlStep2.Controls.Add(this.numCols);
            this.pnlStep2.Controls.Add(this.lblSizeNote);
            this.pnlStep2.Controls.Add(this.lblTimeLimit);
            this.pnlStep2.Controls.Add(this.cboTimeLimit);
            this.pnlStep2.Controls.Add(this.lblTheme);
            this.pnlStep2.Controls.Add(this.cboTheme);
            this.pnlStep2.Controls.Add(this.chkPreview);
            this.pnlStep2.Controls.Add(this.chkHardcore);
            this.pnlStep2.Controls.Add(this.btnStart);
            this.pnlStep2.Controls.Add(this.btnBackStep2);
            this.pnlStep2.Location = new System.Drawing.Point(0, 0);
            this.pnlStep2.Name = "pnlStep2";
            this.pnlStep2.Size = new System.Drawing.Size(500, 560);
            this.pnlStep2.TabIndex = 1;

            // lblStep2Title
            this.lblStep2Title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStep2Title.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblStep2Title.Location = new System.Drawing.Point(0, 16);
            this.lblStep2Title.Name = "lblStep2Title";
            this.lblStep2Title.Size = new System.Drawing.Size(500, 32);
            this.lblStep2Title.Text = "CẤU HÌNH MÀN CHƠI";
            this.lblStep2Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblChosenMode
            this.lblChosenMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChosenMode.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.lblChosenMode.Location = new System.Drawing.Point(0, 48);
            this.lblChosenMode.Name = "lblChosenMode";
            this.lblChosenMode.Size = new System.Drawing.Size(500, 22);
            this.lblChosenMode.Text = "Chế độ";
            this.lblChosenMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblDifficulty
            this.lblDifficulty.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDifficulty.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDifficulty.Location = new System.Drawing.Point(40, 80);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(420, 18);
            this.lblDifficulty.Text = "MỨC ĐỘ KHUYẾN NGHỊ:";

            // btnEasy
            this.btnEasy.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnEasy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEasy.FlatAppearance.BorderSize = 0;
            this.btnEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEasy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEasy.ForeColor = System.Drawing.Color.White;
            this.btnEasy.Location = new System.Drawing.Point(40, 102);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(132, 45);
            this.btnEasy.Text = "DỄ\r\n3 × 4";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);

            // btnMedium
            this.btnMedium.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnMedium.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedium.FlatAppearance.BorderSize = 0;
            this.btnMedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedium.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMedium.ForeColor = System.Drawing.Color.White;
            this.btnMedium.Location = new System.Drawing.Point(184, 102);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(132, 45);
            this.btnMedium.Text = "VỪA\r\n4 × 4";
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);

            // btnHard
            this.btnHard.BackColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.btnHard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHard.FlatAppearance.BorderSize = 0;
            this.btnHard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHard.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnHard.ForeColor = System.Drawing.Color.White;
            this.btnHard.Location = new System.Drawing.Point(328, 102);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(132, 45);
            this.btnHard.Text = "KHÓ\r\n6 × 6";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);

            // lblCustomSize
            this.lblCustomSize.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomSize.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCustomSize.Location = new System.Drawing.Point(40, 160);
            this.lblCustomSize.Name = "lblCustomSize";
            this.lblCustomSize.Size = new System.Drawing.Size(420, 18);
            this.lblCustomSize.Text = "TÙY CHỈNH MA TRẬN (DÒNG × CỘT):";

            // lblRows
            this.lblRows.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRows.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblRows.Location = new System.Drawing.Point(40, 186);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(50, 22);
            this.lblRows.Text = "Dòng:";

            // numRows
            this.numRows.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.numRows.Location = new System.Drawing.Point(92, 184);
            this.numRows.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            this.numRows.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(60, 26);
            this.numRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRows.Value = new decimal(new int[] { 4, 0, 0, 0 });
            this.numRows.ValueChanged += new System.EventHandler(this.numMatrix_ValueChanged);

            // lblX
            this.lblX.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblX.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblX.Location = new System.Drawing.Point(155, 184);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(22, 26);
            this.lblX.Text = "×";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // numCols
            this.numCols.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.numCols.Location = new System.Drawing.Point(180, 184);
            this.numCols.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            this.numCols.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.numCols.Name = "numCols";
            this.numCols.Size = new System.Drawing.Size(60, 26);
            this.numCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCols.Value = new decimal(new int[] { 4, 0, 0, 0 });
            this.numCols.ValueChanged += new System.EventHandler(this.numMatrix_ValueChanged);

            // lblSizeNote
            this.lblSizeNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSizeNote.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblSizeNote.Location = new System.Drawing.Point(250, 186);
            this.lblSizeNote.Name = "lblSizeNote";
            this.lblSizeNote.Size = new System.Drawing.Size(210, 22);
            this.lblSizeNote.Text = "";

            // lblTimeLimit
            this.lblTimeLimit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTimeLimit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblTimeLimit.Location = new System.Drawing.Point(40, 228);
            this.lblTimeLimit.Name = "lblTimeLimit";
            this.lblTimeLimit.Size = new System.Drawing.Size(100, 22);
            this.lblTimeLimit.Text = "Thời gian:";

            // cboTimeLimit
            this.cboTimeLimit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTimeLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeLimit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTimeLimit.FormattingEnabled = true;
            this.cboTimeLimit.Items.AddRange(new object[] {
                "30 giây",
                "1 phút",
                "2 phút",
                "3 phút",
                "Vô hạn"
            });
            this.cboTimeLimit.Location = new System.Drawing.Point(145, 225);
            this.cboTimeLimit.Name = "cboTimeLimit";
            this.cboTimeLimit.Size = new System.Drawing.Size(150, 25);

            // lblTheme
            this.lblTheme.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTheme.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblTheme.Location = new System.Drawing.Point(40, 268);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(100, 22);
            this.lblTheme.Text = "Chủ đề icon:";

            // cboTheme
            this.cboTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheme.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTheme.FormattingEnabled = true;
            this.cboTheme.Items.AddRange(new object[] {
                "Động vật",
                "Công nghệ",
                "Trái cây & Đồ ăn",
                "Ký hiệu học thuật",
                "Biểu tượng vui vẻ"
            });
            this.cboTheme.Location = new System.Drawing.Point(145, 265);
            this.cboTheme.Name = "cboTheme";
            this.cboTheme.Size = new System.Drawing.Size(190, 25);

            // chkPreview
            this.chkPreview.AutoSize = true;
            this.chkPreview.Checked = true;
            this.chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPreview.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkPreview.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.chkPreview.Location = new System.Drawing.Point(42, 310);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(242, 21);
            this.chkPreview.Text = "👁️  Xem trước vị trí thẻ trong 2 giây";
            this.chkPreview.UseVisualStyleBackColor = true;

            // chkHardcore
            this.chkHardcore.AutoSize = true;
            this.chkHardcore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkHardcore.Enabled = false;
            this.chkHardcore.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkHardcore.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.chkHardcore.Location = new System.Drawing.Point(42, 342);
            this.chkHardcore.Name = "chkHardcore";
            this.chkHardcore.Size = new System.Drawing.Size(325, 21);
            this.chkHardcore.Text = "🔥  Hardcore (chọn sai 1 bước = reset toàn bộ)";
            this.chkHardcore.UseVisualStyleBackColor = true;

            // btnBackStep2
            this.btnBackStep2.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnBackStep2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackStep2.FlatAppearance.BorderSize = 0;
            this.btnBackStep2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnBackStep2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackStep2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackStep2.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnBackStep2.Location = new System.Drawing.Point(40, 470);
            this.btnBackStep2.Name = "btnBackStep2";
            this.btnBackStep2.Size = new System.Drawing.Size(125, 48);
            this.btnBackStep2.TabIndex = 4;
            this.btnBackStep2.Text = "← Quay lại";
            this.btnBackStep2.UseVisualStyleBackColor = false;
            this.btnBackStep2.Click += new System.EventHandler(this.btnBackStep2_Click);

            // btnStart
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(175, 470);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(285, 48);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "▶  BẮT ĐẦU CHƠI";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // =============================================
            // FormMenu
            // =============================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(500, 560);
            this.Controls.Add(this.pnlStep2);
            this.Controls.Add(this.pnlStep1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Lật Thẻ - Memory Match";

            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).EndInit();
            this.pnlStep1.ResumeLayout(false);
            this.pnlStep2.ResumeLayout(false);
            this.pnlStep2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Bước 1
        private System.Windows.Forms.Panel pnlStep1;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnModeMemory;
        private System.Windows.Forms.Button btnModeSequence;
        private System.Windows.Forms.Button btnLeaderboardMenu;
        private System.Windows.Forms.Button btnAboutMenu;
        private System.Windows.Forms.Button btnSoundMenu;
        private System.Windows.Forms.Button btnExitStep1;
        private System.Windows.Forms.Label lblFooter;

        // Bước 2
        private System.Windows.Forms.Panel pnlStep2;
        private System.Windows.Forms.Label lblStep2Title;
        private System.Windows.Forms.Label lblChosenMode;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Label lblCustomSize;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown numCols;
        private System.Windows.Forms.Label lblSizeNote;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.ComboBox cboTheme;
        private System.Windows.Forms.Label lblTimeLimit;
        private System.Windows.Forms.ComboBox cboTimeLimit;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.CheckBox chkHardcore;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnBackStep2;
    }
}
