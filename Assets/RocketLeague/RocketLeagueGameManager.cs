using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class RocketLeagueGameManager : MonoBehaviour {


    private static RocketLeagueGameManager _instance;
    public static RocketLeagueGameManager Manager
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("_GM").GetComponent<RocketLeagueGameManager>();
            }
            return _instance;
        }
        set { _instance = value; }
    }
    
    [Serializable]
    public class RockeLeagueScoreInterval
    {
        public int SphereScore;
        public int CubeScore;
        public string GameName;
        public string GameLevelName=string.Empty;
        public int GameLevel;
        public bool isVisited; 
    }
    
    [SerializeField]
    public List<RockeLeagueScoreInterval> scores = new List<RockeLeagueScoreInterval>()
    {
        new RockeLeagueScoreInterval(){
            SphereScore  = 1,
            CubeScore = 1, 
            GameName = "Mario",
            GameLevel =1
        }
    };

    public int HomeGameLevel = 2;

    public int ScoreCubes = 0;
    public int ScoreSpheres = 0;
    
    public static bool visitedPong = false;
    public enum GameState { Counting, Waiting }

    public GameState CurrentState;
    public GameState PreviousState;
    public GameObject NextGameUI;
    public Text NextGameSecondsCountdown;
    public Text NextGameTitle;
    public Text textScoreCubes;             // The score for the cubes 
    public Text textScoreSpheres;           // The score for the spheres

    public AudioSource pickUpAudio;
    public AudioSource endLevelAudio;
    // Use this for initialization


    // privates 
    private Animator countdowownAnimator;
    private float nextAnimationTime;
    private float nextTimeForCountdowAnimation;
    private int levelToLoad;

    void Awake()
    {
        //this.scores = RocketLeagueGameManager.Manager.scores;
        //ScoreCubes = RocketLeagueGameManager.Manager.ScoreCubes;
        //ScoreSpheres = RocketLeagueGameManager.Manager.ScoreSpheres;
        //this.RefreshScore();
        
    }
	void Start () {
       
        CurrentState = GameState.Waiting;
        PreviousState = CurrentState;
	}
	
    public void CheckNextLelve()
    {
        bool endLevel = false;
        foreach (var score in scores)
        {
            if (ScoreCubes > score.CubeScore && ScoreSpheres > score.SphereScore && score.isVisited == false)
            {
                score.isVisited = true;
                NextGameUI.SetActive(true);
                NextGameTitle.text = score.GameName;
                PreviousState = CurrentState;
                CurrentState = GameState.Counting;
                nextTimeForCountdowAnimation = 4f;
                endLevelAudio.Play();
                endLevel = true;
                levelToLoad = score.GameLevel;
            }
        }
        if(endLevel == false)
        {
            pickUpAudio.Play();
        }
    }

    /// <summary>
    /// This function loads the rocket league level and refreshes the content
    /// </summary>
    public void ReturnToRocketLeague(RockeLeagueScoreInterval interval)
    {
        
        

    }


    public void RefreshScore()
    {
        textScoreCubes.text = "Cubes: " + ScoreCubes;
        textScoreSpheres.text = "Spheres: " + ScoreSpheres;
    }
    public void AddScore(int pScoreSpheres = 0, int pScoreCubes = 0)
    {
        
        ScoreCubes += pScoreCubes;
        ScoreSpheres += pScoreSpheres;
        this.RefreshScore();        
        this.CheckNextLelve();
    }

    void Update()
    {
        if (CurrentState == GameState.Counting)
        {
            nextTimeForCountdowAnimation -= Time.deltaTime;
            NextGameSecondsCountdown.text = ((int)nextTimeForCountdowAnimation).ToString();

            if (nextTimeForCountdowAnimation <= 0)
            {
                // load the next level 
                CurrentState = GameState.Waiting;
                NextGameUI.SetActive(false);
                Application.LoadLevel(levelToLoad);
            }
        }
    }
}
