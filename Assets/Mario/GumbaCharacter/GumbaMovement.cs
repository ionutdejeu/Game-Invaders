using UnityEngine;
using System.Collections;

public class GumbaMovement : MonoBehaviour {

    public float speed = 1.0f;
	// Use this for initialization
    private Rigidbody2D rb; 
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(rb.transform.position + transform.right * -1 * speed * Time.deltaTime);
        
	}
}
