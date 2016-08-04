using UnityEngine;
using System.Collections;

public class CircleAroundController : MonoBehaviour {
    
    public GameObject center;
    public float speed = 10;
    public int dir = 1;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 rot = Quaternion.AngleAxis(90, Vector3.up) * (transform.position - center.transform.position);
        rot.Normalize();

        rb.velocity = rot * speed * dir;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 diff = (transform.position - center.transform.position);

        float strength = speed * speed * rb.mass / diff.magnitude;
        diff.Normalize();

        rb.AddForce(-diff * strength);
    }
}
