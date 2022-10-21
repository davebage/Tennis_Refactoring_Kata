using System.Collections.Generic;

namespace Tennis;

internal class ScorePrinter
{
    private readonly TennisPlayers _players;

    public ScorePrinter(TennisPlayers players)
    {
        _players = players;
    }

    public string PrintScore()
    {
        if (_players.MatchingScores())
        {
            return FormatMatchingScores(_players.PlayerOne());
        }
        
        if (_players.IsAdvantageScore())
        {
            return FormatAdvantageScores(_players.PlayerInLead());
        }

        if (_players.GameWinner() != null)
        {
            
            return FormatWinningScore(_players.GameWinner());
        }

        return FormatInPlayScore(_players.PlayerOne(), _players.PlayerTwo());

    }

    private static string FormatInPlayScore(Player player1, Player player2)
    {
        return $"{GetScore(player1)}-{GetScore(player2)}";
    }

    private static string GetScore(Player player)
    {
        return ScoreLookupsFor.RegularScore[player.GetScore()];
    }

    private static string FormatAdvantageScores(Player winningPlayer)
    {
        
        return $"{ScoreLookupsFor.ADVANTAGE} {winningPlayer.GetName()}";
    }

    private static string FormatWinningScore(Player winningPlayer)
    {
        return $"{ScoreLookupsFor.WIN} {winningPlayer.GetName()}";
    }

    private static string FormatMatchingScores(Player player)
    {
        
        if (ScoreLookupsFor.Matching.ContainsKey(player.GetScore()))
            return ScoreLookupsFor.Matching[player.GetScore()];

        return "Deuce";
    }
}