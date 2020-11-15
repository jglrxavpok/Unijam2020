using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    [SerializeField]
    private float radiusFromPlayer = 0.3f;

    [SerializeField]
    private SpriteRenderer dashedLine;

    [SerializeField] private SpriteRenderer targetAnchor;
    [SerializeField] private float dashedLineTilingMultiplier = 1.0f;
    
    private bool controlByMouse = false;
    private float dashedLineYScale;

    public Vector3 CursorPos {get{return transform.position;}}

    private void Start () {
        dashedLineYScale = dashedLine.transform.localScale.y;
        InputManager.Input.Spider.Aim.performed += OnAim;
    }

    private void OnDestroy () {
        InputManager.Input.Spider.Aim.performed -= OnAim;
    }

    private void OnAim (InputAction.CallbackContext ctx)  {
        if(ctx.control.device.name == "Mouse"){
            controlByMouse = true;
        }else{
            controlByMouse = false;
            Vector2 dir = ctx.ReadValue<Vector2>().normalized;
            transform.position = transform.parent.position + new Vector3(dir.x, dir.y, 0) * radiusFromPlayer * transform.parent.localScale.x;
        }
    }

    private void Update () {
        dashedLine.enabled = targetAnchor.enabled;
        Vector2 playerPosition = transform.parent.position;
        var targetPosition = targetAnchor.transform.position;
        Vector2 direction = new Vector2(targetPosition.x, targetPosition.y) - playerPosition;
        dashedLine.transform.position = playerPosition + direction / 2.0f;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        dashedLine.transform.rotation = Quaternion.Euler(0, 0, angle);
        dashedLine.transform.localScale = new Vector3(Mathf.Abs(direction.magnitude), dashedLineYScale, 1);
        dashedLine.material.mainTextureScale = new Vector2(Mathf.Abs(direction.magnitude)*dashedLineTilingMultiplier, 1);
        
        if(!controlByMouse) return;

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 input = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 dir = (input - new Vector2(transform.parent.position.x, transform.parent.position.y)).normalized;
        transform.position = transform.parent.position + new Vector3(dir.x, dir.y, 0) * radiusFromPlayer * transform.parent.localScale.x;
    }
}
