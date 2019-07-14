using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    public GameObject explosion;

    public float playerRange = 10f;

    public Rigidbody2D rb;
    public float moveSpeed;

    public void Update() {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange) {

            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            rb.velocity = playerDirection.normalized * moveSpeed; // limits maximum distance
        } else {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage() {
        health--;
        if(health <= 0) {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
