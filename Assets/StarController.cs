using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Nogata")
        {
            GameObject.Find("GameController").GetComponent<GameController>().AddStar(int.Parse(name.Substring("Star".Length)));
            Destroy(gameObject);
        }
    }

}
