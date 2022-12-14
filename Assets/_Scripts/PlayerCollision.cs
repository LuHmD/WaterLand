using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if(HealthManager.health <= 0)
            {
                GameManager.isGameOver = true;
                gameObject.SetActive(false);

            }
            else
            {
                StartCoroutine(GetHurt());
            }
           
        }
    } 

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
