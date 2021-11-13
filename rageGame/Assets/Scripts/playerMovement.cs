using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float jumpLength;
    [SerializeField] GroundDetector detector;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    public bool canMove = true;
    public Vector2 movement;

    
    
    
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {

        if (movement == Vector2.zero) {
            anim.SetBool("isMoving", false);
        }
        
    }
    private void FixedUpdate() {
        if (canMove) {
            movement = movement.normalized;
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        }

        

    }

    public void OnJump(InputAction.CallbackContext callbackContext) {
        if (callbackContext.performed) {
            if (detector.onGround) {
                rb.AddForce(transform.up * jumpLength, ForceMode2D.Impulse);
            }
        }
        
        
    }
    
    
    
    public void Move(InputAction.CallbackContext callbackContext) {
        movement = new Vector2(callbackContext.ReadValue<Vector2>().x, callbackContext.ReadValue<Vector2>().y);
        if(movement.x < 0) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else if (movement.x > 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        anim.SetBool("isMoving", true);
    }

}
