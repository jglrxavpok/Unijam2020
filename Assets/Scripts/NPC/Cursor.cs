using UnityEngine;
using UnityEngine.InputSystem;

namespace NPC {
    public class Cursor : MonoBehaviour {
        [SerializeField] private GameObject popupPrefab;
        [SerializeField] private GameObject uiCanvas;
        [SerializeField] private LayerMask passerbyLayer;
        [SerializeField] private float popupY = 0;
        
        /// <summary>
        /// Used to compute world position
        /// </summary>
        [SerializeField] private Camera renderCamera;
        
        private PasserbyUI popup = null;
        private PasserbyDescription currentDescription = null;

        /*
        private void Start() {
            InputManager.Input.Debug.Mouse.performed += OnMouseMoved;
        }

        private void OnDestroy() {
            InputManager.Input.Debug.Mouse.performed -= OnMouseMoved;
        }

        private void OnMouseMoved(InputAction.CallbackContext context) {
            Vector3 pos = renderCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
            transform.position = new Vector2(pos.x, pos.y);
        }*/

        public void ShowNPC(GameObject obj) {
            if (obj != null) {
                UpdateContents(obj.GetComponent<PasserbyDescription>());
            } else {
                DestroyPopup();
            }
        }

        private void Update() {
            if (popup != null) {
                float zLevel = popup.transform.position.z;
                float camX = renderCamera.transform.position.x;
                Vector2 cursorPos = renderCamera.WorldToScreenPoint(transform.position);

                if (cursorPos.x + popup.Width >= camX + Screen.width) {
                    cursorPos.x = camX + Screen.width-popup.Width;
                }else if (cursorPos.x - popup.Width <= camX - Screen.width) {
                    cursorPos.x = camX - Screen.width+popup.Width;
                }

                Vector3 pos = renderCamera.ScreenToWorldPoint(cursorPos);
                pos.y = popupY;
                pos.z = zLevel;
                popup.transform.position = pos;
            }
        }

        private void UpdateContents(PasserbyDescription desc) {
            PasserbyUI ui = GetOrCreatePopup();
            ui.ChangeContents(desc);
            currentDescription = desc;
        }
        
        private PasserbyUI GetOrCreatePopup() {
            if (popup != null)
                return popup;

            popup = Instantiate(popupPrefab, uiCanvas.transform).GetComponent<PasserbyUI>();
            return popup;
        }

        private void DestroyPopup() {
            if (popup != null) {
                Destroy(popup.gameObject);
                currentDescription = null;
                popup = null;
            }
        }
    }
}
