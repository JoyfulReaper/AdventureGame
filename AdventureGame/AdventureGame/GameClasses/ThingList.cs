
namespace AdventureGame.GameClasses;

[Serializable]
public class ThingList : List<Thing>
{
    public string Describe()
    {
        string output = "";

        if (this.Count == 0)
        {
            output = $"Nothing.{Environment.NewLine}";
        }
        else
        {
            foreach (Thing thing in this)
            {
                output += thing.Name + ". " + thing.Description + "; ";
            }
        }
        return output;
    }

    public Thing? GetOb(string name)
    {
        Thing? thing = null;
        string thingName = "";
        string nameLowerCase = name.Trim().ToLower();
        foreach (Thing t in this)
        {
            thingName = t.Name.Trim().ToLower();
            if (thingName.Equals(nameLowerCase))
            {
                thing = t;
            }
        }
        return thing;
    }
}
