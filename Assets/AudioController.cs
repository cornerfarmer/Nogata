using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    public AudioClip[] clips;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        AudioController otherAudioController = GameObject.Find("Audio Source").GetComponent<AudioController>();
        if (otherAudioController != this)
        {
            Destroy(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Length)];
            GetComponent<AudioSource>().Play();
        }
    }


}
