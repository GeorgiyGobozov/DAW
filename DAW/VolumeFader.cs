using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class VolumeFader : Control
{
    private float value;
    private Image sliderImage;
    private Image barImage; // Изображение для полосы
    private Color slideColor = Color.Blue;
    private int sliderWidth = 24; // Ширина ползунка
    private const int sliderHeight = 50; // Высота ползунка
    private int barWidth = 10; // Ширина полосы

    [Browsable(true)]
    [Category("Appearance")]
    [Description("Изображение для ползунка.")]
    public Image SliderImage
    {
        get => sliderImage;
        set
        {
            sliderImage = value;
            Invalidate(); // Перерисовать
        }
    }

    [Browsable(true)]
    [Category("Appearance")]
    [Description("Изображение для полосы слайдера.")]
    public Image BarImage
    {
        get => barImage;
        set
        {
            barImage = value;
            Invalidate(); // Перерисовать
        }
    }

    [Browsable(true)]
    [Category("Appearance")]
    [Description("Цвет полосы слайдера.")]
    public Color SlideColor
    {
        get => slideColor;
        set
        {
            slideColor = value;
            Invalidate();
        }
    }

    [Browsable(true)]
    [Category("Appearance")]
    [Description("Ширина полосы слайдера.")]
    public int BarWidth
    {
        get => barWidth;
        set
        {
            barWidth = Math.Max(1, value); // Минимальное значение 1 пиксель
            Invalidate();
        }
    }

    [Browsable(true)]
    [Category("Appearance")]
    [Description("Ширина ползунка.")]
    public int SliderWidth
    {
        get => sliderWidth;
        set
        {
            sliderWidth = Math.Max(1, value); // Минимальное значение 1 пиксель
            Invalidate();
        }
    }

    public float Value
    {
        get => value;
        set
        {
            this.value = Math.Min(Math.Max(value, 0), 1);
            Invalidate(); // Перерисовать
        }
    }

    public VolumeFader()
    {
        this.DoubleBuffered = true;
        this.Height = 220;
        this.Width = 90;
        this.BackColor = System.Drawing.SystemColors.GrayText;
        this.BackgroundImage = global::DAW.Properties.Resources.Scale;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.BarImage = global::DAW.Properties.Resources.bar;
        this.BarWidth = 10;
        this.Location = new System.Drawing.Point(6, 19);
        this.Name = "volumeFader1";
        this.Size = new System.Drawing.Size(90, 220);
        this.SlideColor = System.Drawing.Color.Blue;
        this.SliderImage = global::DAW.Properties.Resources.slider;
        this.SliderWidth = 24;
        this.TabIndex = 0;
        this.Text = "volumeFader1";
        this.Value = 0F;

        this.MouseDown += VolumeFader_MouseDown;
        this.MouseUp += VolumeFader_MouseUp;
        this.MouseMove += VolumeFader_MouseMove;
        this.DoubleClick += VolumeFader_DoubleClick; // Для изменения изображения
    }


    private bool isDragging = false;

    private void VolumeFader_MouseDown(object sender, MouseEventArgs e)
    {
        isDragging = true;
        UpdateValue(e.Y);
    }

    private void VolumeFader_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            UpdateValue(e.Y);
        }
    }

    private void VolumeFader_MouseUp(object sender, MouseEventArgs e)
    {
        isDragging = false;
    }

    private void UpdateValue(int mouseY)
    {
        int y = Math.Max(0, Math.Min(Height - 70, mouseY - (sliderHeight / 2))); // Убираем смещение от 20
        Value = 1 - (float)y / (Height - 70);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        // Вычисляем координаты полосы
        int barX = (Width - barWidth) / 2; // Центрирование полосы
        int barHeight = Height - sliderHeight - 2; // Высота полосы
        int barY = sliderHeight/2 + 1; // Положение начала полосы

        // Рисуем полосу
        if (barImage != null)
        {
            g.DrawImage(barImage, new Rectangle(barX, barY, barWidth, barHeight));
        }
        else
        {
            g.FillRectangle(Brushes.Gray, barX, barY, barWidth, barHeight); // Используем цвет, если нет изображения
        }

        // Рисуем ползунок
        int sliderY = (int)((1 - Value) * (barHeight)) + barY; // Позиция ползунка
        if (sliderImage != null)
        {
            g.DrawImage(sliderImage, new Rectangle((Width - sliderWidth) / 2, sliderY - (sliderHeight / 2), sliderWidth, sliderHeight)); // Центрируем ползунок
        }
        else
        {
            // Рисуем прямоугольник с заданным цветом
            g.FillRectangle(new SolidBrush(SlideColor), new Rectangle((Width - sliderWidth) / 2, sliderY - (sliderHeight / 2), sliderWidth, sliderHeight)); // Центрируем ползунок
        }
    }

    private void VolumeFader_DoubleClick(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SliderImage = Image.FromFile(openFileDialog.FileName); // Загружаем изображение
            }
        }
    }
}