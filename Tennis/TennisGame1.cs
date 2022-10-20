using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private Dictionary<string, int> _scores = new Dictionary<string, int>();
        private readonly string[] _score = new string[] { "Love", "Fifteen", "Thirty", "Forty" };
        private readonly Dictionary<int, string> _matchingScores = new() { {0, "Love-All"}, {1, "Fifteen-All"}, {2, "Thirty-All"} };
        private const int ADVANTAGE_SCORE = 4;
        private const int ADVANTAGE_PLAYER_1 = 1;
        private const int ADVANTAGE_PLAYER_2 = -1;
        private const int WIN_PLAYER_1 = 2;

        public TennisGame1(string player1Name, string player2Name)
        {
            _scores.Add(player1Name, 0);
            _scores.Add(player2Name, 0);
        }

        public void WonPoint(string playerName)
        {
            _scores[playerName]++;
        }

        public string GetScore()
        {
            if (MatchingScores())
            {
                return FormatMatchingScores();
            }

            if (IsAdvantageOrWin())
            {
                return FormatAdvantageOrWinningScores();
            }

            return $"{GetScore(_scores.First().Value)}-{GetScore(_scores.Last().Value)}";
        }

        private string FormatAdvantageOrWinningScores()
        {
            var playerScoreDifference = _scores.First().Value -_scores.Last().Value;
            if (playerScoreDifference == ADVANTAGE_PLAYER_1)
            {
                return "Advantage player1";
            }

            if (playerScoreDifference == ADVANTAGE_PLAYER_2)
            {
                return "Advantage player2";
            }

            if (playerScoreDifference >= WIN_PLAYER_1)
            {
                return "Win for player1";
            }

            return "Win for player2";
        }

        private bool IsAdvantageOrWin()
        {
            return _scores.First().Value >= ADVANTAGE_SCORE || _scores.Last().Value >= ADVANTAGE_SCORE;
        }

        private bool MatchingScores()
        {
            return _scores.First().Value == _scores.Last().Value;
        }

        private string FormatMatchingScores()
        {
            if(_matchingScores.ContainsKey(_scores.First().Value))
                return _matchingScores[_scores.First().Value];

            return "Deuce";
        }

        private string GetScore(int tempScore)
        {
            return _score[tempScore];
        }
    }
}

