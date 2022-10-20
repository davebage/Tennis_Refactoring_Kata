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

        if (player1.GetScore() >= 4 || player2.GetScore() >= 4)
        {
            return FormatAdvantageOrWinningScores(player1, player2);
        }

        return $"{GetScore(player1)}-{GetScore(player2)}";

    }

    private static string GetScore(Player player)
    {
        return _score[player.GetScore()];
    }

    private static Player WinningPlayer(Player player1, Player player2)
    {
        if(player1.CompareTo(player2) > 0)
            return player1;

        return player2;
    }

    private static string FormatAdvantageOrWinningScores(Player player1, Player player2)
    {
        var playerScoreDifference = player1.GetScore() - player2.GetScore();
        if (playerScoreDifference == 1 || playerScoreDifference == -1)
        {
            return $"Advantage {WinningPlayer(player1, player2).GetName()}";
        }

        return $"Win for {WinningPlayer(player1, player2).GetName()}";
    }

    private static string FormatMatchingScores(Player player)
    {
        if (_matchingScores.ContainsKey(player.GetScore()))
            return _matchingScores[player.GetScore()];

        return "Deuce";
    }
}