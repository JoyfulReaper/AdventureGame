using System.Text;
using System.Text.Json;

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
        _advGameEngine.InitializeGame();
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
        Stream stream;
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            if ((stream = saveFileDialog1.OpenFile()) != null)
            {
                var bytes = JsonByteArraySerializer.ObjectToByteArray(_advGameEngine);
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                stream.Dispose();
                WriteLineToTextBox("Saved");
            }
        }
    }

    private void lToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Stream stream;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            if ((stream = openFileDialog1.OpenFile()) != null)
            {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                stream.Dispose();
                var test = Encoding.UTF8.GetString(bytes);
                _advGameEngine = JsonByteArraySerializer.ByteArrayToObject<Adventure>(bytes);
                WriteLineToTextBox("Loaded");
            }
        }
        outputTB.Clear();
        WriteLineToTextBox(_advGameEngine.Look());
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
