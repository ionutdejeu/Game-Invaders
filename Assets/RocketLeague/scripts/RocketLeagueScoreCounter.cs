using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class RocketLeagueScoreCounter : MonoBehaviour {

    // audio components
    public AudioSource pickUpAudio;
    public AudioSource endLevelAudio;

    public Text textScoreCubes;             // The score for the cubes 
    public Text textScoreSpheres;


    public NextGameManager nextGameManager;

    void Start()
    {
        this.RefreshScore();
    }

    public void RefreshScore()
    {
        textScoreCubes.text = "Cubes: " + GlobalScoreManager.GScore.RocketLeagueCubeScore;
        textScoreSpheres.text = "Spheres: " + GlobalScoreManager.GScore.RocketLeagueSphereScore;;
    }
    public void AddScore(int pScoreSpheres = 0, int pScoreCubes = 0)
    {
        GlobalScoreManager.GScore.RocketLeagueCubeScore+=pScoreCubes;
        GlobalScoreManager.GScore.RocketLeagueSphereScore+=pScoreSpheres;
        this.RefreshScore();
        pickUpAudio.Play();
        // get the next level
        ScoreCheckoint ch = this.CheckNextLevel();
        
        if (ch!=null)
        {
            // mark the next level as visited;
            ch.isVisited = true;

            endLevelAudio.Play();
            // begin the transition to the next level
            nextGameManager.BeginTransition(ch.GameLevel,ch.GameLevelName);
            
        }

    }

    // sub classes
    [Serializable]
    public class ScoreCheckoint
    {
        public int SphereScore;
        public int CubeScore;
        public string GameName;
        public string GameLevelName = string.Empty;
        public int GameLevel;
        public bool isVisited;
    }

    [SerializeField]
    public static List<ScoreCheckoint> scores = new List<ScoreCheckoint>()
    {
        new ScoreCheckoint(){
            SphereScore  = 2,
            CubeScore = 2, 
            GameLevelName = "Tetris",
            GameLevel = 2,
            isVisited = false
        },
        new ScoreCheckoint(){
            SphereScore  = 5,
            CubeScore = 5, 
            GameLevelName = "Mario",
            GameLevel =0,
            isVisited = false
        },
        new ScoreCheckoint(){
            SphereScore  = 7,
            CubeScore = 7, 
            GameLevelName = "Pong",
            GameLevel = 3,
            isVisited = false
        }
    };

    public ScoreCheckoint CheckNextLevel()
    {
        foreach (var score in scores)
        {
            if (GlobalScoreManager.GScore.RocketLeagueCubeScore > score.CubeScore &&
                GlobalScoreManager.GScore.RocketLeagueSphereScore > score.SphereScore &&
                score.isVisited == false)
            {
                return score;
            }
        }
        return null;
    }


}
