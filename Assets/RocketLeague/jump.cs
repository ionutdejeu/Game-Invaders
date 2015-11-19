using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {
    private float CurrentTime;
	// Use this for initialization
	void Start () {
        CurrentTime = Time.time + 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentTime < Time.time)
        {
            Rigidbody Rb = GetComponent<Rigidbody>();
            Rb.velocity = new Vector3(Random.Range(-20, 20), Random.Range(15, 20), Random.Range(-20,20));
            CurrentTime = Time.time + 15.0f;
        }
	}
}
