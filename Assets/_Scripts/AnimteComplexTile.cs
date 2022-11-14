using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimteComplexTile : MonoBehaviour
{
    public Vector2[] movePoints; // work in hand with the inspector and editor to make this work well. 
    private int nextIdx;
    public bool playOneShot = false;

    [Tooltip("Set the delay for platform to change direction")] public float transitionDelay;
    [Tooltip("Set time it'll take to move between boundaries")] public float animateSpeed;
    private void Start()
    {
        NavigatePoints();
    }

    void NavigatePoints()
    {
        LeanTween.move(gameObject, movePoints[nextIdx], animateSpeed).setDelay(transitionDelay).setOnComplete(()
            =>
        {
            if (nextIdx < movePoints.Length - 1)
                nextIdx++;
            else
            {
                if (playOneShot)
                    return; // if play one shot, don't start all over. 
                nextIdx = 0;
            }
            NavigatePoints();
        });
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}
