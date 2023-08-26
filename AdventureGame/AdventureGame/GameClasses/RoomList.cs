namespace AdventureGame.GameClasses;
public class RoomList : Dictionary<Rm,  Room>
{
    public Room RoomAt(Rm id)
    {
        return this[id];
    }

    public string Describe()
    {
        string s = string.Empty;
        if (Count == 0)
        {
            s = "Nothing in RoomList.";
        }
        else
        {
            foreach (KeyValuePair<Rm, Room> kvp in this)
            {
                s += kvp.Value.Describe() + Environment.NewLine;
            }
        }

        return s;
    }
}
