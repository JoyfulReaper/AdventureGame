using System.Text.Json.Serialization;

namespace AdventureGame.GameClasses;

public class Room : ThingHolder
{
    // Since Up and Down exits are rare, I have two constructors
    // Constructor #1, initializes all exits, including Up and Down
    public Room(string aName, string aDescription,
        Rm aN, Rm aS, Rm aW, Rm aE, Rm anUp, Rm aDown, ThingList tl)
        : base(aName, aDescription, tl)
    {
        _n = aN;
        _s = aS;
        _w = aW;
        _e = aE;
        _up = anUp;
        _down = aDown;
    }

    // Constructor #2, For Rooms with no Up and Down exits
    public Room(string aName, string aDescription,
       Rm aN, Rm aS, Rm aW, Rm aE, ThingList tl)
       : base(aName, aDescription, tl)
    {
        _n = aN;
        _s = aS;
        _w = aW;
        _e = aE;
        _up = Rm.NOEXIT;
        _down = Rm.NOEXIT;
    }

    private Rm _n;
    private Rm _s;
    private Rm _e;
    private Rm _w;
    private Rm _up;
    private Rm _down;


    public Rm N {
        get => _n;
        set => _n = value;
    }

    public Rm S {
        get => _s;
        set => _s = value;
    }

    public Rm E {
        get => _e;
        set => _e = value;
    }

    public Rm W {
        get => _w;
        set => _w = value;
    }

    public Rm Up {
        get => _up;
        set => _up = value;
    }

    public Rm Down {
        get => _down;
        set => _down = value;
    }

    public override string Describe()
    {
        string roomdesc;
        string thingsdesc;
        roomdesc = $"{Name}. This is {Description}";
        thingsdesc = Things.Describe();
        if (thingsdesc != "")
        {
            roomdesc += $"{Environment.NewLine}{Environment.NewLine}Here you can see:{Environment.NewLine}" + thingsdesc;
        }
        return roomdesc;
    }
}
