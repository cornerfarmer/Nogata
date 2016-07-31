using UnityEngine;
using System.Collections;

public class NogataController : MonoBehaviour {
    
    public GameObject direction;
    private Rigidbody rb;
    private GameObject[] gravitiyInfluencers;
    private float G = 6.674e-11f;
    private bool shot;
    public float rotationSpeed = 800;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        gravitiyInfluencers = GameObject.FindGameObjectsWithTag("GravityInfluencer");
        shot = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (shot)
        {
            foreach (GameObject gravitiyInfluencer in gravitiyInfluencers)
            {
                Vector3 diff = gravitiyInfluencer.transform.position - transform.position;

                float strength = G * gravitiyInfluencer.GetComponent<Rigidbody>().mass * rb.mass / Mathf.Pow(diff.magnitude, 2) * 10e7f;

                diff.Normalize();

                rb.AddForce(diff * strength);
            }
            
        }
    }

    public void Shot()
    {
        Vector3 angle = direction.transform.eulerAngles;
        Vector3 dir = new Vector3(Mathf.Sin(angle.y / 180 * Mathf.PI), 0, Mathf.Cos(angle.y / 180 * Mathf.PI));

        rb.AddForce(dir * direction.transform.localScale.y * 1000);
        shot = true;
        direction.SetActive(false);

        Vector3 rot = new Vector3(Random.Range(0.00001f, 1), Random.Range(0.00001f, 1), Random.Range(0.00001f, 1));
        rot.Normalize();
        rb.AddTorque(rot.x * rotationSpeed, rot.y * rotationSpeed, rot.z * rotationSpeed);
    }



}
