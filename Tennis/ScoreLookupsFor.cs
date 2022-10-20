using System.Collections.Generic;

namespace Tennis;

internal static class ScoreLookupsFor
{
    internal static readonly Dictionary<int, string> Matching = new() { { 0, "Love-All" }, { 1, "Fifteen-All" }, { 2, "Thirty-All" } };
    internal static readonly string[] RegularScore = new string[] { "Love", "Fifteen", "Thirty", "Forty" };
    internal const string ADVANTAGE = "Advantage";
    internal const string WIN = "Win for";
}