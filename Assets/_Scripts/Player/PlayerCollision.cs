using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                GameManager.Instance.GameOver();
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            GameManager.Instance.LevelComplete();
            gameObject.SetActive(false); 
        }
    }
    IEnumerator GetHurt()
    {
        // play hurt animation
        GetComponent<Animator>().Play("MaxHurt");
        SoundManager.Instance.PlayEffect(
            GetComponent<PlayerMotor>().playerClips.playerSoundFx[5]);
        GetComponent<SpriteRenderer>().color = new Color(200, 0, 0, .8f); 
        yield return new WaitForSeconds(.3f);
        GetComponent<SpriteRenderer>().color = Color.white;
        //Physics2D.IgnoreLayerCollision(7, 8);
        //yield return new WaitForSeconds(3);
        //Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
