using AdventureGame.GameClasses;
using System.Xml.Linq;

namespace AdventureGame;
/// <summary>
/// ---------------------------------
/// DarkNeon Adventure Game Framework 
/// ---------------------------------
/// Copyright (c) Huw Collingbourne
/// This game is based on the adventure game framework created by Huw Collingbourne
/// This code may be used 'as is' or modified to create new games as long
/// as this copyright notice and website links are included.
/// http://www.bitwisebooks.com
/// http://www.bitwisemag.com
/// </summary>
/// 


/// The Adventure class contains the 'world' of the game:
/// It creates and initializes the player and the map.
[Serializable]
public partial class Adventure
{
    private RoomList _map = default!;
    private Actor _player = default!;
    /*
    * ADDED: Pull/Push/Put..in
    * TODO: Puzzles: 
    * Drop cheese. rat eats it and knocks something off the rafter
    * pull lever (opens door to new room)
    * put coin in slot
    * press button
    * Squirrel holding coin. Drops coin when you drop acorn
    * Drop cheese in attic to feed rat. Rat knocks off something (from rafter)
    * */

    public Adventure()
    {
        /*
            * 
            * Troll Room -- Forest
            *    |
            *  Cave  -----  Dungeon  
            * */

        _map = new RoomList {
                /*                                                                                 N          S          W          E          */
                { Rm.TrollRoom, new Room("Troll Room", "a dank, dark room that smells of troll", Rm.NOEXIT, Rm.Cave, Rm.NOEXIT, Rm.Forest,
                    new ThingList {
                        new Thing("carrot", "It is a very crunchy carrot")
                }) },
                { Rm.Forest, new Room("Forest", "a light, airy forest shimmering with sunlight", Rm.NOEXIT, Rm.NOEXIT, Rm.TrollRoom, Rm.NOEXIT,
                    new ThingList {
                        new Thing("sausage", "It is a plump pork sausage"),
                        new Thing("tree", "It is a gigantic oak tree", false)
                    }) },
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

    private KeyValuePair<Thing?, ThingList?> ObInContainerHere(string obName)
    {
        ContainerThing? container = null;
        Thing? thing = null;
        ThingList? thingList = null;

        foreach (Thing t in _player.Location.Things)
        {
            if (t is ContainerThing)
            {
                container = (ContainerThing)t;
                if(container.IsOpen)
                {
                    thingList = container.Things;
                    thing = container.Things.GetOb(obName);
                }
            }
        }
        return new KeyValuePair<Thing?, ThingList?>(thing, thingList);
    }

    private Thing? ObHere(string obName)
    {
        KeyValuePair<Thing?, ThingList?> kv;
        Thing? thing = null;
        thing = _player.Location.Things.GetOb(obName);
        if (thing is null)
        {
            thing = _player.Things.GetOb(obName);
        }
        if (thing is null)
        {
            kv = ObInContainerHere(obName);
            thing = kv.Key;
        }
        return thing;
    }

    public string TakeOb(string obName)
    {
        KeyValuePair<Thing?, ThingList?> kv;
        Thing thing;
        ThingList thingList;
        string output = string.Empty;
        thing = _player.Location.Things.GetOb(obName);                   // See if ob is 'in room'
        thingList = _player.Location.Things;

        if (string.IsNullOrWhiteSpace(obName))
        {
            obName = "nameless object"; // if no object specified
        }
        if (thing == null)
        {                                            // if not, see if it's in a container in room
            kv = ObInContainerHere(obName);
            thing = kv.Key;
            thingList = kv.Value;
        }
        if (thing == null)
        {
            output = $"There is no {obName} here!";
        }
        else
        {
            if (thing.Takeable)
            {
                TransferOb(thing, thingList, _player.Things);
                output = thing.Name + " taken!";
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

    private string ProcessCommand(List<WordAndType> command)
    {
        string output = String.Empty;
        if(command.Count == 0)
        {
            output = "You must write a command!";
        }
        else if (command.Count > 4)
        {
            output = "That command is too long!";
        }
        else
        {
            output = "About to process command";
            switch (command.Count)
            {
                case 1:
                    output = ProcessVerb(command);
                    break;
                case 2:
                    output = ProcessVerbNoun(command);
                    break;
                case 3:
                    output = ProcessVerbPrepositionNoun(command);
                    break;
                case 4:
                    output = ProcessVerbNounPrepositionNoun(command);
                    break;
                default:
                    output = "Unable to process command";
                    break;
            }
        }
    }

    private string ParseCommand(List<string> wordList)
    {
        List<WordAndType> command = new List<WordAndType>();
        WT wordType;
        string errMsg = string.Empty;
        string output = string.Empty;

        foreach (var k in wordList)
        {
            // Check to see if Key, s,
            // exists, If not, set WordType to ERROR
            if(vocab.ContainsKey(k))
            {
                wordType = vocab[k];
                if (wordType == WT.ARTICLE)
                {

                }
                else
                {
                    command.Add(new WordAndType(k, wordType));
                }
            }
            else
            {
                command.Add(new WordAndType(k, WT.ERROR));
                errMsg = $"Sorry, I don't understand '{k}'";
            }
        }
        if (!string.IsNullOrEmpty(errMsg))
        {
            output = errMsg;
        }
        else
        {
            output = ProcessCommand(command);
        }
        return output;
    }

    public string RunCommand(string inputStr)
    {
        char[] delims = { ' ', '.' };
        List<string> strList;
        string output = string.Empty;

        string lowStr = inputStr.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(lowStr))
        {
            output = "You must enter a command";
        }
        else
        {
            strList = new List<string>(inputStr.Split(delims, StringSplitOptions.RemoveEmptyEntries));
            output = ParseCommand(strList);
        }
        return output;
    }

    public string PutObInContainer(string obName, string containerName)
    {
        string output = string.Empty;
        Thing thing = _player.Things.GetOb(obName);
        Thing container = ObHere(containerName);

        if (thing is null)
        {
            output = $"You haven't got the {obName}!";
        }
        else if (container == null)
        {
            output = $"There is no {containerName} here!";
        }
        else if (!(container is ContainerThing))
        {
            output = $"You can't put the {obName} into the {containerName}!";
        }
        else if (!((ContainerThing)container).IsOpen)
        {
            output = $"You can't put the {obName} into a closed {containerName}!";
        }
        else
        {
            TransferOb(thing, _player.Things, ((ContainerThing)container).Things);
            output = $"You put the {obName} into the {containerName}.";
        }
        return output;
    }

    public string PullOb(string obName)
    {
        Thing thing;
        string output;
        thing = ObHere(obName);
        if(thing is null)
        {
            output = $"There is no {obName} here!";
        }
        else
        {
            output = PullSpecial(thing);
            if (string.IsNullOrEmpty(output))
            {
                if(thing.Movable)
                {
                    output = $"The {obName} moves slightly with you pull it.";
                }
                else
                {
                    output = $"You try to pull the {obName} but nothing happens.";
                }
            }
        }
        return output;
    }
}
