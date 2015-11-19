using UnityEngine;
using System.Collections;
public class CubeColor : MonoBehaviour
{
    private int CubeSize;
    public GameObject ObjectToCopy;
    public int NrCubes = 10;
    public Color[] ColorList = new Color[] { Color.black, Color.blue, Color.cyan, Color.red, Color.yellow, Color.green };
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i <= NrCubes; i++)
        {
            CubeSize = Random.Range(2, 5);
           GameObject CubeClone = GameObject.Instantiate(ObjectToCopy, new Vector3(Random.Range(70, 420), Random.Range(5,10), Random.Range(70, 430)), Quaternion.Euler(Random.Range(12, 45), Random.Range(12, 45), Random.Range(12, 45))) as GameObject;
            CubeClone.transform.localScale = new Vector3(CubeSize,CubeSize,CubeSize);
            GameObject[] listOfCubes = GameObject.FindGameObjectsWithTag("Cube");
            int currentObject = 0;
            while (currentObject < listOfCubes.Length)
            {
                Renderer rend = listOfCubes[currentObject].GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", ColorList[Random.Range(0, ColorList.Length)]);
                currentObject++;
            }
        }
    }
    //It's mind blowing why that fuckin' "}" doesn't work.Ask Ionut about it, I still don't get it. ... Got it.
    void Update()
    {

    }
}