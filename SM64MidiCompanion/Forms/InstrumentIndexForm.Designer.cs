
namespace SM64MidiCompanion.Forms
{
    partial class InstrumentIndexForm
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
            this.instrumentBankLabel = new System.Windows.Forms.Label();
            this.instrumentIdTextBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.instrumentComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentIdTextBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // instrumentBankLabel
            // 
            this.instrumentBankLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.instrumentBankLabel.AutoSize = true;
            this.instrumentBankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.instrumentBankLabel.Location = new System.Drawing.Point(31, 187);
            this.instrumentBankLabel.Name = "instrumentBankLabel";
            this.instrumentBankLabel.Size = new System.Drawing.Size(228, 26);
            this.instrumentBankLabel.TabIndex = 1;
            this.instrumentBankLabel.Text = "Instrument From Bank";
            // 
            // instrumentIdTextBox
            // 
            this.instrumentIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.instrumentIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.instrumentIdTextBox.Location = new System.Drawing.Point(115, 46);
            this.instrumentIdTextBox.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.instrumentIdTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.instrumentIdTextBox.Name = "instrumentIdTextBox";
            this.instrumentIdTextBox.Size = new System.Drawing.Size(61, 32);
            this.instrumentIdTextBox.TabIndex = 2;
            this.instrumentIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.instrumentIdTextBox.ValueChanged += new System.EventHandler(this.instrumentIdTextBox_ValueChanged);
            this.instrumentIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.instrumentIdTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(88, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "------or------";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(74, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Instrument ID";
            // 
            // instrumentComboBox
            // 
            this.instrumentComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.instrumentComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.instrumentComboBox.FormattingEnabled = true;
            this.instrumentComboBox.Location = new System.Drawing.Point(27, 235);
            this.instrumentComboBox.Name = "instrumentComboBox";
            this.instrumentComboBox.Size = new System.Drawing.Size(236, 33);
            this.instrumentComboBox.TabIndex = 4;
            this.instrumentComboBox.SelectedIndexChanged += new System.EventHandler(this.instrumentComboBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.instrumentComboBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.instrumentBankLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.instrumentIdTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.errorLabel, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.07421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.0212F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.15548F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.19435F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.20141F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(291, 305);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(78, 283);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(135, 20);
            this.errorLabel.TabIndex = 1;
            this.errorLabel.Text = "Error Shows Here";
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.confirmButton.Location = new System.Drawing.Point(160, 328);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(143, 75);
            this.confirmButton.TabIndex = 6;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.cancelButton.Location = new System.Drawing.Point(12, 328);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(143, 75);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // InstrumentIndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 411);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InstrumentIndexForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstrumentIndexForm";
            ((System.ComponentModel.ISupportInitialize)(this.instrumentIdTextBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label instrumentBankLabel;
        private System.Windows.Forms.NumericUpDown instrumentIdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox instrumentComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
    }
}