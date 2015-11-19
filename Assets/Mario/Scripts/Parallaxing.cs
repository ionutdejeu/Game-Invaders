using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds;      //Array (list) of all the back- foregroundsto be parallax
    private float[] parallaxScales;
    public float smoothing = 1f;

    private Transform Cam;
    private Vector3 previousCamPos;


    void Awake() {
        Cam = Camera.main.transform;
    }


    // Use this for initialization
    void Start() {
        previousCamPos = Cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++) {
            parallaxScales[i] = backgrounds[i].position.z *- 1;
        }

	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i< backgrounds.Length ; i++) {
            float parallax = (previousCamPos.x - Cam.position.x) * parallaxScales[i];

            float backgroundsTargetPosX = backgrounds[i].position.x + parallax;


            Vector3 backgroundsTargetPos = new Vector3(backgroundsTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundsTargetPos, smoothing * Time.deltaTime);
        }
        previousCamPos = Cam.position;
    }
}
