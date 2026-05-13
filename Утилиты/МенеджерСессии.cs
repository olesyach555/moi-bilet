using System;
using System.Security.Cryptography;
using System.Text;

namespace УниверсальноеПриложение.Утилиты
{
    public static class МенеджерСессии
    {
        public static int ТекущийПользовательИД { get; set; }
        public static string ТекущийЛогин { get; set; }

        public static string ХешироватьПароль(string пароль)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(пароль));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
