using System.Text.Json.Serialization;

namespace AdventureGame.GameClasses;

[Serializable]
public class Room : Container
{
    // Since Up and Down exits are rare, I have two constructors
    // Constructor #1, initializes all exits, including Up and Down
    public Room(string name, string description,
        RoomId n, RoomId s, RoomId w, RoomId e, RoomId up, RoomId down, Inventory inventory)
        : base(name, description, inventory)
    {
        N = n;
        S = s;
        W = w;
        E = e;
        Up = up;
        Down = down;
    }

    // Constructor #2, For Rooms with no Up and Down exits
    public Room(string name, string description,
       RoomId n, RoomId s, RoomId w, RoomId e, Inventory inventory)
       : base(name, description, inventory)
    {
        N = n;
        S = s;
        W = w;
        E = e;
        Up = RoomId.NOEXIT;
        Down = RoomId.NOEXIT;
    }

    public RoomId N { get; set; }
    public RoomId S { get; set; }
    public RoomId E { get; set; }
    public RoomId W { get; set; }
    public RoomId Up { get; set; }
    public RoomId Down { get; set; }

    public override string Describe()
    {
        string roomdesc;
        string thingsdesc;
        roomdesc = $"{Name}. This is {Description}";
        thingsdesc = Inventory.Describe();
        if (thingsdesc != "")
        {
            roomdesc += $"{Environment.NewLine}{Environment.NewLine}Here you can see:{Environment.NewLine}" + thingsdesc;
        }
        return roomdesc;
    }
}
