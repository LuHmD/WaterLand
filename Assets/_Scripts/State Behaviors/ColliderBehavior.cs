using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBehavior : StateMachineBehaviour
{
    [SerializeField]
    private BoxCollider2D bodyCollider;
    public Vector2 slideSize;
    public Vector2 slideOffset; 
    private Vector2 previousSize;
    private Vector2 previousOffset;
    [SerializeField] float playerInitialSpeed =6f; 
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bodyCollider = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
        previousSize = bodyCollider.size;
        previousOffset = bodyCollider.offset;

        bodyCollider.size = slideSize;
        bodyCollider.offset = slideOffset; 
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bodyCollider.size = previousSize;
        bodyCollider.offset = previousOffset;
        FindObjectOfType<PlayerMotor>().speed = playerInitialSpeed; //initial speed.
    }
}
