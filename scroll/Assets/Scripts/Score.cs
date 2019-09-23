using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int playerScore;
    Text score;

    void Start() {
        score = GetComponent<Text>();
    }

    void Update() {
        score.text = "" + playerScore;
    }

   
}
