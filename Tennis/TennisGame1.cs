using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private readonly string[] _score = new string[] { "Love", "Fifteen", "Thirty", "Forty" };
        private readonly Dictionary<int, string> _matchingScores = new() { {0, "Love-All"}, {1, "Fifteen-All"}, {2, "Thirty-All"} };
        private const int ADVANTAGE_SCORE = 4;
        private const int ADVANTAGE_PLAYER_1 = 1;
        private const int ADVANTAGE_PLAYER_2 = -1;
        private const int WIN_PLAYER_1 = 2;

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        public string GetScore()
        {
            if (MatchingScores())
            {
                return GetMatchingScore();
            }

            if (IsAdvantageOrWin())
            {
                var playerScoreDifference = _player1Score - _player2Score;
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

            return $"{GetScore(_player1Score)}-{GetScore(_player2Score)}";
        }

        private bool IsAdvantageOrWin()
        {
            return _player1Score >= ADVANTAGE_SCORE || _player2Score >= ADVANTAGE_SCORE;
        }

        private bool MatchingScores()
        {
            return _player1Score == _player2Score;
        }

        private string GetMatchingScore()
        {
            if(_matchingScores.ContainsKey(_player1Score))
                return _matchingScores[_player1Score];

            return "Deuce";
        }

        private string GetScore(int tempScore)
        {
            return _score[tempScore];
        }
    }
}

