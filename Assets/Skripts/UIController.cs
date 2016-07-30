using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject nogata;

	// Use this for initialization
	void Start () {
        Button shotButton = transform.FindChild("ShotButton").GetComponent<Button>();
        shotButton.onClick.AddListener(Shot);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Shot()
    {
        nogata.GetComponent<NogataController>().Shot();
    }
}
