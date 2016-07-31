using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

    private Rigidbody rb;
    public float rotationSpeed = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
