﻿namespace AdventureGame.GameClasses;

public class Thing
{
    private string _name = default!;
    private string _description = default!;
    private bool _canTake;

    public Thing(string name, string description)
    {
        _description = description;
        _name = name;
        _canTake = true;
    }

    public Thing(string name, string description, bool canTake)
    {
        _description = description;
        _name = name;
        _canTake = canTake;
    }

    public string Name {
        get => _name;
        set => _name = value;
    }

    public string Description {
        get => _description;
        set => _description = value;
    }

    public bool CanTake {
        get => _canTake;
        set => _canTake = value;
    }

    public virtual string Describe() =>
        $"{Name} {Description}";
}
