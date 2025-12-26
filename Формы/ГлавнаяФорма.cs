using System;
using System.Windows.Forms;
using УниверсальноеПриложение.ДоступКДанным;

namespace УниверсальноеПриложение.Формы
{
    public partial class ГлавнаяФорма : Form
    {
        private ДоступКДанным.ДоступКДанным доступКДанным;

        public ГлавнаяФорма()
        {
            InitializeComponent();
            доступКДанным = new ДоступКДанным.ДоступКДанным();
            ЗагрузитьДанные();
        }

        private void ЗагрузитьДанные()
        {
            try
            {
                таблицаДанных.DataSource = доступКДанным.ПолучитьВсеОбъекты();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void кнопкаДобавить_Click(object sender, EventArgs e)
        {
            using (ФормаОбъекта форма = new ФормаОбъекта())
            {
                if (форма.ShowDialog() == DialogResult.OK)
                {
                    ЗагрузитьДанные();
                }
            }
        }

        private void кнопкаИзменить_Click(object sender, EventArgs e)
        {
            if (таблицаДанных.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(таблицаДанных.SelectedRows[0].Cells["ИДентификатор"].Value);
                using (ФормаОбъекта форма = new ФормаОбъекта(id))
                {
                    if (форма.ShowDialog() == DialogResult.OK)
                    {
                        ЗагрузитьДанные();
                    }
                }
            }
        }

        private void кнопкаУдалить_Click(object sender, EventArgs e)
        {
            if (таблицаДанных.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить выбранный объект?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(таблицаДанных.SelectedRows[0].Cells["ИДентификатор"].Value);
                        доступКДанным.УдалитьОбъект(id);
                        ЗагрузитьДанные();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
