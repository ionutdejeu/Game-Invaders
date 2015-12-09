using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionCube : MonoBehaviour {

    public bool esteCub;
    public bool esteSfera;
    public RocketLeagueScoreCounter scoreCounter;

	// Use this for initialization
	void Start () {
	
	}
    
    
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Car")
        {
           
            GameObject.Destroy(this.gameObject);
           
            if (esteCub)
            {
               scoreCounter.AddScore(1, 0);
            }
            if (esteSfera)
            {
                scoreCounter.AddScore(0, 1);
            }
        }
        

    }
}
