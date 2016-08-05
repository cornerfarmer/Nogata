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
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Shot()
    {
        nogata.GetComponent<NogataController>().Shot();
    }

    void NextShot()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
