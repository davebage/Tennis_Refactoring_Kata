using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Tennis;

public class TennisPlayers
{
    private readonly List<Player> _players = new();
    private const int PLAYER1 = 0;
    private const int PLAYER2 = 1;
    public TennisPlayers(string player1Name, string player2Name)
    {
        _players.Add(new Player(player1Name));
        _players.Add(new Player(player2Name));
    }

    public void AddPointForPlayer(string playerName)
    {
        if (_players.Any(x => x.CompareName(playerName)))
            _players.First(player => player.CompareName(playerName)).IncrementScore();
    }

    public Player PlayerOne()
    {
        return _players[PLAYER1];
    }

    public Player PlayerTwo()
    {
        return _players[PLAYER2];
    }

    public bool IsAdvantageScore()
    {
        var player1 = _players[PLAYER1];
        var player2 = _players[PLAYER2];
        var scoreDifference = player1.GetScore() - player2.GetScore();
        if ((player1.GetScore() >= 4 || player2.GetScore() >= 4) && 
            (scoreDifference == 1 || scoreDifference == -1))
            return true;

        return false;
    }

    public Player PlayerInLead()
    {
        var comparator = _players[PLAYER1].CompareTo(_players[PLAYER2]);

        return comparator switch
        {
            0 => null,
            1 => _players[PLAYER1],
            _ => _players[PLAYER2]
        };
    }

    public Player GameWinner()
    {
        if ((_players[PLAYER1].GetScore() >= 4 || _players[PLAYER2].GetScore() >= 4) &&
            (_players[PLAYER1].GetScore() - _players[PLAYER2].GetScore() >= 2 ||
             _players[PLAYER1].GetScore() - _players[PLAYER2].GetScore() <= -2))
            return PlayerInLead();

        return null;

    }

}