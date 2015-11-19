using UnityEngine;
using System.Collections;

public class BoundryScript : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Application.LoadLevel("PacPong");
    }
}