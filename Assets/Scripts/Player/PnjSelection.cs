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
        var desc = col.GetComponent<PasserbyDescription>();
        if (desc && !desc.HasBeenBitten()) {
            pnjs.Add(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        pnjs.Remove(col.gameObject);
    }

    public GameObject SelectedPnj {
        get{
            GameObject closestPnj = null;
            float closestDistance = Mathf.Infinity;

            foreach(GameObject pnj in pnjs){
                var desc = pnj.GetComponent<PasserbyDescription>();
                if (desc && desc.HasBeenBitten()) {
                    continue;
                }

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
