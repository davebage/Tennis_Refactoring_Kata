using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private readonly string[] _score = new string[] { "Love", "Fifteen", "Thirty", "Forty" };
        private readonly Dictionary<int, string> _matchingScores = new Dictionary<int, string>() { {0, "Love-All"}, {1, "Fifteen-All"}, {2, "Thirty-All"} };

        public TennisGame1(string player1Name, string player2Name)
        {
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (MatchingScores())
            {
                return GetMatchingScore();
            }
            else if (_player1Score >= 4 || _player2Score >= 4)
            {
                var minusResult = _player1Score - _player2Score;
                if (minusResult == 1)
                {
                    score = "Advantage player1";
                }
                else if (minusResult == -1)
                {
                    score = "Advantage player2";
                }
                else if (minusResult >= 2)
                {
                    score = "Win for player1";
                }
                else
                {
                    score = "Win for player2";
                }
            }
            else
            {
                return $"{GetScore(_player1Score)}-{GetScore(_player2Score)}";
            }
            return score;
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

