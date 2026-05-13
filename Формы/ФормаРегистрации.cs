using System;
using System.Drawing;
using System.Windows.Forms;
using УниверсальноеПриложение.Сервисы;
using УниверсальноеПриложение.Утилиты;

namespace УниверсальноеПриложение.Формы
{
    public class ФормаРегистрации : Form
    {
        private TextBox txtЛогин;
        private TextBox txtПароль;
        private TextBox txtПочта;
        private TextBox txtКод;
        private Button btnОтправитьКод;
        private Button btnЗарегистрироваться;
        private Label lblКод;
        private Panel pnlКод;

        private readonly ДоступКДанным.ДоступКДанным доступКДанным;
        private readonly IEmailVerificationService emailService;

        public ФормаРегистрации()
        {
            доступКДанным = new ДоступКДанным.ДоступКДанным();
            emailService = new EmailVerificationService();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtЛогин = new TextBox();
            this.txtПароль = new TextBox();
            this.txtПочта = new TextBox();
            this.txtКод = new TextBox();
            this.btnОтправитьКод = new Button();
            this.btnЗарегистрироваться = new Button();
            this.pnlКод = new Panel();
            this.lblКод = new Label();

            this.SuspendLayout();

            int top = 20;
            AddLabelAndControl("Логин:", txtЛогин, ref top);
            AddLabelAndControl("Пароль:", txtПароль, ref top);
            txtПароль.PasswordChar = '*';
            AddLabelAndControl("Email:", txtПочта, ref top);

            btnОтправитьКод.Text = "Отправить код";
            btnОтправитьКод.Location = new Point(120, top);
            btnОтправитьКод.Size = new Size(150, 30);
            btnОтправитьКод.Click += btnОтправитьКод_Click;
            this.Controls.Add(btnОтправитьКод);
            top += 40;

            pnlКод.Location = new Point(10, top);
            pnlКод.Size = new Size(300, 70);
            pnlКод.Visible = false;

            lblКод.Text = "Введите код из письма:";
            lblКод.Location = new Point(0, 0);
            lblКод.Size = new Size(200, 20);
            pnlКод.Controls.Add(lblКод);

            txtКод.Location = new Point(0, 25);
            txtКод.Size = new Size(260, 25);
            pnlКод.Controls.Add(txtКод);
            this.Controls.Add(pnlКод);

            btnЗарегистрироваться.Text = "Зарегистрироваться";
            btnЗарегистрироваться.Location = new Point(120, top + 80);
            btnЗарегистрироваться.Size = new Size(150, 30);
            btnЗарегистрироваться.Enabled = false;
            btnЗарегистрироваться.Click += btnЗарегистрироваться_Click;
            this.Controls.Add(btnЗарегистрироваться);

            this.Text = "Регистрация";
            this.Size = new Size(350, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private void AddLabelAndControl(string text, Control control, ref int top)
        {
            Label lbl = new Label { Text = text, Location = new Point(10, top), Size = new Size(100, 20) };
            control.Location = new Point(120, top);
            control.Size = new Size(180, 25);
            this.Controls.Add(lbl);
            this.Controls.Add(control);
            top += 35;
        }

        private async void btnОтправитьКод_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtПочта.Text))
            {
                MessageBox.Show("Введите Email");
                return;
            }

            try
            {
                btnОтправитьКод.Enabled = false;
                string code = emailService.GenerateCode();
                await emailService.SendVerificationCodeAsync(txtПочта.Text, code);
                pnlКод.Visible = true;
                btnЗарегистрироваться.Enabled = true;
                MessageBox.Show("Код отправлен на вашу почту");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отправке почты: " + ex.Message);
                btnОтправитьКод.Enabled = true;
            }
        }

        private void btnЗарегистрироваться_Click(object sender, EventArgs e)
        {
            if (emailService.VerifyCode(txtПочта.Text, txtКод.Text))
            {
                try
                {
                    string hash = МенеджерСессии.ХешироватьПароль(txtПароль.Text);
                    доступКДанным.СоздатьПользователя(txtЛогин.Text, hash, txtПочта.Text);
                    emailService.RemoveCode(txtПочта.Text);
                    MessageBox.Show("Регистрация успешна!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка регистрации: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Неверный код подтверждения");
            }
        }
    }
}
