using System;
using System.Windows.Forms;
using NAudio.Wave;

public class Metronome : IDisposable
{
    private Timer timer;
    private IWavePlayer waveOut;
    private AudioFileReader audioFileReader;

    public Metronome(string soundFilePath)
    {
        timer = new Timer();
        waveOut = new WaveOutEvent();
        audioFileReader = new AudioFileReader(soundFilePath);
        waveOut.Init(audioFileReader);
    }

    public void Start(int bpm)
    {
        PlaySound();
        timer.Interval = CalculateInterval(bpm);
        timer.Tick += (sender, e) => PlaySound();
        timer.Start();
    }

    public void Stop()
    {
        timer.Stop();
        waveOut.Stop();
    }

    private int CalculateInterval(int bpm)
    {
        return 60000 / bpm; // Минимальный интервал в миллисекундах
    }

    private void PlaySound()
    {
        try
        {
            audioFileReader.Position = 0; // Сбрасываем позицию
            waveOut.Play(); // Воспроизводим звук
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing sound: " + ex.Message);
        }
    }

    public void Dispose()
    {
        waveOut?.Dispose();
        audioFileReader?.Dispose();
        timer?.Dispose();
    }
}
