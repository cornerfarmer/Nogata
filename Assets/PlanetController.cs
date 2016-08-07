using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

    private Rigidbody rb;
    public float rotationSpeed = 2;
    private bool exploded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        exploded = false;
        Physics.IgnoreCollision(GameObject.FindGameObjectsWithTag("Nogata")[0].GetComponent<Collider>(), GetComponent<Collider>());

    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
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

            other.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity * 0.08f;
            other.GetComponent<Collider>().isTrigger = true;

            exploded = true;

            Destroy(other.gameObject, 2);

            GameObject.Find("GameController").GetComponent<GameController>().ShotFinished(name == "Earth");
        }
    }
}
