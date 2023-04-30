using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
public GameObject player;
public GameObject AudioHandler;
void OnTriggerEnter(Collider collision)
    {
        
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "PlayerCapsule")
        {
            //DestroyObject(gameObject);
            Object.Destroy(gameObject);
            player.GetComponent<PlayerScore>().AddScore();
           
           AudioHandler.GetComponent<WeDoALittleAudioHandling>().playcoinPickup();
           Debug.Log("Do something here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
    }
}
