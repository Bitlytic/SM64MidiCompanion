using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SM64MidiCompanion.Forms
{
    public partial class ChannelIndexForm : Form
    {
        public int channelId = 0;

        public ChannelIndexForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;

            channelIdTextBox.Focus();
            channelIdTextBox.Select(0, 100);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            ConfirmDialog();
        }

        private void ConfirmDialog()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelDialog();
        }

        private void CancelDialog()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void channelIdTextBox_ValueChanged(object sender, EventArgs e)
        {
            channelId = (int)channelIdTextBox.Value;
        }

        private void UpdateTextBox()
        {
            channelIdTextBox.ValueChanged -= channelIdTextBox_ValueChanged;
            channelIdTextBox.Value = channelId;
            channelIdTextBox.ValueChanged += channelIdTextBox_ValueChanged;
        }

        public void SetChannelId(int channelId)
        {
            this.channelId = channelId;
            UpdateTextBox();
        }

        private void channelIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmDialog();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                CancelDialog();
            }
        }
    }
}
