using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Data
{
    public int stars;
    public int meteoritesLeft;
    public bool earthHit;
    public int[] highscores;
    public Data()
    {
        stars = 0;
        meteoritesLeft = 5;
        earthHit = false;
        highscores = new int[SceneManager.sceneCountInBuildSettings - 1];
    }

    public int getCurrentHighscore()
    {
        return highscores[int.Parse(SceneManager.GetActiveScene().name.Substring("Level".Length)) - 1];
    }

    public void setCurrentHighscore(int score)
    {
        highscores[int.Parse(SceneManager.GetActiveScene().name.Substring("Level".Length)) - 1] = score;
    }

    public void resetIngame()
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
        data.resetIngame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameObject.Find("Canvas").GetComponent<UIController>().ShowIngameUI();
    }
}
