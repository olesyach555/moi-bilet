namespace УниверсальноеПриложение.Формы
{
    partial class ФормаОбъекта
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.меткаНаименование = new System.Windows.Forms.Label();
            this.полеНаименование = new System.Windows.Forms.TextBox();
            this.меткаОписание = new System.Windows.Forms.Label();
            this.полеОписание = new System.Windows.Forms.TextBox();
            this.меткаСтатус = new System.Windows.Forms.Label();
            this.полеСтатус = new System.Windows.Forms.ComboBox();
            this.меткаПримечания = new System.Windows.Forms.Label();
            this.полеПримечания = new System.Windows.Forms.TextBox();
            this.кнопкаСохранить = new System.Windows.Forms.Button();
            this.кнопкаОтмена = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // меткаНаименование
            //
            this.меткаНаименование.AutoSize = true;
            this.меткаНаименование.Location = new System.Drawing.Point(13, 13);
            this.меткаНаименование.Name = "меткаНаименование";
            this.меткаНаименование.Size = new System.Drawing.Size(83, 13);
            this.меткаНаименование.TabIndex = 0;
            this.меткаНаименование.Text = "Наименование";
            //
            // полеНаименование
            //
            this.полеНаименование.Location = new System.Drawing.Point(16, 30);
            this.полеНаименование.Name = "полеНаименование";
            this.полеНаименование.Size = new System.Drawing.Size(350, 20);
            this.полеНаименование.TabIndex = 1;
            //
            // меткаОписание
            //
            this.меткаОписание.AutoSize = true;
            this.меткаОписание.Location = new System.Drawing.Point(13, 60);
            this.меткаОписание.Name = "меткаОписание";
            this.меткаОписание.Size = new System.Drawing.Size(57, 13);
            this.меткаОписание.TabIndex = 2;
            this.меткаОписание.Text = "Описание";
            //
            // полеОписание
            //
            this.полеОписание.Location = new System.Drawing.Point(16, 77);
            this.полеОписание.Multiline = true;
            this.полеОписание.Name = "полеОписание";
            this.полеОписание.Size = new System.Drawing.Size(350, 80);
            this.полеОписание.TabIndex = 3;
            //
            // меткаСтатус
            //
            this.меткаСтатус.AutoSize = true;
            this.меткаСтатус.Location = new System.Drawing.Point(13, 170);
            this.меткаСтатус.Name = "меткаСтатус";
            this.меткаСтатус.Size = new System.Drawing.Size(41, 13);
            this.меткаСтатус.TabIndex = 4;
            this.меткаСтатус.Text = "Статус";
            //
            // полеСтатус
            //
            this.полеСтатус.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.полеСтатус.FormattingEnabled = true;
            this.полеСтатус.Items.AddRange(new object[] {
            "Активно",
            "Архив",
            "Ожидание",
            "Заблокировано"});
            this.полеСтатус.Location = new System.Drawing.Point(16, 187);
            this.полеСтатус.Name = "полеСтатус";
            this.полеСтатус.Size = new System.Drawing.Size(150, 21);
            this.полеСтатус.TabIndex = 5;
            //
            // меткаПримечания
            //
            this.меткаПримечания.AutoSize = true;
            this.меткаПримечания.Location = new System.Drawing.Point(13, 220);
            this.меткаПримечания.Name = "меткаПримечания";
            this.меткаПримечания.Size = new System.Drawing.Size(70, 13);
            this.меткаПримечания.TabIndex = 6;
            this.меткаПримечания.Text = "Примечания";
            //
            // полеПримечания
            //
            this.полеПримечания.Location = new System.Drawing.Point(16, 237);
            this.полеПримечания.Multiline = true;
            this.полеПримечания.Name = "полеПримечания";
            this.полеПримечания.Size = new System.Drawing.Size(350, 60);
            this.полеПримечания.TabIndex = 7;
            //
            // кнопкаСохранить
            //
            this.кнопкаСохранить.Location = new System.Drawing.Point(190, 310);
            this.кнопкаСохранить.Name = "кнопкаСохранить";
            this.кнопкаСохранить.Size = new System.Drawing.Size(85, 25);
            this.кнопкаСохранить.TabIndex = 8;
            this.кнопкаСохранить.Text = "Сохранить";
            this.кнопкаСохранить.UseVisualStyleBackColor = true;
            this.кнопкаСохранить.Click += new System.EventHandler(this.кнопкаСохранить_Click);
            //
            // кнопкаОтмена
            //
            this.кнопкаОтмена.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.кнопкаОтмена.Location = new System.Drawing.Point(281, 310);
            this.кнопкаОтмена.Name = "кнопкаОтмена";
            this.кнопкаОтмена.Size = new System.Drawing.Size(85, 25);
            this.кнопкаОтмена.TabIndex = 9;
            this.кнопкаОтмена.Text = "Отмена";
            this.кнопкаОтмена.UseVisualStyleBackColor = true;
            this.кнопкаОтмена.Click += new System.EventHandler(this.кнопкаОтмена_Click);
            //
            // ФормаОбъекта
            //
            this.AcceptButton = this.кнопкаСохранить;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.кнопкаОтмена;
            this.ClientSize = new System.Drawing.Size(384, 346);
            this.Controls.Add(this.кнопкаОтмена);
            this.Controls.Add(this.кнопкаСохранить);
            this.Controls.Add(this.полеПримечания);
            this.Controls.Add(this.меткаПримечания);
            this.Controls.Add(this.полеСтатус);
            this.Controls.Add(this.меткаСтатус);
            this.Controls.Add(this.полеОписание);
            this.Controls.Add(this.меткаОписание);
            this.Controls.Add(this.полеНаименование);
            this.Controls.Add(this.меткаНаименование);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ФормаОбъекта";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ФормаОбъекта";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label меткаНаименование;
        private System.Windows.Forms.TextBox полеНаименование;
        private System.Windows.Forms.Label меткаОписание;
        private System.Windows.Forms.TextBox полеОписание;
        private System.Windows.Forms.Label меткаСтатус;
        private System.Windows.Forms.ComboBox полеСтатус;
        private System.Windows.Forms.Label меткаПримечания;
        private System.Windows.Forms.TextBox полеПримечания;
        private System.Windows.Forms.Button кнопкаСохранить;
        private System.Windows.Forms.Button кнопкаОтмена;
    }
}
