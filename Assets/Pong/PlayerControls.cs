using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    //Use this for initialization
    void Start()
    {

    }
    //Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = new Vector3( transform.position.x, Mathf.Clamp(ray.GetPoint(10f).y,-2.0f,2.0f),transform.position.z);
    }
}