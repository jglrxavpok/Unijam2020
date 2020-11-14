using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingText : MonoBehaviour {
    
    [SerializeField]
    private float speed;

    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float deltaTime = Time.deltaTime;
        time += deltaTime;
        if (time > 3) {
            transform.position -= new Vector3(speed*deltaTime, 0);
        }
    }
}
