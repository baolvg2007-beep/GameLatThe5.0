using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace game_lật_thẻ_1._1
{
    public static class SoundManager
    {
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        private const string ALIAS_BGM = "GameBGM";
        private const string ALIAS_FLIP = "SFX_Flip";
        private const string ALIAS_WRONG = "SFX_Wrong";
        private const string ALIAS_VICTORY = "SFX_Victory";
        private const string ALIAS_GAMEOVER = "SFX_GameOver";

        private static SoundPlayer flipPlayer;
        private static SoundPlayer wrongPlayer;
        private static SoundPlayer victoryPlayer;
        private static SoundPlayer gameOverPlayer;
        private static SoundPlayer bgmPlayer;

        public static bool IsMuted { get; set; } = false;
        public static bool HasSoundsAvailable { get; private set; } = false;

        private static string soundDirectory;
        private static bool isInitialized = false;
        private static bool hasWarnedMissingFolder = false;
        private static bool isMciAvailable = false;
        private static bool isBgmPlaying = false;

        static SoundManager()
        {
            InitializeSounds();
        }

        public static void InitializeSounds()
        {
            if (isInitialized) return;

            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                soundDirectory = Path.Combine(baseDir, "bg");

                if (!Directory.Exists(soundDirectory))
                {
                    string parentDir = Directory.GetParent(baseDir)?.Parent?.FullName;
                    if (parentDir != null)
                    {
                        string candidate = Path.Combine(parentDir, "bg");
                        if (Directory.Exists(candidate))
                        {
                            soundDirectory = candidate;
                        }
                    }
                }

                if (!Directory.Exists(soundDirectory))
                {
                    if (!hasWarnedMissingFolder)
                    {
                        hasWarnedMissingFolder = true;
                        MessageBox.Show(
                            "Cảnh báo bẫy lỗi (Exception Handling):\nKhông tìm thấy thư mục âm thanh 'bg/'.\n" +
                            "Trò chơi sẽ tự động chuyển sang chế độ im lặng để đảm bảo không bị văng (crash) ứng dụng.",
                            "Cảnh Báo Âm Thanh (Thiếu Thư Mục bg/)",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    IsMuted = true;
                    HasSoundsAvailable = false;
                    return;
                }

                InitMciDevice(ALIAS_BGM, "bgm.wav");
                InitMciDevice(ALIAS_FLIP, "flip.wav");
                InitMciDevice(ALIAS_WRONG, "false.wav");
                InitMciDevice(ALIAS_VICTORY, "victory.wav");
                InitMciDevice(ALIAS_GAMEOVER, "gameover.wav");

                flipPlayer = CreatePlayer("flip.wav");
                wrongPlayer = CreatePlayer("false.wav");
                victoryPlayer = CreatePlayer("victory.wav");
                gameOverPlayer = CreatePlayer("gameover.wav");
                bgmPlayer = CreatePlayer("bgm.wav");

                HasSoundsAvailable = (flipPlayer != null || bgmPlayer != null || isMciAvailable);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(
                    "Lỗi thư mục âm thanh không tồn tại:\n" + ex.Message + "\nTrò chơi sẽ tiếp tục trong chế độ im lặng.",
                    "Lỗi Thư Mục Âm Thanh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                IsMuted = true;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(
                    "Thiếu tệp âm thanh trong thư mục 'bg/':\n" + ex.Message + "\nTrò chơi sẽ tiếp tục không có âm thanh.",
                    "Lỗi Tệp Âm Thanh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                IsMuted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể nạp một số tài nguyên âm thanh từ thư mục 'bg/':\n" + ex.Message + "\nTrò chơi sẽ tiếp tục mà không có âm thanh.",
                    "Cảnh Báo Âm Thanh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                IsMuted = true;
            }
            finally
            {
                isInitialized = true;
            }
        }

        private static void InitMciDevice(string alias, string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(soundDirectory) || !Directory.Exists(soundDirectory)) return;
                string path = Path.Combine(soundDirectory, fileName);
                if (File.Exists(path))
                {
                    mciSendString($"close {alias}", null, 0, IntPtr.Zero);
                    int res = mciSendString($"open \"{path}\" type mpegvideo alias {alias}", null, 0, IntPtr.Zero);
                    if (res == 0)
                    {
                        isMciAvailable = true;
                    }
                }
            }
            catch { }
        }

        private static SoundPlayer CreatePlayer(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(soundDirectory) || !Directory.Exists(soundDirectory))
                    return null;

                string path = Path.Combine(soundDirectory, fileName);
                if (File.Exists(path))
                {
                    SoundPlayer sp = new SoundPlayer(path);
                    sp.LoadAsync();
                    return sp;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        private static void PlayMci(string alias, SoundPlayer fallbackPlayer, bool isLoop = false)
        {
            if (IsMuted || !HasSoundsAvailable) return;

            try
            {
                if (isMciAvailable)
                {
                    if (isLoop)
                    {
                        mciSendString($"play {alias} repeat", null, 0, IntPtr.Zero);
                    }
                    else
                    {
                        mciSendString($"play {alias} from 0", null, 0, IntPtr.Zero);
                    }
                    return;
                }
            }
            catch { }

            try
            {
                if (isLoop)
                {
                    fallbackPlayer?.PlayLooping();
                }
                else
                {
                    fallbackPlayer?.Play();
                }
            }
            catch { }
        }

        public static void PlayFlip()
        {
            PlayMci(ALIAS_FLIP, flipPlayer);
        }

        public static void PlayCorrect()
        {
        }

        public static void PlayWrong()
        {
            PlayMci(ALIAS_WRONG, wrongPlayer);
        }

        public static void PlayVictory()
        {
            if (IsMuted || !HasSoundsAvailable) return;
            try
            {
                PauseBgm();
                PlayMci(ALIAS_VICTORY, victoryPlayer);
            }
            catch { }
        }

        public static void PlayGameOver()
        {
            if (IsMuted || !HasSoundsAvailable) return;
            try
            {
                PauseBgm();
                PlayMci(ALIAS_GAMEOVER, gameOverPlayer);
            }
            catch { }
        }

        public static void PlayBgm()
        {
            if (IsMuted || !HasSoundsAvailable) return;
            try
            {
                isBgmPlaying = true;
                PlayMci(ALIAS_BGM, bgmPlayer, isLoop: true);
            }
            catch { }
        }

        public static void StopBgm()
        {
            try
            {
                isBgmPlaying = false;
                if (isMciAvailable)
                {
                    mciSendString($"stop {ALIAS_BGM}", null, 0, IntPtr.Zero);
                }
                bgmPlayer?.Stop();
            }
            catch { }
        }

        private static void PauseBgm()
        {
            try
            {
                if (isMciAvailable)
                {
                    mciSendString($"pause {ALIAS_BGM}", null, 0, IntPtr.Zero);
                }
                else
                {
                    bgmPlayer?.Stop();
                }
            }
            catch { }
        }

        public static void ResumeBgm()
        {
            if (IsMuted || !HasSoundsAvailable) return;
            try
            {
                if (isBgmPlaying)
                {
                    PlayBgm();
                }
            }
            catch { }
        }

        public static bool ToggleMute()
        {
            IsMuted = !IsMuted;
            if (IsMuted)
            {
                StopBgm();
            }
            else
            {
                PlayBgm();
            }
            return IsMuted;
        }

        public static void CloseAll()
        {
            try
            {
                StopBgm();
                mciSendString($"close {ALIAS_BGM}", null, 0, IntPtr.Zero);
                mciSendString($"close {ALIAS_FLIP}", null, 0, IntPtr.Zero);
                mciSendString($"close {ALIAS_WRONG}", null, 0, IntPtr.Zero);
                mciSendString($"close {ALIAS_VICTORY}", null, 0, IntPtr.Zero);
                mciSendString($"close {ALIAS_GAMEOVER}", null, 0, IntPtr.Zero);
            }
            catch { }
        }
    }
}
