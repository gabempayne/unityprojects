using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int points = 0;
    public static int pickUpPoints = 0;

    void Start() {
        pickUpPoints = points;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && other.tag != "StompTrigger") {
            Destroy(gameObject);
        }
    }


}
