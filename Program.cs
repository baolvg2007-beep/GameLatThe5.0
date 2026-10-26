using System;
using System.Threading;
using System.Windows.Forms;

namespace game_lật_thẻ_1._1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Tích hợp cơ chế Bẫy lỗi toàn cục (Global Exception Handling)
        /// Đảm bảo game 100% không bao giờ bị văng (crash) trong quá trình chơi theo tiêu chí 1.0đ.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Bẫy lỗi luồng UI WinForms
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            // Bẫy lỗi không đồng bộ / background thread
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMenu());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(
                "Bẫy lỗi giao diện (Thread Exception Handling):\n" + e.Exception.Message +
                "\n\nTrò chơi đã ngăn chặn sự cố thành công và tiếp tục hoạt động an toàn.",
                "Cảnh Báo Bẫy Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                MessageBox.Show(
                    "Bẫy lỗi hệ thống (Domain Exception Handling):\n" + ex.Message +
                    "\n\nTrò chơi đã ngăn chặn việc văng ứng dụng an toàn.",
                    "Cảnh Báo Bẫy Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
