namespace AdventureGame.GameClasses;

[Serializable]
public class Inventory : List<Item>
{
    public string Describe()
    {
        // return a string showing things each on a new line
        string output = string.Empty;
        if (this.Count > 0)
        {
            foreach (Item item in this)
            {
                output += $"{item.Name}{Environment.NewLine}";
            }
        }
        else
        {
            output = string.Empty;
        }
        return output;
    }

    public Item? GetItem(string itemName)
    {
        Item? ouput = null;
        string name;
        string nameLowerCase = itemName.Trim().ToLower();
        foreach (Item item in this)
        {
            name = item.Name.Trim().ToLower();
            if (name.Equals(nameLowerCase))
            {
                ouput = item;
            }
        }
        return ouput;
    }
}
