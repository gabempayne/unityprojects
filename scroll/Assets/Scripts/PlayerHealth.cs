using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    int health;
    public bool hasDied;


    void Start() {
        health = 3;
        hasDied = false;
    }

    void Update() {
        if(gameObject.transform.position.y < -7) {
            hasDied = true;
            Die();
        }
    }

    public static void Die() {
        Score.playerScore = 0;
        SceneManager.LoadScene("SampleScene");
    }

}
