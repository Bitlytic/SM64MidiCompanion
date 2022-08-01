
using System;
using System.Drawing;

namespace SM64MidiCompanion
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.midiInputTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openMidiButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outputM64TextBox = new System.Windows.Forms.TextBox();
            this.saveM64SelectButton = new System.Windows.Forms.Button();
            this.saveErrorLabel = new System.Windows.Forms.Label();
            this.saveM64Button = new System.Windows.Forms.Button();
            this.refreshMidiButton = new System.Windows.Forms.Button();
            this.refreshToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.trackNameListView = new SM64MidiCompanion.Components.TrackListView();
            this.enabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.channelId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trackName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instrumentId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pitchShiftId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoAssignChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flStudioCheckbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // midiInputTextBox
            // 
            this.midiInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.midiInputTextBox.Location = new System.Drawing.Point(12, 65);
            this.midiInputTextBox.Name = "midiInputTextBox";
            this.midiInputTextBox.Size = new System.Drawing.Size(244, 32);
            this.midiInputTextBox.TabIndex = 0;
            this.midiInputTextBox.TextChanged += new System.EventHandler(this.midiInputTextBox_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openMidiButton
            // 
            this.openMidiButton.Location = new System.Drawing.Point(259, 65);
            this.openMidiButton.Margin = new System.Windows.Forms.Padding(0);
            this.openMidiButton.Name = "openMidiButton";
            this.openMidiButton.Size = new System.Drawing.Size(32, 32);
            this.openMidiButton.TabIndex = 1;
            this.openMidiButton.Text = "...";
            this.openMidiButton.UseVisualStyleBackColor = true;
            this.openMidiButton.Click += new System.EventHandler(this.openMidiButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Midi Input File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "M64 Output File";
            // 
            // outputM64TextBox
            // 
            this.outputM64TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.outputM64TextBox.Location = new System.Drawing.Point(12, 129);
            this.outputM64TextBox.Name = "outputM64TextBox";
            this.outputM64TextBox.Size = new System.Drawing.Size(244, 32);
            this.outputM64TextBox.TabIndex = 9;
            // 
            // saveM64SelectButton
            // 
            this.saveM64SelectButton.Location = new System.Drawing.Point(259, 129);
            this.saveM64SelectButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveM64SelectButton.Name = "saveM64SelectButton";
            this.saveM64SelectButton.Size = new System.Drawing.Size(32, 32);
            this.saveM64SelectButton.TabIndex = 1;
            this.saveM64SelectButton.Text = "...";
            this.saveM64SelectButton.UseVisualStyleBackColor = true;
            this.saveM64SelectButton.Click += new System.EventHandler(this.saveM64SelectButton_Click);
            // 
            // saveErrorLabel
            // 
            this.saveErrorLabel.AutoSize = true;
            this.saveErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveErrorLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.saveErrorLabel.Location = new System.Drawing.Point(8, 164);
            this.saveErrorLabel.Name = "saveErrorLabel";
            this.saveErrorLabel.Size = new System.Drawing.Size(129, 20);
            this.saveErrorLabel.TabIndex = 8;
            this.saveErrorLabel.Text = "Errors show here";
            // 
            // saveM64Button
            // 
            this.saveM64Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveM64Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.saveM64Button.Location = new System.Drawing.Point(12, 385);
            this.saveM64Button.Name = "saveM64Button";
            this.saveM64Button.Size = new System.Drawing.Size(80, 64);
            this.saveM64Button.TabIndex = 10;
            this.saveM64Button.Text = "Export .m64";
            this.saveM64Button.UseVisualStyleBackColor = true;
            this.saveM64Button.Click += new System.EventHandler(this.saveM64Button_Click);
            // 
            // refreshMidiButton
            // 
            this.refreshMidiButton.BackgroundImage = global::SM64MidiCompanion.Properties.Resources.Refresh;
            this.refreshMidiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshMidiButton.Image = global::SM64MidiCompanion.Properties.Resources.Refresh;
            this.refreshMidiButton.Location = new System.Drawing.Point(294, 65);
            this.refreshMidiButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.refreshMidiButton.Name = "refreshMidiButton";
            this.refreshMidiButton.Size = new System.Drawing.Size(32, 32);
            this.refreshMidiButton.TabIndex = 1;
            this.refreshToolTip.SetToolTip(this.refreshMidiButton, "Reloads MIDI from disk (Keeps current changes)\r\n");
            this.refreshMidiButton.UseVisualStyleBackColor = true;
            this.refreshMidiButton.Click += new System.EventHandler(this.refreshMidiButton_Click);
            // 
            // refreshToolTip
            // 
            this.refreshToolTip.ToolTipTitle = "Reload";
            // 
            // trackNameListView
            // 
            this.trackNameListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackNameListView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.trackNameListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.enabled,
            this.channelId,
            this.trackName,
            this.instrumentId,
            this.pitchShiftId});
            this.trackNameListView.FullRowSelect = true;
            this.trackNameListView.HideSelection = false;
            this.trackNameListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.trackNameListView.Location = new System.Drawing.Point(347, 37);
            this.trackNameListView.Name = "trackNameListView";
            this.trackNameListView.OwnerDraw = true;
            this.trackNameListView.Size = new System.Drawing.Size(625, 412);
            this.trackNameListView.TabIndex = 7;
            this.trackNameListView.UseCompatibleStateImageBehavior = false;
            this.trackNameListView.View = System.Windows.Forms.View.Details;
            // 
            // enabled
            // 
            this.enabled.Text = "Enabled";
            this.enabled.Width = 52;
            // 
            // channelId
            // 
            this.channelId.Text = "Channel";
            this.channelId.Width = 52;
            // 
            // trackName
            // 
            this.trackName.Text = "Track Name";
            this.trackName.Width = 150;
            // 
            // instrumentId
            // 
            this.instrumentId.Text = "Instrument ID";
            this.instrumentId.Width = 84;
            // 
            // pitchShiftId
            // 
            this.pitchShiftId.Text = "Pitch Shift";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundBankToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // soundBankToolStripMenuItem
            // 
            this.soundBankToolStripMenuItem.Name = "soundBankToolStripMenuItem";
            this.soundBankToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.soundBankToolStripMenuItem.Text = "Load Sound Bank...";
            this.soundBankToolStripMenuItem.Click += new System.EventHandler(this.soundBankToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoAssignChannelsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // autoAssignChannelsToolStripMenuItem
            // 
            this.autoAssignChannelsToolStripMenuItem.Name = "autoAssignChannelsToolStripMenuItem";
            this.autoAssignChannelsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.autoAssignChannelsToolStripMenuItem.Text = "Auto Assign Channels";
            this.autoAssignChannelsToolStripMenuItem.Click += new System.EventHandler(this.autoAssignChannelsToolStripMenuItem_Click);
            // 
            // flStudioCheckbox
            // 
            this.flStudioCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flStudioCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.flStudioCheckbox.Location = new System.Drawing.Point(12, 351);
            this.flStudioCheckbox.Name = "flStudioCheckbox";
            this.flStudioCheckbox.Size = new System.Drawing.Size(314, 28);
            this.flStudioCheckbox.TabIndex = 15;
            this.flStudioCheckbox.Text = "FL Studio compat. mode";
            this.flStudioCheckbox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.flStudioCheckbox);
            this.Controls.Add(this.saveM64Button);
            this.Controls.Add(this.outputM64TextBox);
            this.Controls.Add(this.saveErrorLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackNameListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveM64SelectButton);
            this.Controls.Add(this.refreshMidiButton);
            this.Controls.Add(this.openMidiButton);
            this.Controls.Add(this.midiInputTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SM64 Midi Companion";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox midiInputTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openMidiButton;
        private System.Windows.Forms.Label label1;
        private Components.TrackListView trackNameListView;
        private System.Windows.Forms.ColumnHeader enabled;
        private System.Windows.Forms.ColumnHeader trackName;
        private System.Windows.Forms.ColumnHeader instrumentId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputM64TextBox;
        private System.Windows.Forms.Button saveM64SelectButton;
        private System.Windows.Forms.Label saveErrorLabel;
        private System.Windows.Forms.Button saveM64Button;
        private System.Windows.Forms.Button refreshMidiButton;
        private System.Windows.Forms.ToolTip refreshToolTip;
        private System.Windows.Forms.ColumnHeader pitchShiftId;
        private System.Windows.Forms.ColumnHeader channelId;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundBankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoAssignChannelsToolStripMenuItem;
        private System.Windows.Forms.CheckBox flStudioCheckbox;
    }
}

