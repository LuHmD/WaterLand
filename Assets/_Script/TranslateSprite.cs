using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSprite : MonoBehaviour
{
    public Vector2 moveDirection;
    [SerializeField] float moveSpeed; 
    private void FixedUpdate()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); 
    }
}
