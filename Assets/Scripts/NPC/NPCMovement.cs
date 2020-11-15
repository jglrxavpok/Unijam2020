using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

public class NPCMovement : MonoBehaviour {
    [SerializeField] 
    private float maxMovementRange;

    [SerializeField] 
    private float chanceOfMovement;

    [SerializeField] 
    private float maxSpeed;

    [SerializeField] 
    private float percentageOfAnnulationRange = 0;


    private float speed = 0;
    private bool isMoving = false;
    private float initialPosition;
    private float leftRange = 0;
    private float rightRange = 0;
    private float side = 1;
    private int nbMove = 0;
    private Rigidbody2D rigidBody;
    private float realSpeed = 0;

    // Start is called before the first frame update
    void Start() {
        initialPosition = transform.position.x;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving) {
            if (Random.value < chanceOfMovement) {
                leftRange = setRange();
                rightRange = setRange();
                speed = ((Random.value/4f)+0.75f) * maxSpeed;
                chooseSide();
                isMoving = true;
            }
        }
        else {
            movement();
        }
    }

    private void movement() {
        if (nbMove >= 2) {
            isMoving = false;
            nbMove = 0;
            return;
        }
        float position = transform.position.x;
        if (position >= initialPosition - leftRange && position <= initialPosition + rightRange) {
            realSpeed = speed * side;
        }
        else {
            initialPosition = position;
            realSpeed = 0;
            nbMove++;
            side *= -1;
        }
        rigidBody.velocity = new Vector2(realSpeed, rigidBody.velocity.y);
    }

    private float setRange() {
        float rand = Random.value;
        float side = 0;
        if (rand > percentageOfAnnulationRange) {
            side = rand * maxMovementRange;
        }

        return side;
    }
    
    private void chooseSide() {
        if (Random.value < 0.5) {
            side = 1;
        }
        else {
            side = -1;
        }
    }

    public float getSpeed() {
        return realSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall")) {
            side *= -1;
            nbMove++;
            initialPosition = transform.position.x;
        }
    }
}
