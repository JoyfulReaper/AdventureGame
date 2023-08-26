namespace AdventureGame.GameClasses;

[Serializable]
public class Actor : ThingHolder
{
    private Room _location = default!; // Room where Actor is at present

    public Actor(string name, string description, Room room, ThingList thingList) :
        base(name, description, thingList)
    {
        _location = room;
    }

    public Room Location {
        get => _location;
        set => _location = value;
    }

    public override string Describe() =>
        $"[{Name}] ({Description}) is in {_location.Describe()}";
}
