using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    [SerializeField, Tooltip("Set the int indicator times before the tile collapses"), Range(3, 7)] int fallDelay;
    [SerializeField, Tooltip("Set Fall Speed"), Range(0, 5)] float fallSpeed;

    [Tooltip("Set the Indicator Color")] public Color indicatorColor;
    private float indicatorRate = .5f;

    private bool _shouldFall = false;
    // This tile will fall when you trigger it, it will fall all the way to the button, out of sight and destroy itself. 

    IEnumerator CollapseTile()
    {
        for (int i = 0; i < fallDelay; i++)
        {
            ChangeColor(indicatorColor);
            yield return new WaitForSeconds(indicatorRate);
            ChangeColor(Color.white);
            yield return new WaitForSeconds(indicatorRate);
            indicatorRate /= 2f; // it'll start slow, then start beeping fast to indicate fall. 
        }
        _shouldFall = true;
    }

    private void FixedUpdate()
    {
        if (!_shouldFall)
            return;
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void ChangeColor(Color c)
    {
        GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 1); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!_shouldFall)
                StartCoroutine(CollapseTile());
        }
    }

}
