using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    [SerializeField]
    private bool invincible = false;

    [SerializeField] 
    private Text textLives;
    
    private int lives = 3;
    private Rigidbody2D rb;
        
    // Start is called before the first frame update
    void Start()
    {
        textLives.text = lives.ToString();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!invincible) {
            if (lives == 0) {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    private void rebounce() {
        rb.velocity = new Vector2(0, 20);
        /*if (rb.velocity.y <= 0) {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }*/
    }

    private void looseLife() {
        lives--;
        textLives.text = lives.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor")) {
            looseLife();
            rebounce();
        }
    }
}
