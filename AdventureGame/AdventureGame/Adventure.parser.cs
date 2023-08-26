namespace AdventureGame;

partial class Adventure
{
    // ===============================================================
    //                        --- Parser ---
    // ===============================================================

    Dictionary<string, WT> vocab = new Dictionary<string, WT>();

    private void InitVocab()
    {
        vocab.Add("acorn", WT.NOUN);
        vocab.Add("bed", WT.NOUN);
        vocab.Add("bin", WT.NOUN);
        vocab.Add("bone", WT.NOUN);
        vocab.Add("button", WT.NOUN);
        vocab.Add("cheese", WT.NOUN);
        vocab.Add("chest", WT.NOUN);
        vocab.Add("coin", WT.NOUN);
        vocab.Add("door", WT.NOUN);
        vocab.Add("dust", WT.NOUN);
        vocab.Add("gardenia", WT.NOUN);
        vocab.Add("key", WT.NOUN);
        vocab.Add("knife", WT.NOUN);
        vocab.Add("lamp", WT.NOUN);
        vocab.Add("leaflet", WT.NOUN);
        vocab.Add("lever", WT.NOUN);
        vocab.Add("pearl", WT.NOUN);
        vocab.Add("rat", WT.NOUN);
        vocab.Add("sack", WT.NOUN);
        vocab.Add("shop", WT.NOUN);
        vocab.Add("sign", WT.NOUN);
        vocab.Add("slot", WT.NOUN);
        vocab.Add("squirrel", WT.NOUN);
        vocab.Add("take", WT.VERB);
        vocab.Add("drop", WT.VERB);
        vocab.Add("put", WT.VERB);
        vocab.Add("look", WT.VERB);
        vocab.Add("open", WT.VERB);
        vocab.Add("close", WT.VERB);
        vocab.Add("pull", WT.VERB);
        vocab.Add("push", WT.VERB);
        vocab.Add("n", WT.VERB);
        vocab.Add("s", WT.VERB);
        vocab.Add("w", WT.VERB);
        vocab.Add("e", WT.VERB);
        vocab.Add("up", WT.VERB);
        vocab.Add("down", WT.VERB);
        vocab.Add("a", WT.ARTICLE);
        vocab.Add("an", WT.ARTICLE);
        vocab.Add("the", WT.ARTICLE);
        vocab.Add("in", WT.PREPOSITION);
        vocab.Add("into", WT.PREPOSITION);
        vocab.Add("at", WT.PREPOSITION);
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

        if ((wt1.Type != WT.VERB) || (wt3.Type != WT.PREPOSITION))
        {
            output = $"Can't do this because I don't understand how to {wt1.Word} something {wt3.Word} something else!";
        }
        else if (wt2.Type != WT.NOUN)
        {
            output = $"Can't do this because '{wt2.Word}' is not an object!";
        }
        else if (wt4.Type != WT.NOUN)
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
        if ((wt1.Type != WT.VERB) || (wt2.Type != WT.PREPOSITION))
        {
            output = $"Can't do this because I don't understand '{wt1.Word} {wt2.Word}' !";
        }
        else if (wt3.Type != WT.NOUN)
        {
            output = $"Can't do this because '{wt3.Word}' is not an object!\r\n";
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
        if (wt1.Type != WT.VERB)
        {
            output = $"Can't do this because '{wt1.Word}' is not a command!";
        }
        else if (wt2.Type != WT.NOUN)
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
        if (wt1.Type != WT.VERB)
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
                    ouput = MovePlayerTo(Dir.NORTH);
                    break;
                case "s":
                    ouput = MovePlayerTo(Dir.SOUTH);
                    break;
                case "w":
                    ouput = MovePlayerTo(Dir.WEST);
                    break;
                case "e":
                    ouput = MovePlayerTo(Dir.EAST);
                    break;
                case "up":
                    ouput = MovePlayerTo(Dir.UP);
                    break;
                case "down":
                    ouput = MovePlayerTo(Dir.DOWN);
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
        WT wordType;
        string errMsg = string.Empty;
        string output = string.Empty;

        foreach (var k in wordList)
        {
            // Check to see if Key, s,
            // exists, If not, set WordType to ERROR
            if (vocab.ContainsKey(k))
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
}
