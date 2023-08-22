namespace AdventureGame;

public partial class Form1 : Form
{

    /*
    * 
    * Troll Room -- Forest
    *    |
    *  Cave  -----  Dungeon  
    * */

    Room room0;
    Room room1;
    Room room2;
    Room room3;

    Room[] map;

    int position;

    public Form1()
    {
        InitializeComponent();
        InitGame();
        StartGame();
    }

    private void InitGame()
    {
        room0 = new Room();
        room1 = new Room();
        room2 = new Room();
        room3 = new Room();

        map = new Room[4];

        map[0] = room0;
        map[1] = room1;
        map[2] = room2;
        map[3] = room3;

        room0.Name = "Troll Room";
        room0.Description = "a dank, dark room that smells of troll";
        room0.n = -1;
        room0.s = 2;
        room0.w = -1;
        room0.e = 1;

        room1.Name = "Forest";
        room1.Description = "a light, airy forest shimmering with sunlight";
        room1.n = -1;
        room1.s = -1;
        room1.w = 0;
        room1.e = -1;

        room2.Name = "Cave";
        room2.Description = "a vast cave with walls covered by luminous moss";
        room2.n = 0;
        room2.s = -1;
        room2.w = -1;
        room2.e = 3;

        room3.Name = "Dungeon";
        room3.Description = "a gloomy dungeon. Rats scurry across its floor";
        room3.n = -1;
        room3.s = -1;
        room3.w = 2;
        room3.e = -1;

        position = 0;
    }

    private void StartGame()
    {
        outputTB.Text = $"Welcome to the Great Adventure!\r\n";
        outputTB.AppendText($"You are in the {map[position].Name}.");
        outputTB.AppendText($"It is {map[position].Description}\r\n");
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
            position = newpos;
            outputTB.Text = $"You are now in the {map[position].Name}\r\n";
        }
    }

    private void NBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(map[position].n);
    }

    private void SBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(map[position].s);
    }

    private void WBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(map[position].w);
    }

    private void EBtn_Click(object sender, EventArgs e)
    {
        MovePlayer(map[position].e);
    }

    private void LookBtn_Click(object sender, EventArgs e)
    {
        outputTB.Text = $"You are in the {map[position].Name}.\r\n";
        outputTB.AppendText($"It is {map[position].Description}\r\n");
    }
}
