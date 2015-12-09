using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GlobalScoreManager
{
    public static int RocketLeagueGameLevel = 2;
    public static int MarioGameLevel = 1;


    public class GlobalScore
    {
        public int RocketLeagueCubeScore = 0;
        public int RocketLeagueSphereScore = 0;
        public int MarioCollectedCoins = 0;
        public int PongScore = 0;
        public int TetrisScore = 0;
    }

    private static GlobalScore _globalScore;

    public static GlobalScore GScore
    {
        get {
            if (_globalScore == null)
            {
                _globalScore = new GlobalScore();
            }
            return GlobalScoreManager._globalScore; 
        }
        set { GlobalScoreManager._globalScore = value; }
    }
    
}

