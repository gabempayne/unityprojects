using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2d(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            canvas.gameObject.SetActive(true);
            Debug.Log("Winner");
        }
    }
}
