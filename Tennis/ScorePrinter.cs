using System.Collections.Generic;

namespace Tennis;

internal class ScorePrinter
{
    private static readonly Dictionary<int, string> _matchingScores = new() { { 0, "Love-All" }, { 1, "Fifteen-All" }, { 2, "Thirty-All" } };
    private static readonly string[] _score = new string[] { "Love", "Fifteen", "Thirty", "Forty" };

    public string PrintScore(Player player1, Player player2)
    {

        if (player1.AreMatchingScores(player2))
        {
            return FormatMatchingScores(player1);
        }

        if (player1._score >= 4 || player2._score >= 4)
        {
            return FormatAdvantageOrWinningScores(player1, player2);
        }

        return $"{GetScore(player1)}-{GetScore(player2)}";

    }

    private static string GetScore(Player player)
    {
        return _score[player._score];
    }

    private static string FormatAdvantageOrWinningScores(Player player1, Player player2)
    {
        var playerScoreDifference = player1._score - player2._score;
        if (playerScoreDifference == 1)
        {
            return "Advantage player1";
        }

        if (playerScoreDifference == -1)
        {
            return "Advantage player2";
        }

        if (playerScoreDifference >= 2)
        {
            return "Win for player1";
        }

        return "Win for player2";
    }

    private static string FormatMatchingScores(Player player)
    {
        if (_matchingScores.ContainsKey(player._score))
            return _matchingScores[player._score];

        return "Deuce";
    }
}