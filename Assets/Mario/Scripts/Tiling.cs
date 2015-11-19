using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour {

    public int offsetX = 2;

    public bool hasARightBuddy = false;
    public bool hasARLeftBuddy = false;

    public bool reverseScale = false;

    private float spriteWidh = 0f;
    private Camera cam;
    private Transform myTransform;

    void Awake() {
        cam = Camera.main;
        myTransform = transform;
    }


    // Use this for initialization
    void Start () {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidh = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
	    if(hasARLeftBuddy == false || hasARightBuddy == false){
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidh / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidh / 2) - camHorizontalExtend;

            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false) {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisiblePositionRight + offsetX == false) {
                MakeNewBuddy(-1);
                hasARLeftBuddy = true;
            }

        }
    }
    void MakeNewBuddy(int rightOrLeft) {
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidh + rightOrLeft, myTransform.position.y, myTransform.position.z);
        Transform newBuddy = Instantiate ( myTransform, newPosition, myTransform.rotation) as Transform ;

        if (reverseScale == true) {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }
        newBuddy.parent = myTransform.parent;
        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasARLeftBuddy = true;
        }

    }
}
