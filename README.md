[README.md](https://github.com/user-attachments/files/33972097/README.md)
# 🃏 GAME LẬT THẺ TRÍ NHỚ (MEMORY CARD GAME)

<p align="center">
  <img src="https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4?style=for-the-badge\&logo=dotnet\&logoColor=white" alt=".NET Framework 4.7.2" />
  <img src="https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge\&logo=c-sharp\&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/UI-Windows%20Forms-0078D4?style=for-the-badge\&logo=windows\&logoColor=white" alt="Windows Forms" />
  <img src="https://img.shields.io/badge/Team-CHARLIEKODE-FF6F00?style=for-the-badge" alt="Team CHARLIEKODE" />
  <img src="https://img.shields.io/badge/Status-Completed%2010%2F10-brightgreen?style=for-the-badge" alt="Status" />
</p>

\---

## 📌 Giới Thiệu Dự Án

**Game Lật Thẻ Trí Nhớ** là minigame được phát triển trên môi trường Windows bằng ngôn ngữ **C#** và nền tảng **Windows Forms Application (.NET Framework 4.7.2)**. Đây là đồ án môn học **Lập Trình Trên Môi Trường Windows (LTWIN)** được xây dựng và hoàn thiện bởi nhóm **CHARLIEKODE**.

Trò chơi đánh giá toàn diện các kỹ năng:

* **Tư duy thuật toán**: Xáo trộn ngẫu nhiên Fisher-Yates, quản lý trạng thái lật thẻ, luân phiên lượt chơi đối kháng.
* **Xử lý sự kiện \& Thời gian**: Điều phối linh hoạt các `System.Windows.Forms.Timer` (Xem trước, Đếm ngược, Tự động úp thẻ khi lật sai).
* **Quản lý tập tin (I/O)**: Đọc/ghi bảng thành tích người chơi dạng append vào `thanhtichs.txt` thông qua thư viện `System.IO`.
* **Đa phương tiện**: Xử lý nạp hình ảnh từ thư mục `img/`, phát hiệu ứng âm thanh sự kiện và nhạc nền qua `System.Media.SoundPlayer` từ thư mục `bg/`.
* **Bẫy lỗi (Exception Handling)**: Bọc khối `try...catch` an toàn ở toàn bộ các tiến trình đọc/ghi file và nạp tài nguyên, tự động kích hoạt chế độ dự phòng nếu thiếu file.

\---

## 👥 Nhóm Thực Hiện: CHARLIEKODE

|STT|Họ và Tên|Mã Số Sinh Viên (MSSV)|Lớp Học Phần|Nhiệm Vụ Phụ Trách|
|:-:|-|:-:|:-:|-|
|**1**|**Hứa Nhựt Tuấn**|*51.01.104.114*|*2611COMP101901*|Thiết kế Game Logic|
|**2**|**Lê Văn Gia Bảo**|*51.01.104.007*|*2611COMP101901*|Xử lý Âm thanh \& Hình ảnh, Exception Handling|
|**3**|**Huỳnh Phú Vinh**|*51.01.104.120*|*2611COMP101901*|Thuật toán Shuffle, Timer, UI Game|
|**4**|**Nguyễn Đăng Khoa**|*51.01.104.045*|*2611COMP101901*|Bảng thành tích (System.IO)|



## ✨ Các Tính Năng Nổi Bật

### 1\. Luồng Game Logic Hoàn Thiện \& Chặt Chẽ

* **Start / Restart / End Game**: Bắt đầu màn chơi mới, khởi động lại màn hiện tại hoặc quay về Menu chính an toàn.
* **Tạm dừng (Pause / Resume)**: Nút `⏸ Tạm dừng` cho phép dừng đồng hồ đếm ngược và che mờ bàn chơi bằng lớp phủ (Overlay) để chống gian lận.
* **Tự động tăng độ khó**: Khi hoàn thành một màn, hệ thống tự động mở rộng ma trận thẻ bài (từ 3x4 -> 4x4 -> 6x6 -> 8x8) và chuyển sang cấp độ tiếp theo.

### 2\. Hai Chế Độ Chơi Đa Dạng

* 🧠 **Lật Thẻ Trí Nhớ (Memory Match)**:

  * Chọn 2 thẻ bài giống nhau để triệt tiêu cặp thẻ.
  * Lật đúng: **+25 điểm**, giữ nguyên thẻ mở và phát âm thanh `true.wav`.
  * Lật sai: **-5 điểm**, tự động úp thẻ lại sau 0.6 giây và phát âm thanh `false.wav`.
* 🔢 **Lật Thẻ Theo Thứ Tự (Sequential Numbers)**:

  * Lật lần lượt các số tăng dần từ 1 đến N. Có hệ số thưởng combo điểm khi lật đúng liên tiếp.
  * Chế độ Thường: Lật sai sẽ bị phạt lùi lại 2 bước.
  * Chế độ **Hardcore 🔥**: Sai 1 bước sẽ sập toàn bộ bàn cờ về số 1!

### 3\. Bảng Thành Tích Trực Quan (Leaderboard)

* Đọc và ghi dữ liệu người chơi (`Tên`, `Điểm Số`, `Thời Gian Còn Lại`, `Chế Độ`, `Ngày Giờ`) vào file `thanhtichs.txt` qua `System.IO`.
* Hộp thoại nhập tên người chơi xuất hiện khi chiến thắng hoặc hết giờ.
* Bảng xếp hạng hiển thị trực quan qua `DataGridView` với biểu tượng vinh danh top 3 (🥇, 🥈, 🥉), có nút làm mới và xóa lịch sử.

### 4\. Tích Hợp Đầy Đủ Âm Thanh \& Hình Ảnh

* **Âm thanh (`bg/`)**: Sử dụng `System.Media.SoundPlayer` phát file `.wav`:

  * `flip.wav`: Tiếng lách cách nhẹ khi lật thẻ.
  * `true.wav`: Giai điệu vui vẻ khi ghép đúng cặp thẻ.
  * `false.wav`: Âm thanh cảnh báo khi lật sai.
  * `victory.wav`: Giai điệu hoan hô khi hoàn thành ván.
  * `gameover.wav`: Âm thanh thông báo khi hết thời gian.
  * `bgm.wav`: Nhạc nền nhẹ nhàng phát lặp (Looping).
  * Có nút bật/tắt âm thanh (🔊 / 🔇) chủ động ngay trên giao diện.
* **Hình ảnh (`img/`)**:

  * Nạp bộ 32 ảnh thẻ bài độc đáo cùng mặt úp `card\_back.png` và `no-image.png`.
  * Đổi các chủ đề linh hoạt: Hình ảnh thẻ bài, Động vật, Công nghệ, Trái cây, Biểu tượng vui vẻ...

### 5\. Bẫy Lỗi Toàn Diện (Exception Handling)

* Toàn bộ các thao tác I/O tập tin và nạp tài nguyên ngoài đều được bao bọc trong khối `try...catch`.
* Nếu thư mục `img/` hoặc `bg/` bị mất hoặc di dời, trò chơi **không bao giờ bị văng (crash)** mà tự động chuyển sang đồ họa / âm thanh dự phòng kèm thông báo cảnh báo thân thiện.

\---

## 📁 Cấu Trúc Thư Mục Dự Án

```
LTW-MINIGAME-CHARLIEKODE/
│
├── game lật thẻ 1.1.sln            # Tập tin Solution Visual Studio chuẩn
├── game lật thẻ 1.1.slnx           # Tập tin Solution phiên bản mới
├── game lật thẻ 1.1.csproj         # Cấu hình dự án C# Windows Forms
├── App.config                      # Cấu hình runtime .NET
├── .gitignore                      # Bộ lọc loại bỏ file tạm build (.vs, bin, obj)
├── README.md                       # Tài liệu hướng dẫn \& giới thiệu dự án
├── thanhtichs.txt                  # Dữ liệu bảng thành tích mẫu
│
├── bg/                             # Thư mục âm thanh sự kiện \& nhạc nền
│   ├── bgm.wav
│   ├── false.wav
│   ├── flip.wav
│   ├── gameover.wav
│   ├── true.wav
│   └── victory.wav
│
├── img/                            # Thư mục hình ảnh các thẻ bài \& mặt sau
│   ├── card\_back.png
│   ├── no-image.png
│   ├── card\_1.png ... card\_32.png
│
├── GameMode.cs                     # Enum định nghĩa chế độ chơi \& số lượng người chơi
├── SoundManager.cs                 # Quản lý phát âm thanh SoundPlayer \& Bật/Tắt
├── CardImageManager.cs             # Quản lý nạp ảnh thẻ bài \& cơ chế dự phòng
├── LeaderboardManager.cs           # Đọc/ghi file thanhtichs.txt bằng System.IO
│
├── FormMenu.cs / .Designer.cs      # Màn hình Menu chính \& chọn độ khó / chế độ
├── FormGame.cs / .Designer.cs      # Màn hình bàn chơi, đồng hồ, điều khiển
├── FormLeaderboard.cs / .Designer.cs # Màn hình xem Bảng thành tích (DataGridView)
├── FormAbout.cs / .Designer.cs     # Màn hình Hướng dẫn chơi \& Thông tin nhóm CHARLIEKODE
├── FormInputName.cs / .Designer.cs # Hộp thoại nhập tên lưu điểm khi kết thúc
│
└── Properties/                     # AssemblyInfo, Resources, Settings
```

\---

## 🚀 Hướng Dẫn Cài Đặt \& Chạy Thử

### Yêu Cầu Hệ Thống:

* **Hệ điều hành**: Windows 10 / Windows 11.
* **Môi trường chạy**: .NET Framework 4.7.2 trở lên (mặc định đã có sẵn trên Windows 10/11).
* **Môi trường lập trình (nếu cần chỉnh sửa)**: Visual Studio 2019 hoặc Visual Studio 2022 (đã cài gói *.NET desktop development*).

### Các Bước Thực Hiện:

1. **Clone repository về máy:**

```bash
   git clone https://github.com/HuaNhutTuan/LTW-MINIGAME-CHARLIEKODE.git
   cd LTW-MINIGAME-CHARLIEKODE
   ```

2. **Mở dự án:**

   * Nhấp đúp vào file `game lật thẻ 1.1.sln` để mở trong Visual Studio.
3. **Biên dịch và Chạy:**

   * Nhấn phím `F5` hoặc chọn nút **Start (Debug)** trên thanh công cụ của Visual Studio.
   * Hoặc chạy trực tiếp file thực thi tại `bin\\Debug\\game lật thẻ 1.1.exe` sau khi build.

\---

## 🎯 Bảng Đánh Giá Mức Độ Hoàn Thiện (Thang Điểm 10)

|Tiêu Chí Chấm Điểm|Trọng Số|Mức Độ Đạt Được|Ghi Chú|
|-|:-:|:-:|-|
|**1. Mức độ hoàn thiện \& Độ khó**|4.0đ|**4.0 / 4.0**|Hoàn chỉnh luồng Start, Pause, Restart, End Game; thuật toán Fisher-Yates shuffle; chế độ 2 người chơi đối kháng mượt mà.|
|**2. Giao diện - UI**|2.0đ|**2.0 / 2.0**|Tự thiết kế thủ công bằng mã C# WinForms; nạp hình ảnh từ `img/`; bố cục khoa học, thoáng đãng, không bị đè chữ.|
|**3. Bảng thành tích (Leaderboard)**|1.0đ|**1.0 / 1.0**|Đọc/ghi `thanhtichs.txt` dạng append bằng `System.IO`; hiển thị DataGridView sắp xếp giảm dần theo điểm số.|
|**4. Âm thanh**|1.0đ|**1.0 / 1.0**|Đầy đủ nhạc nền và hiệu ứng sự kiện (`flip`, `true`, `false`, `victory`, `gameover`); nút Bật/Tắt âm thanh chủ động.|
|**5. Hướng dẫn \& Thông tin nhóm**|1.0đ|**1.0 / 1.0**|Form About hướng dẫn chi tiết luật chơi và thông tin nhóm **CHARLIEKODE**.|
|**6. Bẫy lỗi (Exception Handling)**|1.0đ|**1.0 / 1.0**|Bọc `try...catch` ở toàn bộ tiến trình I/O và nạp tài nguyên; tự động fallback an toàn không crash.|
|**TỔNG CỘNG**|**10.0đ**|**10.0 / 10.0**|**XUẤT SẮC**|

\---

<p align="center">
  <b>© 2026 CHARLIEKODE - Đồ án môn học Lập Trình Trên Môi Trường Windows (LTWIN)</b>
</p>

