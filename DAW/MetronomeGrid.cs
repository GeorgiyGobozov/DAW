using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class MetronomeGrid : UserControl
{
    private List<GridLine> gridLines; // Линии сетки
    private int linePosition; // Позиция красной линии
    private int gridSpacing = 50; // Расстояние между линиями сетки
    private int tickInterval = 1000; // Интервал в миллисекундах (1 секунда)
    private CancellationTokenSource cancellationTokenSource;
    private Task updateLineTask; // Задача для обновления линии
    private Task redrawTask; // Задача для отрисовки
    private object lockObject = new object(); // Объект для синхронизации

    public MetronomeGrid()
    {
        //InitializeComponent(); // Вызов сгенерированного метода

        gridLines = new List<GridLine>();
        linePosition = 0; // Начальное положение линии
        cancellationTokenSource = new CancellationTokenSource();

        CreateGridLines(); // Создание линий сетки

        StartTasks(); // Запуск задач
    }

    // Создание линий сетки с определённым интервалом
    private void CreateGridLines()
    {
        for (int i = 0; i < this.Width; i += gridSpacing)
        {
            gridLines.Add(new GridLine(i));
        }
    }

    // Запуск задач для движения линии и перерисовки
    private void StartTasks()
    {
        // Задача для обновления положения линии
        updateLineTask = Task.Run(() => UpdateLine(cancellationTokenSource.Token), cancellationTokenSource.Token);

        // Задача для перерисовки UI
        redrawTask = Task.Run(() => RedrawGrid(cancellationTokenSource.Token), cancellationTokenSource.Token);
    }

    // Метод для обновления положения линии
    private void UpdateLine(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            lock (lockObject)
            {
                // Обновляем положение линии
                linePosition += gridSpacing;

                // Если линия вышла за пределы контрола, начинаем заново
                if (linePosition >= this.Width)
                {
                    linePosition = 0;
                }
            }

            // Задержка в 1 секунду
            Task.Delay(tickInterval).Wait();
        }
    }

    // Метод для перерисовки UI
    private void RedrawGrid(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            // Вызываем перерисовку в UI потоке
            this.Invoke(new Action(() => this.Invalidate()));

            // Задержка в 1 миллисекунду перед следующей отрисовкой
            Task.Delay(1).Wait();
        }
    }

    // Метод для отрисовки сетки и красной линии
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        lock (lockObject)
        {
            // Отрисовка сетки
            foreach (var gridLine in gridLines)
            {
                gridLine.Draw(e.Graphics, 0, this.Height);
            }

            // Отрисовка красной линии
            using (Pen redPen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawLine(redPen, linePosition, 0, linePosition, this.Height);
            }
        }
    }

    // Остановка задач при закрытии контрола
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }
        base.Dispose(disposing);
    }
}

// Класс для представления линий сетки
public class GridLine
{
    public int PositionX { get; }

    public GridLine(int positionX)
    {
        PositionX = positionX;
    }

    public void Draw(Graphics g, int startY, int endY)
    {
        using (Pen pen = new Pen(Color.Gray))
        {
            g.DrawLine(pen, PositionX, startY, PositionX, endY);
        }
    }
}
