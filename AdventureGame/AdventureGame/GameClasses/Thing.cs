namespace AdventureGame.GameClasses;

public class Thing
{
    public Thing(string name, string description)
    {
        _description = description;
        _name = name;
    }

    private string _name = default!;
    private string _description = default!;

    public string Name {
        get => _name;
        set => _name = value;
    }

    public string Description {
        get => _description;
        set => _description = value;
    }
}
