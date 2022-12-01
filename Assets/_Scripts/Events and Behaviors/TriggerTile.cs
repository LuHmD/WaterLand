using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTile : MonoBehaviour
{
    public GameObject[] triggerObject;
    public AnimteComplexTile[] enableObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (var trigger in triggerObject)
            {
                trigger.SetActive(true);
            }
            foreach (var go in enableObject)
            {
                go.enabled = true; 
            }
        }

    }
}
