using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public GameObject nogata;
    
	// Use this for initialization
	void Start () {
        Button shotButton = transform.FindChild("ShotButton").GetComponent<Button>();
        shotButton.onClick.AddListener(Shot);

        Button nextShotButton = transform.FindChild("ShotFinishedPanel").FindChild("NextShotButton").GetComponent<Button>();
        nextShotButton.onClick.AddListener(NextShot);

        Button finishButton = transform.FindChild("ShotFinishedPanel").FindChild("FinishButton").GetComponent<Button>();
        finishButton.onClick.AddListener(FinishLevel);

        Button retryButton = transform.FindChild("LevelFinishedPanel").FindChild("RetryButton").GetComponent<Button>();
        retryButton.onClick.AddListener(Retry);

        RefreshScore();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Shot()
    {
        nogata.GetComponent<NogataController>().Shot();
        GameObject.Find("GameController").GetComponent<GameController>().ShotStarted();
        transform.FindChild("ShotButton").gameObject.SetActive(false);
    }

    void NextShot()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RefreshScore()
    {
        transform.FindChild("ScoreUI").GetComponent<Text>().text = "Stars: " + GameObject.Find("GameController").GetComponent<GameController>().GetData().stars;
        transform.FindChild("MeteoritesUI").GetComponent<Text>().text = "Meteorites: " + GameObject.Find("GameController").GetComponent<GameController>().GetData().meteoritesLeft;
    }

    public void ShowShotFinishedPanel()
    {
        Data data = GameObject.Find("GameController").GetComponent<GameController>().GetData();
        transform.FindChild("ShotFinishedPanel").FindChild("ScoreSummary").GetComponent<Text>().text = "Stars: " + data.stars + " (x2)\n";
        transform.FindChild("ShotFinishedPanel").FindChild("ScoreSummary").GetComponent<Text>().text += "Meteorites left: " + data.meteoritesLeft;
        transform.FindChild("ShotFinishedPanel").FindChild("NoScoreWarning").gameObject.SetActive(!data.earthHit);
        transform.FindChild("ShotFinishedPanel").FindChild("WholeScore").gameObject.SetActive(data.earthHit);
        transform.FindChild("ShotFinishedPanel").FindChild("WholeScore").GetComponent<Text>().text = "Score: " + (data.stars * 2 + data.meteoritesLeft);
        transform.FindChild("ShotFinishedPanel").FindChild("NextShotButton").gameObject.SetActive(data.meteoritesLeft > 0 && data.stars < 3);

        transform.FindChild("ShotFinishedPanel").gameObject.SetActive(true);
    }

    void Retry()
    {
        GameObject.Find("GameController").GetComponent<GameController>().Retry();
    }

    void FinishLevel()
    {
        transform.FindChild("ShotFinishedPanel").gameObject.SetActive(false);

        Data data = GameObject.Find("GameController").GetComponent<GameController>().GetData();
        transform.FindChild("LevelFinishedPanel").FindChild("Score").GetComponent<Text>().text = "Score: " + (data.stars * 2 + data.meteoritesLeft);
        transform.FindChild("LevelFinishedPanel").gameObject.SetActive(true);
    }
}
