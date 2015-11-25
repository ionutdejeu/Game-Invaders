using UnityEngine;
using System.Collections;

public class ExitMario_Tetris : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Application.LoadLevel("GameOver");
    }

}
