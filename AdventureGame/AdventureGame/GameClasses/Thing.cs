namespace AdventureGame.GameClasses;

public class Thing
{
    private string _name = default!;
    private string _description = default!;
    private bool _takeable;
    private bool _movable;

    public Thing(string name, string description)
    {
        _description = description;
        _name = name;
        _takeable = true; // set default value
        _movable = true; // set default value
    }

    public Thing(string name, string description, bool isTakable, bool isMoveable)
    {
        _description = description;
        _name = name;
        _takeable = isTakable;
        _movable = isMoveable;
    }

    public string Name {
        get => _name;
        set => _name = value;
    }

    public string Description   // Description property
    {
        get => _description;
        set => _description = value;
    }

    public bool Takeable {
        get => _takeable;
        set => _takeable = value;
    }

    public bool Movable {
        get => _movable;
        set => _movable = value;
    }

    public virtual string Describe() =>
        $"{Name} {Description}";
}
