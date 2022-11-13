using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public float movespd = 2f;
    public float jumpForce = 10f; 
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * movespd * Time.deltaTime); 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // gravity will then reduce the velocity on it's own. 
            rb.velocity = Vector2.up * jumpForce; 
        }
    }
}
