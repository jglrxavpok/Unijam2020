using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance {get; private set;}
    [SerializeField]
    private Transform follow;

    public float speed = 1;
    public float minX = -1;
    public float maxX = 1;

    private void Awake () {
        if(Instance){
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void OnDestroy () {
        if(Instance == this) Instance = null;
    }

    private void FixedUpdate () {
        Vector3 nextPos = new Vector3(follow.position.x, 0, -10);
        if(nextPos.x < minX){
            nextPos.x = minX;
        }
        if(nextPos.x > maxX){
            nextPos.x = maxX;
        }

        transform.position = Vector3.Lerp(transform.position, nextPos, Time.fixedDeltaTime * speed);
    }
}
