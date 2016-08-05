using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    private int stars;
    public GameObject shotFinishedPanel;

    // Use this for initialization
    void Start () {
        stars = 0;
        DontDestroyOnLoad(transform.gameObject);
        GameController otherGameController = GameObject.Find("GameController").GetComponent< GameController>();
        if (otherGameController != this)
        {
            stars = otherGameController.stars;
            Destroy(otherGameController.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddStar()
    {
        stars++;
        GameObject.Find("ScoreUI").GetComponent<ScoreController>().Refresh(stars);
    }

    public void ShotFinished(bool successful)
    {
        shotFinishedPanel.SetActive(true);
    }
}
