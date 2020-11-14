using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWebRenderer : MonoBehaviour
{
    public WebRenderer webRenderer;
    public Transform testStickPoint;

    private void Start () {
        webRenderer.CreateWeb(testStickPoint.position);
    }
}
