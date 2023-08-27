namespace AdventureGame.GameClasses;

public class ThingHolder : Thing
{
    private ThingList _things = new ThingList();

    // for objects that can't be opened: openable=false, open=true
    public ThingHolder(string name, string description, ThingList thinglist) 
        : base(name, description)
    {
        _things = thinglist;
    }

    public ThingHolder(string name, string description, bool isTakable, bool isMovable, ThingList thingList)
            : base(name, description, isTakable, isMovable)
    {
        _things = thingList;
    }

    public ThingList Things {
        get { return _things; }
        set { _things = value; }
    }

    public void AddThing(Thing thing) =>
        _things.Add(thing);
    

    public void AddThings(ThingList thinglist) =>
        _things.AddRange(thinglist);
    

    public override string Describe() =>
        $"Name: {Name}, Description: {Description} which contains -> {_things.Describe()}";
}
