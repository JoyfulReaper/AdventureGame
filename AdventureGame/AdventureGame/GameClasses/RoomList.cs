using System.Runtime.Serialization;

namespace AdventureGame.GameClasses;

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
        string s = "";
        if (this.Count == 0)
        {
            s = "Nothing in RoomList.";
        }
        else
        {
            foreach (KeyValuePair<Rm, Room> kv in this)
            {
                s = s + kv.Value.Describe() + "\r\n";
            }
        }
        return s;
    }
}
