using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBite : MonoBehaviour
{

    private PlayerGrab grab;

    private void Awake () {
        grab = GetComponent<PlayerGrab>();
        
    }

    private void Start () {
        InputManager.Input.Spider.Bite.performed += OnBite;
    }

    private void OnDestroy () {
        InputManager.Input.Spider.Bite.performed -= OnBite;
    }

    private void OnBite (InputAction.CallbackContext ctx)  {
        
    }
}
