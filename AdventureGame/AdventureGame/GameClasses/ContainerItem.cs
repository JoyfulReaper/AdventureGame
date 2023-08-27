namespace AdventureGame.GameClasses;

[Serializable]
public class ContainerItem : Container
{
    public bool Openable { get; set; }
    public bool IsOpen { get; set; }

    public ContainerItem(string name, string description, Inventory thingList)
        : base(name, description, thingList)
    {
        Openable = false;
        IsOpen = true;
    }

    // For openable object
    public ContainerItem(string name, string description, bool isTakable, bool isMovable, bool isOpenable, bool isOpen, Inventory inventory)
            : base(name, description, isTakable, isMovable, inventory)
    {
        Openable = isOpenable;
        IsOpen = isOpen;
    }

    public void Open()
    {
        IsOpen = true;
    }

    public void Close()
    {
        IsOpen = false;
    }

    public override string Describe()
    {
        string description;
        string itemDescription;
        description = $"This is {Description}";
        itemDescription = Inventory.Describe();
        if (!string.IsNullOrWhiteSpace(itemDescription))
        {
            description += $"{Environment.NewLine}In the {Name} you can see:{Environment.NewLine}" + itemDescription;
        }
        return description;
    }
}

