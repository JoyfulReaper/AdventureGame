namespace AdventureGame.GameClasses;

[Serializable]
public class Container : Item
{
    public Inventory Inventory { get; set; } = new Inventory();

    // for objects that can't be opened: openable=false, open=true
    public Container(string name, string description, Inventory inventory) 
        : base(name, description)
    {
        Inventory = inventory;
    }

    public Container(string name, string description, bool isTakable, bool isMovable, Inventory inventory)
            : base(name, description, isTakable, isMovable)
    {
        Inventory = inventory;
    }


    public void AddThing(Item item) =>
        Inventory.Add(item);
    

    public void AddThings(Inventory itemList) =>
        Inventory.AddRange(itemList);
    

    public override string Describe() =>
        $"Name: {Name}, Description: {Description} which contains -> {Inventory.Describe()}";
}
