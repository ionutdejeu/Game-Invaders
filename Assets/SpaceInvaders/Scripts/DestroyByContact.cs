using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private  GameController gameController;

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    


    void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject == null)
        {
            Debug.Log("Cannot find  'GameController' script");
        }
        currentHealth = startingHealth;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        GameObject naveExpl = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        GameObject.Destroy(naveExpl.gameObject, 1f);
        if (other.tag == "Player")
        {
            GameObject playerExpl = Instantiate(playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            GameObject.Destroy(playerExpl, 1f);
            gameController.GameOver();
        }
        gameController.AddScore (scoreValue);
        // Destroy(other.gameObject);   
        if(other.gameObject.tag == "wall")
        {
           
            // aici nava/obiectu se loveste de perete 
            HealthWall viataPere= other.gameObject.GetComponent<HealthWall>();
            // scazi viata din perete 
            viataPere.TakeDamage(10);
        }
      
        Destroy(gameObject);
    }
}