﻿namespace AdventureGame.GameClasses;

public class Actor : ThingHolder
{
    private Room _location = default!;

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
