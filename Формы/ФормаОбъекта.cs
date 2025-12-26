using System;
using System.Data;
using System.Windows.Forms;
using УниверсальноеПриложение.ДоступКДанным;

namespace УниверсальноеПриложение.Формы
{
    public partial class ФормаОбъекта : Form
    {
        private ДоступКДанным.ДоступКДанным доступКДанным;
        private int? объектИД;

        // Конструктор для добавления нового объекта
        public ФормаОбъекта()
        {
            InitializeComponent();
            доступКДанным = new ДоступКДанным.ДоступКДанным();
            объектИД = null;
            this.Text = "Новый объект";
        }

        // Конструктор для редактирования существующего объекта
        public ФормаОбъекта(int id)
        {
            InitializeComponent();
            доступКДанным = new ДоступКДанным.ДоступКДанным();
            объектИД = id;
            this.Text = "Редактирование объекта";
            ЗагрузитьДанныеОбъекта();
        }

        private void ЗагрузитьДанныеОбъекта()
        {
            try
            {
                if (объектИД.HasValue)
                {
                    DataTable таблица = доступКДанным.ПолучитьОбъектПоИД(объектИД.Value);
                    if (таблица.Rows.Count > 0)
                    {
                        DataRow ряд = таблица.Rows[0];
                        полеНаименование.Text = ряд["Наименование"].ToString();
                        полеОписание.Text = ряд["Описание"].ToString();
                        полеСтатус.Text = ряд["Статус"].ToString();
                        полеПримечания.Text = ряд["Примечания"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных объекта: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void кнопкаСохранить_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(полеНаименование.Text))
                {
                    MessageBox.Show("Поле 'Наименование' обязательно для заполнения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (объектИД.HasValue)
                {
                    // Обновление
                    доступКДанным.ОбновитьОбъект(объектИД.Value, полеНаименование.Text, полеОписание.Text, полеСтатус.Text, полеПримечания.Text);
                }
                else
                {
                    // Вставка
                    доступКДанным.ВставитьОбъект(полеНаименование.Text, полеОписание.Text, полеСтатус.Text, полеПримечания.Text);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void кнопкаОтмена_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
