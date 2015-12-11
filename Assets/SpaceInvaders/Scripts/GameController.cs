using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int waveCount;
    public int hazardCount;
    public float spawnWait;
    public float startWait;


    public GUIText scoreText;
    public GUIText restartText;
    public GUIText GameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    private NextGameManager nextGame;
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        GameOverText.text = "";
        score = 0;
        UpdateScore();
       StartCoroutine (SpawnWaves(waveCount));
        nextGame = GameObject.Find("_GM").GetComponent<NextGameManager>();
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if(restart) {
            if(Input.GetKeyDown (KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
   IEnumerator SpawnWaves(int waveCount = 1)
    {
        for (int w = 0; w < waveCount; w++)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity; ;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
        }

        yield return new WaitForSeconds(5f);
        nextGame.BeginTransition(NextGameManager.HomeScene, "Rocket league");
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
	void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
        restartText.text = "Press 'R' to Restart !";
        restart = true;
        //break;
        // 0 - Stop 

        // 1 - Normal 
        Time.timeScale = 0.1f;

    }
}
