
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
                s += thing.Name + ". " + thing.Description + "; ";
            }
        }
        return s;
    }

    public Thing? ThisOb(string name) => 
        this.Where(t => t.Name.Equals(name.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                   .FirstOrDefault();
}
