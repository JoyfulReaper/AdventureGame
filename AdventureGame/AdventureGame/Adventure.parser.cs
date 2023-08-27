namespace AdventureGame;

partial class Adventure
{
    // ===============================================================
    //                        --- Parser ---
    // ===============================================================

    readonly Dictionary<string, GrammarElement> _vocabulary = new Dictionary<string, GrammarElement>();

    private void InitializeVocabulary()
    {
        _vocabulary.Add("acorn", GrammarElement.NOUN);
        _vocabulary.Add("bed", GrammarElement.NOUN);
        _vocabulary.Add("bin", GrammarElement.NOUN);
        _vocabulary.Add("bone", GrammarElement.NOUN);
        _vocabulary.Add("button", GrammarElement.NOUN);
        _vocabulary.Add("cheese", GrammarElement.NOUN);
        _vocabulary.Add("chest", GrammarElement.NOUN);
        _vocabulary.Add("coin", GrammarElement.NOUN);
        _vocabulary.Add("door", GrammarElement.NOUN);
        _vocabulary.Add("dust", GrammarElement.NOUN);
        _vocabulary.Add("gardenia", GrammarElement.NOUN);
        _vocabulary.Add("key", GrammarElement.NOUN);
        _vocabulary.Add("knife", GrammarElement.NOUN);
        _vocabulary.Add("lamp", GrammarElement.NOUN);
        _vocabulary.Add("leaflet", GrammarElement.NOUN);
        _vocabulary.Add("lever", GrammarElement.NOUN);
        _vocabulary.Add("pearl", GrammarElement.NOUN);
        _vocabulary.Add("rat", GrammarElement.NOUN);
        _vocabulary.Add("sack", GrammarElement.NOUN);
        _vocabulary.Add("shop", GrammarElement.NOUN);
        _vocabulary.Add("sign", GrammarElement.NOUN);
        _vocabulary.Add("slot", GrammarElement.NOUN);
        _vocabulary.Add("squirrel", GrammarElement.NOUN);
        _vocabulary.Add("take", GrammarElement.VERB);
        _vocabulary.Add("drop", GrammarElement.VERB);
        _vocabulary.Add("put", GrammarElement.VERB);
        _vocabulary.Add("look", GrammarElement.VERB);
        _vocabulary.Add("open", GrammarElement.VERB);
        _vocabulary.Add("close", GrammarElement.VERB);
        _vocabulary.Add("pull", GrammarElement.VERB);
        _vocabulary.Add("push", GrammarElement.VERB);
        _vocabulary.Add("n", GrammarElement.VERB);
        _vocabulary.Add("s", GrammarElement.VERB);
        _vocabulary.Add("w", GrammarElement.VERB);
        _vocabulary.Add("e", GrammarElement.VERB);
        _vocabulary.Add("up", GrammarElement.VERB);
        _vocabulary.Add("down", GrammarElement.VERB);
        _vocabulary.Add("a", GrammarElement.ARTICLE);
        _vocabulary.Add("an", GrammarElement.ARTICLE);
        _vocabulary.Add("the", GrammarElement.ARTICLE);
        _vocabulary.Add("in", GrammarElement.PREPOSITION);
        _vocabulary.Add("into", GrammarElement.PREPOSITION);
        _vocabulary.Add("at", GrammarElement.PREPOSITION);
    }

    /* Command types:
       * VERB                           // e.g. N or Look
       * VERB+NOUN                      // e.g. Take X, Drop Y
       * VERB+PREPOSITION+NOUN          // e.g. Look at X
       * VERB+NOUN+PREPOSITION+NOUN     // e.g. Put X in Y
       * */

    private string ProcessVerbNounPrepositionNoun(List<WordAndType> command)
    {
        // "put in" is the only implemented command of this type
        WordAndType wt1 = command[0];
        WordAndType wt2 = command[1];
        WordAndType wt3 = command[2];
        WordAndType wt4 = command[3];

        string output = string.Empty;

        if ((wt1.Type != GrammarElement.VERB) || (wt3.Type != GrammarElement.PREPOSITION))
        {
            output = $"Can't do this because I don't understand how to {wt1.Word} something {wt3.Word} something else!";
        }
        else if (wt2.Type != GrammarElement.NOUN)
        {
            output = $"Can't do this because '{wt2.Word}' is not an object!";
        }
        else if (wt4.Type != GrammarElement.NOUN)
        {
            output = $"Can't do this because '{wt4.Word}' is not an object!";
        }
        else
        {
            switch (wt1.Word + wt3.Word)
            {
                case "putin":
                case "putinto":
                    output = PutObInContainer(wt2.Word, wt4.Word);
                    break;
                default:
                    output = $"I don't know how to {wt1.Word} {wt2.Word} {wt3.Word} {wt4.Word}!";
                    break;
            }
        }

        return output;
    }

