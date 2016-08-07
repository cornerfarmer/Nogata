using UnityEngine;
using System.Collections;

public class WorldsEndController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Nogata")
        {
            GameObject.Find("GameController").GetComponent<GameController>().ShotFinished(false);
        }
    }
}
