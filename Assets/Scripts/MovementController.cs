using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 3.0F;
    private Vector2 movement = new Vector2();
    private Rigidbody2D rgb;
    Animator animator;
    string animationState = "AnimationState";

enum CharStates
 {
 walkEast = 1,
 walkSouth = 2,
 walkWest = 3,
 walkNorth = 4,
 idleSouth = 5
 }

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        this.MoveCharacter();
    }

    private void MoveCharacter() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        rgb.velocity = movement * speed;
    }

    private void UpdateState()
 {

    if (movement.x > 0)
 {
    animator.SetInteger(animationState, (int)
    CharStates.walkEast);
 } else if (movement.x < 0)
 {
 animator.SetInteger(animationState, (int)
CharStates.walkWest);
 } else if (movement.y > 0)
 {
 animator.SetInteger(animationState, (int)
CharStates.walkNorth);
 } else if (movement.y < 0)
 {
 animator.SetInteger(animationState, (int)
CharStates.walkSouth);
 }
 else
 {
 animator.SetInteger(animationState, (int)
CharStates.idleSouth);
 }


 }
}
