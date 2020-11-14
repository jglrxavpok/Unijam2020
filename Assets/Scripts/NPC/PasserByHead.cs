using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasserByHead : MonoBehaviour
{
    public GameObject GetPnj {get{return transform.parent.gameObject;}} 
}
