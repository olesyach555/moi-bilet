using System;
using System.Windows.Forms;

namespace УниверсальноеПриложение
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new Формы.ФормаВхода())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Формы.ГлавнаяФорма());
                }
            }
        }
    }
}
