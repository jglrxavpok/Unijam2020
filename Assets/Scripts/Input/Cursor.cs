using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    [SerializeField]
    private float radiusFromPlayer = 0.3f;

    public Vector3 CursorPos {get{return transform.position;}}

    private void Start () {
        InputManager.Input.Spider.Aim.performed += OnAim;
    }

    private void OnDestroy () {
        InputManager.Input.Spider.Aim.performed -= OnAim;
    }

    private void OnAim (InputAction.CallbackContext ctx)  {
        Vector2 dir = Vector2.zero;
        if(ctx.control.device.name == "Mouse"){
            Vector2 input = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
            dir = (input - new Vector2(transform.parent.position.x, transform.parent.position.y)).normalized;
        }else{
            dir = ctx.ReadValue<Vector2>().normalized;
        }

        transform.position = transform.parent.position + new Vector3(dir.x, dir.y, 0) * radiusFromPlayer * transform.parent.localScale.x;
    }
}
