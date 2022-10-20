using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly TennisPlayers _players;
        private readonly ScorePrinter _scorePrinter;

        public TennisGame1(string player1Name, string player2Name)
        {
            _players = new TennisPlayers(player1Name, player2Name);
            _scorePrinter = new ScorePrinter(_players);
        }

        public void WonPoint(string playerName)
        {
            _players.AddPointForPlayer(playerName);
        }

        public string GetScore()
        {
            return _scorePrinter.PrintScore();
        }
    }
}

