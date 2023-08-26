namespace AdventureGame.GameClasses;
public class Room : ThingHolder
{
    public Room(string name, string description, Rm n, Rm s, Rm w, Rm e, ThingList thingList)
        : base (name, description, thingList)
    {
        _n = n;
        _s = s;
        _w = w;
        _e = e;
    }

    private Rm _n;
    private Rm _s;
    private Rm _e;
    private Rm _w;


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

    public override string Describe()
    {
        return $"[{Name}] This is {Description}" + "\r\nHere there is: " + Things.Describe();
    }
}
