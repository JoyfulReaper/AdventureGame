
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

    public Thing? ThisOb(string name) => 
        this.Where(t => t.Name.Equals(name.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                   .FirstOrDefault();
}
