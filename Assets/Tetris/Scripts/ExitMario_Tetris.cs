using UnityEngine;
using System.Collections;

public class ExitMario_Tetris : MonoBehaviour {

    TetrisScoreCounter counter;
    void Start()
    {
        counter = GameObject.Find("_GM").GetComponent<TetrisScoreCounter>();
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        counter.EndGame();
    }

}
