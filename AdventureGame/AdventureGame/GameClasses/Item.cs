namespace AdventureGame.GameClasses;

[Serializable]
public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Takeable { get; set; }
    public bool Movable { get; set; }

    public Item(string name, string description)
    {
        Description = description;
        Name = name;
        Takeable = true; // set default value
        Movable = true; // set default value
    }

    public Item(string name, string description, bool isTakable, bool isMoveable)
    {
        Description = description;
        Name = name;
        Takeable = isTakable;
        Movable = isMoveable;
    }

    public virtual string Describe() =>
        $"{Name} {Description}";
}
