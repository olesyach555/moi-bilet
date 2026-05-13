using System;
using System.Drawing;
using System.Windows.Forms;
using УниверсальноеПриложение.Утилиты;
using System.Data;

namespace УниверсальноеПриложение.Формы
{
    public class ФормаВхода : Form
    {
        private TextBox txtЛогин;
        private TextBox txtПароль;
        private Button btnВойти;
        private Button btnРегистрация;
        private readonly ДоступКДанным.ДоступКДанным доступКДанным;

        public ФормаВхода()
        {
            доступКДанным = new ДоступКДанным.ДоступКДанным();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtЛогин = new TextBox();
            this.txtПароль = new TextBox();
            this.btnВойти = new Button();
            this.btnРегистрация = new Button();
            this.SuspendLayout();

            int top = 30;
            Label lblL = new Label { Text = "Логин:", Location = new Point(20, top), Size = new Size(80, 20) };
            txtЛогин.Location = new Point(110, top);
            txtЛогин.Size = new Size(150, 25);
            top += 40;

            Label lblP = new Label { Text = "Пароль:", Location = new Point(20, top), Size = new Size(80, 20) };
            txtПароль.Location = new Point(110, top);
            txtПароль.Size = new Size(150, 25);
            txtПароль.PasswordChar = '*';
            top += 50;

            btnВойти.Text = "Войти";
            btnВойти.Location = new Point(110, top);
            btnВойти.Size = new Size(150, 30);
            btnВойти.Click += btnВойти_Click;

            btnРегистрация.Text = "Регистрация";
            btnРегистрация.Location = new Point(110, top + 40);
            btnРегистрация.Size = new Size(150, 30);
            btnРегистрация.Click += btnРегистрация_Click;

            this.Controls.AddRange(new Control[] { lblL, txtЛогин, lblP, txtПароль, btnВойти, btnРегистрация });
            this.Text = "Авторизация";
            this.Size = new Size(300, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private void btnВойти_Click(object sender, EventArgs e)
        {
            DataTable dt = доступКДанным.ПолучитьПользователяПоЛогину(txtЛогин.Text);
            if (dt.Rows.Count > 0)
            {
                string storedHash = dt.Rows[0]["ПарольХэш"].ToString();
                string enteredHash = МенеджерСессии.ХешироватьПароль(txtПароль.Text);
                if (storedHash == enteredHash)
                {
                    МенеджерСессии.ТекущийПользовательИД = (int)dt.Rows[0]["ИДентификатор"];
                    МенеджерСессии.ТекущийЛогин = dt.Rows[0]["Логин"].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void btnРегистрация_Click(object sender, EventArgs e)
        {
            using (var form = new ФормаРегистрации())
            {
                form.ShowDialog();
            }
        }
    }
}
