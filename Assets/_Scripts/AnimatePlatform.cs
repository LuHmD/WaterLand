using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlatform : MonoBehaviour
{
    public Vector2 minBoundary;
    public Vector2 maxBoundary;

    public bool reverse = false;

    [Tooltip("Set the delay for platform to change direction")] public float transitionDelay;
    [Tooltip("Set time it'll take to move between boundaries")] public float animateSpeed;


    private void Start()
    {
        if (!reverse)
            moveToMin();
        else
            moveToMax();
    }
    void moveToMax()
    {
        LeanTween.move(gameObject, maxBoundary, animateSpeed).setDelay(transitionDelay).setOnComplete(moveToMin);
    }
    void moveToMin()
    {
        LeanTween.move(gameObject, minBoundary, animateSpeed).setDelay(transitionDelay).setOnComplete(moveToMax);
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
