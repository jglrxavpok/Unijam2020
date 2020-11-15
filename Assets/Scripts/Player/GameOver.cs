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
    private float hitedTime = 1f;
    [SerializeField]
    private float clignotementFreq = 0.1f;

    [SerializeField] 
    private Text textLives;

    [SerializeField] 
    private SpriteRenderer spiderRenderer;
    
    private int lives = 3;
    private Rigidbody2D rb;
    private bool hited = false;


        
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
                if(SceneControl.Instance){
                    SceneControl.Instance.ChangeScene("GameOver");
                }else{
                    SceneManager.LoadScene("GameOver");
                }
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

        AudioBox.Instance?.PlaySoundOneShot(SoundOneShot.SpiderHit);
        hited = true;
        StartCoroutine(Hit());

        textLives.text = lives.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor") && !hited) {
            looseLife();
            rebounce();
        }
    }

    private IEnumerator Hit () {
        float time = Time.time;
         Color color = Color.white;

        while(Time.time - time < hitedTime){
            yield return new WaitForSeconds(clignotementFreq);
            float a = color.a == 0 ? 1 : 0;
            color = spiderRenderer.color;
            color.a = a;
            spiderRenderer.color = color;
            spiderRenderer.material.SetFloat("_OutlineWidth", a);
        }

        color = spiderRenderer.color;
        color.a = 1;
        spiderRenderer.color = color;
        spiderRenderer.material.SetFloat("_OutlineWidth", 1);

        hited = false;
    }
}
