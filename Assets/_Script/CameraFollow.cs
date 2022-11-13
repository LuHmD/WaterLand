using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform m_FollowTarget;
    public Vector3 offset; 

    public bool followVertical = false;

    private void Start()
    {
        transform.position = m_FollowTarget.position; 
    }
    private void LateUpdate()
    {
        var targetPos = m_FollowTarget.position + offset;
        transform.position = targetPos; 
        if (!followVertical)
            transform.position = new Vector3(m_FollowTarget.position.x,9.5f, m_FollowTarget.position.z) + offset;     
    }
}
