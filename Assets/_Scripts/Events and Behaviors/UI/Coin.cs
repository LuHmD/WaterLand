using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public PlayerClips coinClips; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            SoundManager.Instance.PlayEffect(coinClips.playerSoundFx[0]); 
            GameManager.Instance.numberOfCoins++;
            PlayerPrefs.SetInt("NumberOfCoins", GameManager.Instance.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
