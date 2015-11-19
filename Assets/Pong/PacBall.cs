using UnityEngine;
using System.Collections;

public class PacBall : MonoBehaviour {

    int Invert;
    public int TowardsPlayer = 1;

    //Use this for initialization
    void Start()
    {
        Invert = 1;
        TowardsPlayer = 1;
        GetComponent<Rigidbody2D>().velocity = new Vector3(5.0f, 1.0f, 0.0f);
        
    }

    //Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
   
        if (collision.gameObject.name == "TOP" || collision.gameObject.name == "BOT")
        {
            Invert = Invert * -1;
            GetComponent<Rigidbody2D>().velocity = new Vector3(5.0f * TowardsPlayer, 5.0f * Invert, 0.0f);
        }
   else if (collision.gameObject.name == "Player1")
        {
            TowardsPlayer = 1;
            this.transform.Rotate(0.0f, 0.0f, 180.0f);
            GetComponent<Rigidbody2D>().velocity = new Vector3(5.0f, 5.0f * Invert, 0.0f);
        }
        else if (collision.gameObject.name == "Player2")
        {
            TowardsPlayer = -1;
            this.transform.Rotate(0.0f, 0.0f, -180.0f);
            GetComponent<Rigidbody2D>().velocity = new Vector3(-5.0f, 5.0f * Invert, 0.0f);
        }
    }
}
