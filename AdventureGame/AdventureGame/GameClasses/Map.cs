using System.Runtime.Serialization;

namespace AdventureGame.GameClasses;

[Serializable]
public class Map : Dictionary<RoomId,  Room>
{
    protected Map(SerializationInfo info, StreamingContext context)
        : base(info, context) {
        // constructor needed for serialization
    }

    public Map() { }

    public Room RoomAt(RoomId id)
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
            foreach (KeyValuePair<RoomId, Room> kv in this)
            {
                s = s + kv.Value.Describe() + "\r\n";
            }
        }
        return s;
    }
}
