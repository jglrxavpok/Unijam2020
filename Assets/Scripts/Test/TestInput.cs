using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    private void Start () {
        InputManager.Input.Spider.Web.performed += OnWeb;
        InputManager.Input.Spider.Swing.performed += OnSwing;
        InputManager.Input.Spider.Slide.performed += OnSlide;
    }

    private void OnDestroy () {
        InputManager.Input.Spider.Web.performed -= OnWeb;
        InputManager.Input.Spider.Swing.performed -= OnSwing;
        InputManager.Input.Spider.Slide.performed -= OnSlide;
    }

    private void OnWeb (InputAction.CallbackContext ctx)  {
        if(ctx.ReadValue<float>() == 1){
            Debug.Log("spider throw web");
        }else{
            Debug.Log("spider release web");
        }
    }

    private void OnSwing (InputAction.CallbackContext ctx)  {
        float swing = ctx.ReadValue<float>();
        Debug.Log("swing : " + swing);
    }

    private void OnSlide (InputAction.CallbackContext ctx)  {
        float slide = ctx.ReadValue<float>();
        Debug.Log("slide : " + slide);
    }
}
