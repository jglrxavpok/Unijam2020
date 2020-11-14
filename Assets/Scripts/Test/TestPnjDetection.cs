using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPnjDetection : MonoBehaviour
{
    public PnjSelection selection;

    public void Update () {
        GameObject pnj = selection.SelectedPnj;
        Debug.Log(pnj ? pnj.name : "Empty");
    }
}
