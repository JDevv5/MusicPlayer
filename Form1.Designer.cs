using System.Windows.Forms;

namespace MusicPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.volumeScroll = new System.Windows.Forms.TrackBar();
            this.addbtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sortbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.searchtxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.lbltime = new System.Windows.Forms.Label();
            this.lblduration = new System.Windows.Forms.Label();
            this.TimerTick = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.albumArtBox = new FontAwesome.Sharp.IconPictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.spotifyListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.volumeScroll)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // volumeScroll
            // 
            resources.ApplyResources(this.volumeScroll, "volumeScroll");
            this.volumeScroll.Maximum = 100;
            this.volumeScroll.Name = "volumeScroll";
            this.volumeScroll.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addbtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.addbtn, "addbtn");
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.Name = "addbtn";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sortbtn
            // 
            resources.ApplyResources(this.sortbtn, "sortbtn");
            this.sortbtn.Name = "sortbtn";
            this.sortbtn.UseVisualStyleBackColor = true;
            this.sortbtn.Click += new System.EventHandler(this.sortbtn_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Name = "label2";
            // 
            // searchtxt
            // 
            resources.ApplyResources(this.searchtxt, "searchtxt");
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.Player);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // Player
            // 
            resources.ApplyResources(this.Player, "Player");
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Player_PlayStateChange);
            this.Player.Enter += new System.EventHandler(this.Player_Enter);
            // 
            // lbltime
            // 
            resources.ApplyResources(this.lbltime, "lbltime");
            this.lbltime.ForeColor = System.Drawing.SystemColors.Control;
            this.lbltime.Name = "lbltime";
            // 
            // lblduration
            // 
            resources.ApplyResources(this.lblduration, "lblduration");
            this.lblduration.BackColor = System.Drawing.Color.Purple;
            this.lblduration.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblduration.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblduration.Name = "lblduration";
            // 
            // TimerTick
            // 
            resources.ApplyResources(this.TimerTick, "TimerTick");
            this.TimerTick.ForeColor = System.Drawing.SystemColors.Control;
            this.TimerTick.Name = "TimerTick";
            this.TimerTick.UseVisualStyleBackColor = true;
            this.TimerTick.CheckedChanged += new System.EventHandler(this.TimerTick_CheckedChanged_1);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(16)))), ((int)(((byte)(33)))));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Name = "label3";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(16)))), ((int)(((byte)(33)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.addbtn);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.iconButton3);
            this.panel3.Controls.Add(this.iconButton2);
            this.panel3.Controls.Add(this.iconButton1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // iconButton3
            // 
            resources.ApplyResources(this.iconButton3, "iconButton3");
            this.iconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.iconButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.Forward;
            this.iconButton3.IconColor = System.Drawing.Color.Black;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 25;
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // iconButton2
            // 
            resources.ApplyResources(this.iconButton2, "iconButton2");
            this.iconButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Forward;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 25;
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.iconButton1, "iconButton1");
            this.iconButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 25;
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Purple;
            this.panel4.Controls.Add(this.albumArtBox);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.lblduration);
            this.panel4.Controls.Add(this.lbltime);
            this.panel4.Controls.Add(this.TimerTick);
            this.panel4.Controls.Add(this.volumeScroll);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // albumArtBox
            // 
            this.albumArtBox.BackColor = System.Drawing.Color.Purple;
            this.albumArtBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.albumArtBox.IconChar = FontAwesome.Sharp.IconChar.Music;
            this.albumArtBox.IconColor = System.Drawing.SystemColors.ButtonFace;
            this.albumArtBox.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.albumArtBox.IconSize = 43;
            resources.ApplyResources(this.albumArtBox, "albumArtBox");
            this.albumArtBox.Name = "albumArtBox";
            this.albumArtBox.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchtxt);
            this.panel5.Controls.Add(this.label2);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // spotifyListView
            // 
            resources.ApplyResources(this.spotifyListView, "spotifyListView");
            this.spotifyListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyListView.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.spotifyListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spotifyListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyListView.ForeColor = System.Drawing.Color.White;
            this.spotifyListView.FullRowSelect = true;
            this.spotifyListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.spotifyListView.HideSelection = false;
            this.spotifyListView.Location = new System.Drawing.Point(0, 120);
            this.spotifyListView.Name = "spotifyListView";
            this.spotifyListView.Size = new System.Drawing.Size(800, 380);
            this.spotifyListView.TabIndex = 10;
            this.spotifyListView.UseCompatibleStateImageBehavior = false;
            this.spotifyListView.View = System.Windows.Forms.View.Details;
            this.spotifyListView.Columns.Add("Canciones", 600);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Controls.Add(this.spotifyListView);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sortbtn);
            this.Name = "Form1";
            this.TransparencyKey = System.Drawing.Color.Violet;
            ((System.ComponentModel.ISupportInitialize)(this.volumeScroll)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TrackBar volumeScroll;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button sortbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchtxt;
        private AxWMPLib.AxWindowsMediaPlayer Player;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lblduration;
        private System.Windows.Forms.CheckBox TimerTick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconPictureBox albumArtBox;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView spotifyListView;
    }
}

