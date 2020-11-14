using UnityEngine;
using UnityEngine.UI;

namespace NPC {
    public class PasserbyUI : MonoBehaviour {
        [SerializeField] private Text fullName = null;
        [SerializeField] private GameObject tasteGroup = null;
        [SerializeField] private Text thoughtTaste = null;
        [SerializeField] private GameObject intentionGroup = null;
        [SerializeField] private Text thoughtIntention = null;
        [SerializeField] private GameObject judgmentGroup = null;
        [SerializeField] private Text thoughtJudgment = null;
        [SerializeField] private GameObject desireGroup = null;
        [SerializeField] private Text thoughtDesire = null;
        [SerializeField] private Image facePicture = null;
        
        private RectTransform _transform;
        private Canvas _canvas;

        public float Width => _transform.rect.width*_canvas.scaleFactor;

        private void Awake() {
            _transform = GetComponent<RectTransform>();
            _canvas = GetComponent<Canvas>();
            
            tasteGroup.SetActive(true);
            intentionGroup.SetActive(false);
            judgmentGroup.SetActive(false);
            desireGroup.SetActive(false);
        }

        public void ChangeContents(PasserbyDescription description) {
            fullName.text = $"{description.FirstName} {description.Name}";
            thoughtTaste.text = description.Taste;
            thoughtDesire.text = description.Desire;
            thoughtIntention.text = description.Intention;
            thoughtJudgment.text = description.Judgment;
            facePicture.sprite = description.FacePhoto;
        }
    }
}
