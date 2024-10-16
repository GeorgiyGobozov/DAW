#region сборка NAudio.WinForms, Version=2.2.1.0, Culture=neutral, PublicKeyToken=e279aa5131008a41
// C:\Users\Гоша\Desktop\DAW\packages\NAudio.WinForms.2.2.1\lib\net472\NAudio.WinForms.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

//
// Сводка:
//     Pan slider control
public class PanSlider : UserControl
{
    //
    // Сводка:
    //     Required designer variable.
    private Container components;

    private float pan;

    //
    // Сводка:
    //     The current Pan setting
    public float Pan
    {
        get
        {
            return pan;
        }
        set
        {
            if (value < -1f)
            {
                value = -1f;
            }

            if (value > 1f)
            {
                value = 1f;
            }

            if (value != pan)
            {
                pan = value;
                if (this.PanChanged != null)
                {
                    this.PanChanged(this, EventArgs.Empty);
                }

                Invalidate();
            }
        }
    }

    //
    // Сводка:
    //     True when pan value changed
    public event EventHandler PanChanged;

    //
    // Сводка:
    //     Creates a new PanSlider control
    public PanSlider()
    {
        InitializeComponent();
    }

    //
    // Сводка:
    //     Clean up any resources being used.
    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    //
    // Сводка:
    //     Required method for Designer support - do not modify the contents of this method
    //     with the code editor.
    private void InitializeComponent()
    {
        base.Name = "PanSlider";
        base.Size = new System.Drawing.Size(104, 16);
    }

    //
    // Сводка:
    //     System.Windows.Forms.Control.OnPaint(System.Windows.Forms.PaintEventArgs)
    protected override void OnPaint(PaintEventArgs pe)
    {
        StringFormat stringFormat = new StringFormat();
        stringFormat.LineAlignment = StringAlignment.Center;
        stringFormat.Alignment = StringAlignment.Center;
        string s;
        if ((double)pan == 0.0)
        {
            pe.Graphics.FillRectangle(Brushes.DarkViolet, base.Width / 2 - 1, 1, 3, base.Height - 2);
            s = "C";
        }
        else if (pan > 0f)
        {
            pe.Graphics.FillRectangle(Brushes.DarkViolet, base.Width / 2, 1, (int)((float)(base.Width / 2) * pan), base.Height - 2);
            s = $"{pan * 100f:F0}%R";
        }
        else
        {
            pe.Graphics.FillRectangle(Brushes.DarkViolet, (int)((float)(base.Width / 2) * (pan + 1f)), 1, (int)((float)(base.Width / 2) * (0f - pan)), base.Height - 2);
            s = $"{pan * -100f:F0}%L";
        }

        pe.Graphics.DrawRectangle(Pens.Black, 0, 0, base.Width - 1, base.Height - 1);
        pe.Graphics.DrawString(s, Font, Brushes.White, base.ClientRectangle, stringFormat);
    }

    //
    // Сводка:
    //     System.Windows.Forms.Control.OnMouseMove(System.Windows.Forms.MouseEventArgs)
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            SetPanFromMouse(e.X);
        }

        base.OnMouseMove(e);
    }

    //
    // Сводка:
    //     System.Windows.Forms.Control.OnMouseDown(System.Windows.Forms.MouseEventArgs)
    //
    //
    // Параметры:
    //   e:
    protected override void OnMouseDown(MouseEventArgs e)
    {
        SetPanFromMouse(e.X);
        base.OnMouseDown(e);
    }

    private void SetPanFromMouse(int x)
    {
        Pan = (float)x / (float)base.Width * 2f - 1f;
    }
}
#if false // Журнал декомпиляции
Элементов в кэше: "61"
------------------
Разрешить: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\mscorlib.dll"
------------------
Разрешить: "NAudio.WinMM, Version=2.2.1.0, Culture=neutral, PublicKeyToken=e279aa5131008a41"
Найдена одна сборка: "NAudio.WinMM, Version=2.2.1.0, Culture=neutral, PublicKeyToken=e279aa5131008a41"
Загрузить из: "C:\Users\Гоша\Desktop\DAW\packages\NAudio.WinMM.2.2.1\lib\netstandard2.0\NAudio.WinMM.dll"
------------------
Разрешить: "NAudio.Core, Version=2.2.1.0, Culture=neutral, PublicKeyToken=e279aa5131008a41"
Найдена одна сборка: "NAudio.Core, Version=2.2.1.0, Culture=neutral, PublicKeyToken=e279aa5131008a41"
Загрузить из: "C:\Users\Гоша\Desktop\DAW\packages\NAudio.Core.2.2.1\lib\netstandard2.0\NAudio.Core.dll"
------------------
Разрешить: "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.Windows.Forms.dll"
------------------
Разрешить: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.dll"
------------------
Разрешить: "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.Drawing.dll"
#endif
