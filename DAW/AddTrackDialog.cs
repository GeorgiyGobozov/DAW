using System;
using System.Windows.Forms;

public class InputDialog : Form
{
    private TextBox textBox;
    private Button okButton;
    private Button cancelButton;

    public string InputText { get; private set; }

    public InputDialog(string title, string prompt)
    {
        this.Text = title;
        this.Size = new System.Drawing.Size(300, 150);

        Label label = new Label { Left = 20, Top = 20, Text = prompt, AutoSize = true };
        textBox = new TextBox { Left = 20, Top = 50, Width = 240 };
        okButton = new Button { Text = "OK", Left = 60, Top = 80, DialogResult = DialogResult.OK };
        cancelButton = new Button { Text = "Cancel", Left = 160, Top = 80, DialogResult = DialogResult.Cancel };

        okButton.Click += (sender, e) => { InputText = textBox.Text; this.Close(); };
        cancelButton.Click += (sender, e) => { this.Close(); };

        this.Controls.Add(label);
        this.Controls.Add(textBox);
        this.Controls.Add(okButton);
        this.Controls.Add(cancelButton);

        this.AcceptButton = okButton;
        this.CancelButton = cancelButton;
    }
}
