using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime); 
    }
}
