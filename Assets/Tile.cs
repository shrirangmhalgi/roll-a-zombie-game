using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public GameManager gameManager; //normal java style has a relationship (it takes script of main camera as AddPoint func is in GameManager)
    public AudioClip hit; //this is for getting the audioclip 
    AudioSource source;  //for adding a audio and then we will use to play it

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        gameManager.AddPoint();
        source.PlayOneShot(hit);
    }
}
