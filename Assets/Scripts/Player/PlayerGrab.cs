using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    public float grabOffsetPos = 0;

    [SerializeField]
    private PnjSelection pnjSelection = null;
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private SpriteRenderer sprite = null;

    [SerializeField]
    private NPC.Cursor npcCursor = null;

    private Rigidbody2D rb;
    private Player.PlayerMovement playerMovement;

    public bool IsGrab {get; private set;}
    public GameObject PnjGrabbed {get; private set;}

    private void Awake () {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<Player.PlayerMovement>();
        
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
            
            InputManager.Input.Spider.Web.Disable();
            InputManager.Input.Spider.Swing.Disable();
            InputManager.Input.Spider.Slide.Disable();

            Grab(pnjSelected);
        }else{
            if(!IsGrab) return;

            UnGrab();
            
            InputManager.Input.Spider.Web.Enable();
            InputManager.Input.Spider.Swing.Enable();
            InputManager.Input.Spider.Slide.Enable();
        }
    }

    private void Grab (GameObject pnj) {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        animator.SetBool("IsGrab", true);
        playerMovement.enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, pnj.transform.position - transform.position, 100f, LayerMask.GetMask("PasserbyLayer"));
        if (hit.collider != null) {
            float z = Vector3.Angle(transform.up, hit.normal);
            if(hit.normal.x > 0) z *= -1;
            sprite.gameObject.transform.rotation = Quaternion.Euler(0, 0, z);
            transform.position = hit.point + hit.normal * grabOffsetPos;
        }else{
            transform.LookAt(Vector2.up);
        }

        npcCursor?.ShowNPC(pnj);

        PnjGrabbed = pnj;
        IsGrab = true;
    }

    public void UnGrab () {
        rb.isKinematic = false;
        animator.SetBool("IsGrab", false);
        playerMovement.enabled = true;
        npcCursor?.ShowNPC(null);

        PnjGrabbed = null;
        IsGrab = false;
    }
}
