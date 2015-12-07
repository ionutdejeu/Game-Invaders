using UnityEngine;
using System.Collections;

public class MarioGameManager : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter2D(Collider2D other)
    {
        // reset 
        if (this.gameObject.name == "Bounday")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (this.gameObject.name == "EndGame")
        {
            Application.LoadLevel(RocketLeagueGameManager.Manager.HomeGameLevel);
        }
    }

}
