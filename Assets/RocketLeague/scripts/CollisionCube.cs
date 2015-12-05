using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionCube : MonoBehaviour {

    public bool esteCub;
    public bool esteSfera;

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
                RocketLeagueGameManager.Manager.AddScore(1, 0);
            }
            if (esteSfera)
            {
                RocketLeagueGameManager.Manager.AddScore(0, 1);
            }
        }
        

    }
}
