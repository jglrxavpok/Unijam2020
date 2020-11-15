using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;

//Info : bien pensez à ce que pnjSelection ne détecte QUE les pnj grâce à la configuration des matrices de layer

public class PnjSelection : MonoBehaviour
{
    private List<GameObject> pnjs;

    private void Awake () {
        pnjs = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.GetComponent<PasserbyDescription>()) {
            pnjs.Add(col.gameObject);
            return;
        }

        GameObject pnj = col.GetComponent<PasserByHead>() ? col.transform.parent.gameObject : null;
        if (pnj && !pnjs.Contains(pnj)) {
            pnjs.Add(pnj);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.GetComponent<PasserbyDescription>()) {
            pnjs.Remove(col.gameObject);
            return;
        }

        GameObject pnj = col.GetComponent<PasserByHead>() ? col.transform.parent.gameObject : null;
        if (pnj && pnjs.Contains(pnj)) {
            pnjs.Remove(pnj);
        }
    }

    public GameObject SelectedPnj {
        get{
            GameObject closestPnj = null;
            float closestDistance = Mathf.Infinity;

            foreach(GameObject pnj in pnjs){
                float distance = Vector3.Distance(transform.position, pnj.transform.position);

                if(distance < closestDistance){
                    closestPnj = pnj;
                    closestDistance = distance;
                }
            }

            return closestPnj;
        }
    }
}
