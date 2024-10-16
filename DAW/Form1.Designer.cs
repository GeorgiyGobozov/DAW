namespace DAW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pauseButton = new System.Windows.Forms.Button();
            this.SnapButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.addTrackButton = new System.Windows.Forms.Button();
            this.tempo = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.metronomeGrid1 = new MetronomeGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pauseButton);
            this.panel1.Controls.Add(this.SnapButton);
            this.panel1.Controls.Add(this.stopButton);
            this.panel1.Controls.Add(this.playButton);
            this.panel1.Controls.Add(this.addTrackButton);
            this.panel1.Controls.Add(this.tempo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1288, 100);
            this.panel1.TabIndex = 9;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(239, 58);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(25, 25);
            this.pauseButton.TabIndex = 12;
            this.pauseButton.Text = "❚❚";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // SnapButton
            // 
            this.SnapButton.Location = new System.Drawing.Point(735, 55);
            this.SnapButton.Name = "SnapButton";
            this.SnapButton.Size = new System.Drawing.Size(138, 23);
            this.SnapButton.TabIndex = 0;
            this.SnapButton.Text = "привязать к сетке";
            this.SnapButton.UseVisualStyleBackColor = true;
            this.SnapButton.Click += new System.EventHandler(this.SnapButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(270, 58);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(25, 25);
            this.stopButton.TabIndex = 11;
            this.stopButton.Text = "◼";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(208, 58);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(25, 25);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "▶";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // addTrackButton
            // 
            this.addTrackButton.Location = new System.Drawing.Point(368, 55);
            this.addTrackButton.Name = "addTrackButton";
            this.addTrackButton.Size = new System.Drawing.Size(114, 23);
            this.addTrackButton.TabIndex = 10;
            this.addTrackButton.Text = "Добавить трек";
            this.addTrackButton.UseVisualStyleBackColor = true;
            this.addTrackButton.Click += new System.EventHandler(this.addTrackButton_Click);
            // 
            // tempo
            // 
            this.tempo.Location = new System.Drawing.Point(557, 58);
            this.tempo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tempo.Name = "tempo";
            this.tempo.Size = new System.Drawing.Size(120, 20);
            this.tempo.TabIndex = 0;
            this.tempo.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.tempo.ValueChanged += new System.EventHandler(this.tempo_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 492);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(2, 310);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1288, 310);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(209, 392);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // metronomeGrid1
            // 
            this.metronomeGrid1.AutoScroll = true;
            this.metronomeGrid1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.metronomeGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metronomeGrid1.Location = new System.Drawing.Point(209, 100);
            this.metronomeGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.metronomeGrid1.Name = "metronomeGrid1";
            this.metronomeGrid1.Size = new System.Drawing.Size(1079, 392);
            this.metronomeGrid1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 802);
            this.Controls.Add(this.metronomeGrid1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tempo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown tempo;
        private System.Windows.Forms.Button addTrackButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private MetronomeGrid metronomeGrid1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button SnapButton;
        private System.Windows.Forms.Button pauseButton;
    }

}

