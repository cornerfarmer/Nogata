using UnityEngine;
using System.Collections;

public class SkyboxController : MonoBehaviour {

    public float rotateSpeed = 0.01f;
    private Skybox s;
    // Use this for initialization
    void Start () {
         s = GetComponent<Skybox>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        s.material.SetFloat("_Rotation", (s.material.GetFloat("_Rotation") + rotateSpeed) % 360);
    }
}
