using UnityEngine;
using System.Collections;

public class MarioCollectCoin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.name)
        {
            case "PacmanPrefab":
            CoinController.coinCount++;
                Destroy(this.gameObject);

            break;
        }

    }
}
