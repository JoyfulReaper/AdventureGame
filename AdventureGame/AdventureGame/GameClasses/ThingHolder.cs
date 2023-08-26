namespace AdventureGame.GameClasses;

public class ThingHolder : Thing
{
    private ThingList _things = new ThingList();

    public ThingHolder(string name, string description, ThingList thinglist) 
        : base(name, description)
    {
        _things = thinglist;
    }

    public ThingHolder(string name, string description, bool canTake, ThingList thingList)
            : base(name, description, canTake)
    {
        _things = thingList;
    }

    public ThingList Things {
        get { return _things; }
        set { _things = value; }
    }

    public void AddThing(Thing thing)
    {
        _things.Add(thing);
    }

    public void AddThings(ThingList thinglist)
    {
        _things.AddRange(thinglist);
    }

    public virtual string Describe() =>
        $"Name: {Name}, Description: {Description} which contains -> {_things.Describe()}";
}
