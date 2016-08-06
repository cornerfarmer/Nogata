using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Data
{
    public int stars;
    public int meteoritesLeft;
    public bool earthHit;

    public Data()
    {
        stars = 0;
        meteoritesLeft = 5;
        earthHit = false;
    }
}

public class GameController : MonoBehaviour {

    private Data data;
    public GameObject shotFinishedPanel;
    
    // Use this for initialization
    void Awake () {
        data = new Data();
        DontDestroyOnLoad(transform.gameObject);
        GameController otherGameController = GameObject.Find("GameController").GetComponent< GameController>();
        if (otherGameController != this)
        {
            data = otherGameController.data;
            Destroy(otherGameController.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddStar()
    {
        data.stars++;
        GameObject.Find("Canvas").GetComponent<UIController>().RefreshScore();
    }

    public void ShotFinished(bool successful)
    {
        data.earthHit |= successful;
        GameObject.Find("Canvas").GetComponent<UIController>().ShowShotFinishedPanel();
    }

    public void ShotStarted()
    {
        data.meteoritesLeft--;
        GameObject.Find("Canvas").GetComponent<UIController>().RefreshScore();
    }

    public Data GetData()
    {
        return data;
    }

    public void Retry()
    {
        data = new Data();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameObject.Find("Canvas").GetComponent<UIController>().ShowIngameUI();
    }
}
