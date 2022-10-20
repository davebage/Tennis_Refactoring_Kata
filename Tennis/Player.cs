namespace Tennis;

public class Player
{
    private readonly string _name;
    internal int _score;

    public Player(string name)
    {
        _name = name;
    }

    public bool CompareName(string playerName)
    {
        if(string.IsNullOrEmpty(playerName)) return false;

        return _name.Equals(playerName);

    }

    public bool AreMatchingScores(Player other)
    {
        if(other == null) return false;
        return _score == other._score;
    }

    public void IncrementScore()
    {
        _score++;
    }
}