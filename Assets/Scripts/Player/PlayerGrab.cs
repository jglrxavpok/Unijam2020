using System;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
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
    private PlayerMovement _movement;
    private GameObject pnjGrab = null;
    private NPCMovement _npcMovement = null;

    public bool IsGrab {get; private set;}
    public GameObject PnjGrabbed {get; private set;}

    private void Awake () {
        rb = GetComponent<Rigidbody2D>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Start () {
        InputManager.Input.Spider.Grab.performed += OnGrab;
    }

    void Update() {
        if (pnjGrab) {
            rb.velocity = new Vector2(_npcMovement.getSpeed(), 0);
        }
    }

    private void OnDestroy () {
        InputManager.Input.Spider.Grab.performed -= OnGrab;
    }

    private void OnGrab (InputAction.CallbackContext ctx)  {
        if(ctx.ReadValueAsButton()) {
            GameObject pnjSelected = pnjSelection.SelectedPnj;
            if(!pnjSelected) return;

            Grab(pnjSelected);
        }else{
            if(!IsGrab) return;

            UnGrab();
        }
    }

    private void Grab (GameObject pnj) {
        pnjGrab = pnj;
        _npcMovement = pnjGrab.GetComponent<NPCMovement>();
        _movement.KeepWeb();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        animator.SetBool("IsGrab", true);
        _movement.enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, pnj.transform.position - transform.position, 100f, LayerMask.GetMask("PasserbyLayer"));
        if (hit.collider != null) {

            if(hit.collider.bounds.Contains(transform.position)){
                transform.position = hit.collider.transform.position;
                sprite.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                animator.SetBool("InsidePnj", true);
            }else{
                float z = Vector3.Angle(transform.up, hit.normal);
                if(hit.normal.x > 0) z *= -1;
                sprite.gameObject.transform.rotation = Quaternion.Euler(0, 0, z);
                transform.position = hit.point + hit.normal * grabOffsetPos;
                animator.SetBool("InsidePnj", false);
            }
        }else{
            transform.LookAt(Vector2.up);
        }

        transform.parent = pnj.transform;

        npcCursor?.ShowNPC(pnj);

        PnjGrabbed = pnj;
        IsGrab = true;

        InputManager.Input.Spider.Web.Disable();
        InputManager.Input.Spider.Swing.Disable();
        InputManager.Input.Spider.Slide.Disable();
    }


    public void UnGrab () {
        _npcMovement = null;
        pnjGrab = null;
        _movement.DontKeepWeb();
        rb.isKinematic = false;
        rb.velocity = Vector2.zero;
        animator.SetBool("IsGrab", false);
        _movement.enabled = true;
        if(!_movement.IsOnWeb) _movement.ShootWeb(Vector2.up);

        transform.parent = null;
        
        npcCursor?.ShowNPC(null);

        PnjGrabbed = null;
        IsGrab = false;


        InputManager.Input.Spider.Web.Enable();
        InputManager.Input.Spider.Swing.Enable();
        InputManager.Input.Spider.Slide.Enable();
    }
}
