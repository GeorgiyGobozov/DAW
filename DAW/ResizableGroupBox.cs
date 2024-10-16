using System;
using System.Drawing;
using System.Windows.Forms;

public class ResizableGroupBox : GroupBox
{
    private bool isResizing = false;
    private Point lastMousePosition;
    private ResizeDirection resizeDirection;

    private enum ResizeDirection
    {
        None,
        Top,
        Bottom,
        Left,
        Right,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public ResizableGroupBox()
    {
        this.Cursor = Cursors.SizeNWSE; // Изменение курсора
        this.MouseDown += ResizableGroupBox_MouseDown;
        this.MouseMove += ResizableGroupBox_MouseMove;
        this.MouseUp += ResizableGroupBox_MouseUp;
    }

    private void ResizableGroupBox_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            resizeDirection = DetectResizeDirection(e.Location);
            if (resizeDirection != ResizeDirection.None)
            {
                isResizing = true;
                lastMousePosition = e.Location;
            }
        }
    }

    private void ResizableGroupBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResizing)
        {
            int deltaX = e.X - lastMousePosition.X;
            int deltaY = e.Y - lastMousePosition.Y;

            switch (resizeDirection)
            {
                case ResizeDirection.Bottom:
                    this.Height += deltaY;
                    break;
                case ResizeDirection.Right:
                    this.Width += deltaX;
                    break;
                case ResizeDirection.Left:
                    this.Width -= deltaX;
                    this.Left += deltaX; // Перемещение GroupBox влево
                    break;
                case ResizeDirection.Top:
                    this.Height -= deltaY;
                    this.Top += deltaY; // Перемещение GroupBox вверх
                    break;
                case ResizeDirection.TopRight:
                    this.Width += deltaX;
                    this.Height -= deltaY;
                    this.Top += deltaY; // Перемещение GroupBox вверх
                    break;
                case ResizeDirection.BottomRight:
                    this.Width += deltaX;
                    this.Height += deltaY;
                    break;
                case ResizeDirection.TopLeft:
                    this.Width -= deltaX;
                    this.Height -= deltaY;
                    this.Left += deltaX; // Перемещение GroupBox влево
                    this.Top += deltaY; // Перемещение GroupBox вверх
                    break;
                case ResizeDirection.BottomLeft:
                    this.Width -= deltaX;
                    this.Height += deltaY;
                    this.Left += deltaX; // Перемещение GroupBox влево
                    break;
            }

            // Устанавливаем последнее положение мыши
            lastMousePosition = e.Location;
        }
        else
        {
            resizeDirection = DetectResizeDirection(e.Location);
            UpdateCursor();
        }
    }

    private void ResizableGroupBox_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isResizing = false;
            resizeDirection = ResizeDirection.None;
        }
    }

    private ResizeDirection DetectResizeDirection(Point mousePosition)
    {
        if (mousePosition.X < 10 && mousePosition.Y < 10) return ResizeDirection.TopLeft;
        if (mousePosition.X > this.Width - 10 && mousePosition.Y < 10) return ResizeDirection.TopRight;
        if (mousePosition.X < 10 && mousePosition.Y > this.Height - 10) return ResizeDirection.BottomLeft;
        if (mousePosition.X > this.Width - 10 && mousePosition.Y > this.Height - 10) return ResizeDirection.BottomRight;

        if (mousePosition.X < 10) return ResizeDirection.Left;
        if (mousePosition.X > this.Width - 10) return ResizeDirection.Right;
        if (mousePosition.Y < 10) return ResizeDirection.Top;
        if (mousePosition.Y > this.Height - 10) return ResizeDirection.Bottom;

        return ResizeDirection.None;
    }

    private void UpdateCursor()
    {
        switch (resizeDirection)
        {
            case ResizeDirection.TopLeft:
            case ResizeDirection.BottomRight:
                this.Cursor = Cursors.SizeNWSE;
                break;
            case ResizeDirection.TopRight:
            case ResizeDirection.BottomLeft:
                this.Cursor = Cursors.SizeNESW;
                break;
            case ResizeDirection.Left:
            case ResizeDirection.Right:
                this.Cursor = Cursors.SizeWE;
                break;
            case ResizeDirection.Top:
            case ResizeDirection.Bottom:
                this.Cursor = Cursors.SizeNS;
                break;
            default:
                this.Cursor = Cursors.Default;
                break;
        }
    }
}
