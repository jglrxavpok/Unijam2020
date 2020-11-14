using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    [RequireComponent(typeof(Rigidbody2D), typeof(SpringJoint2D))]
    public class PlayerMovement : MonoBehaviour {

        // INSPECTOR ACCESSIBLE
        [SerializeField] private float torqueFactor = 0.25f;
        [SerializeField] private float webRaycastDistance = 10f;
        [SerializeField] private float swingInputDeadzone = 0.1f;
        [SerializeField] private float slideSpeed = 1f;
        [SerializeField] private float minDistanceFromAnchor = 1f;
        [SerializeField] private float maxDistanceFromAnchor = 10f;
        [SerializeField] private GameObject anchor;
        [SerializeField] private GameObject ghostAnchor;
        [SerializeField] private GameObject debugArrow;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private LayerMask webRaycastLayer;

        // PRIVATE-PRIVATE
        private bool onWeb = true; // TODO: dynamically change
        private Vector2 AnchorPoint => anchor.transform.position;

        private Vector2 Position {
            get => transform.position;
            set => transform.position = value;
        }
        private Rigidbody2D _rigidbody;
        private SpringJoint2D _springJoint;
        private WebRenderer _webRenderer;
        private float swingInput;
        private float slideInput;
        private bool shouldShootWeb;
        private float shootingAngle;

        void Start() {
            InputManager.Input.Spider.Web.started += OnShootWeb;
            InputManager.Input.Spider.Swing.performed += OnSwing;
            InputManager.Input.Spider.Slide.performed += OnSlide;
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _springJoint = GetComponent<SpringJoint2D>();

            _webRenderer = GetComponentInChildren<WebRenderer>();

            // don't show ghost anchor
            ghostAnchor.SetActive(false);
            AnchorTo(AnchorPoint);
        }

        private void OnDestroy() {
            InputManager.Input.Spider.Web.started -= OnShootWeb;
            InputManager.Input.Spider.Swing.performed -= OnSwing;
            InputManager.Input.Spider.Slide.performed -= OnSlide;
        }

        // Update is called once per frame
        void Update() {
            if (shouldShootWeb) {
                ShootWeb();
                shouldShootWeb = false;
            }

            // swing spider
            if (onWeb) {
                float horizontalInput = swingInput;

                Vector2 positionToAnchor = AnchorPoint - Position;
                
                Vector2 orthogonalDirection = new Vector2(positionToAnchor.y, -positionToAnchor.x).normalized;

                Vector2 force = orthogonalDirection * torqueFactor * horizontalInput;

                _rigidbody.AddForce(force, ForceMode2D.Force); // TODO: move to FixedUpdate

                // player is forcing direction, let them choose
                Vector2 directionToComputeAngleFrom;
                if (Mathf.Abs(horizontalInput) > swingInputDeadzone) {
                    directionToComputeAngleFrom = force;
                } else {
                    directionToComputeAngleFrom = orthogonalDirection*Mathf.Sign(_rigidbody.velocity.x);    
                }

                float newAngle = Vector2.SignedAngle(Vector2.right, directionToComputeAngleFrom);
                if (!float.IsNaN(newAngle)) {
                    shootingAngle = newAngle;
                    debugArrow.transform.rotation = Quaternion.Euler(0, 0, shootingAngle);
                }

                // slide along web
                float targetDistance = _springJoint.distance - slideInput * slideSpeed * Time.deltaTime;
                _springJoint.distance = Mathf.Clamp(targetDistance, minDistanceFromAnchor, maxDistanceFromAnchor);
                
                // rotate player sprite to show angle from anchor
                float renderAngle = Vector2.SignedAngle(Vector2.up, AnchorPoint - Position);
                _renderer.transform.rotation = Quaternion.Euler(0, 0, renderAngle);
            }
            
            // update ghost anchor position
            Vector2 castDirection = new Vector2(Mathf.Cos(shootingAngle*Mathf.Deg2Rad), Mathf.Sin(shootingAngle*Mathf.Deg2Rad));
            var hit = Physics2D.Raycast(Position, castDirection, webRaycastDistance, webRaycastLayer.value);
            if (hit.collider != null && hit.collider.gameObject != null) {
                ghostAnchor.SetActive(true);
                ghostAnchor.transform.position = hit.point;
            } else {
                ghostAnchor.SetActive(false);
            }
        }

        private void ShootWeb() {
            // make sure an anchor is possible
            // TODO: shoot projectile instead
            if (ghostAnchor.activeSelf) {
                _webRenderer.DestroyWeb();
                AnchorTo(ghostAnchor.transform.position);
            }
        }

        private void AnchorTo(Vector2 point) {
            anchor.transform.position = point;
            _springJoint.distance = (AnchorPoint - Position).magnitude;
            _webRenderer.CreateWeb(AnchorPoint);
        }

        private void OnSwing (InputAction.CallbackContext ctx)  {
            float swing = ctx.ReadValue<float>();
            swingInput = swing;
        }

        private void OnSlide (InputAction.CallbackContext ctx)  {
            float slide = ctx.ReadValue<float>();
            slideInput = slide;
        }
        
        private void OnShootWeb(InputAction.CallbackContext ctx) {
            shouldShootWeb = true;
        }
    }
}
