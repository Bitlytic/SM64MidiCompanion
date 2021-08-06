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
    public partial class PitchShiftForm : Form
    {
        public int pitchShift = 0;

        public PitchShiftForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;

            pitchShiftTextBox.Focus();
            pitchShiftTextBox.Select(0, 100);
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

        private void pitchShiftTextBox_ValueChanged(object sender, EventArgs e)
        {
            pitchShift = (int)pitchShiftTextBox.Value;
        }

        private void UpdateTextBox()
        {
            pitchShiftTextBox.ValueChanged -= pitchShiftTextBox_ValueChanged;
            pitchShiftTextBox.Value = pitchShift;
            pitchShiftTextBox.ValueChanged += pitchShiftTextBox_ValueChanged;
        }

        public void SetPitchShift(int pitchShiftId)
        {
            this.pitchShift = pitchShiftId;
            UpdateTextBox();

        }

        private void pitchShiftTextBox_KeyDown(object sender, KeyEventArgs e)
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
