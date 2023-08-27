using AdventureGame.GameClasses;

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
    private Map _map = default!;
    private Character _player = default!;
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

    public void InitializeGame()
    {
        InitializeVocabulary();        //!! Be sure to initialize the vocabulary list...

        /*
         * 
         *                                  Attic -- Bedroom
         *                                     ^
         *                                     |
         *                           DesertedShop -- Kitchen
         *                                |    |
         *                                |    V
         *                                |  Basement
         *                                |
         *                   ------  DaggerStreet --------- Ripper Mews
         *                   |            |                   |
         * GoreStreet -- Alleyway -- OpiumTerrace  -------- GardenN       
         *    |                                               |  Oak Tree    Balcony
         *    |                                               |  ^              ^
         *    |                                               |  |              |
         *  DeadEnd               VegetableGarden --------- GardenS --------- PalmHouse
         *                                               
         *  
        * */

        // Initialize _map with Rooms
        _map = new Map {
                /*                  N                   S                   W                   E               Up              Down   */
                { RoomId.GoreStreet, new Room("Gore Street", "a narrow, twisty street that smells of decay.\r\nThere is a sign on the wall",
                                RoomId.NOEXIT,          RoomId.DeadEnd,         RoomId.NOEXIT,           RoomId.Alleyway,
                                new Inventory())  },
                { RoomId.Alleyway, new Room("Alleyway", "a dismal alleyway enclosed by the crumbling walls of tall buildings",
                                RoomId.NOEXIT,          RoomId.NOEXIT,          RoomId.GoreStreet,       RoomId.OpiumTerrace,
                                new Inventory ()) },
                { RoomId.DeadEnd, new Room("Dead End", "a sinister little street that leads nowhere.\r\nThere is a button on the wall",
                                RoomId.GoreStreet,      RoomId.NOEXIT,          RoomId.NOEXIT,           RoomId.OpiumTerrace,
                                new Inventory()) },
                { RoomId.OpiumTerrace, new Room("Opium Terrace", "a dark, dripping terrace illuminated by a hissing gas lamp.\r\nThere is a sign on the wall",
                                RoomId.NOEXIT,          RoomId.NOEXIT,          RoomId.Alleyway,         RoomId.GardenN,
                                new Inventory()) },
                { RoomId.DaggerStreet, new Room("Dagger Street", "a long, winding street with exits to North and South. There is a narrow alleyway to the west." +
                                            "\r\nOn the northern side stands a deserted shop. There is a sign on the wall",
                                RoomId.NOEXIT,          RoomId.OpiumTerrace,    RoomId.Alleyway,         RoomId.RipperMews,
                                new Inventory()) },
                { RoomId.RipperMews, new Room("Ripper Mews", "a delightful little street filled with the scent of gardenia.\r\nThere is a sign on the wall",
                                RoomId.NOEXIT,          RoomId.GardenN,         RoomId.DaggerStreet,     RoomId.NOEXIT,
                                new Inventory()) },
                { RoomId.GardenN, new Room("Garden", "a lovely garden. A gardenia bush blossoms next to the gate. Walkways lead to other parts of the garden.\r\n" +
                                        "A squirrel suddenly runs across the grass in front of you. It seems to be holding a pearl." +
                                        "\r\nThe squirrel squeals then runs off into the distance.",
                                RoomId.RipperMews,      RoomId.GardenS,         RoomId.OpiumTerrace,     RoomId.NOEXIT,
                                new Inventory()) },
                { RoomId.GardenS, new Room("Garden", "a lovely garden. A mighty oak tree towers above you. Walkways lead to other parts of the garden",
                                RoomId.GardenN,         RoomId.NOEXIT,          RoomId.VegetableGarden,   RoomId.PalmHouse,     RoomId.OakTree,     RoomId.NOEXIT,
                                new Inventory()) },
                { RoomId.OakTree, new Room("Oak tree", "a mighty oak tree that towers over the garden. You have a glorious view of a splendid Palm House to your East," +
                                        "the vegetable garden to the West and other parts of the garden to the North. You vaguely see other parts of the city" +
                                        "in the distance, but the buildings are obscured by drifting fog.",
                                RoomId.NOEXIT,         RoomId.NOEXIT,           RoomId.NOEXIT,            RoomId.NOEXIT,        RoomId.NOEXIT,      RoomId.GardenS,
                                new Inventory()) },
                 { RoomId.VegetableGarden, new Room("Vegetable garden", "a garden filled with sprouting vegetables in bewildering variety",
                                RoomId.NOEXIT,         RoomId.NOEXIT,           RoomId.NOEXIT,            RoomId.GardenS,
                                new Inventory()) },
                 { RoomId.PalmHouse, new Room("Palm House", "a tall, elegant structure made of glass panes set in an cast-iron frame. The atmosphere is hot and humid." +
                                        "\r\nHuge palm trees rise high overhead. An elaborate cast-iron staircase leads up to a bacony",
                                RoomId.NOEXIT,         RoomId.NOEXIT,           RoomId.GardenS,            RoomId.NOEXIT,       RoomId.Balcony,     RoomId.NOEXIT,
                                new Inventory()) },
                 { RoomId.Balcony, new Room("Balcony", "a balcony at the height of the tallest palms. All you can see are palm fronds everywhere. The windows are too misty to see through",
                                RoomId.NOEXIT,         RoomId.NOEXIT,           RoomId.NOEXIT,            RoomId.NOEXIT,       RoomId.NOEXIT,     RoomId.PalmHouse,
                                new Inventory()) },
                 { RoomId.DesertedShop, new Room("Deserted shop", "a musty old shop. There is nothing here but dust",
                                RoomId.NOEXIT,         RoomId.DaggerStreet,     RoomId.NOEXIT,            RoomId.Kitchen,       RoomId.Attic,     RoomId.Basement,
                                new Inventory()) },
                 { RoomId.Basement, new Room("Basement", "a dank, dripping basement that smells of fungus",
                                RoomId.NOEXIT,         RoomId.NOEXIT,           RoomId.NOEXIT,            RoomId.NOEXIT,       RoomId.DesertedShop,     RoomId.NOEXIT,
                                new Inventory()) },
                 { RoomId.Attic, new Room("Attic", "a cramped space under the roof. A hungry-looking rat is sitting on a rafter",
                                RoomId.NOEXIT,         RoomId.NOEXIT,           RoomId.NOEXIT,            RoomId.Bedroom,       RoomId.NOEXIT,     RoomId.DesertedShop,
                                new Inventory()) },
                 { RoomId.Bedroom, new Room("Bedroom", "a tiny room containing a small, damp bed and a huge wooden chest",
                                RoomId.NOEXIT,         RoomId.NOEXIT,           RoomId.Attic,            RoomId.NOEXIT,
                                new Inventory()) },
                 { RoomId.Kitchen, new Room("Kitchen", "an untidy kitchen that smells of rancid cheese",
                                RoomId.NOEXIT,         RoomId.NOEXIT,           RoomId.DesertedShop,            RoomId.NOEXIT,
                                new Inventory()) }

            };

        // NOTE: Add Things to selected Rooms (after Rooms are created and added to map)
        _map[RoomId.GoreStreet].AddThings(new Inventory {
                        new Item("leaflet", "The leaflet says: 'Ripper Strikes Again!'"),
                        new Item("sign", "The sign says 'Gore Street'", false, false),
                        new ContainerItem("sack", "a smelly old sack", true, true, true, true, new Inventory())
                });
        _map[RoomId.Alleyway].AddThings(new Inventory {
                        new ContainerItem("bin", "It is a smelly bin.", false, true, true, true,
                            new Inventory{
                                new Item("bone", "A bone that looks as though it has been gnawed by a dog"),
                                new Item("coin", "A small, silver coin of unknown denomination")
                            }),
                        new Item("knife", "It is a blood-stained carving knife")
                    });
        _map[RoomId.OpiumTerrace].AddThing(new Item("lamp", "The hissing gas lamp is fixed high up on a wall. It produces a sickly, green, flickering light", false, false));
        _map[RoomId.OpiumTerrace].AddThing(new Item("sign", "The sign says 'Opium Terrace'", false, false));
        _map[RoomId.DaggerStreet].AddThing(new Item("sign", "The sign says 'Dagger Street'", false, false));
        _map[RoomId.DaggerStreet].AddThing(new Item("shop", "It is a deserted shop", false, false));
        _map[RoomId.OakTree].AddThing(new Item("acorn", "A very ordinary-looking acorn"));
        _map[RoomId.Bedroom].AddThing(new Item("bed", "A nasty, rather damp bed", false, true));
        _map[RoomId.Bedroom].AddThing(new ContainerItem("chest", "A wooden chest", false, true, true, false,
             new Inventory{
                                new Item("key", "A small brass key")
                        }));
        _map[RoomId.DesertedShop].AddThing(new Item("dust", "It is very ordinary-looking dust.", false, true));
        _map[RoomId.Attic].AddThing(new Item("rat", "A scabby, hungry-looking rat with yellow teeth and green eyes.\r\nIt is sitting on the rafter sniffing the air and squeaking.", false, false));
        _map[RoomId.Kitchen].AddThing(new Item("cheese", "A smelly lump of cheese"));
        _map[RoomId.Balcony].AddThing(new Item("lever", "A lever fixed to the wall", false, true));
        _map[RoomId.Balcony].AddThing(new Item("sign", "The sign says: 'Coin operated'", false, true));
        _map[RoomId.Balcony].AddThing(new ContainerItem("slot", "A lever fixed to the wall", false, false, false, true, new Inventory()));
        _map[RoomId.DeadEnd].AddThing(new Item("button", "A glowing green button on the wall", false, true));
        _player = new Character("You", "The Player", _map.RoomAt(RoomId.GoreStreet), new Inventory());
    }

    //// --- Player
    public Character Player {
        get => _player;
    }

    private static void MoveActorTo(Character actor, Room room) =>
        actor.Location = room;

    private RoomId MoveTo(Character actor, Direction direction)
    {
        Room r = actor.Location;
        RoomId exit;
        switch (direction)
        {
            case Direction.NORTH:
                exit = r.N;
                break;
            case Direction.SOUTH:
                exit = r.S;
                break;
            case Direction.EAST:
                exit = r.E;
                break;
            case Direction.WEST:
                exit = r.W;
                break;
            case Direction.UP:
                exit = r.Up;
                break;
            case Direction.DOWN:
                exit = r.Down;
                break;
            default:
                exit = RoomId.NOEXIT;
                break;
        }

        if (exit != RoomId.NOEXIT)
        {
            MoveActorTo(actor, _map.RoomAt(exit));
        }
        return exit;
    }

    private static void TransferOb(Item thing, Inventory source, Inventory destination)
    {
        source.Remove(thing);
        destination.Add(thing);
    }

    // NOTE: Looks for ob in any open containers in current room
    // if found returns a pair of objects: Key = Thing, Value = ThingList containing Thing
    private KeyValuePair<Item?, Inventory?> ObInContainerHere(string obName)
    {
        ContainerItem? container = null;
        Item? thing = null;
        Inventory? thingList = null;

        foreach (Item t in _player.Location.Inventory)
        {
            if (t is ContainerItem)
            {
                container = (ContainerItem)t;
                if (container.IsOpen)
                {
                    thingList = container.Inventory;
                    thing = container.Inventory.GetItem(obName);
                }
            }
        }
        return new KeyValuePair<Item?, Inventory?>(thing, thingList);
    }

        private Item? ObHere(string obName)
    {
        KeyValuePair<Item?, Inventory?> kv;
        Item? thing = null;
        thing = _player.Location.Inventory.GetItem(obName);
        if (thing is null)
        {
            thing = _player.Inventory.GetItem(obName);
        }
        if (thing is null)
        {
            kv = ObInContainerHere(obName);
            thing = kv.Key;
        }
        return thing;
    }

    private static string TryToOpen(ContainerItem container)
    {
        string output;
        if (!container.Openable)
        {
            output = $"Can't open the {container.Name}";
        }
        else
        {
            if (container.IsOpen)
            {
                output = $"The {container.Name} is already open.";
            }
            else
            {
                container.IsOpen = true;
                output = $"You open the {container.Name}";
            }
        }
        return output;
    }

    private static string TryToClose(ContainerItem container)
    {
        string output;
        if (!container.Openable)
        {
            output = $"Can't close the {container.Name}";
        }
        else
        {
            if (container.IsOpen)
            {
                container.IsOpen = false;
                output = $"You close the {container.Name}";
            }
            else
            {
                output = $"The {container.Name} is already closed.";
            }
        }
        return output;
    }

    // --- Public methods
    public string MovePlayerTo(Direction direction)
    {
        string output;
        if (MoveTo(_player, direction) == RoomId.NOEXIT)
        {
            output = $"There is no exit in that direction.{Environment.NewLine}";
        }
        else
        {
            output = $"You are in the {_player.Location.Name}{Environment.NewLine}";
        }
        return output;
    }

    public string Look()
    {
        return "You are in " + _player.Location.Describe();
    }

    public string PutObInContainer(string obName, string containerName)
    {
        string output = string.Empty;
        Item thing = _player.Inventory.GetItem(obName);
        Item container = ObHere(containerName);

        if (thing is null)
        {
            output = $"You haven't got the {obName}!";
        }
        else if (container == null)
        {
            output = $"There is no {containerName} here!";
        }
        else if (!(container is ContainerItem))
        {
            output = $"You can't put the {obName} into the {containerName}!";
        }
        else if (!((ContainerItem)container).IsOpen)
        {
            output = $"You can't put the {obName} into a closed {containerName}!";
        }
        else
        {
            TransferOb(thing, _player.Inventory, ((ContainerItem)container).Inventory);
            output = $"You put the {obName} into the {containerName}.";
        }
        return output;
    }

    // NOTE: Now allows things to be taken from open Containers!
    public string TakeOb(string obName)
    {
        KeyValuePair<Item?, Inventory?> kv;
        Item thing;
        Inventory thingList;
        string output = string.Empty;
        thing = _player.Location.Inventory.GetItem(obName);                   // See if ob is 'in room'
        thingList = _player.Location.Inventory;

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
                TransferOb(thing, thingList, _player.Inventory);
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
        Item? thing = _player.Inventory.GetItem(obName);
        string output;
        if (thing is null)
        {
            output = "You haven't got one!";
        }
        else
        {
            TransferOb(thing, _player.Inventory, _player.Location.Inventory);
            output = thing.Name + " dropped!";
        }
        return output;
    }

    public string LookAtOb(string obName)
    {
        Item? thing;
        string s = "";
        if (obName == "")
        {
            s = "You'll have to say what you want to look at!";
        }
        else
        {
            thing = ObHere(obName);
            if (thing == null)
            {
                s = $"There is no {obName} here!";
            }
            else
            {
                s = thing.Describe();
            }
        }
        return s;
    }

    public string OpenOb(string obName)
    {
        Item? thing;
        string output = "";
        if (obName == "")
        {
            output = "You'll have to say what you want to open!";
        }
        else
        {
            thing = ObHere(obName);
            if (thing is null)
            {
                output = $"There is no {obName} here!";
            }
            else
            {
                if (thing is ContainerItem)
                {
                    output = TryToOpen((ContainerItem)thing);
                }
                else
                {
                    output = $"Cannot open the {obName}";
                }
            }
        }
        return output;
    }

    public string CloseOb(string obName)
    {
        Item? thing;
        string ouput = "";
        if (obName == "")
        {
            ouput = "You'll have to say what you want to close!";
        }
        else
        {
            thing = ObHere(obName);
            if (thing == null)
            {
                ouput = $"There is no {obName} here!";
            }
            else
            {
                if (thing is ContainerItem)
                {
                    ouput = TryToClose((ContainerItem)thing);
                }
                else
                {
                    ouput = $"Cannot close the {obName}";
                }
            }
        }
        return ouput;
    }

    public string PullOb(string obName)
    {
        Item? thing;
        string output;
        thing = ObHere(obName);
        if (thing is null)
        {
            output = $"There is no {obName} here!";
        }
        else
        {
            output = PullSpecial(thing);
            if (string.IsNullOrEmpty(output))
            {
                if (thing.Movable)
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

    public string PushOb(string obName)
    {
        Item? thing;
        string ouput = "";
        thing = ObHere(obName);
        if (thing == null)
        {
            ouput = $"There is no {obName} here!";
        }
        else
        {
            if (thing.Movable)
            {
                ouput = $"The {obName} moves slightly when you push it.";
            }
            else
            {
                ouput = $"You try to push the {obName} but nothing happens.";
            }
        }
        return ouput;
    }
}