    private string ProcessVerbPrepositionNoun(List<WordAndType> command)
    {
        // "look at" is the only implemented command of this type
        WordAndType wt1 = command[0];
        WordAndType wt2 = command[1];
        WordAndType wt3 = command[2];
        string output = String.Empty;
        if ((wt1.Type != GrammarElement.VERB) || (wt2.Type != GrammarElement.PREPOSITION))
        {
            output = $"Can't do this because I don't understand '{wt1.Word} {wt2.Word}' !";
        }
        else if (wt3.Type != GrammarElement.NOUN)
        {
            output = $"Can't do this because '{wt3.Word}' is not an object!{Environment.NewLine}";
        }
        else
        {
            switch (wt1.Word + wt2.Word)
            {
                case "lookat":
                    output = LookAtOb(wt3.Word);
                    break;
                default:
                    output = $"I don't know how to {wt1.Word} {wt2.Word} a {wt3.Word}!";
                    break;
            }
        }
        return output;
    }

    private string ProcessVerbNoun(List<WordAndType> command)
    {
        WordAndType wt1 = command[0];
        WordAndType wt2 = command[1];

        string output = string.Empty;
        if (wt1.Type != GrammarElement.VERB)
        {
            output = $"Can't do this because '{wt1.Word}' is not a command!";
        }
        else if (wt2.Type != GrammarElement.NOUN)
        {
            output = $"Can't do this because '{wt2.Word}' is not an object!";
        }
        else
        {
            switch (wt1.Word)
            {
                case "take":
                    output = TakeOb(wt2.Word);
                    break;
                case "drop":
                    output = DropOb(wt2.Word);
                    break;
                case "open":
                    output = OpenOb(wt2.Word);
                    break;
                case "close":
                    output = CloseOb(wt2.Word);
                    break;
                case "pull":
                    output = PullOb(wt2.Word);
                    break;
                case "push":
                    output = PushOb(wt2.Word);
                    break;
                default:
                    output = $"I don't know how to {wt1.Word} a {wt2.Word}!";
                    break;
            }
        }
        return output;
    }

    private string ProcessVerb(List<WordAndType> command)
    {
        WordAndType wt1 = command[0];
        string ouput = "";
        if (wt1.Type != GrammarElement.VERB)
        {
            ouput = $"Can't do this because '{wt1.Word}' is not a command!";
        }
        else
        {
            switch (wt1.Word)
            {
                case "look":
                    ouput = Look();
                    break;
                case "n":
                    ouput = MovePlayerTo(Direction.NORTH);
                    break;
                case "s":
                    ouput = MovePlayerTo(Direction.SOUTH);
                    break;
                case "w":
                    ouput = MovePlayerTo(Direction.WEST);
                    break;
                case "e":
                    ouput = MovePlayerTo(Direction.EAST);
                    break;
                case "up":
                    ouput = MovePlayerTo(Direction.UP);
                    break;
                case "down":
                    ouput = MovePlayerTo(Direction.DOWN);
                    break;
                default:
                    ouput = $"Sorry, I can't {wt1.Word}!";
                    break;
            }
        }
        return ouput;
    }

    private string ProcessCommand(List<WordAndType> command)
    {
        string output = String.Empty;
        if (command.Count == 0)
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
        return output;
    }

    private string ParseCommand(List<string> wordList)
    {
        List<WordAndType> command = new List<WordAndType>();
        GrammarElement wordType;
        string errMsg = string.Empty;
        string output = string.Empty;

        foreach (var k in wordList)
        {
            // Check to see if Key, s,
            // exists, If not, set WordType to ERROR
            if (_vocabulary.ContainsKey(k))
            {
                wordType = _vocabulary[k];
                if (wordType == GrammarElement.ARTICLE)
                {

                }
                else
                {
                    command.Add(new WordAndType(k, wordType));
                }
            }
            else
            {
                command.Add(new WordAndType(k, GrammarElement.ERROR));
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
}
