using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenga.OopAdv.Class01.Task03.Logic.Game
{
    public class Game
    {
        private int GamesPlayed { get; set; }
        protected bool IsActive { get; set; }

        public Game()
        {
            GamesPlayed = 0;
        }

        protected void IncreaseGamesPlayed()
        {
            GamesPlayed += 1;
        }

        protected int GetGamesPlayed()
        {
            return GamesPlayed;
        }
    }
}
