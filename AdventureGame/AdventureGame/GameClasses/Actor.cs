namespace AdventureGame.GameClasses;

public class Actor : Thing
{
    private Room _location = default!;

    public Actor(string name, string description, Room room) :
        base(name, description)
    {
        _location = room;
    }

    public Room Location {
        get => _location;
        set => _location = value;
    }
}
