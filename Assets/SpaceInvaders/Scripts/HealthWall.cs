using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthWall : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    void Start()
    {
        currentHealth = startingHealth;
    }



}

