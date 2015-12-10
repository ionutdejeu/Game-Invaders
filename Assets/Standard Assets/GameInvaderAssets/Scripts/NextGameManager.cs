using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class NextGameManager : MonoBehaviour {

    public enum GameState { Counting, Waiting };

    public GameState CurrentState;
    public GameObject NextGameUI;
    public Text NextGameSecondsCountdown;
    public Text NextGameTitle;
   
    // privates
    private float nextTimeForCountdowAnimation;
    private int levelToLoad;

   
    public static int HomeScene = 2;            // This is the scene where the app should return

	// Use this for initialization
	void Start () {
        NextGameUI.SetActive(false);
        // U = User 
        // I = Interface
        CurrentState = GameState.Waiting;
	}
	
	// Update is called once per frame
	void Update () {
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

    /// <summary>
    /// This function gegins the transition to the next game level
    /// </summary>
    /// <param name="LevelToLoad">the ID of the scene to load as next level</param>
    public void BeginTransition(int pLevelToLoad, string nextLevelName="")
    {
        NextGameTitle.text = nextLevelName;
        NextGameUI.SetActive(true);
        levelToLoad = pLevelToLoad;
        nextTimeForCountdowAnimation = 4f;
        CurrentState = GameState.Counting;
    }

    
}
