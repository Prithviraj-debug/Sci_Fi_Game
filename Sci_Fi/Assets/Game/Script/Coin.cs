using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coinPickUp;                                                                 //play coin sound

    //check for collision
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")                                                              //check if player
        {
            if (Input.GetKeyDown(KeyCode.E))                                                  //check for e key press
            {
                Player player = other.GetComponent<Player>();
                if (player != null)                                                           //give player the coin
                {
                    player.hasCoin = true;
                    AudioSource.PlayClipAtPoint(_coinPickUp, Camera.main.transform.position, 1f);
                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if (uiManager != null)
                    {
                        uiManager.CollectedCoin();
                    }

                    Destroy(this.gameObject);                                               //destroy the coin
                }
            }
        }
    }
    
    

    
    
}
