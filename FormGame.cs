using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace game_lật_thẻ_1._1
{
    public partial class FormGame : Form
    {
        // --- THÔNG SỐ CẤU HÌNH TRÒ CHƠI ---
        private readonly GameMode currentMode;
        private int rows;
        private int cols;
        private readonly string theme;
        private readonly bool enablePreview;
        private readonly bool isHardcore;
        private readonly int timeLimitSeconds;      // Thời gian giới hạn (giây), 0 = vô hạn
        private readonly bool isUnlimitedTime;      // true nếu chơi vô hạn thời gian

        // --- TRẠNG THÁI HIỆN TẠI ---
        private int currentLevel = 1;
        private int score = 0;
        private bool isBusy = false;            // Khóa bàn chơi khi đang Preview hoặc chờ Timer úp thẻ
        private Button firstCard = null;        // Thẻ thứ 1 được lật
        private Button secondCard = null;       // Thẻ thứ 2 được lật (cho Game 1)
        private int pairsFound = 0;             // Số cặp đã ghép thành công (cho Game 1)
        private int expectedNumber = 1;         // Số tiếp theo cần lật (cho Game 2)
        private int consecutiveCorrect = 0;     // Số lần đúng liên tiếp (cho Game 2)
        private readonly Random rng = new Random();

        // --- QUẢN LÝ THỜI GIAN ---
        private int maxTime = 0;                // Thời gian tối đa của màn hiện tại (giây)
        private int remainingTime = 0;          // Thời gian còn lại thực tế (giây)

        // --- BỘ TÀI NGUYÊN BIỂU TƯỢNG UNICODE THEO CHỦ ĐỀ ---
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

            // Gắn sự kiện các Timer
            tmrPreview.Tick += tmrPreview_Tick;
            tmrCountdown.Tick += tmrCountdown_Tick;
            tmrFlipBack.Tick += tmrFlipBack_Tick;

            // Cập nhật nhãn chế độ
            if (currentMode == GameMode.MemoryMatch)
            {
                lblMode.Text = "Chế độ: Lật thẻ ghép cặp trí nhớ";
            }
            else
            {
                lblMode.Text = isHardcore
                    ? "Chế độ: Lật thẻ tiến lên (HARDCORE 🔥)"
                    : "Chế độ: Lật thẻ tiến lên (sai lùi 2 bước)";
            }

            // Bắt đầu màn chơi đầu tiên
            InitializeBoard();
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

        // Sinh danh sách giá trị và xáo trộn ngẫu nhiên theo thuật toán Fisher-Yates
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

            // Thuật toán Fisher-Yates Shuffle
            for (int i = values.Count - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                int temp = values[i];
                values[i] = values[swapIndex];
                values[swapIndex] = temp;
            }
            return values;
        }

        // Khởi tạo hoặc vẽ lại toàn bộ bàn chơi
        private void InitializeBoard()
        {
            // 1. Dừng toàn bộ các Timer đang chạy (nếu có)
            tmrPreview.Stop();
            tmrCountdown.Stop();
            tmrFlipBack.Stop();

            // 2. Reset các biến trạng thái
            pnlBoard.SuspendLayout();
            pnlBoard.Controls.Clear();
            firstCard = null;
            secondCard = null;
            pairsFound = 0;
            expectedNumber = 1;
            consecutiveCorrect = 0;

            int totalCards = rows * cols;
            List<int> cardValues = GenerateShuffledValues(totalCards);

            // 3. Thiết lập thời gian theo cấu hình người chơi
            if (isUnlimitedTime)
            {
                // Chế độ vô hạn: ẩn thanh thời gian
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

            // 4. Sinh ma trận thẻ bài động trên Panel
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
                        ShowCard(btnCard); // Lật ngửa sẵn để nhìn trước
                    }
                    else
                    {
                        HideCard(btnCard); // Úp thẻ ngay
                    }

                    btnCard.Click += Card_Click;
                    pnlBoard.Controls.Add(btnCard);
                }
            }

            pnlBoard.ResumeLayout();
            UpdateStatusLabel();

            // 5. Điều phối giai đoạn Preview hoặc bắt đầu chơi ngay
            if (enablePreview)
            {
                isBusy = true; // Khóa không cho bấm khi đang nhìn trước
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

        // Hết 2 giây nhìn trước -> Úp thẻ và bắt đầu đếm ngược
        private void tmrPreview_Tick(object sender, EventArgs e)
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

        // Đồng hồ đếm ngược mỗi giây
        private void tmrCountdown_Tick(object sender, EventArgs e)
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

            // Hết giờ -> Game Over
            if (remainingTime <= 0)
            {
                tmrCountdown.Stop();
                tmrFlipBack.Stop();
                isBusy = true;

                // Lật mở các thẻ còn lại để người chơi quan sát đáp án
                foreach (Control ctrl in pnlBoard.Controls)
                {
                    if (ctrl is Button btnCard && btnCard.Enabled)
                    {
                        ShowCard(btnCard);
                        btnCard.BackColor = Color.FromArgb(235, 235, 235);
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

        // Cộng thêm thời gian thưởng khi lật đúng
        private void AddBonusTime(int bonusSeconds)
        {
            remainingTime = Math.Min(remainingTime + bonusSeconds, maxTime);
            prgTime.Value = remainingTime;
            lblTime.Text = $"Thời gian: {remainingTime}s (+{bonusSeconds}s)";
            lblTime.ForeColor = Color.DarkGreen;
        }

        // Lấy hình ảnh màu theo emoji tương ứng nếu có
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
                    string path = Path.Combine(baseDir, "assets", "emojis", folder, hex + ".png");
                    if (File.Exists(path))
                    {
                        Image img = Image.FromFile(path);
                        imageCache[emoji] = img;
                        return img;
                    }
                }
            }
            catch
            {
                // Nếu có lỗi nạp ảnh, sẽ fallback về vẽ Text chữ
            }

            imageCache[emoji] = null;
            return null;
        }

        // Lật ngửa thẻ
        private void ShowCard(Button card)
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

        // Vẽ hiệu ứng viền bóng 3D Arcade Playful cho thẻ bài
        private void BtnCard_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                Graphics g = e.Graphics;
                int w = btn.Width;
                int h = btn.Height;

                // Nếu thẻ đang úp
                if (btn.BackColor == Color.FromArgb(79, 70, 229))
                {
                    // Viền nổi sáng phía trên và trái
                    using (Pen lightPen = new Pen(Color.FromArgb(129, 140, 248), 3))
                    {
                        g.DrawLine(lightPen, 0, 1, w - 1, 1);
                        g.DrawLine(lightPen, 1, 0, 1, h - 1);
                    }
                    // Viền bóng lún 3D đậm phía dưới và phải
                    using (Pen darkPen = new Pen(Color.FromArgb(55, 48, 163), 4))
                    {
                        g.DrawLine(darkPen, 0, h - 2, w - 1, h - 2);
                        g.DrawLine(darkPen, w - 2, 0, w - 2, h - 1);
                    }
                }
                // Nếu thẻ đã mở đúng (ghép thành công)
                else if (btn.BackColor == Color.FromArgb(209, 250, 229))
                {
                    using (Pen greenBorder = new Pen(Color.FromArgb(16, 185, 129), 3))
                    {
                        g.DrawRectangle(greenBorder, 1, 1, w - 3, h - 3);
                    }
                }
                // Thẻ đang mở ngửa bình thường
                else if (btn.BackColor == Color.White)
                {
                    using (Pen subtleBorder = new Pen(Color.FromArgb(203, 213, 225), 2))
                    {
                        g.DrawRectangle(subtleBorder, 1, 1, w - 2, h - 2);
                    }
                }
            }
        }

        // Úp thẻ xuống
        private void HideCard(Button card)
        {
            card.Image = null;
            card.Text = "?";
            card.BackColor = Color.FromArgb(79, 70, 229); // Tím chàm hiện đại
            card.ForeColor = Color.White;
        }

        // Sự kiện Click dùng chung cho toàn bộ thẻ bài
        private void Card_Click(object sender, EventArgs e)
        {
            if (isBusy) return;

            Button clickedCard = sender as Button;
            if (clickedCard == null) return;

            // Chặn nhấn vào thẻ đã mở thành công hoặc đang mở
            if (clickedCard.BackColor == Color.White || clickedCard.BackColor == Color.FromArgb(209, 250, 229) || !clickedCard.Enabled)
                return;

            // Chặn nhấn lại chính thẻ đầu tiên trong Game 1
            if (currentMode == GameMode.MemoryMatch && clickedCard == firstCard)
                return;

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

        // --- LOGIC GAME 1: LẬT THẺ TRÍ NHỚ (MEMORY MATCH) ---
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
                // Lật đúng cặp → +25 điểm
                firstCard.BackColor = Color.FromArgb(209, 250, 229); // Xanh ngọc nhạt êm dịu
                secondCard.BackColor = Color.FromArgb(209, 250, 229);
                firstCard.Enabled = false;
                secondCard.Enabled = false;
                firstCard = null;
                secondCard = null;

                pairsFound++;
                score += 25;
                // Không cộng thêm thời gian - thời gian giảm cố định
                UpdateStatusLabel();

                // Kiểm tra thắng màn
                if (pairsFound == (rows * cols) / 2)
                {
                    tmrCountdown.Stop(); // BẮT BUỘC dừng đồng hồ trước khi hiện thông báo
                    AdvanceToNextLevel();
                }
            }
            else
            {
                // Lật sai cặp → -5 điểm (tối thiểu 0)
                score = Math.Max(0, score - 5);
                UpdateStatusLabel();

                isBusy = true;
                tmrFlipBack.Interval = 600;
                tmrFlipBack.Start();
            }
        }

        // --- LOGIC GAME 2: LẬT THẺ TIẾN LÊN (SEQUENTIAL NUMBERS) ---
        private void HandleSequentialOrder(Button clickedCard)
        {
            int cardValue = (int)clickedCard.Tag;

            if (cardValue == expectedNumber)
            {
                // Lật đúng số thứ tự tiếp theo
                clickedCard.BackColor = Color.FromArgb(209, 250, 229);
                clickedCard.Enabled = false;

                consecutiveCorrect++;

                // Tính điểm theo công thức:
                // - Số đầu tiên (số 1): +10 điểm
                // - Các số tiếp theo: +5 điểm
                // - Đúng liên tiếp từ 2 lần trở lên: +(5 + số lần đúng liên tiếp)
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
                // Không cộng thêm thời gian - thời gian giảm cố định
                UpdateStatusLabel();

                // Kiểm tra thắng màn
                if (expectedNumber > (rows * cols))
                {
                    tmrCountdown.Stop(); // BẮT BUỘC dừng đồng hồ trước khi hiện thông báo
                    AdvanceToNextLevel();
                }
            }
            else
            {
                // Lật sai thứ tự → -3 điểm (tối thiểu 0), reset chuỗi đúng liên tiếp
                score = Math.Max(0, score - 3);
                consecutiveCorrect = 0;
                UpdateStatusLabel();

                clickedCard.BackColor = Color.FromArgb(254, 226, 226); // Đỏ pastel nhẹ nhàng khi sai
                firstCard = clickedCard;
                isBusy = true;
                tmrFlipBack.Interval = 600;
                tmrFlipBack.Start();
            }
        }

        // Timer úp lại thẻ sau 600ms khi lật sai
        private void tmrFlipBack_Tick(object sender, EventArgs e)
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
                    // Chế độ Hardcore: Sai một bước, sập toàn bàn về số 1!
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
                    // Chế độ thường: Sai → úp thẻ sai + lùi 2 bước trước đó
                    if (firstCard != null) HideCard(firstCard);

                    // Lùi 2 bước: tìm và úp lại 2 thẻ đã lật đúng gần nhất
                    int stepsToUndo = Math.Min(2, expectedNumber - 1); // Không lùi quá số 1
                    if (stepsToUndo > 0)
                    {
                        pnlBoard.SuspendLayout();
                        for (int step = 0; step < stepsToUndo; step++)
                        {
                            int undoValue = expectedNumber - 1 - step; // Lùi từ số gần nhất
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

            isBusy = false; // Mở khóa bàn chơi
        }

        // Tự động nâng cấp độ và mở rộng kích thước ma trận
        private void AdvanceToNextLevel()
        {
            MessageBox.Show(
                $"🎉 Chúc mừng! Bạn đã hoàn thành xuất sắc Cấp độ {currentLevel} (Ma trận {rows}x{cols})!\n" +
                $"Điểm số hiện tại: {score}\n\n" +
                $"Nhấn OK để bước sang Cấp độ {currentLevel + 1}!",
                "Qua Màn Thành Công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            currentLevel++;

            // Quy tắc tự động mở rộng kích thước ma trận
            if (rows < cols)
                rows++;
            else
                cols++;

            // Với Game 1: Nếu tổng số ô là lẻ, tăng thêm 1 cột để đảm bảo số chẵn
            if (currentMode == GameMode.MemoryMatch && (rows * cols) % 2 != 0)
            {
                cols++;
            }

            // Giới hạn ma trận tối đa 8x8
            if (rows > 8) rows = 8;
            if (cols > 8) cols = 8;

            InitializeBoard();
        }

        // Cập nhật nhãn trạng thái và điểm số
        private void UpdateStatusLabel()
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

        private void btnRestart_Click(object sender, EventArgs e)
        {
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

        private void btnBack_Click(object sender, EventArgs e)
        {
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

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dừng an toàn tất cả Timer khi đóng form
            tmrPreview.Stop();
            tmrCountdown.Stop();
            tmrFlipBack.Stop();
        }
    }
}
