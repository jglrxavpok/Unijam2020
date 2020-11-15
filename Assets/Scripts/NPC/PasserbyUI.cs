using UnityEngine;
using UnityEngine.InputSystem;
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
        [SerializeField] private Image faceHair = null;

        private RectTransform _transform;
        private Canvas _canvas;
        private int score = 0;
        private GameObject player;
        private PlayerGrab grabCapability;
        private GameObject[] groups = new GameObject[0];
        private int selectedGroupIndex = 0;

        private int tastePositivity;
        private string thing;

        private PasserbyDescription currentDescription;

        public float Width => _transform.rect.width*_canvas.scaleFactor;

        private void Awake() {
            _transform = GetComponent<RectTransform>();
            _canvas = GetComponent<Canvas>();
            
            tasteGroup.SetActive(true);
            intentionGroup.SetActive(false);
            judgmentGroup.SetActive(false);
            desireGroup.SetActive(false);

            player = GameObject.FindWithTag("Player");
            grabCapability = player.GetComponent<PlayerGrab>();

            groups = new[] {tasteGroup, intentionGroup, judgmentGroup, desireGroup};
        }
        
        private void Start () {
            InputManager.Input.Spider.Bite.performed += OnBite;
            InputManager.Input.UI.SwitchThoughtType.started += OnSwitchThought;
        }

        private void OnDestroy () {
            InputManager.Input.Spider.Bite.performed -= OnBite;
            InputManager.Input.UI.SwitchThoughtType.started -= OnSwitchThought;
        }

        private void OnSwitchThought(InputAction.CallbackContext ctx) {
            float value = ctx.ReadValue<float>();
            if (value > 0) {
                selectedGroupIndex++;
                selectedGroupIndex %= groups.Length;
            } else if (value < 0) {
                selectedGroupIndex--;
                if (selectedGroupIndex < 0) {
                    selectedGroupIndex = groups.Length - 1;
                }
            }

            for (int i = 0; i < groups.Length; i++) {
                groups[i].SetActive(false);
            }
            groups[selectedGroupIndex].SetActive(true);

            AudioBox.Instance?.PlaySoundOneShot(SoundOneShot.SpiderSwitchEmotion);
        }

        private void OnBite(InputAction.CallbackContext ctx) {

            BitingSystem.Instance.OnBite(score, tastePositivity, thing);
            currentDescription.Bite();
            grabCapability.UnGrab();
        }

        public void ChangeContents(PasserbyDescription description) {
            currentDescription = description;
            fullName.text = $"{description.FirstName} {description.Name}";
            thoughtTaste.text = description.Taste;
            thoughtDesire.text = description.Desire;
            thoughtIntention.text = description.Intention;
            thoughtJudgment.text = description.Judgment;
            
            score = description.Score;
            tastePositivity = description.TastePositivity;
            thing = description.Thing;

            facePicture.sprite = description.GetComponent<NPCVisual>().getGenderSprite();
            facePicture.color = description.GetComponent<NPCVisual>().getGenderColor();
            
            faceHair.sprite = description.GetComponent<NPCVisual>().getHairSprite();
            faceHair.color = description.GetComponent<NPCVisual>().getHairColor();
        }
    }
}
