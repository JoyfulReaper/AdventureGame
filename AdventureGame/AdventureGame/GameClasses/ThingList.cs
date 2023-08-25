
namespace AdventureGame.GameClasses;

public class ThingList : List<Thing>
{
    public string Describe()
    {
        string s = "";

        if (this.Count == 0)
        {
            s = $"Nothing.{Environment.NewLine}";
        }
        else
        {
            foreach (Thing thing in this)
            {
                s += thing.Description + "; ";
            }
        }
        return s;
    }

    // This is the code from the book, but it can be done in one line, see below
    //public Thing? ThisOb(string name)
    //{
    //    Thing? thing = null;
    //    string thingName = String.Empty;
    //    string nameLowCase = name.Trim().ToLower();

    //    foreach (Thing t in this)
    //    {
    //        thingName = t.Name.Trim().ToLower();
    //        if (thingName.Equals(nameLowCase))
    //        {
    //            thing = t;
    //        }
    //    }

    //    return thing;
    //}

    public Thing? ThisOb(string name) => 
        this.Where(t => t.Name.Equals(name.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
}
