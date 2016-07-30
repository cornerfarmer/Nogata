using UnityEngine;
using System.Collections;
using System;

public class DirectionController : MonoBehaviour {

    private Vector3 lastMousePos;
    public GameObject nogata;
    public float maxAngle = 360;
    public float minAngle = 270;
    public float maxScale = 5;
    public float minScale = 1;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        lastMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        lastMousePos.y = 0;
    }

    void OnMouseDrag()
    {
        Vector3 currMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        currMousePos.y = 0;

        Vector3 diff = currMousePos - nogata.transform.position;
        int sign = (currMousePos.z < nogata.transform.position.z ? -1 : 1);

        Vector3 currAngles = transform.parent.gameObject.transform.eulerAngles;
        currAngles.y = (float)(sign * Mathf.Acos(Vector3.Dot(diff, new Vector3(-1, 0, 0)) / diff.magnitude) / Mathf.PI * 180 + 270);
        currAngles.y = Mathf.Max(minAngle, Mathf.Min(maxAngle, currAngles.y));
        transform.parent.gameObject.transform.eulerAngles = currAngles;

        float scale = diff.magnitude / 7;
        scale = Mathf.Max(minScale, Mathf.Min(maxScale, scale));
        transform.parent.gameObject.transform.localScale = new Vector3(transform.parent.gameObject.transform.localScale.x, scale, transform.parent.gameObject.transform.localScale.z);
        lastMousePos = currMousePos;
    }

}
