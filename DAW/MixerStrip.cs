using CuoreUI.Controls;
using System;
using System.Windows.Forms;

public class MixerStrip : UserControl
{
    private Label Name;
    private cuiButton singleButton;
    private cuiButton muteButton;
    private PanSlider panSlider;
    private VolumeFader volumeFader;

    public MixerStrip(string trackName)
    {
        this.Width = 104;
        this.Height = 310;
        this.BorderStyle = BorderStyle.FixedSingle;
        this.Margin = new System.Windows.Forms.Padding(0);
        this.BackColor = System.Drawing.SystemColors.GrayText;
        this.Cursor = System.Windows.Forms.Cursors.Default;
        InitializeComponents(trackName);
    }
    public MixerStrip()
    {
        this.Width = 104;
        this.Height = 310;
        this.BorderStyle = BorderStyle.FixedSingle;
        this.Margin = new System.Windows.Forms.Padding(0);
        this.BackColor = System.Drawing.SystemColors.GrayText;
        this.Cursor = System.Windows.Forms.Cursors.Default;
        InitializeComponents("newTrack");
    }
    private void InitializeComponents(string trackName)
    {

        // Инициализация элементов управления
        Name = new Label { 
        Text = trackName,
        Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F),
            ForeColor = System.Drawing.Color.White
        };
        singleButton = new cuiButton
        {
        CheckButton = true,
        Checked = false,
        CheckedBackground = System.Drawing.Color.Red,
        CheckedImageTint = System.Drawing.Color.White,
        CheckedOutline = System.Drawing.Color.Silver,
        Content = "S",
        Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F),
        ForeColor = System.Drawing.Color.White,
        HoverBackground = System.Drawing.Color.Gray,
        HoveredImageTint = System.Drawing.Color.White,
        HoverOutline = System.Drawing.Color.Silver,
        Image = null,
        ImageAutoCenter = true,
        ImageExpand = new System.Drawing.Point(0, 0),
        ImageOffset = new System.Drawing.Point(0, 0),
        ImageTint = System.Drawing.Color.White,
        Location = new System.Drawing.Point(52, 25),
        Name = "cuiButton2",
        NormalBackground = System.Drawing.Color.Gray,
        NormalOutline = System.Drawing.Color.Silver,
        OutlineThickness = 1.6F,
        PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
        PressedImageTint = System.Drawing.Color.White,
        PressedOutline = System.Drawing.Color.DarkGray,
        Rounding = new System.Windows.Forms.Padding(3),
        Size = new System.Drawing.Size(19, 19),
        TabIndex = 3,
        TextOffset = new System.Drawing.Point(0, 0)
    };
        muteButton = new cuiButton { 
        CheckButton = true,
        Checked = false,
        CheckedBackground = System.Drawing.Color.Orange,
        CheckedImageTint = System.Drawing.Color.White,
        CheckedOutline = System.Drawing.Color.Silver,
        Content = "M",
        Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F),
        ForeColor = System.Drawing.Color.White,
        HoverBackground = System.Drawing.Color.Gray,
        HoveredImageTint = System.Drawing.Color.White,
        HoverOutline = System.Drawing.Color.Silver,
        Image = null,
        ImageAutoCenter = true,
        ImageExpand = new System.Drawing.Point(0, 0),
        ImageOffset = new System.Drawing.Point(0, 0),
        ImageTint = System.Drawing.Color.White,
        Location = new System.Drawing.Point(77, 25),
        Name = "cuiButton1",
        NormalBackground = System.Drawing.Color.Gray,
        NormalOutline = System.Drawing.Color.Silver,
        OutlineThickness = 1.6F,
        PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
        PressedImageTint = System.Drawing.Color.White,
        PressedOutline = System.Drawing.Color.DarkGray,
        Rounding = new System.Windows.Forms.Padding(3),
        Size = new System.Drawing.Size(19, 19),
        TabIndex = 2,
        TextOffset = new System.Drawing.Point(0, 0)
    };
        panSlider = new PanSlider
        {
        BackColor = System.Drawing.SystemColors.GrayText,
        BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
        Location = new System.Drawing.Point(6, 50),
        Name = "panSlider2",
        Pan = 0F,
        Size = new System.Drawing.Size(90, 19),
        TabIndex = 2
    };
        volumeFader = new VolumeFader
        {
            Location = new System.Drawing.Point(6, 75),
            Value = 0.76f
    };

        // Добавление элементов управления в пользовательский элемент
        Controls.Add(Name);
        Controls.Add(singleButton);
        Controls.Add(muteButton);
        Controls.Add(panSlider);
        Controls.Add(volumeFader);
    }


}
