using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform originPoint;
    public int xMoveDirection;
    public float speed;

    public bool isFacingRight;
    

    Rigidbody2D rb2d;


    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection,0), 1 << LayerMask.NameToLayer("Bounding box"));
        rb2d.velocity = new Vector2(xMoveDirection, 0) * speed;

        if (hit.distance < 0.44f && gameObject.tag != "bounding box") {
            Flip();
        }
    }

    void Flip() {
        isFacingRight = !isFacingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        if (xMoveDirection < 0 && !isFacingRight) {
            xMoveDirection = 1;
        }else {
            xMoveDirection = -1;
        }
    }


}
