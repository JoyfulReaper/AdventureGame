using System.Runtime.Serialization.Formatters.Binary;

namespace AdventureGame;

public partial class frmAdventure : Form
{
    private Adventure _advGameEngine = default!;

    public frmAdventure()
    {
        InitializeComponent();
        InitGame();
    }

    private void InitGame()
    {
        _advGameEngine = new Adventure();
        StartGame();
    }

    private void StartGame()
    {
        WriteLineToTextBox($"Welcome to the Dark Neon City --- a futuristic Victorian adventure game");
        WriteLineToTextBox(_advGameEngine.Look());
        WriteLineToTextBox("Where do you want to go now?");
        WriteLineToTextBox("Click a direction button: N, S, W or E or enter a command");
    }

    private void WriteToTextBox(string s)
    {
        // utility method to append text to textbox
        outputTB.AppendText(s);
    }

    private void WriteLineToTextBox(string s)
    {
        // simple utility method that appends carriage-return/linefeed before caling WriteToTextBox()
        WriteToTextBox(s + Environment.NewLine);
    }

    private void ShowInventory()
    {        
        WriteLineToTextBox($"You have {_advGameEngine.Player.Things.Describe()}");
    }

    private void LookBtn_Click(object sender, EventArgs e)
    {
        WriteLineToTextBox(_advGameEngine.Look());
    }

    private void MovePlayer(Dir direction)
    {
        WriteLineToTextBox(_advGameEngine.MovePlayerTo(direction));
    }

    private void NBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.NORTH);
    }

    private void WBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.WEST);
    }

    private void EBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.EAST);
    }

    private void SBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.SOUTH);
    }

    private void UpBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.UP);
    }

    private void DownBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(Dir.DOWN);
    }

    private void TakeBtn_Click(object sender, EventArgs e)
    {
        WriteLineToTextBox(_advGameEngine.TakeOb(inputTB.Text));
    }

    private void DropBtn_Click(object sender, EventArgs e)
    {
        WriteLineToTextBox(_advGameEngine.DropOb(inputTB.Text));
    }

    private void InventoryBtn_Click(object sender, EventArgs e)
    {
        ShowInventory();
    }

    private void LookAtBtn_Click(object sender, EventArgs e)
    {
        WriteLineToTextBox(_advGameEngine.LookAtOb(inputTB.Text));
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // TODO - Serialze to JSON or something other that BinaryFormatter
        Stream stream;
        BinaryFormatter binaryFormatter;
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            if ((stream = saveFileDialog1.OpenFile()) != null)
            {
                binaryFormatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011
                binaryFormatter.Serialize(stream, _advGameEngine); //TODO: https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-security-guide
#pragma warning restore SYSLIB0011
                stream.Close();
                WriteLineToTextBox("Saved");
            }
        }
    }

    private void lToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // TODO - Deserialize from JSON or something other that BinaryFormatter
        Stream stream;
        BinaryFormatter binaryFormatter;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            if ((stream = openFileDialog1.OpenFile()) != null)
            {
                binaryFormatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011
                _advGameEngine = (Adventure)binaryFormatter.Deserialize(stream); //TODO: https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-security-guide
#pragma warning restore SYSLIB0011
                stream.Close();
            }
        }
        outputTB.Clear();
        _advGameEngine.Look();
    }

    private void restartToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you would like to restart the game and lose all progress?",
            "Restart the game?",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
            InitGame();
    }


    private void inputTB_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            WriteLineToTextBox(_advGameEngine.LookAtOb(inputTB.Text));
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }


    private void cmdTB_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            WriteLineToTextBox(_advGameEngine.RunCommand(cmdTB.Text));
            cmdTB.Clear();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }

    private void cmdBtn_Click(object sender, EventArgs e)
    {
        WriteLineToTextBox(_advGameEngine.RunCommand(cmdTB.Text));
    }
}
