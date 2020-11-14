using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebRenderer : MonoBehaviour
{
    [Min(3)]
    public int nbPoint = 50;
    public Rigidbody2D followRigidbody;
    [Range(0, 1)]
    public float velocityInfluence = 0.5f;

    private LineRenderer line;

    private Vector3 endPoint;
    private bool show = false;

    private void Awake () {
        line = GetComponent<LineRenderer>();

        line.positionCount = nbPoint;
    }

    private void Update () {
        if(!show) return;

        UpdateLine();
    }

    public void CreateWeb (Vector3 endPoint) {
        this.endPoint = endPoint;
        line.SetPosition(nbPoint - 1, endPoint);

        UpdateLine();

        show = true;
    }

    public void DestroyWeb() {
        show = false;
    }

    private void UpdateLine () {
        line.SetPosition(0, transform.position);

        float distance = Vector3.Distance(transform.position, endPoint);
        Vector3 center = transform.position + transform.up * distance / 2;
        center += -new Vector3(followRigidbody.velocity.x, followRigidbody.velocity.y, 0) * velocityInfluence;

        for(int i = 1; i < nbPoint - 1; ++i){
            float t = (float)i / (nbPoint - 1);
            line.SetPosition(i, GetPoint(transform.position, center, endPoint, t));
        }

        //line.SetPosition(1, GetPoint(transform.position, center.position, endPoint, (float)2/3));
        //line.SetPosition(2, GetPoint(transform.position, center.position, endPoint, (float)1/3));
    } 

    public static Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, float t) {
		t = Mathf.Clamp01(t);
		float oneMinusT = 1f - t;
		return
			oneMinusT * oneMinusT * p0 +
			2f * oneMinusT * t * p1 +
			t * t * p2;
	}
}
