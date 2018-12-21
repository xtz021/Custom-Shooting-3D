using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestorePU : MonoBehaviour {

    GameObject player_;
    PlayerHealth playerHealth;
    bool playerInRange;
    AudioSource puAudio;

    // Use this for initialization
    void Awake () {
        puAudio = GameObject.Find("PowerUpAudio").GetComponent<AudioSource>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player_ = other.gameObject;
            playerInRange = true;
        }
    }
    

    // Update is called once per frame
    void Update () {
		if(playerInRange)
        {
            playerInRange = false;
            playerHealth = player_.GetComponent<PlayerHealth>();
            playerHealth.HealToFull();
            puAudio.Play();
            PowerUpsDuration.puCount--;
            Destroy(transform.parent.gameObject);
        }
	}
}
