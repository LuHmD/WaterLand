using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform m_FollowTarget;
    public Vector3 offset = new Vector3(4, 1.5f, -8f); 

    public bool followVertical = false; 
    private void LateUpdate()
    {
        transform.position = m_FollowTarget.position + offset;
        if (!followVertical)
            transform.position = new Vector3(m_FollowTarget.position.x, 2.5f, m_FollowTarget.position.z) + offset;     
    }
}
