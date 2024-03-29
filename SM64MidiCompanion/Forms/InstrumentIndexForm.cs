﻿using SM64MidiCompanion.Classes;
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
    public partial class InstrumentIndexForm : Form
    {
        public int instrumentId = 0;

        private SoundBank soundBank;

        private Instrument[] instruments;

        public InstrumentIndexForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;

            instrumentIdTextBox.Focus();
            instrumentIdTextBox.Select(0, 100);

            soundBank = Form1.LoadedSoundBank;

            Dictionary<int, string> instDict = new Dictionary<int, string>();

            if (soundBank != null)
            {
                errorLabel.Text = "";
                instrumentComboBox.Items.Clear();
                instruments = soundBank.GetInstruments().ToArray();

                int instIndex = 0;
                foreach (var inst in instruments)
                {
                    instDict.Add(instIndex, inst.sound);
                    instIndex++;
                }
                if (soundBank.hasPercussion)
                {
                    instDict.Add(127, "PERCUSSION");
                }

                instrumentComboBox.DataSource = instDict.ToList();
                instrumentComboBox.ValueMember = "Value";
                instrumentComboBox.DisplayMember = "Value";
            }
            else
            {
                instrumentBankLabel.Enabled = false;
                instrumentComboBox.Enabled = false;
                errorLabel.Text = "Sound Bank must be loaded.";
            }

        }

        private void instrumentIdTextBox_KeyDown(object sender, KeyEventArgs e)
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelDialog();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            ConfirmDialog();
        }

        private void ConfirmDialog()
        {
            instrumentId = (int)instrumentIdTextBox.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelDialog()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void instrumentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(instrumentComboBox.SelectedIndex < 0 || instrumentComboBox.SelectedIndex > instruments.Length + (soundBank.hasPercussion ? 1 : 0))
            {
                return;
            }

            if (((KeyValuePair<int, string>)instrumentComboBox.SelectedItem).Key != 127)
            {
                Instrument inst = instruments[((KeyValuePair<int, string>)instrumentComboBox.SelectedItem).Key];
                instrumentId = soundBank.GetInstrumentIndex(inst);
            } else
            {
                instrumentId = 127;
            }

            UpdateTextBoxValue();
        }

        private void instrumentIdTextBox_ValueChanged(object sender, EventArgs e)
        {
            // If user changes to text or some shit, don't really care but it mucks up combo box code
            try
            {
                instrumentId = (int)instrumentIdTextBox.Value;
            }
            catch (Exception err) { }

            UpdateComboBoxValue();
        }

        private void UpdateTextBoxValue()
        {
            instrumentIdTextBox.ValueChanged -= instrumentIdTextBox_ValueChanged;
            instrumentIdTextBox.Value = instrumentId;
            instrumentIdTextBox.ValueChanged += instrumentIdTextBox_ValueChanged;
        }

        private void UpdateComboBoxValue()
        {
            if (soundBank == null || instruments == null || instruments.Length == 0)
            {
                return;
            }

            if (instrumentId == 127 && soundBank.hasPercussion)
            {
                instrumentComboBox.SelectedIndexChanged -= instrumentComboBox_SelectedIndexChanged;
                instrumentComboBox.SelectedIndex = ((List<KeyValuePair<int, string>>)instrumentComboBox.DataSource).Count - 1;
                instrumentComboBox.SelectedIndexChanged += instrumentComboBox_SelectedIndexChanged;
                return;
            }

            Instrument inst = soundBank.GetInstrumentFromBankIndex(instrumentId);

            if (inst == null)
            {
                instrumentComboBox.SelectedIndexChanged -= instrumentComboBox_SelectedIndexChanged;
                instrumentComboBox.SelectedIndex = -1;
                instrumentComboBox.SelectedIndexChanged += instrumentComboBox_SelectedIndexChanged;
                return;
            }

            instrumentComboBox.SelectedIndexChanged -= instrumentComboBox_SelectedIndexChanged;

            for (int i = 0; i < instrumentComboBox.Items.Count; i++)
            {
                if (instruments[i].Equals(inst))
                {
                    instrumentComboBox.SelectedIndex = i;
                    break;
                }
            }
            instrumentComboBox.SelectedIndexChanged += instrumentComboBox_SelectedIndexChanged;
        }

        public void SetInstrumentId(int newId)
        {
            if(newId < 0)
            {
                newId = 0;
            }
            this.instrumentId = newId;
            UpdateTextBoxValue();
            UpdateComboBoxValue();
        }
    }
}
