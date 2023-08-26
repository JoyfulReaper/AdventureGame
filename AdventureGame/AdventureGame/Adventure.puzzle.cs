using AdventureGame.GameClasses;

namespace AdventureGame;

partial class Adventure
{
    // ===============================================================
    //                        --- Special actions for puzzles  ---
    // ===============================================================

    private string PullSpecial(Thing t)
    {
        // return "" if no special action
        string s = "";
        if (t.Name == "lever") { }
        return s;
    }
}
