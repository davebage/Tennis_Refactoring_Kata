using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly TennisPlayers _players;
        private readonly ScorePrinter _scorePrinter = new();

        public TennisGame1(string player1Name, string player2Name)
        {
            _players = new TennisPlayers(player1Name, player2Name);
        }

        public void WonPoint(string playerName)
        {
            _players.AddPointForPlayer(playerName);
        }

        public string GetScore()
        {
            return _scorePrinter.PrintScore(_players.GetPlayerOne(), _players.GetPlayerTwo());
        }
    }
}

