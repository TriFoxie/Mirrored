using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerNumber;
    public float speed;
    public float jumpStrength;
    private bool facingRight;

    private float horizontal;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private Buttons buttons;
    [SerializeField] private LayerMask ExitDoorLayer;
    private bool won = false;

    void Update(){
        switch (playerNumber){
            case 1: horizontal = Input.GetAxisRaw("Horizontal"); break;
            case 2: horizontal = -Input.GetAxisRaw("Horizontal"); break;
            default: horizontal = Input.GetAxisRaw("Horizontal"); break;
        }

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();

        //Win
        if(Physics2D.OverlapCircle(GroundCheck.position, 0.2f, ExitDoorLayer) && !won){
            buttons.winCount += 1;
            won = true;
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded(){
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }

    private void Flip(){
        if(facingRight && horizontal < 0f || !facingRight && horizontal > 0f){
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
