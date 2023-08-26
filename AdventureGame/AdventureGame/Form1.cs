using AdventureGame.GameClasses;

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
}
