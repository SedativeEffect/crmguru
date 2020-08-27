namespace crmguruapp
{
    partial class CountryInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CountryNameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchCountryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CountryNameField
            // 
            this.CountryNameField.Location = new System.Drawing.Point(31, 57);
            this.CountryNameField.Name = "CountryNameField";
            this.CountryNameField.Size = new System.Drawing.Size(178, 22);
            this.CountryNameField.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите название страны";
            // 
            // SearchCountryButton
            // 
            this.SearchCountryButton.Location = new System.Drawing.Point(68, 118);
            this.SearchCountryButton.Name = "SearchCountryButton";
            this.SearchCountryButton.Size = new System.Drawing.Size(75, 23);
            this.SearchCountryButton.TabIndex = 2;
            this.SearchCountryButton.Text = "Поиск";
            this.SearchCountryButton.UseVisualStyleBackColor = true;
            this.SearchCountryButton.Click += new System.EventHandler(this.SearchCountryButton_Click);
            // 
            // CountryInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SearchCountryButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CountryNameField);
            this.Name = "CountryInfoForm";
            this.Text = "CountryInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CountryNameField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SearchCountryButton;
    }
}