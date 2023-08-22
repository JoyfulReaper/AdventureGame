using AdventureGame.GameClasses;

namespace AdventureGame;

public partial class Form1 : Form
{

    /*
    * 
    * Troll Room -- Forest
    *    |
    *  Cave  -----  Dungeon  
    * */

    Room _room0 = default!;
    Room _room1 = default!;
    Room _room2 = default!;
    Room _room3 = default!;

    Room[] _map = default!;

    private Actor _player = default!;

    public Form1()
    {
        InitializeComponent();
        InitGame();
        StartGame();
    }

    private void InitGame()
    {
        _room0 = new Room("Troll Room", "a dank, dark room that smells of troll", -1, 2, -1, 1);
        _room1 = new Room("Forest", "a light, airy forest shimmering with sunlight", -1, -1, 0, -1);
        _room2 = new Room("Cave", "a vast cave with walls covered by luminous moss", 0, -1, -1, 3);
        _room3 = new Room("Dungeon", "a gloomy dungeon. Rats scurry across its floor", -1, -1, 2, -1);

        _map = new Room[4];

        _map[0] = _room0;
        _map[1] = _room1;
        _map[2] = _room2;
        _map[3] = _room3;

        _player = new Actor("You", "The Player", _room0);
    }

    private void StartGame()
    {
        outputTB.Text = $"Welcome to the Great Adventure!\r\n";
        outputTB.AppendText($"You are in the {_player.Location.Name}.");
        outputTB.AppendText($"It is {_player.Location.Description}\r\n");
        outputTB.AppendText("Where do you want to go now?\r\n");
        outputTB.AppendText("Click a direction button: N, S, W or E.\r\n");
    }

    private void MovePlayer(int newpos)
    {
        if (newpos == -1)
        {
            outputTB.Text = "There is no exit in that direction\r\n";
        }
        else
        {
            _player.Location = _map[newpos];
            outputTB.Text = $"You are in the {_player.Location.Name}.\r\n";
        }
    }

    private void NBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(_player.Location.N);
    }

    private void SBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(_player.Location.S);
    }

    private void WBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(_player.Location.W);
    }

    private void EBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(_player.Location.E);
    }

    private void LookBtn_Click(object sender, EventArgs e)
    {
        outputTB.Text = $"You are in the {_player.Location.Name}.\r\n";
        outputTB.AppendText($"It is {_player.Location.Description}\r\n");
    }
}
