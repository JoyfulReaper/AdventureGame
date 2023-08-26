using AdventureGame.GameClasses;
using System.Runtime.Serialization.Formatters.Binary;

namespace AdventureGame;

public partial class Form1 : Form
{
    private Adventure _adv = default!;

    public Form1()
    {
        InitializeComponent();
        InitGame();
        StartGame();
    }

    private void InitGame()
    {
        _adv = new Adventure();
    }

    private void StartGame()
    {
        outputTB.Text = $"Welcome to the Great Adventure!{Environment.NewLine}You are in the {_adv.Player.Location.Name}. It is {_adv.Player.Location.Description}{Environment.NewLine}";
        outputTB.AppendText($"Where do you want to go now?{Environment.NewLine}");
        outputTB.AppendText($"Click a direction button: N, S, W or E.{Environment.NewLine}");
    }

    private void WriteToTextBox(string s)
    {
        outputTB.AppendText(s);
    }

    private void WriteLineToTextBox(string s)
    {
        WriteToTextBox(s + Environment.NewLine);
    }

    private void MovePlayer(Dir direction)
    {
        outputTB.Text = _adv.MovePlayerTo(direction);
    }

    private void NBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.NORTH);
    }

    private void SBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.SOUTH);
    }

    private void WBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.WEST);
    }

    private void EBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.EAST);
    }

    private void ShowLocation()
    {
        WriteToTextBox(_adv.Player.Name);
        WriteToTextBox(" are currently in this room: ");
        WriteLineToTextBox(_adv.Player.Location.Describe());
    }

    private void LookBtn_Click(object sender, EventArgs e)
    {
        ShowLocation();
    }

    private void TakeBtn_Click(object sender, EventArgs e)
    {
        WriteLineToTextBox(_adv.TakeOb(inputTB.Text));
    }

    private void DropBtn_Click(object sender, EventArgs e)
    {
        WriteLineToTextBox(_adv.DropOb(inputTB.Text));
    }

    private void ShowInventory()
    {
        WriteLineToTextBox($"You have {_adv.Player.Things.Describe()}");
    }

    private void InventoryBtn_Click(object sender, EventArgs e)
    {
        ShowInventory();
    }

    private void LookAtBtn_Click(object sender, EventArgs e)
    {
        WriteLineToTextBox(_adv.LookAtOb(inputTB.Text));
    }

    private void inputTB_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            WriteLineToTextBox(_adv.LookAtOb(inputTB.Text));
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Stream stream;
        BinaryFormatter binaryFormatter;
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            if ((stream = saveFileDialog1.OpenFile()) != null)
            {
                binaryFormatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011
                binaryFormatter.Serialize(stream, _adv); //TODO: https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-security-guide
#pragma warning restore SYSLIB0011
                stream.Close();
                WriteLineToTextBox("Saved");
            }
        }
    }

    private void lToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Stream stream;
        BinaryFormatter binaryFormatter;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            if ((stream = openFileDialog1.OpenFile()) != null)
            {
                binaryFormatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011
                _adv = (Adventure)binaryFormatter.Deserialize(stream); //TODO: https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-security-guide
#pragma warning restore SYSLIB0011
                stream.Close();
            }
        }
        outputTB.Clear();
        ShowLocation();
    }

    private void restartToolStripMenuItem_Click(object sender, EventArgs e)
    {
        InitGame();
    }
}
