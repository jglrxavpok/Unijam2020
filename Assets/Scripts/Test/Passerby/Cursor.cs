using System;
using Test.Passerby;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Test {
    public class Cursor : MonoBehaviour {
        [SerializeField] private GameObject popupPrefab;
        [SerializeField] private GameObject uiCanvas;
        [SerializeField] private LayerMask passerbyLayer;
        
        /// <summary>
        /// Used to compute world position
        /// </summary>
        [SerializeField] private Camera renderCamera;
        
        private PasserbyUI popup = null;
        private PasserbyDescription currentDescription = null;

        private void Start() {
            InputManager.Input.Debug.Mouse.performed += OnMouseMoved;
        }

        private void OnDestroy() {
            InputManager.Input.Debug.Mouse.performed -= OnMouseMoved;
        }

        private void OnMouseMoved(InputAction.CallbackContext context) {
            Vector3 pos = renderCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
            transform.position = new Vector2(pos.x, pos.y);
        }

        private void Update() {
            var passerby = Physics2D.OverlapPoint(transform.position, passerbyLayer.value);
            if (passerby != null && passerby.gameObject != null) {
                UpdateContents(passerby.GetComponent<PasserbyDescription>());
            } else {
                DestroyPopup();
            }
            if (popup != null) {
                float zLevel = popup.transform.position.z;
                Vector2 cursorPos = renderCamera.WorldToScreenPoint(transform.position);
                if (cursorPos.x + popup.Width >= Screen.width) {
                    cursorPos.x = Screen.width-popup.Width;
                }

                Vector3 pos = renderCamera.ScreenToWorldPoint(cursorPos);
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
