namespace AdventureGame.GameClasses;
public class Room : Thing
{
    public Room(string name, string description, int n, int s, int w, int e)
        : base (name, description)
    {
        _n = n;
        _s = s;
        _w = w;
        _e = e;
    }

    private int _n;
    private int _s;
    private int _e;
    private int _w;


    public int N {
        get => _n;
        set => _n = value;
    }

    public int S {
        get => _s;
        set => _s = value;
    }

    public int E {
        get => _e;
        set => _e = value;
    }

    public int W {
        get => _w;
        set => _w = value;
    }
}
