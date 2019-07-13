﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 25;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            PlayerController.instance.currentAmmo += ammoAmount;

            Destroy(gameObject);
        }
    }
}
