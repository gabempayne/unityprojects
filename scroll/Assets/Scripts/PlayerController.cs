using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerSpeed = 10;
    bool isFacingRight = true;
    public int jumpPower = 0;
    public int playerBounceForce = 0;

    public float hitDistance = 0;
    public float rayCastlen = 0;

    // Raycast system
    public Transform rayStart, rayEnd;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Animator anim;

    public bool isGrounded;

    Rigidbody2D rb2d;

    float moveX;
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Update() {
       PlayerRaycast();
       PlayerMove();
    }

    void PlayerMove() {
        // Player controls
        moveX = Input.GetAxisRaw("Horizontal") * playerSpeed;

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("Speed", Mathf.Abs(moveX));

        if(Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }
        // Player anim
        // Player direction
        if(moveX > 0.0f && !isFacingRight) {
            Flip();
        } else if(moveX < 0.0f && isFacingRight) {
            Flip();
        }
        // Player physics
        rb2d.velocity = new Vector2(moveX, rb2d.velocity.y);

    }

    void Jump() {
        // Player jump
        rb2d.AddForce(Vector2.up * jumpPower);
        anim.SetBool("isGrounded", isGrounded);
/*  
        // Better Jump
        if(rb2d.velocity.y <0) {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb2d.velocity.y > 0 && !Input.GetButtonDown("Jump")) {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }*/
        isGrounded = false;
    }

    void Flip() {
        isFacingRight = !isFacingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Obstacle") {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Collectible") {
            Score.playerScore += PickUp.pickUpPoints;
        }

        // Enemy Logic
        if (other.gameObject.CompareTag("Attack point")) {
            PlayerHealth.Die();
        }
        if (other.gameObject.CompareTag("Stomp point")) {
            Score.playerScore += 10;
            // Bounce after jumping on enemy
            rb2d.velocity = new Vector2(rb2d.velocity.x, playerBounceForce);

            Debug.Log("dead");
            Destroy(other.transform.parent.gameObject);
        }
    }
    void PlayerRaycast() {

        RaycastHit2D hit = Physics2D.Raycast(rayStart.position, rayEnd.position);
        if (hit.distance < 0.25f && gameObject.tag == "Enemy") {
            Debug.Log("dick head");
            
        }
    }
}
