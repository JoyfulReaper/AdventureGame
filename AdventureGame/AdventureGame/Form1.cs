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

    private RoomList _map = default!;

    private Actor _player = default!;

    public Form1()
    {
        InitializeComponent();
        InitGame();
        StartGame();
    }

    private void InitGame()
    {
        _room0 = new Room("Troll Room", "a dank, dark room that smells of troll", Rm.NOEXIT, Rm.Cave, Rm.NOEXIT, Rm.Forest);
        _room1 = new Room("Forest", "a light, airy forest shimmering with sunlight", Rm.NOEXIT, Rm.NOEXIT, Rm.TrollRoom, Rm.NOEXIT);
        _room2 = new Room("Cave", "a vast cave with walls covered by luminous moss", Rm.TrollRoom, Rm.NOEXIT, Rm.NOEXIT, Rm.Dungeon);
        _room3 = new Room("Dungeon", "a gloomy dungeon. Rats scurry across its floor", Rm.NOEXIT, Rm.NOEXIT, Rm.Cave, Rm.NOEXIT);

        _map = new RoomList {
            { Rm.TrollRoom, _room0 },
            { Rm.Forest, _room1 },
            { Rm.Cave, _room2 },
            { Rm.Dungeon, _room3 }
        };

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

    private void MovePlayer(Rm newpos)
    {
        if (newpos == Rm.NOEXIT)
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
