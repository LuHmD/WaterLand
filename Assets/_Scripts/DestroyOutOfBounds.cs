using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);
        if (collision.CompareTag("Player"))
        {
            HealthManager.health = 0;
            GameManager.Instance.GameOver(); 
        }

    }
}
