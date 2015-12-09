using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.name)
        {
            case "Player":
            CoinController.coinCount++;
                Destroy(this.gameObject);

            break;
        }

    }
}
