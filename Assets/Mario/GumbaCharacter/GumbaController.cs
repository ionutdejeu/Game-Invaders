using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class GumbaController : MonoBehaviour {

    
    private Transform groundCheck;                      // A position marking where to check if the player is grounded.
    private float groundedRadius = .2f;                 // Radius of the overlap circle to determine if grounded
    private bool grounded = false;                      // Whether or not the player is grounded.
    private Transform ceilingCheck;                     // A position marking where to check for ceilings
    private float ceilingRadius = .2f;                 // Radius of the overlap circle to determine if the player can stand up
    private bool isHitAbove = false;
    private Animator anim;                              // Reference to the player's animator component.
    private BoxCollider2D gumbaCollider;
    private Rigidbody2D rigidbody;
    // publics
    public LayerMask whatIsGround;
    public float movingSpeed = 2f;
    public float fallSpeed = 2f;

    // Use this for initialization
	void Awake() {
        groundCheck = transform.FindChild("GroundCheck");
        ceilingCheck = transform.FindChild("CeilingCheck");
        anim = this.GetComponent<Animator>();
        gumbaCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        //var groundCollider = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        //if (groundCollider != null && groundCollider.gameObject.name != this.name)
        //{
        //    grounded = true;
        //}
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

        var collider = Physics2D.OverlapPoint(ceilingCheck.position, whatIsGround);

        if (collider != null && collider.gameObject.name != this.name)
        {
            // Gumba should be squished.
            Debug.Log("Squish");
            anim.SetTrigger("IsDead");
            gumbaCollider.enabled = false;
            GameObject.Destroy(this.gameObject, 2f);
        }
        Move();
	}

    void Move()
    {
        if (grounded)
        {
            rigidbody.velocity = new Vector2(-movingSpeed, 0f) ;
        }
        else
        {
            rigidbody.velocity = new Vector2(-movingSpeed, -fallSpeed);
        }
    }


}
