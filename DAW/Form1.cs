using System;
using System.Drawing;
using System.Windows.Forms;

namespace DAW
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true; // Разрешаем перетаскивание на форму
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Изменяем эффект перетаскивания
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop); // Получаем файлы
            foreach (var file in files)
            {
                // Проверяем, что это аудиофайл (например, mp3 или wav) и добавляем его
                if (file.EndsWith(".mp3") || file.EndsWith(".wav"))
                {
                    AddTrack(file);
                }
            }
        }
        private void AddTrack(string filePath)
        {
            using (InputDialog inputDialog = new InputDialog("Введите название дорожки", "Название:"))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    string trackName = inputDialog.InputText;

                    // Создание нового MixerStrip и установка названия дорожки
                    MixerStrip mixerStrip = new MixerStrip(trackName);
                    flowLayoutPanel1.Controls.Add(mixerStrip);
                    //metronomeGrid1.AddTrack(filePath); // Добавляем дорожку в MetronomeGrid
                }
            }
        }
        private void addTrackButton_Click(object sender, EventArgs e)
        {
            using (InputDialog inputDialog = new InputDialog("Введите название дорожки", "Название:"))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    string trackName = inputDialog.InputText;

                    // Создание нового MixerStrip и установка названия дорожки
                    MixerStrip mixerStrip = new MixerStrip(trackName);
                    flowLayoutPanel1.Controls.Add(mixerStrip);
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //metronomeGrid1.TogglePlay();
            
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            //metronomeGrid1.Stop();
        }

        private void tempo_ValueChanged(object sender, EventArgs e)
        {
            //metronomeGrid1.SetTempo((int)(tempo.Value));
        }

        private void SnapButton_Click(object sender, EventArgs e)
        {
            bool isEnabled = !SnapButton.BackColor.Equals(Color.LightGreen);
            //metronomeGrid1.SetSnapToGridEnabled(isEnabled);
            SnapButton.BackColor = isEnabled ? Color.LightGreen : DefaultBackColor;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            //metronomeGrid1.Pause();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
