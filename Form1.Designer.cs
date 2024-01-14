namespace IPCulc
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            IpAddressTextBox = new TextBox();
            CalculateButton = new Button();
            MaskTextBox = new TextBox();
            ResultTextBox = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // IpAddressTextBox
            // 
            IpAddressTextBox.BackColor = SystemColors.Info;
            IpAddressTextBox.Location = new Point(144, 14);
            IpAddressTextBox.Name = "IpAddressTextBox";
            IpAddressTextBox.Size = new Size(176, 27);
            IpAddressTextBox.TabIndex = 0;
            // 
            // CalculateButton
            // 
            CalculateButton.BackColor = Color.Moccasin;
            CalculateButton.Location = new Point(227, 85);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(94, 29);
            CalculateButton.TabIndex = 1;
            CalculateButton.Text = "Рассчитать";
            CalculateButton.UseVisualStyleBackColor = false;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // MaskTextBox
            // 
            MaskTextBox.BackColor = SystemColors.Info;
            MaskTextBox.Location = new Point(144, 47);
            MaskTextBox.Name = "MaskTextBox";
            MaskTextBox.Size = new Size(176, 27);
            MaskTextBox.TabIndex = 2;
            // 
            // ResultTextBox
            // 
            ResultTextBox.BackColor = Color.PapayaWhip;
            ResultTextBox.Location = new Point(12, 120);
            ResultTextBox.Name = "ResultTextBox";
            ResultTextBox.Size = new Size(309, 165);
            ResultTextBox.TabIndex = 3;
            ResultTextBox.Text = "";
            ResultTextBox.TextChanged += ResultTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(255, 224, 192);
            label1.Location = new Point(21, 17);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 4;
            label1.Text = "Введите IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(255, 224, 192);
            label2.Location = new Point(21, 48);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 5;
            label2.Text = "Введите маску:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(332, 297);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ResultTextBox);
            Controls.Add(MaskTextBox);
            Controls.Add(CalculateButton);
            Controls.Add(IpAddressTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Расчет IP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox IpAddressTextBox;
        private Button CalculateButton;
        private TextBox MaskTextBox;
        private RichTextBox ResultTextBox;
        private Label label1;
        private Label label2;
    }
}