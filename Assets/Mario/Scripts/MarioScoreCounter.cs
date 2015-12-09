using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarioScoreCounter : MonoBehaviour {

    public Text scoreText;
    public NextGameManager nextGameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RefreshScore()
    {
        scoreText.text = GlobalScoreManager.GScore.MarioCollectedCoins.ToString() ;
        
    }
    public void AddScore(int pCoin = 0)
    {
        
        GlobalScoreManager.GScore.MarioCollectedCoins += pCoin;
        this.RefreshScore();

    }
    
}
