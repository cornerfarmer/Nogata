using UnityEngine;
using System.Collections;

public class EarthController : MonoBehaviour {

    private bool exploded;
	// Use this for initialization
	void Start () {
        exploded = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (!exploded && other.name == "Nogata")
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(10, other.transform.position, 10);

            Vector3 dir = other.transform.position - transform.position;
            dir.Normalize();
            Quaternion particleRotation = Quaternion.LookRotation(dir);
            Vector3 particlePosition = transform.position + dir * transform.localScale.x / 2;

            GameObject explosionGO = (GameObject)Instantiate(Resources.Load("Explosion"));
            ParticleSystem explosionPS = explosionGO.GetComponent<ParticleSystem>();
            explosionPS.transform.rotation = particleRotation;
            explosionPS.transform.position = particlePosition;
            explosionPS.Play();

            GameObject smokeGO = (GameObject)Instantiate(Resources.Load("Smoke"));
            ParticleSystem smokePS = smokeGO.GetComponent<ParticleSystem>();
            smokePS.transform.rotation = particleRotation;
            smokePS.transform.position = particlePosition;
            smokePS.Play();

            other.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity * 0.3f;
            other.GetComponent<Collider>().isTrigger = true;

            exploded = true;
        }
    }
}
