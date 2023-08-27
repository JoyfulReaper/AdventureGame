namespace AdventureGame.GameClasses;

[Serializable]
public class Character : Container
{
    public Room Location { get; set; }

    public Character(string name, string description, Room room, Inventory inventory) :
        base(name, description, inventory)
    {
        Location = room;
    }

    public override string Describe() =>
        $"[{Name}] ({Description}) is in {Location.Describe()}";
}
