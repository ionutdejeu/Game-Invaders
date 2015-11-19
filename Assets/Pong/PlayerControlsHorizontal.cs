using UnityEngine;
using System.Collections;

public class PlayerControlsHorizontal: MonoBehaviour
{

    //Use this for initialization
    void Start()
    {

    }
    //Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = new Vector3(Mathf.Clamp( ray.GetPoint(10f).x,-2.5f,2.5f), transform.position.y, transform.position.z);
    }
}