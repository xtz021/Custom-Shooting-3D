using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerPU : MonoBehaviour {

    GameObject player_;
    GameObject rifleGun;
    bool playerInRange;
    AudioSource puAudio;
    
    [SerializeField]
    GameObject flameThrowerGun;

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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (playerInRange)
        {
            rifleGun = GameObject.Find("GunRifle");
            if(rifleGun != null)
            {
                playerInRange = false;
                Vector3 position = rifleGun.transform.position;
                Destroy(rifleGun);
                GameObject myFlameThrower = Instantiate(flameThrowerGun, position, rifleGun.transform.rotation,player_.transform) as GameObject;
                //myFlameThrower.transform.SetParent(player_.transform);
                puAudio.Play();
                PowerUpsDuration.puCount--;
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
