using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionCube : MonoBehaviour {
    public static int score = 0;
    public static int ScoreCubes = 0;
    public static int ScoreSpheres = 0;
    public static bool visitedPong = false;
    public bool esteCub;
    public bool esteSfera;
    public Text textScoreCubes;
    public Text textScoreSpheres;
	// Use this for initialization
	void Start () {
	
	}
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Car")
        {
            Debug.Log("Picked up cube.");
            GameObject.Destroy(this.gameObject);
            score++;
            if (esteCub)
            {
                ScoreCubes++;
                textScoreCubes.text = "Cubes: " + ScoreCubes;
            }
            if (esteSfera)
            {
                ScoreSpheres++;
                textScoreSpheres.text = "Spheres: " + ScoreSpheres;
            }
        }
        CheckScore();

    }

    // Update is called once per frame
    void Update () {
        
	
	}

    public void CheckScore()
    {
        if (ScoreCubes > 1 && ScoreSpheres >1 && visitedPong==false)
        {
            visitedPong = true;
            // go to the next level 
            Application.LoadLevel(1);
        }
        if (ScoreCubes > 50 && ScoreSpheres > 50)
        {
            Application.LoadLevel("Pong/PacPong");
        }
    }
}
