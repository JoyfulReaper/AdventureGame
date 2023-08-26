namespace AdventureGame;

public class WordAndType
{
    string _word;
    WT _wordtype;

    public WordAndType(string word, WT wordType)
    {
        _word = word;
        _wordtype = wordType;
    }

    public string Word {
        get { return _word; }
        set { _word = value; }
    }

    public WT Type {
        get { return _wordtype; }
        set { _wordtype = value; }
    }
}
