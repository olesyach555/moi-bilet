namespace УниверсальноеПриложение.Формы
{
    partial class ГлавнаяФорма
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
            this.таблицаДанных = new System.Windows.Forms.DataGridView();
            this.кнопкаДобавить = new System.Windows.Forms.Button();
            this.кнопкаИзменить = new System.Windows.Forms.Button();
            this.кнопкаУдалить = new System.Windows.Forms.Button();
            this.меню = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.строкаСостояния = new System.Windows.Forms.StatusStrip();
            this.статусТекст = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.таблицаДанных)).BeginInit();
            this.меню.SuspendLayout();
            this.строкаСостояния.SuspendLayout();
            this.SuspendLayout();
            //
            // таблицаДанных
            //
            this.таблицаДанных.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.таблицаДанных.Location = new System.Drawing.Point(12, 70);
            this.таблицаДанных.Name = "таблицаДанных";
            this.таблицаДанных.Size = new System.Drawing.Size(760, 350);
            this.таблицаДанных.TabIndex = 0;
            this.таблицаДанных.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.таблицаДанных.ReadOnly = true;
            this.таблицаДанных.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //
            // кнопкаДобавить
            //
            this.кнопкаДобавить.Location = new System.Drawing.Point(12, 30);
            this.кнопкаДобавить.Name = "кнопкаДобавить";
            this.кнопкаДобавить.Size = new System.Drawing.Size(100, 30);
            this.кнопкаДобавить.TabIndex = 1;
            this.кнопкаДобавить.Text = "Добавить";
            this.кнопкаДобавить.UseVisualStyleBackColor = true;
            this.кнопкаДобавить.Click += new System.EventHandler(this.кнопкаДобавить_Click);
            //
            // кнопкаИзменить
            //
            this.кнопкаИзменить.Location = new System.Drawing.Point(120, 30);
            this.кнопкаИзменить.Name = "кнопкаИзменить";
            this.кнопкаИзменить.Size = new System.Drawing.Size(100, 30);
            this.кнопкаИзменить.TabIndex = 2;
            this.кнопкаИзменить.Text = "Изменить";
            this.кнопкаИзменить.UseVisualStyleBackColor = true;
            this.кнопкаИзменить.Click += new System.EventHandler(this.кнопкаИзменить_Click);
            //
            // кнопкаУдалить
            //
            this.кнопкаУдалить.Location = new System.Drawing.Point(230, 30);
            this.кнопкаУдалить.Name = "кнопкаУдалить";
            this.кнопкаУдалить.Size = new System.Drawing.Size(100, 30);
            this.кнопкаУдалить.TabIndex = 3;
            this.кнопкаУдалить.Text = "Удалить";
            this.кнопкаУдалить.UseVisualStyleBackColor = true;
            this.кнопкаУдалить.Click += new System.EventHandler(this.кнопкаУдалить_Click);
            //
            // меню
            //
            this.меню.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.меню.Location = new System.Drawing.Point(0, 0);
            this.меню.Name = "меню";
            this.меню.Size = new System.Drawing.Size(784, 24);
            this.меню.TabIndex = 4;
            this.меню.Text = "menuStrip1";
            //
            // файлToolStripMenuItem
            //
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            //
            // выходToolStripMenuItem
            //
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += (s, e) => { System.Windows.Forms.Application.Exit(); };
            //
            // справкаToolStripMenuItem
            //
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            //
            // оПрограммеToolStripMenuItem
            //
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе...";
            //
            // строкаСостояния
            //
            this.строкаСостояния.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.статусТекст});
            this.строкаСостояния.Location = new System.Drawing.Point(0, 428);
            this.строкаСостояния.Name = "строкаСостояния";
            this.строкаСостояния.Size = new System.Drawing.Size(784, 22);
            this.строкаСостояния.TabIndex = 5;
            this.строкаСостояния.Text = "statusStrip1";
            //
            // статусТекст
            //
            this.статусТекст.Name = "статусТекст";
            this.статусТекст.Size = new System.Drawing.Size(118, 17);
            this.статусТекст.Text = "Готово";
            //
            // ГлавнаяФорма
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.строкаСостояния);
            this.Controls.Add(this.меню);
            this.Controls.Add(this.кнопкаУдалить);
            this.Controls.Add(this.кнопкаИзменить);
            this.Controls.Add(this.кнопкаДобавить);
            this.Controls.Add(this.таблицаДанных);
            this.MainMenuStrip = this.меню;
            this.Name = "ГлавнаяФорма";
            this.Text = "Универсальное приложение";
            ((System.ComponentModel.ISupportInitialize)(this.таблицаДанных)).EndInit();
            this.меню.ResumeLayout(false);
            this.меню.PerformLayout();
            this.строкаСостояния.ResumeLayout(false);
            this.строкаСостояния.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView таблицаДанных;
        private System.Windows.Forms.Button кнопкаДобавить;
        private System.Windows.Forms.Button кнопкаИзменить;
        private System.Windows.Forms.Button кнопкаУдалить;
        private System.Windows.Forms.MenuStrip меню;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.StatusStrip строкаСостояния;
        private System.Windows.Forms.ToolStripStatusLabel статусТекст;
    }
}
