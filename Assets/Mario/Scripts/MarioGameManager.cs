using UnityEngine;
using System.Collections;

public class MarioGameManager : MonoBehaviour {


    private float scoreTransferTick; 
    
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
            Application.LoadLevel(GlobalScoreManager.RocketLeagueGameLevel);
        }
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(other.gameObject, 1f);
        }
    }

    
}
