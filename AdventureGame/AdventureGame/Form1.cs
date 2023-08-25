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

    private void Wr(string s)
    {
        outputTB.AppendText(s);
    }

    private void WrLn(string s)
    {
        Wr(s + Environment.NewLine);
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

    private void LookBtn_Click(object sender, EventArgs e)
    {
        outputTB.Text = $"You are in the {_adv.Player.Location.Name}. It is {_adv.Player.Location.Description}{Environment.NewLine}";
    }

    private void TakeBtn_Click(object sender, EventArgs e)
    {
        WrLn(_adv.TakeOb(inputTB.Text));
    }
}
