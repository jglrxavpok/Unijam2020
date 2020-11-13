using UnityEngine;

namespace Player {
    [RequireComponent(typeof(Rigidbody2D), typeof(SpringJoint2D))]
    public class PlayerMovementTest : MonoBehaviour {

        // INSPECTOR ACCESSIBLE
        [SerializeField]
        private float torqueFactor;

        // PRIVATE-PRIVATE
        private bool onWeb;
        private Vector2 anchorPoint;
        private Rigidbody2D _rigidbody;
        private SpringJoint2D _springJoint;


        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _springJoint = GetComponent<SpringJoint2D>();

            // TODO: anchor to spawn point?
//            _springJoint.enabled = false;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetButtonDown("Jump")) {// TODO: change to new input
                ShootWeb();
            }

            if (/*TODO onWeb*/true) {
                float horizontalInput = Input.GetAxis("Horizontal");

                Vector2 positionToAnchor = _springJoint.connectedBody.position - new Vector2(transform.position.x, transform.position.y);
                
                Vector2 orthogonalDirection = new Vector2(positionToAnchor.y, -positionToAnchor.x).normalized;

                Vector2 force = orthogonalDirection * torqueFactor * horizontalInput;
                
                Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y)+force, Color.red);
                _rigidbody.AddForce(force, ForceMode2D.Force);
            }
        }

        private void ShootWeb() {
            // TODO: raycast and link correctly
            
        }
    }
}
