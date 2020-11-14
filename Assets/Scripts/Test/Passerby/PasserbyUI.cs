using UnityEngine;
using UnityEngine.UI;

namespace Test.Passerby {
    public class PasserbyUI : MonoBehaviour {
        [SerializeField] private Text fullName;
        [SerializeField] private Text thought;
        [SerializeField] private Image facePicture;
        
        private RectTransform _transform;
        private Canvas _canvas;

        public float Width => _transform.rect.width*_canvas.scaleFactor;

        private void Awake() {
            _transform = GetComponent<RectTransform>();
            _canvas = GetComponent<Canvas>();
        }

        public void ChangeContents(PasserbyDescription description) {
            fullName.text = $"{description.FirstName} {description.Name}";
            thought.text = description.Thought;
            facePicture.sprite = description.FacePhoto;
        }
    }
}
