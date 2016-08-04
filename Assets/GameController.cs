using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private int stars;

	// Use this for initialization
	void Start () {
        stars = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddStar()
    {
        stars++;
        GameObject.Find("ScoreUI").GetComponent<ScoreController>().Refresh(stars);

    }
}
