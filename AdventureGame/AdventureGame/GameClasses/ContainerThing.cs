namespace AdventureGame.GameClasses;

[Serializable]
public class ContainerThing : ThingHolder
{
    private bool _openable;
    private bool _isOpen;

    public ContainerThing(string name, string description, ThingList thingList)
        : base(name, description, thingList)
    {
        _openable = false;
        _isOpen = true;
    }

    // For openable object
    public ContainerThing(string name, string description, bool isTakable, bool isMovable, bool isOpenable, bool open, ThingList thingList)
            : base(name, description, isTakable, isMovable, thingList)
    {
        _openable = isOpenable;
        _isOpen = open;
    }

    public void Open()
    {
        _isOpen = true;
    }

    public void Close()
    {
        _isOpen = false;
    }

    public override string Describe()
    {
        string desc = string.Empty;
        string thingsdesc = string.Empty;
        desc = $"This is {Description}";
        thingsdesc = Things.Describe();
        if (!string.IsNullOrWhiteSpace(thingsdesc))
        {
            desc += $"{Environment.NewLine}In the {Name} you can see:{Environment.NewLine}" + thingsdesc;
        }
        return desc;
    }

    public bool Openable { get => _openable; set => _openable = value; }
    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
}

