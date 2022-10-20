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

        if (IsAdvantageScore(player1, player2))
        {
            return FormatAdvantageScores(player1, player2);
        }

        if (IsGameWon(player1, player2))
        {
            return FormatWinningScore(player1, player2);
        }

        return $"{GetScore(player1)}-{GetScore(player2)}";

    }

    private static bool IsAdvantageOrWinScore(Player player1, Player player2)
    {
        return player1.GetScore() >= 4 || player2.GetScore() >= 4;
    }

    private static string GetScore(Player player)
    {
        return ScoreLookupsFor.RegularScore[player.GetScore()];
    }

    private static Player WinningPlayer(Player player1, Player player2)
    {
        if(player1.CompareTo(player2) > 0)
            return player1;

        return player2;
    }

    private bool IsAdvantageScore(Player player1, Player player2)
    {
        return ((player1.GetScore() >= 4 || player2.GetScore() >= 4) &&
                (player1.GetScore() - player2.GetScore() == 1 || 
                 player1.GetScore() - player2.GetScore() == -1));
    }

    private bool IsGameWon(Player player1, Player player2)
    {
        return ((player1.GetScore() >= 4 || player2.GetScore() >= 4) &&
                (player1.GetScore() - player2.GetScore() >= 2 ||
                 player1.GetScore() - player2.GetScore() <= -2));
    }

    private static string FormatAdvantageScores(Player player1, Player player2)
    {
        
        return $"{ScoreLookupsFor.ADVANTAGE} {WinningPlayer(player1, player2).GetName()}";
    }

    private static string FormatWinningScore(Player player1, Player player2)
    {
        return $"{ScoreLookupsFor.WIN} {WinningPlayer(player1, player2).GetName()}";
    }

    private static string FormatMatchingScores(Player player)
    {
        
        if (ScoreLookupsFor.Matching.ContainsKey(player.GetScore()))
            return ScoreLookupsFor.Matching[player.GetScore()];

        return "Deuce";
    }
}