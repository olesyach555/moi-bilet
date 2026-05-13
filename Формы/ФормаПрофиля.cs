using System;
using System.Drawing;
using System.Windows.Forms;
using УниверсальноеПриложение.Сервисы;
using УниверсальноеПриложение.Утилиты;
using System.Data;

namespace УниверсальноеПриложение.Формы
{
    public class ФормаПрофиля : Form
    {
        private TextBox txtПочта;
        private TextBox txtТекущийПароль;
        private TextBox txtНовыйПароль;
        private TextBox txtПовторитеПароль;
        private Button btnСохранить;

        private readonly ДоступКДанным.ДоступКДанным доступКДанным;
        private readonly IEmailVerificationService emailService;

        public ФормаПрофиля()
        {
            доступКДанным = new ДоступКДанным.ДоступКДанным();
            emailService = new EmailVerificationService();
            InitializeComponent();
            ЗагрузитьДанные();
        }

        private void InitializeComponent()
        {
            this.txtПочта = new TextBox();
            this.txtТекущийПароль = new TextBox();
            this.txtНовыйПароль = new TextBox();
            this.txtПовторитеПароль = new TextBox();
            this.btnСохранить = new Button();

            this.SuspendLayout();

            int top = 30;
            AddLabelAndControl("Почта:", txtПочта, ref top);
            txtПочта.ReadOnly = true;
            top += 20;

            AddLabelAndControl("Текущий пароль:", txtТекущийПароль, ref top);
            txtТекущийПароль.PasswordChar = '*';
            AddLabelAndControl("Новый пароль:", txtНовыйПароль, ref top);
            txtНовыйПароль.PasswordChar = '*';
            AddLabelAndControl("Повторите пароль:", txtПовторитеПароль, ref top);
            txtПовторитеПароль.PasswordChar = '*';

            btnСохранить.Text = "Сохранить изменения";
            btnСохранить.BackColor = Color.FromArgb(32, 149, 163);
            btnСохранить.ForeColor = Color.White;
            btnСохранить.Location = new Point(20, top);
            btnСохранить.Size = new Size(180, 35);
            btnСохранить.Click += btnСохранить_Click;
            this.Controls.Add(btnСохранить);

            this.Text = "Мой профиль";
            this.Size = new Size(400, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private void AddLabelAndControl(string text, Control control, ref int top)
        {
            Label lbl = new Label { Text = text, Location = new Point(20, top), Size = new Size(120, 20) };
            control.Location = new Point(150, top);
            control.Size = new Size(200, 25);
            this.Controls.Add(lbl);
            this.Controls.Add(control);
            top += 40;
        }

        private void ЗагрузитьДанные()
        {
            DataTable dt = доступКДанным.ПолучитьПользователяПоИД(МенеджерСессии.ТекущийПользовательИД);
            if (dt.Rows.Count > 0)
            {
                txtПочта.Text = dt.Rows[0]["Почта"].ToString();
            }
        }

        private async void btnСохранить_Click(object sender, EventArgs e)
        {
            if (txtНовыйПароль.Text != txtПовторитеПароль.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            DataTable dt = доступКДанным.ПолучитьПользователяПоИД(МенеджерСессии.ТекущийПользовательИД);
            string storedHash = dt.Rows[0]["ПарольХэш"].ToString();
            if (МенеджерСессии.ХешироватьПароль(txtТекущийПароль.Text) != storedHash)
            {
                MessageBox.Show("Неверный текущий пароль");
                return;
            }

            try
            {
                string code = emailService.GenerateCode();
                await emailService.SendVerificationCodeAsync(txtПочта.Text, code);

                string enteredCode = Microsoft.VisualBasic.Interaction.InputBox("Введите 5-значный код, отправленный на " + txtПочта.Text, "Подтверждение");

                if (emailService.VerifyCode(txtПочта.Text, enteredCode))
                {
                    доступКДанным.ОбновитьПароль(МенеджерСессии.ТекущийПользовательИД, МенеджерСессии.ХешироватьПароль(txtНовыйПароль.Text));
                    emailService.RemoveCode(txtПочта.Text);
                    MessageBox.Show("Пароль успешно изменен");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный код");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
