using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Data
{
    public bool[] stars;
    public bool[] currentStars;
    public int meteoritesLeft;
    public bool earthHit;
    public int[] highscores;
    public Data()
    {
        resetIngame();
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
        stars = new bool[3];
        currentStars = new bool[3];
        meteoritesLeft = 5;
        earthHit = false;
    }

    public int getStarCount()
    {
        int starCount = 0;
        for (int i = 0; i < 3; i++)
            starCount += stars[i] ? 1 : 0;
        return starCount;
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
            for (int i = 0; i < data.stars.Length; i++)
            {
                if (data.stars[i])
                    Destroy(GameObject.Find("Star" + i));
            }
            data.currentStars = new bool[3];

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddStar(int nr)
    {
        data.currentStars[nr] = true;
        GameObject.Find("Canvas").GetComponent<UIController>().RefreshScore();
    }

    public void ShotFinished(bool successful)
    {
        data.earthHit |= successful;
        if (successful)
        {
            for (int i = 0; i < 3; i++)
            {
                data.stars[i] |= data.currentStars[i];
            }
        }
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
