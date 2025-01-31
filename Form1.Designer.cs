namespace MusicBeePlugin {
    partial class VGMV {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.songName = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.ScoreP2 = new System.Windows.Forms.Label();
            this.ScoreP1 = new System.Windows.Forms.Label();
            this.TimerP1 = new System.Windows.Forms.Label();
            this.TimerP2 = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.DisplayHistoryCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.missedSongs = new System.Windows.Forms.Button();
            this.SampleRounds = new System.Windows.Forms.CheckBox();
            this.quizSwitch = new System.Windows.Forms.Button();
            this.chaseClassicB = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.P2NameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.export = new System.Windows.Forms.Button();
            this.SingePlayerCheckBox = new System.Windows.Forms.CheckBox();
            this.ShufflePlaylistCheckBox = new System.Windows.Forms.CheckBox();
            this.P2NameSettingsLabel = new System.Windows.Forms.Label();
            this.P1NameTextBox = new System.Windows.Forms.TextBox();
            this.P1NameSettingsLabel = new System.Windows.Forms.Label();
            this.LoopPlaylistCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.P2IncrementUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.P2PointsToPassUpDown = new System.Windows.Forms.NumericUpDown();
            this.P1PointsToPassUpDown = new System.Windows.Forms.NumericUpDown();
            this.P2ChangeColorButton = new System.Windows.Forms.Button();
            this.P1ChangeColorButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P1IncrementUpDown = new System.Windows.Forms.NumericUpDown();
            this.Secs = new System.Windows.Forms.NumericUpDown();
            this.Mins = new System.Windows.Forms.NumericUpDown();
            this.P2StartsRadioButton = new System.Windows.Forms.RadioButton();
            this.P1StartsRadioButton = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.settingsButton = new System.Windows.Forms.Button();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.LosingPlayerLabel = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.HintPicture = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.BufferedPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2IncrementUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2PointsToPassUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1PointsToPassUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1IncrementUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Secs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HintPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // songName
            // 
            this.songName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.songName.AutoEllipsis = true;
            this.songName.BackColor = System.Drawing.Color.Transparent;
            this.songName.Font = new System.Drawing.Font("Montserrat", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songName.ForeColor = System.Drawing.Color.Coral;
            this.songName.Location = new System.Drawing.Point(266, 9);
            this.songName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.songName.Name = "songName";
            this.songName.Size = new System.Drawing.Size(673, 122);
            this.songName.TabIndex = 1;
            this.songName.Text = "VGM Versus";
            this.songName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.songName.UseMnemonic = false;
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Start.FlatAppearance.BorderSize = 5;
            this.Start.Location = new System.Drawing.Point(409, 259);
            this.Start.Margin = new System.Windows.Forms.Padding(2);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(389, 160);
            this.Start.TabIndex = 2;
            this.Start.Text = "Click to start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click_1);
            // 
            // ScoreP2
            // 
            this.ScoreP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreP2.BackColor = System.Drawing.Color.Transparent;
            this.ScoreP2.Font = new System.Drawing.Font("Riffic Free Medium", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreP2.Location = new System.Drawing.Point(908, 541);
            this.ScoreP2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScoreP2.Name = "ScoreP2";
            this.ScoreP2.Size = new System.Drawing.Size(285, 118);
            this.ScoreP2.TabIndex = 3;
            this.ScoreP2.Text = "Score Player 2";
            this.ScoreP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreP1
            // 
            this.ScoreP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ScoreP1.BackColor = System.Drawing.Color.Transparent;
            this.ScoreP1.Font = new System.Drawing.Font("Riffic Free Medium", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreP1.Location = new System.Drawing.Point(11, 541);
            this.ScoreP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScoreP1.Name = "ScoreP1";
            this.ScoreP1.Size = new System.Drawing.Size(285, 118);
            this.ScoreP1.TabIndex = 5;
            this.ScoreP1.Text = "Score Player 1";
            this.ScoreP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerP1
            // 
            this.TimerP1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TimerP1.BackColor = System.Drawing.Color.Transparent;
            this.TimerP1.Font = new System.Drawing.Font("Riffic Free Medium", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerP1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.TimerP1.Location = new System.Drawing.Point(45, 59);
            this.TimerP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimerP1.Name = "TimerP1";
            this.TimerP1.Size = new System.Drawing.Size(178, 51);
            this.TimerP1.TabIndex = 6;
            this.TimerP1.Text = "5:00";
            this.TimerP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerP2
            // 
            this.TimerP2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TimerP2.BackColor = System.Drawing.Color.Transparent;
            this.TimerP2.Font = new System.Drawing.Font("Riffic Free Medium", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerP2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.TimerP2.Location = new System.Drawing.Point(981, 59);
            this.TimerP2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimerP2.Name = "TimerP2";
            this.TimerP2.Size = new System.Drawing.Size(178, 51);
            this.TimerP2.TabIndex = 7;
            this.TimerP2.Text = "5:00";
            this.TimerP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restartButton
            // 
            this.restartButton.Font = new System.Drawing.Font("Riffic Free Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.Location = new System.Drawing.Point(1086, 9);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(107, 47);
            this.restartButton.TabIndex = 8;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.Lavender;
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox2.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(895, 141);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox2.Size = new System.Drawing.Size(297, 425);
            this.listBox2.TabIndex = 11;
            this.listBox2.TabStop = false;
            this.listBox2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox2_DrawItem);
            // 
            // DisplayHistoryCheckBox
            // 
            this.DisplayHistoryCheckBox.AutoSize = true;
            this.DisplayHistoryCheckBox.Checked = true;
            this.DisplayHistoryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayHistoryCheckBox.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayHistoryCheckBox.Location = new System.Drawing.Point(304, 169);
            this.DisplayHistoryCheckBox.Name = "DisplayHistoryCheckBox";
            this.DisplayHistoryCheckBox.Size = new System.Drawing.Size(156, 26);
            this.DisplayHistoryCheckBox.TabIndex = 12;
            this.DisplayHistoryCheckBox.Text = "Display History";
            this.DisplayHistoryCheckBox.UseVisualStyleBackColor = true;
            this.DisplayHistoryCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.missedSongs);
            this.groupBox1.Controls.Add(this.SampleRounds);
            this.groupBox1.Controls.Add(this.quizSwitch);
            this.groupBox1.Controls.Add(this.chaseClassicB);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.P2NameTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.export);
            this.groupBox1.Controls.Add(this.SingePlayerCheckBox);
            this.groupBox1.Controls.Add(this.ShufflePlaylistCheckBox);
            this.groupBox1.Controls.Add(this.P2NameSettingsLabel);
            this.groupBox1.Controls.Add(this.P1NameTextBox);
            this.groupBox1.Controls.Add(this.P1NameSettingsLabel);
            this.groupBox1.Controls.Add(this.LoopPlaylistCheckBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.P2IncrementUpDown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.P2PointsToPassUpDown);
            this.groupBox1.Controls.Add(this.DisplayHistoryCheckBox);
            this.groupBox1.Controls.Add(this.P1PointsToPassUpDown);
            this.groupBox1.Controls.Add(this.P2ChangeColorButton);
            this.groupBox1.Controls.Add(this.P1ChangeColorButton);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.P1IncrementUpDown);
            this.groupBox1.Controls.Add(this.Secs);
            this.groupBox1.Controls.Add(this.Mins);
            this.groupBox1.Controls.Add(this.P2StartsRadioButton);
            this.groupBox1.Controls.Add(this.P1StartsRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1181, 342);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // missedSongs
            // 
            this.missedSongs.Location = new System.Drawing.Point(666, 254);
            this.missedSongs.Name = "missedSongs";
            this.missedSongs.Size = new System.Drawing.Size(162, 31);
            this.missedSongs.TabIndex = 34;
            this.missedSongs.Text = "Missed Playlist";
            this.missedSongs.UseVisualStyleBackColor = true;
            this.missedSongs.Click += new System.EventHandler(this.missedSongs_Click);
            // 
            // SampleRounds
            // 
            this.SampleRounds.AutoSize = true;
            this.SampleRounds.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SampleRounds.Location = new System.Drawing.Point(17, 229);
            this.SampleRounds.Name = "SampleRounds";
            this.SampleRounds.Size = new System.Drawing.Size(160, 26);
            this.SampleRounds.TabIndex = 33;
            this.SampleRounds.Text = "Sample Rounds";
            this.SampleRounds.UseVisualStyleBackColor = true;
            this.SampleRounds.CheckedChanged += new System.EventHandler(this.SampleRounds_CheckedChanged);
            // 
            // quizSwitch
            // 
            this.quizSwitch.Location = new System.Drawing.Point(490, 289);
            this.quizSwitch.Name = "quizSwitch";
            this.quizSwitch.Size = new System.Drawing.Size(162, 31);
            this.quizSwitch.TabIndex = 32;
            this.quizSwitch.Text = "Go to Quiz Mode";
            this.quizSwitch.UseVisualStyleBackColor = true;
            this.quizSwitch.Click += new System.EventHandler(this.quizSwitch_Click);
            // 
            // chaseClassicB
            // 
            this.chaseClassicB.AutoSize = true;
            this.chaseClassicB.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chaseClassicB.Location = new System.Drawing.Point(499, 257);
            this.chaseClassicB.Name = "chaseClassicB";
            this.chaseClassicB.Size = new System.Drawing.Size(142, 26);
            this.chaseClassicB.TabIndex = 31;
            this.chaseClassicB.Text = "Chase Classic";
            this.chaseClassicB.UseVisualStyleBackColor = true;
            this.chaseClassicB.CheckedChanged += new System.EventHandler(this.chaseClassicB_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(17, 261);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 26);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "Quick Rounds";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(112, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 22);
            this.label9.TabIndex = 29;
            this.label9.Text = "Quick Round Length";
            this.label9.Click += new System.EventHandler(this.label6_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Location = new System.Drawing.Point(17, 293);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(89, 27);
            this.numericUpDown2.TabIndex = 28;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(962, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 22);
            this.label6.TabIndex = 29;
            this.label6.Text = "Auto Pause";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(1074, 296);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 27);
            this.numericUpDown1.TabIndex = 28;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // P2NameTextBox
            // 
            this.P2NameTextBox.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold);
            this.P2NameTextBox.Location = new System.Drawing.Point(1009, 46);
            this.P2NameTextBox.Multiline = true;
            this.P2NameTextBox.Name = "P2NameTextBox";
            this.P2NameTextBox.Size = new System.Drawing.Size(166, 49);
            this.P2NameTextBox.TabIndex = 26;
            this.P2NameTextBox.Text = "Player 2";
            this.P2NameTextBox.TextChanged += new System.EventHandler(this.P2NameTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(344, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 23;
            this.label3.Text = "Volume";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(329, 202);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(111, 45);
            this.trackBar1.TabIndex = 22;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(666, 212);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(162, 31);
            this.export.TabIndex = 21;
            this.export.Text = "Export Tracklist";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // SingePlayerCheckBox
            // 
            this.SingePlayerCheckBox.AutoSize = true;
            this.SingePlayerCheckBox.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingePlayerCheckBox.Location = new System.Drawing.Point(499, 212);
            this.SingePlayerCheckBox.Name = "SingePlayerCheckBox";
            this.SingePlayerCheckBox.Size = new System.Drawing.Size(134, 26);
            this.SingePlayerCheckBox.TabIndex = 18;
            this.SingePlayerCheckBox.Text = "Singleplayer";
            this.SingePlayerCheckBox.UseVisualStyleBackColor = true;
            this.SingePlayerCheckBox.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // ShufflePlaylistCheckBox
            // 
            this.ShufflePlaylistCheckBox.AutoSize = true;
            this.ShufflePlaylistCheckBox.Checked = true;
            this.ShufflePlaylistCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShufflePlaylistCheckBox.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShufflePlaylistCheckBox.Location = new System.Drawing.Point(673, 169);
            this.ShufflePlaylistCheckBox.Name = "ShufflePlaylistCheckBox";
            this.ShufflePlaylistCheckBox.Size = new System.Drawing.Size(155, 26);
            this.ShufflePlaylistCheckBox.TabIndex = 17;
            this.ShufflePlaylistCheckBox.Text = "Shuffle Playlist";
            this.ShufflePlaylistCheckBox.UseVisualStyleBackColor = true;
            this.ShufflePlaylistCheckBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // P2NameSettingsLabel
            // 
            this.P2NameSettingsLabel.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold);
            this.P2NameSettingsLabel.Location = new System.Drawing.Point(909, 47);
            this.P2NameSettingsLabel.Name = "P2NameSettingsLabel";
            this.P2NameSettingsLabel.Size = new System.Drawing.Size(116, 49);
            this.P2NameSettingsLabel.TabIndex = 27;
            this.P2NameSettingsLabel.Text = "Name:";
            this.P2NameSettingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // P1NameTextBox
            // 
            this.P1NameTextBox.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1NameTextBox.Location = new System.Drawing.Point(101, 46);
            this.P1NameTextBox.Multiline = true;
            this.P1NameTextBox.Name = "P1NameTextBox";
            this.P1NameTextBox.Size = new System.Drawing.Size(166, 49);
            this.P1NameTextBox.TabIndex = 25;
            this.P1NameTextBox.Text = "Player 1";
            this.P1NameTextBox.TextChanged += new System.EventHandler(this.P1NameTextBox_TextChanged);
            // 
            // P1NameSettingsLabel
            // 
            this.P1NameSettingsLabel.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1NameSettingsLabel.Location = new System.Drawing.Point(6, 46);
            this.P1NameSettingsLabel.Name = "P1NameSettingsLabel";
            this.P1NameSettingsLabel.Size = new System.Drawing.Size(89, 49);
            this.P1NameSettingsLabel.TabIndex = 24;
            this.P1NameSettingsLabel.Text = "Name:";
            this.P1NameSettingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoopPlaylistCheckBox
            // 
            this.LoopPlaylistCheckBox.AutoSize = true;
            this.LoopPlaylistCheckBox.Checked = true;
            this.LoopPlaylistCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LoopPlaylistCheckBox.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoopPlaylistCheckBox.Location = new System.Drawing.Point(499, 169);
            this.LoopPlaylistCheckBox.Name = "LoopPlaylistCheckBox";
            this.LoopPlaylistCheckBox.Size = new System.Drawing.Size(137, 26);
            this.LoopPlaylistCheckBox.TabIndex = 16;
            this.LoopPlaylistCheckBox.Text = "Loop Playlist";
            this.LoopPlaylistCheckBox.UseVisualStyleBackColor = true;
            this.LoopPlaylistCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(597, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 22);
            this.label8.TabIndex = 15;
            this.label8.Text = "Increment on Pass";
            // 
            // P2IncrementUpDown
            // 
            this.P2IncrementUpDown.DecimalPlaces = 2;
            this.P2IncrementUpDown.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2IncrementUpDown.Location = new System.Drawing.Point(584, 118);
            this.P2IncrementUpDown.Name = "P2IncrementUpDown";
            this.P2IncrementUpDown.Size = new System.Drawing.Size(200, 27);
            this.P2IncrementUpDown.TabIndex = 14;
            this.P2IncrementUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.P2IncrementUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.P2IncrementUpDown.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1005, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 22);
            this.label5.TabIndex = 13;
            this.label5.Text = "Points to pass";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "Points to pass";
            // 
            // P2PointsToPassUpDown
            // 
            this.P2PointsToPassUpDown.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2PointsToPassUpDown.Location = new System.Drawing.Point(1138, 151);
            this.P2PointsToPassUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.P2PointsToPassUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.P2PointsToPassUpDown.Name = "P2PointsToPassUpDown";
            this.P2PointsToPassUpDown.Size = new System.Drawing.Size(37, 27);
            this.P2PointsToPassUpDown.TabIndex = 11;
            this.P2PointsToPassUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.P2PointsToPassUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.P2PointsToPassUpDown.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // P1PointsToPassUpDown
            // 
            this.P1PointsToPassUpDown.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1PointsToPassUpDown.Location = new System.Drawing.Point(7, 151);
            this.P1PointsToPassUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.P1PointsToPassUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.P1PointsToPassUpDown.Name = "P1PointsToPassUpDown";
            this.P1PointsToPassUpDown.Size = new System.Drawing.Size(37, 27);
            this.P1PointsToPassUpDown.TabIndex = 10;
            this.P1PointsToPassUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.P1PointsToPassUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.P1PointsToPassUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // P2ChangeColorButton
            // 
            this.P2ChangeColorButton.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2ChangeColorButton.Location = new System.Drawing.Point(1036, 106);
            this.P2ChangeColorButton.Name = "P2ChangeColorButton";
            this.P2ChangeColorButton.Size = new System.Drawing.Size(139, 39);
            this.P2ChangeColorButton.TabIndex = 9;
            this.P2ChangeColorButton.Text = "Change Color";
            this.P2ChangeColorButton.UseVisualStyleBackColor = true;
            this.P2ChangeColorButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // P1ChangeColorButton
            // 
            this.P1ChangeColorButton.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1ChangeColorButton.Location = new System.Drawing.Point(7, 106);
            this.P1ChangeColorButton.Name = "P1ChangeColorButton";
            this.P1ChangeColorButton.Size = new System.Drawing.Size(139, 39);
            this.P1ChangeColorButton.TabIndex = 8;
            this.P1ChangeColorButton.Text = "Change Color";
            this.P1ChangeColorButton.UseVisualStyleBackColor = true;
            this.P1ChangeColorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(362, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Increment on Pass";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(640, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seconds";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(407, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minutes";
            // 
            // P1IncrementUpDown
            // 
            this.P1IncrementUpDown.DecimalPlaces = 2;
            this.P1IncrementUpDown.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1IncrementUpDown.Location = new System.Drawing.Point(352, 118);
            this.P1IncrementUpDown.Name = "P1IncrementUpDown";
            this.P1IncrementUpDown.Size = new System.Drawing.Size(200, 27);
            this.P1IncrementUpDown.TabIndex = 4;
            this.P1IncrementUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.P1IncrementUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.P1IncrementUpDown.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // Secs
            // 
            this.Secs.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Secs.Location = new System.Drawing.Point(585, 58);
            this.Secs.Name = "Secs";
            this.Secs.Size = new System.Drawing.Size(200, 27);
            this.Secs.TabIndex = 3;
            this.Secs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Secs.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Secs.ValueChanged += new System.EventHandler(this.Secs_ValueChanged);
            // 
            // Mins
            // 
            this.Mins.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mins.Location = new System.Drawing.Point(353, 58);
            this.Mins.Margin = new System.Windows.Forms.Padding(6);
            this.Mins.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Mins.Name = "Mins";
            this.Mins.Size = new System.Drawing.Size(200, 27);
            this.Mins.TabIndex = 2;
            this.Mins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Mins.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Mins.ValueChanged += new System.EventHandler(this.Mins_ValueChanged);
            // 
            // P2StartsRadioButton
            // 
            this.P2StartsRadioButton.AutoSize = true;
            this.P2StartsRadioButton.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2StartsRadioButton.Location = new System.Drawing.Point(1003, 13);
            this.P2StartsRadioButton.Name = "P2StartsRadioButton";
            this.P2StartsRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.P2StartsRadioButton.Size = new System.Drawing.Size(172, 30);
            this.P2StartsRadioButton.TabIndex = 1;
            this.P2StartsRadioButton.TabStop = true;
            this.P2StartsRadioButton.Text = "Player 2 Starts";
            this.P2StartsRadioButton.UseVisualStyleBackColor = true;
            this.P2StartsRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // P1StartsRadioButton
            // 
            this.P1StartsRadioButton.AutoSize = true;
            this.P1StartsRadioButton.Checked = true;
            this.P1StartsRadioButton.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1StartsRadioButton.Location = new System.Drawing.Point(6, 13);
            this.P1StartsRadioButton.Name = "P1StartsRadioButton";
            this.P1StartsRadioButton.Size = new System.Drawing.Size(168, 30);
            this.P1StartsRadioButton.TabIndex = 0;
            this.P1StartsRadioButton.TabStop = true;
            this.P1StartsRadioButton.Text = "Player 1 Starts";
            this.P1StartsRadioButton.UseVisualStyleBackColor = true;
            this.P1StartsRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // settingsButton
            // 
            this.settingsButton.Font = new System.Drawing.Font("Riffic Free Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.Location = new System.Drawing.Point(975, 9);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(105, 47);
            this.settingsButton.TabIndex = 14;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Lavender;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(12, 141);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(297, 425);
            this.listBox1.TabIndex = 15;
            this.listBox1.TabStop = false;
            // 
            // LosingPlayerLabel
            // 
            this.LosingPlayerLabel.Font = new System.Drawing.Font("Riffic Free Medium", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LosingPlayerLabel.Location = new System.Drawing.Point(470, 517);
            this.LosingPlayerLabel.Name = "LosingPlayerLabel";
            this.LosingPlayerLabel.Size = new System.Drawing.Size(255, 124);
            this.LosingPlayerLabel.TabIndex = 17;
            this.LosingPlayerLabel.Text = "PLAYER 1 LOST";
            this.LosingPlayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::MusicBeePlugin.Properties.Resources.noooo;
            this.pictureBox5.Location = new System.Drawing.Point(724, 517);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(124, 124);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 20;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Location = new System.Drawing.Point(-3, 214);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(351, 351);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Location = new System.Drawing.Point(848, 214);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(351, 351);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MusicBeePlugin.Properties.Resources.D_colon;
            this.pictureBox2.Location = new System.Drawing.Point(348, 517);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(124, 124);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // Player1Name
            // 
            this.Player1Name.Font = new System.Drawing.Font("Riffic Free Medium", 12F, System.Drawing.FontStyle.Bold);
            this.Player1Name.Location = new System.Drawing.Point(8, 110);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(253, 28);
            this.Player1Name.TabIndex = 21;
            this.Player1Name.Text = "Player1";
            this.Player1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player2Name
            // 
            this.Player2Name.Font = new System.Drawing.Font("Riffic Free Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Name.Location = new System.Drawing.Point(944, 110);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(253, 28);
            this.Player2Name.TabIndex = 22;
            this.Player2Name.Text = "Player2";
            this.Player2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // HintPicture
            // 
            this.HintPicture.Location = new System.Drawing.Point(348, 141);
            this.HintPicture.Name = "HintPicture";
            this.HintPicture.Size = new System.Drawing.Size(500, 500);
            this.HintPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HintPicture.TabIndex = 33;
            this.HintPicture.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(348, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 30;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // VGMV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1204, 668);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.songName);
            this.Controls.Add(this.Player1Name);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LosingPlayerLabel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.TimerP2);
            this.Controls.Add(this.TimerP1);
            this.Controls.Add(this.ScoreP1);
            this.Controls.Add(this.ScoreP2);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HintPicture);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VGMV";
            this.Text = "VGMV";
            this.Load += new System.EventHandler(this.VGMV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2IncrementUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2PointsToPassUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1PointsToPassUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1IncrementUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Secs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HintPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox P2NameTextBox;
        public System.Windows.Forms.Label P2NameSettingsLabel;
        public System.Windows.Forms.Label Player2Name;
        public System.Windows.Forms.TextBox P1NameTextBox;
        public System.Windows.Forms.Label P1NameSettingsLabel;
        public System.Windows.Forms.Label Player1Name;
        public System.Windows.Forms.Label songName;
        public System.Windows.Forms.Button Start;
        public System.Windows.Forms.Label ScoreP2;
        public System.Windows.Forms.Label ScoreP1;
        public System.Windows.Forms.Label TimerP1;
        public System.Windows.Forms.Label TimerP2;
        public System.Windows.Forms.Button restartButton;
        public System.Windows.Forms.ListBox listBox2;
        public System.Windows.Forms.CheckBox DisplayHistoryCheckBox;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton P2StartsRadioButton;
        public System.Windows.Forms.RadioButton P1StartsRadioButton;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown Secs;
        public System.Windows.Forms.NumericUpDown Mins;
        public System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.Button P2ChangeColorButton;
        public System.Windows.Forms.Button P1ChangeColorButton;
        public System.Windows.Forms.Button settingsButton;
        public System.Windows.Forms.ColorDialog colorDialog2;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown P2PointsToPassUpDown;
        public System.Windows.Forms.NumericUpDown P1PointsToPassUpDown;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown P2IncrementUpDown;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown P1IncrementUpDown;
        public System.Windows.Forms.Label LosingPlayerLabel;
        public System.Windows.Forms.CheckBox LoopPlaylistCheckBox;
        public System.Windows.Forms.CheckBox ShufflePlaylistCheckBox;
        public System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.CheckBox SingePlayerCheckBox;
        public System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.Button export;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TrackBar trackBar1;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.BufferedPanel panel1;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.NumericUpDown numericUpDown2;
        public System.Windows.Forms.CheckBox chaseClassicB;
        public System.Windows.Forms.Button quizSwitch;
        public System.Windows.Forms.PictureBox HintPicture;
        public System.Windows.Forms.CheckBox SampleRounds;
        public System.Windows.Forms.Button missedSongs;
    }


}