namespace crmguruapp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ShowCountryButton = new System.Windows.Forms.Button();
            this.CountryListBox = new System.Windows.Forms.ListBox();
            this.getCountryFromBDbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowCountryButton
            // 
            this.ShowCountryButton.Location = new System.Drawing.Point(12, 348);
            this.ShowCountryButton.Name = "ShowCountryButton";
            this.ShowCountryButton.Size = new System.Drawing.Size(138, 31);
            this.ShowCountryButton.TabIndex = 0;
            this.ShowCountryButton.Text = "Поиск страны";
            this.ShowCountryButton.UseVisualStyleBackColor = true;
            this.ShowCountryButton.Click += new System.EventHandler(this.ShowCountryButton_Click);
            // 
            // CountryListBox
            // 
            this.CountryListBox.FormattingEnabled = true;
            this.CountryListBox.ItemHeight = 16;
            this.CountryListBox.Location = new System.Drawing.Point(-1, 2);
            this.CountryListBox.Name = "CountryListBox";
            this.CountryListBox.Size = new System.Drawing.Size(997, 340);
            this.CountryListBox.TabIndex = 1;
            // 
            // getCountryFromBDbutton
            // 
            this.getCountryFromBDbutton.Location = new System.Drawing.Point(170, 348);
            this.getCountryFromBDbutton.Name = "getCountryFromBDbutton";
            this.getCountryFromBDbutton.Size = new System.Drawing.Size(201, 31);
            this.getCountryFromBDbutton.TabIndex = 2;
            this.getCountryFromBDbutton.Text = "Список стран из БД";
            this.getCountryFromBDbutton.UseVisualStyleBackColor = true;
            this.getCountryFromBDbutton.Click += new System.EventHandler(this.getCountryFromBDbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 450);
            this.Controls.Add(this.getCountryFromBDbutton);
            this.Controls.Add(this.CountryListBox);
            this.Controls.Add(this.ShowCountryButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowCountryButton;
        private System.Windows.Forms.ListBox CountryListBox;
        private System.Windows.Forms.Button getCountryFromBDbutton;
    }
}

