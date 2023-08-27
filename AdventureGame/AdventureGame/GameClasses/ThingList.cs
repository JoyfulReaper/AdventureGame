
namespace AdventureGame.GameClasses;
public class ThingList : List<Thing>
{
    public string Describe()
    {
        // return a string showing things each on a new line
        string s = "";
        if (this.Count > 0)
        {
            foreach (Thing t in this)
            {
                s = s + t.Name + "\r\n";
            }
        }
        else
        {
            s = "";
        }
        return s;
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
