using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

    public static int coinCount = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        string coinText = "Total Coins: " + coinCount;

        GUI.Box(new Rect(Screen.width - 150, 20, 130, 20), coinText);
    }
}
