using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace game_lật_thẻ_1._1
{
    public partial class FormGame : Form
    {
        private readonly GameMode currentMode;
        private int rows;
        private int cols;
        private readonly string theme;
        private readonly bool enablePreview;
        private readonly bool isHardcore;
        private readonly int timeLimitSeconds;
        private readonly bool isUnlimitedTime;

        private int currentLevel = 1;
        private int score = 0;
        private bool isBusy = false;
        private Button firstCard = null;
        private Button secondCard = null;
        private int pairsFound = 0;
        private int expectedNumber = 1;
        private int consecutiveCorrect = 0;
        private readonly Random rng = new Random();

        private int maxTime = 0;
        private int remainingTime = 0;

        private readonly string[] animalIcons = {
            "🐶", "🐱", "🐭", "🐹", "🐰", "🦊", "🐻", "🐼",
            "🐨", "🐯", "🦁", "🐮", "🐷", "🐸", "🐵", "🐔",
            "🐧", "🐦", "🐤", "🐺", "🐗", "🐴", "🦄", "🐝",
            "🐛", "🦋", "🐌", "🐞", "🐢", "🐍", "🐙", "🦑",
            "🐬", "🐳", "🐠", "🦀", "🦞", "🦕", "🦖", "🦩"
        };

        private readonly string[] techIcons = {
            "💻", "🖥️", "🖨️", "⌨️", "🖱️", "💽", "💾", "💿",
            "📀", "📱", "☎️", "📟", "📺", "📻", "🎙️", "🧭",
            "⏱️", "⏰", "🔋", "🔌", "💡", "📡", "🚀", "🛸",
            "🎮", "🕹️", "🎧", "📷", "📹", "🔭", "🔬", "🤖",
            "🚁", "🚗", "🛰️", "⚙️", "🔋", "🧲", "🔧", "📱"
        };

        private readonly string[] fruitIcons = {
            "🍎", "🍐", "🍊", "🍋", "🍌", "🍉", "🍇", "🍓",
            "🫐", "🍈", "🍒", "🍑", "🥭", "🍍", "🥥", "🥝",
            "🍅", "🥑", "🥦", "🌽", "🥕", "🍔", "🍕", "🍟",
            "🌭", "🍿", "🍩", "🍪", "🎂", "🍰", "🧁", "🍫",
            "🍦", "🍭", "🍬", "🥨", "🥞", "🥐", "🍙", "🍣"
        };

        private readonly string[] academicIcons = {
            "π", "Σ", "Ω", "∞", "√", "∫", "Δ", "θ",
            "λ", "μ", "α", "β", "γ", "ψ", "φ", "⚛",
            "⚡", "🧬", "🧪", "🧮", "📐", "📏", "🔭", "🔬",
            "💡", "🎓", "📚", "📖", "✏️", "🪐", "⌛", "⚙️",
            "🌍", "🧲", "🔮", "✒️", "🔑", "🔍", "📈", "🧩"
        };

        private readonly string[] emojiIcons = {
            "😀", "😂", "😎", "😍", "🥳", "🤩", "😇", "🤠",
            "🤖", "👻", "👽", "🦄", "🌟", "🌈", "☀️", "🌙",
            "🔥", "💎", "🍀", "🍕", "🚀", "🎸", "🎨", "⚽",
            "🏆", "🎯", "🎲", "👑", "🎁", "🔔", "🔮", "🎈",
            "⚡", "✨", "🎵", "❤️", "⭐", "🎉", "🏆", "🥇"
        };

        public FormGame(GameMode mode, int initialRows, int initialCols, string selectedTheme, bool preview = true, bool hardcore = false, int timeLimit = 60)
        {
            InitializeComponent();

            this.currentMode = mode;
            this.rows = initialRows;
            this.cols = initialCols;
            this.theme = selectedTheme;
            this.enablePreview = preview;
            this.isHardcore = hardcore;
            this.timeLimitSeconds = timeLimit;
            this.isUnlimitedTime = (timeLimit <= 0);

            try
            {
                tmrPreview.Tick += tmrPreview_Tick;
                tmrCountdown.Tick += tmrCountdown_Tick;
                tmrFlipBack.Tick += tmrFlipBack_Tick;

                UpdateSoundButtonText();

                if (currentMode == GameMode.MemoryMatch)
                {
                    lblMode.Text = "Chế độ: Lật thẻ ghép cặp";
                }
                else
                {
                    lblMode.Text = isHardcore
                        ? "Chế độ: Tiến lên (HARDCORE 🔥)"
                        : "Chế độ: Tiến lên (sai lùi 2 bước)";
                }

                InitializeBoard();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Bẫy lỗi khi khởi tạo màn chơi (Exception Handling):\n" + ex.Message,
                    "Lỗi Khởi Tạo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateSoundButtonText()
        {
            try
            {
                btnSound.Text = SoundManager.IsMuted ? "🔇" : "🔊";
            }
            catch { }
        }

        private void btnSound_Click(object sender, EventArgs e)
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
                MessageBox.Show("Lỗi điều khiển âm thanh:\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                bool wasRunning = tmrCountdown.Enabled;
                if (wasRunning) tmrCountdown.Stop();

                FormAbout frmAbout = new FormAbout();
                frmAbout.ShowDialog(this);

                if (wasRunning && remainingTime > 0 && !isBusy)
                {
                    tmrCountdown.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form hướng dẫn:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                bool wasRunning = tmrCountdown.Enabled;
                if (wasRunning) tmrCountdown.Stop();

                FormLeaderboard frmLeaderboard = new FormLeaderboard();
                frmLeaderboard.ShowDialog(this);

                if (wasRunning && remainingTime > 0 && !isBusy)
                {
                    tmrCountdown.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở bảng thành tích:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string[] GetActiveIcons()
        {
            switch (theme)
            {
                case "Công nghệ":
                    return techIcons;
                case "Trái cây & Đồ ăn":
                    return fruitIcons;
                case "Ký hiệu học thuật":
                    return academicIcons;
                case "Biểu tượng vui vẻ":
                    return emojiIcons;
                case "Động vật":
                default:
                    return animalIcons;
            }
        }

        private List<int> GenerateShuffledValues(int totalCards)
        {
            List<int> values = new List<int>();
            if (currentMode == GameMode.MemoryMatch)
            {
                int pairCount = totalCards / 2;
                for (int i = 1; i <= pairCount; i++)
                {
                    values.Add(i);
                    values.Add(i);
                }
            }
            else
            {
                for (int i = 1; i <= totalCards; i++)
                {
                    values.Add(i);
                }
            }

            for (int i = values.Count - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                int temp = values[i];
                values[i] = values[swapIndex];
                values[swapIndex] = temp;
            }
            return values;
        }

        private void InitializeBoard()
        {
            try
            {
                tmrPreview.Stop();
                tmrCountdown.Stop();
                tmrFlipBack.Stop();

                pnlBoard.SuspendLayout();
                pnlBoard.Controls.Clear();
                firstCard = null;
                secondCard = null;
                pairsFound = 0;
                expectedNumber = 1;
                consecutiveCorrect = 0;

                int totalCards = rows * cols;
                List<int> cardValues = GenerateShuffledValues(totalCards);

                if (isUnlimitedTime)
                {
                    maxTime = 0;
                    remainingTime = 0;
                    prgTime.Visible = false;
                    lblTime.Text = "⏱ Thời gian: Vô hạn";
                    lblTime.ForeColor = Color.DarkGreen;
                }
                else
                {
                    maxTime = timeLimitSeconds;
                    remainingTime = maxTime;
                    prgTime.Visible = true;
                    prgTime.Minimum = 0;
                    prgTime.Maximum = maxTime;
                    prgTime.Value = remainingTime;
                }

                int spacing = 6;
                int cardWidth = (pnlBoard.Width - spacing * (cols + 1)) / cols;
                int cardHeight = (pnlBoard.Height - spacing * (rows + 1)) / rows;

                int index = 0;
                float fontSize = Math.Max(10f, Math.Min(cardWidth, cardHeight) / 3f);

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        Button btnCard = new Button();
                        btnCard.Width = cardWidth;
                        btnCard.Height = cardHeight;
                        btnCard.Left = spacing + c * (cardWidth + spacing);
                        btnCard.Top = spacing + r * (cardHeight + spacing);

                        btnCard.Tag = cardValues[index++];
                        btnCard.Font = new Font("Segoe UI", fontSize, FontStyle.Bold);
                        btnCard.FlatStyle = FlatStyle.Flat;
                        btnCard.FlatAppearance.BorderSize = 0;
                        btnCard.Cursor = Cursors.Hand;
                        btnCard.Paint += BtnCard_Paint;

                        if (enablePreview)
                        {
                            ShowCard(btnCard);
                        }
                        else
                        {
                            HideCard(btnCard);
                        }

                        btnCard.Click += Card_Click;
                        pnlBoard.Controls.Add(btnCard);
                    }
                }

                pnlBoard.ResumeLayout();
                UpdateStatusLabel();

                if (enablePreview)
                {
                    isBusy = true;
                    lblTime.Text = "Chuẩn bị: Nhìn trước 2 giây...";
                    lblTime.ForeColor = Color.DarkOrange;
                    tmrPreview.Interval = 2000;
                    tmrPreview.Start();
                }
                else
                {
                    isBusy = false;
                    if (!isUnlimitedTime)
                    {
                        lblTime.ForeColor = Color.Black;
                        lblTime.Text = $"Thời gian: {remainingTime}s";
                        tmrCountdown.Interval = 1000;
                        tmrCountdown.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Bẫy lỗi khi khởi tạo bàn cờ (Exception Handling):\n" + ex.Message,
                    "Lỗi Khởi Tạo Bàn Chơi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                isBusy = false;
            }
        }

        private void tmrPreview_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrPreview.Stop();

                pnlBoard.SuspendLayout();
                foreach (Control ctrl in pnlBoard.Controls)
                {
                    if (ctrl is Button btnCard)
                    {
                        HideCard(btnCard);
                    }
                }
                pnlBoard.ResumeLayout();

                isBusy = false;

                if (isUnlimitedTime)
                {
                    lblTime.Text = "⏱ Thời gian: Vô hạn";
                    lblTime.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblTime.ForeColor = Color.Black;
                    lblTime.Text = $"Thời gian: {remainingTime}s";
                    tmrCountdown.Interval = 1000;
                    tmrCountdown.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong timer nhìn trước: " + ex.Message);
                isBusy = false;
            }
        }

        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            try
            {
                remainingTime--;

                if (remainingTime >= 0)
                {
                    prgTime.Value = remainingTime;
                    lblTime.Text = $"Thời gian: {remainingTime}s";

                    if (remainingTime <= 5)
                        lblTime.ForeColor = Color.Red;
                    else
                        lblTime.ForeColor = Color.Black;
                }

                if (remainingTime <= 0)
                {
                    tmrCountdown.Stop();
                    tmrFlipBack.Stop();
                    isBusy = true;

                    SoundManager.PlayGameOver();

                    foreach (Control ctrl in pnlBoard.Controls)
                    {
                        if (ctrl is Button btnCard && btnCard.Enabled)
                        {
                            ShowCard(btnCard);
                            btnCard.BackColor = Color.FromArgb(235, 235, 235);
                        }
                    }

                    string modeDisplayName = (currentMode == GameMode.MemoryMatch) ? "Lật thẻ ghép cặp" : "Lật thẻ thứ tự";
                    if (score > 0)
                    {
                        try
                        {
                            FormInputName dlg = new FormInputName("⏰ HẾT THỜI GIAN!", "Rất tiếc! Bạn đã dừng bước do hết giờ.", score);
                            if (dlg.ShowDialog(this) == DialogResult.OK)
                            {
                                LeaderboardManager.SaveRecord(dlg.PlayerName, score, remainingTime, modeDisplayName);
                                FormLeaderboard frmLeaderboard = new FormLeaderboard();
                                frmLeaderboard.ShowDialog(this);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi lưu điểm thành tích:\n" + ex.Message, "Lỗi Thành Tích", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    DialogResult result = MessageBox.Show(
                        $"Hết thời gian! Bạn đã dừng chân tại Cấp độ {currentLevel} (Ma trận {rows}x{cols}).\nĐiểm số đạt được: {score}\n\nBạn có muốn chơi lại màn này không?",
                        "Hết giờ (Game Over)",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);

                    if (result == DialogResult.Yes)
                    {
                        InitializeBoard();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                tmrCountdown.Stop();
                MessageBox.Show("Lỗi trong đồng hồ đếm ngược: " + ex.Message);
            }
        }

        private static readonly Dictionary<string, Image> imageCache = new Dictionary<string, Image>();

        private Image GetEmojiImage(string emoji)
        {
            if (string.IsNullOrEmpty(emoji)) return null;

            if (imageCache.TryGetValue(emoji, out Image cached))
                return cached;

            try
            {
                int cp = char.ConvertToUtf32(emoji, 0);
                string hex = cp.ToString("x");

                string[] folders = { "animals", "fruits", "tech", "fun" };
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;

                foreach (string folder in folders)
                {
                    string dirPath = Path.Combine(baseDir, "assets", "emojis", folder);
                    if (!Directory.Exists(dirPath))
                    {
                        string parentDir = Directory.GetParent(baseDir)?.Parent?.FullName;
                        if (parentDir != null)
                        {
                            dirPath = Path.Combine(parentDir, "assets", "emojis", folder);
                        }
                    }

                    if (Directory.Exists(dirPath))
                    {
                        string path = Path.Combine(dirPath, hex + ".png");
                        if (File.Exists(path))
                        {
                            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                Image img = new Bitmap(Image.FromStream(stream));
                                imageCache[emoji] = img;
                                return img;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception)
            {
            }

            imageCache[emoji] = null;
            return null;
        }

        private void ShowCard(Button card)
        {
            try
            {
                int val = (int)card.Tag;
                card.BackColor = Color.White;
                card.ForeColor = Color.DarkSlateBlue;

                if (currentMode == GameMode.SequentialOrder)
                {
                    card.Image = null;
                    card.Text = val.ToString();
                }
                else
                {
                    string[] activeIcons = GetActiveIcons();
                    int iconIndex = (val - 1) % activeIcons.Length;
                    string iconText = activeIcons[iconIndex];

                    Image emojiImg = GetEmojiImage(iconText);
                    if (emojiImg != null)
                    {
                        card.Text = "";
                        card.Image = emojiImg;
                        card.ImageAlign = ContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        card.Image = null;
                        card.Text = iconText;
                    }
                }
            }
            catch (Exception)
            {
                card.Image = null;
                card.Text = card.Tag?.ToString() ?? "?";
            }
        }

        private void BtnCard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (sender is Button btn)
                {
                    Graphics g = e.Graphics;
                    int w = btn.Width;
                    int h = btn.Height;

                    if (btn.BackColor == Color.FromArgb(79, 70, 229))
                    {
                        using (Pen lightPen = new Pen(Color.FromArgb(129, 140, 248), 3))
                        {
                            g.DrawLine(lightPen, 0, 1, w - 1, 1);
                            g.DrawLine(lightPen, 1, 0, 1, h - 1);
                        }
                        using (Pen darkPen = new Pen(Color.FromArgb(55, 48, 163), 4))
                        {
                            g.DrawLine(darkPen, 0, h - 2, w - 1, h - 2);
                            g.DrawLine(darkPen, w - 2, 0, w - 2, h - 1);
                        }
                    }
                    else if (btn.BackColor == Color.FromArgb(209, 250, 229))
                    {
                        using (Pen greenBorder = new Pen(Color.FromArgb(16, 185, 129), 3))
                        {
                            g.DrawRectangle(greenBorder, 1, 1, w - 3, h - 3);
                        }
                    }
                    else if (btn.BackColor == Color.White)
                    {
                        using (Pen subtleBorder = new Pen(Color.FromArgb(203, 213, 225), 2))
                        {
                            g.DrawRectangle(subtleBorder, 1, 1, w - 2, h - 2);
                        }
                    }
                }
            }
            catch { }
        }

        private void HideCard(Button card)
        {
            try
            {
                card.Image = null;
                card.Text = "?";
                card.BackColor = Color.FromArgb(79, 70, 229);
                card.ForeColor = Color.White;
            }
            catch (Exception)
            {
                card.Image = null;
                card.Text = "?";
                card.BackColor = Color.FromArgb(79, 70, 229);
                card.ForeColor = Color.White;
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (isBusy) return;

            try
            {
                Button clickedCard = sender as Button;
                if (clickedCard == null) return;

                if (clickedCard.BackColor == Color.White || clickedCard.BackColor == Color.FromArgb(209, 250, 229) || !clickedCard.Enabled)
                    return;

                if (currentMode == GameMode.MemoryMatch && clickedCard == firstCard)
                    return;

                SoundManager.PlayFlip();

                ShowCard(clickedCard);

                if (currentMode == GameMode.MemoryMatch)
                {
                    HandleMemoryMatch(clickedCard);
                }
                else
                {
                    HandleSequentialOrder(clickedCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý lật thẻ bài: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleMemoryMatch(Button clickedCard)
        {
            if (firstCard == null)
            {
                firstCard = clickedCard;
                return;
            }

            secondCard = clickedCard;

            if ((int)firstCard.Tag == (int)secondCard.Tag)
            {
                firstCard.BackColor = Color.FromArgb(209, 250, 229);
                secondCard.BackColor = Color.FromArgb(209, 250, 229);
                firstCard.Enabled = false;
                secondCard.Enabled = false;
                firstCard = null;
                secondCard = null;

                pairsFound++;
                score += 25;
                UpdateStatusLabel();

                if (pairsFound == (rows * cols) / 2)
                {
                    tmrCountdown.Stop();
                    AdvanceToNextLevel();
                }
            }
            else
            {
                SoundManager.PlayWrong();

                score = Math.Max(0, score - 5);
                UpdateStatusLabel();

                isBusy = true;
                tmrFlipBack.Interval = 600;
                tmrFlipBack.Start();
            }
        }

        private void HandleSequentialOrder(Button clickedCard)
        {
            int cardValue = (int)clickedCard.Tag;

            if (cardValue == expectedNumber)
            {
                clickedCard.BackColor = Color.FromArgb(209, 250, 229);
                clickedCard.Enabled = false;

                consecutiveCorrect++;

                if (expectedNumber == 1)
                {
                    score += 10;
                }
                else if (consecutiveCorrect >= 2)
                {
                    score += (5 + consecutiveCorrect);
                }
                else
                {
                    score += 5;
                }

                expectedNumber++;
                UpdateStatusLabel();

                if (expectedNumber > (rows * cols))
                {
                    tmrCountdown.Stop();
                    AdvanceToNextLevel();
                }
            }
            else
            {
                SoundManager.PlayWrong();

                score = Math.Max(0, score - 3);
                consecutiveCorrect = 0;
                UpdateStatusLabel();

                clickedCard.BackColor = Color.FromArgb(254, 226, 226);
                firstCard = clickedCard;
                isBusy = true;
                tmrFlipBack.Interval = 600;
                tmrFlipBack.Start();
            }
        }

        private void tmrFlipBack_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrFlipBack.Stop();

                if (currentMode == GameMode.MemoryMatch)
                {
                    if (firstCard != null) HideCard(firstCard);
                    if (secondCard != null) HideCard(secondCard);
                    firstCard = null;
                    secondCard = null;
                }
                else
                {
                    if (isHardcore)
                    {
                        pnlBoard.SuspendLayout();
                        foreach (Control ctrl in pnlBoard.Controls)
                        {
                            if (ctrl is Button btnCard)
                            {
                                HideCard(btnCard);
                                btnCard.Enabled = true;
                            }
                        }
                        pnlBoard.ResumeLayout();
                        expectedNumber = 1;
                        UpdateStatusLabel();
                    }
                    else
                    {
                        if (firstCard != null) HideCard(firstCard);

                        int stepsToUndo = Math.Min(2, expectedNumber - 1);
                        if (stepsToUndo > 0)
                        {
                            pnlBoard.SuspendLayout();
                            for (int step = 0; step < stepsToUndo; step++)
                            {
                                int undoValue = expectedNumber - 1 - step;
                                foreach (Control ctrl in pnlBoard.Controls)
                                {
                                    if (ctrl is Button btnCard && (int)btnCard.Tag == undoValue)
                                    {
                                        HideCard(btnCard);
                                        btnCard.Enabled = true;
                                        break;
                                    }
                                }
                            }
                            pnlBoard.ResumeLayout();
                            expectedNumber -= stepsToUndo;
                        }
                        UpdateStatusLabel();
                    }
                    firstCard = null;
                }

                isBusy = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi úp lại thẻ: " + ex.Message);
                isBusy = false;
            }
        }

        private void AdvanceToNextLevel()
        {
            try
            {
                SoundManager.PlayVictory();

                string modeDisplayName = (currentMode == GameMode.MemoryMatch) ? "Lật thẻ ghép cặp" : "Lật thẻ thứ tự";

                try
                {
                    FormInputName dlg = new FormInputName("🎉 CHIẾN THẮNG XUẤT SẮC!", $"Bạn đã vượt qua Cấp độ {currentLevel}!", score);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LeaderboardManager.SaveRecord(dlg.PlayerName, score, remainingTime, modeDisplayName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu bảng thành tích:\n" + ex.Message, "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                MessageBox.Show(
                    $"🎉 Chúc mừng! Bạn đã hoàn thành xuất sắc Cấp độ {currentLevel} (Ma trận {rows}x{cols})!\n" +
                    $"Điểm số hiện tại: {score}\n\n" +
                    $"Nhấn OK để bước sang Cấp độ {currentLevel + 1}!",
                    "Qua Màn Thành Công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                currentLevel++;

                if (rows < cols)
                    rows++;
                else
                    cols++;

                if (currentMode == GameMode.MemoryMatch && (rows * cols) % 2 != 0)
                {
                    cols++;
                }

                if (rows > 8) rows = 8;
                if (cols > 8) cols = 8;

                InitializeBoard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nâng cấp độ màn chơi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusLabel()
        {
            try
            {
                lblLevel.Text = $"Cấp độ: {currentLevel} ({rows} x {cols})";
                lblScore.Text = $"Điểm số: {score}";

                if (currentMode == GameMode.MemoryMatch)
                {
                    lblStatus.Text = $"Cặp đã ghép: {pairsFound} / {(rows * cols) / 2}";
                }
                else
                {
                    lblStatus.Text = $"Số cần lật tiếp theo: {expectedNumber} / {rows * cols}";
                }
            }
            catch { }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                DialogResult res = MessageBox.Show(
                    "Bạn có chắc muốn chơi lại màn hiện tại không?",
                    "Chơi lại",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    score = 0;
                    InitializeBoard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi động lại: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                SoundManager.PlayFlip();
                DialogResult res = MessageBox.Show(
                    "Bạn có chắc muốn thoát về Menu chính?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thoát: " + ex.Message);
                this.Close();
            }
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tmrPreview.Stop();
                tmrCountdown.Stop();
                tmrFlipBack.Stop();
            }
            catch { }
        }
    }
}
