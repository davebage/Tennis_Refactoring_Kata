using System.Collections.Generic;
using System.Linq;

namespace Tennis;

public class TennisPlayers
{
    private readonly List<Player> _players = new();

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

    public Player GetPlayerOne()
    {
        return _players.First();
    }

    public Player GetPlayerTwo()
    {
        return _players.Last();
    }

}