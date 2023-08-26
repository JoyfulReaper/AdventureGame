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
}
