using UnityEngine;
using System.Collections;

public class MarioCollectCoin : MonoBehaviour {


    private MarioScoreCounter counter;
	// Use this for initialization
	void Start () {
        counter = GameObject.Find("_GM").GetComponent<MarioScoreCounter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

 
   void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.name)
        {
            case "PacmanPrefab":
                counter.AddScore(1);
                Destroy(this.gameObject);

            break;
        }
    }
}
