using UnityEngine;
using System.Collections;

public class HitGhost : MonoBehaviour
{
    public static int TotalNumberOfGhosts = 8;
    // Use this for initialization
    private NextGameManager gameManager;
    void Start()
    {
        TotalNumberOfGhosts = 8;
        gameManager = GameObject.Find("_GM").GetComponent<NextGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "pacman")
        {
            TotalNumberOfGhosts = TotalNumberOfGhosts - 1;
            if(TotalNumberOfGhosts <= 0)
            {
                gameManager.BeginTransition(NextGameManager.HomeScene, "Rocket league");
            }
            GameObject.Destroy(this.gameObject);
        }
        
    }
}