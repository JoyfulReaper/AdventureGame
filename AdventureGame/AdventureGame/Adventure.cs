using AdventureGame.GameClasses;

namespace AdventureGame;

/// <summary>
/// The Adventure class contains the 'world' of the game:
/// It creates and initializes the player and the map.
/// </summary>
/// 
public class Adventure
{
    private RoomList _map = default!;
    private Actor _player = default!;

    public Adventure()
    {
        /*
            * 
            * Troll Room -- Forest
            *    |
            *  Cave  -----  Dungeon  
            * */

        ThingList trollRoomList = new ThingList();
        ThingList forestList = new ThingList();

        trollRoomList.Add(new Thing("Carrot", "It's a very crunchy carrot"));

        forestList.Add(new Thing("Sausage", "It is a plump pork sausage"));
        forestList.Add(new Thing("Tree", "It is a gigantic oak tree", false));

        _map = new RoomList {
            { Rm.TrollRoom, new Room("Troll Room", "a dank, dark room that smells of troll", Rm.NOEXIT, Rm.Cave, Rm.NOEXIT, Rm.Forest, trollRoomList) },
            { Rm.Forest, new Room("Forest", "a light, airy forest shimmering with sunlight", Rm.NOEXIT, Rm.NOEXIT, Rm.TrollRoom, Rm.NOEXIT, forestList) },
            { Rm.Cave, new Room("Cave", "a vast cave with walls covered by luminous moss", Rm.TrollRoom, Rm.NOEXIT, Rm.NOEXIT, Rm.Dungeon, new ThingList()) },
            { Rm.Dungeon, new Room("Dungeon", "a gloomy dungeon. Rats scurry across its floor", Rm.NOEXIT, Rm.NOEXIT, Rm.Cave, Rm.NOEXIT, new ThingList()) }
        };

        _player = new Actor("You", "The Player", _map.RoomAt(Rm.TrollRoom), new ThingList());
    }

    //// --- Player
    public Actor Player {
        get => _player;
    }

    private Rm MoveTo(Actor actor, Dir direction)
    {
        Room r = actor.Location;
        Rm exit;
        switch (direction)
        {
            case Dir.NORTH:
                exit = r.N;
                break;
            case Dir.SOUTH:
                exit = r.S;
                break;
            case Dir.EAST:
                exit = r.E;
                break;
            case Dir.WEST:
                exit = r.W;
                break;
            default:
                exit = Rm.NOEXIT;
                break;
        }

        if(exit != Rm.NOEXIT)
        {
            MoveActorTo(actor, _map.RoomAt(exit));
        }
        return exit;
    }

    private static void MoveActorTo(Actor actor, Room room) =>
        actor.Location = room;
    

    public string MovePlayerTo(Dir direction)
    {
        string output;
        if (MoveTo(_player, direction) == Rm.NOEXIT)
        {
            output = $"There is no exit in that direction.{Environment.NewLine}";
        }
        else
        {
            output = $"You are in the {_player.Location.Name}{Environment.NewLine}";
        }
        return output;
    }

    private static void TransferOb(Thing thing, ThingList source, ThingList destination)
    {
        source.Remove(thing);
        destination.Add(thing);
    }

    public string TakeOb(string obName)
    {
        Thing? thing = _player.Location.Things.ThisOb(obName);
        string output;

        if(string.IsNullOrWhiteSpace(obName))
        {
            obName = "nameless object";
        }

        if (thing is null)
        {
            output = $"There is no {obName} here!";
        }
        else
        {
            if (thing.CanTake)
            {
                TransferOb(thing, _player.Location.Things, _player.Things);
                output = $"{thing.Name} taken!";
            }
            else
            {
                output = $"You can't take the {thing.Name}!";
            }
        }

        return output;
    }

    public string DropOb(string obName)
    {
        Thing? thing = _player.Things.ThisOb(obName);
        string output;
        if (thing is null)
        {
            output = "You haven't got one!";
        }
        else
        {
            TransferOb(thing, _player.Things, _player.Location.Things);
            output = thing.Name + " dropped!";
        }
        return output;
    }

    public string LookAtOb(string obName)
    {
        Thing? thing;
        string output;

        if (string.IsNullOrEmpty(obName))
        {
            output = "You'll have to say what you want to look at!";
        }
        else
        {
            thing = _player.Location.Things.ThisOb(obName);
            if (thing is null)
            {
                thing = _player.Things.ThisOb(obName);
            }
            if (thing is null)
            {
                output = $"There is no {obName} here!";
            }
            else
            {
                output = thing.Description + ".";
            }
        }
        return output;
    }
}
