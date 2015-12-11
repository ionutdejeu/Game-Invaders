using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TetrisScoreCounter : MonoBehaviour {

    public Text ScoreText;

    public AudioSource tetralinoRotateSound;
    public AudioSource marioJumpSound;
    public AudioSource endGameSound;

    public NextGameManager nextGameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore(int points)
    {
        GlobalScoreManager.GScore.TetrisScore += points;
        ScoreText.text = points + " points";
    }

    public void EndGame()
    {
        endGameSound.Play();
        nextGameManager.BeginTransition(NextGameManager.HomeScene, "Rocket league");
        
    }

    public void PlayRotateSound()
    {
        tetralinoRotateSound.Play();
    }
    public void PlayJumpSound()
    {
        marioJumpSound.Play();
    }
    
}
