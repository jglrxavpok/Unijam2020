using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField]
    private PnjSelection pnjSelection;

    [SerializeField] private NPC.Cursor npcCursor;

    private Rigidbody2D rb;

    private void Awake () {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start () {
        InputManager.Input.Spider.Grab.performed += OnGrab;
    }

    private void OnDestroy () {
        InputManager.Input.Spider.Grab.performed -= OnGrab;
    }

    private void OnGrab (InputAction.CallbackContext ctx)  {
        if(ctx.ReadValueAsButton()) {
            GameObject pnjSelected = pnjSelection.SelectedPnj;
            if(!pnjSelected) return;
            
            Debug.LogWarning("grab");

            InputManager.Input.Spider.Web.Disable();
            InputManager.Input.Spider.Swing.Disable();
            InputManager.Input.Spider.Slide.Disable();

            Grab(pnjSelected);
        }else{
            UnGrab();
            
            Debug.LogWarning("ungrab");

            InputManager.Input.Spider.Web.Enable();
            InputManager.Input.Spider.Swing.Enable();
            InputManager.Input.Spider.Slide.Enable();
        }
    }

    private void Grab (GameObject pnj) {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;

        npcCursor.ShowNPC(pnj);
        //TODO
    }

    private void UnGrab () {
        rb.isKinematic = false;
        
        npcCursor.ShowNPC(null);

        //TODO
    }
}
