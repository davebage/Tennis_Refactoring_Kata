using System;

namespace Tennis;

public class Player : IComparable<Player>
{
    private readonly string _name;
    private int _score;

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

    public int CompareTo(Player other)
    {
        if(this._score == other._score) return 0;

        if(this._score < other._score) return -1;

        return 1;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetScore()
    {
        return _score;
    }
}