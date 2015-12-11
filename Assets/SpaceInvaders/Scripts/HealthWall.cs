using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthWall : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
   
    void Start()
    {
        currentHealth = 10;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            GameObject.Destroy(this.transform.parent.gameObject);
        }
    }

    public void DestroyWall()
    {
        // aici apare explozia de perete;
    }
}

