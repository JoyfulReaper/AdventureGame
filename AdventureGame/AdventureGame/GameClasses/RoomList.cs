using System.Runtime.Serialization;

namespace AdventureGame.GameClasses;

[Serializable]
public class RoomList : Dictionary<Rm,  Room>
{
    protected RoomList(SerializationInfo info, StreamingContext context)
        : base(info, context) {
        // constructor needed for serialization
    }

    public RoomList() { }

    public Room RoomAt(Rm id)
    {
        return this[id];
    }

    public string Describe()
    {
        string output = string.Empty;
        if (Count == 0)
        {
            output = "Nothing in RoomList.";
        }
        else
        {
            foreach (KeyValuePair<Rm, Room> kvp in this)
            {
                output += kvp.Value.Describe() + Environment.NewLine;
            }
        }

        return output;
    }
}
