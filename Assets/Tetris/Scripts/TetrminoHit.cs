using UnityEngine;
using System.Collections;

public class TetrminoHit : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
    
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Tetramino")
        {
            Application.LoadLevel("Level");
        }
    }
}