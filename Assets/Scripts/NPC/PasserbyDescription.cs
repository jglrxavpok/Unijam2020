using Player;
using UnityEngine;

namespace NPC {
    public class PasserbyDescription : MonoBehaviour {
        [SerializeField] private string firstName;
        [SerializeField] private string name;
        [SerializeField] private string taste;
        [SerializeField] private string intention;
        [SerializeField] private string judgment;
        [SerializeField] private string desire;
        [SerializeField] private Sprite facePhoto;
        [SerializeField] private float score;

        private bool alreadyBitten = false;

        [Header("Bite rendering")] 
        [SerializeField]
        private SpriteRenderer[] _renderers;

        [SerializeField] private Material materialToApplyOnceBitten;
        

        private void Start() {
            LoadRandom();
        }

        public void LoadRandom() {
            var fullName = NPCBuilder.GetRandomName(); 
            firstName = fullName.Split(' ')[0];
            name = fullName.Split(' ')[1];
        }

        public void Bite() {
            alreadyBitten = true;
            foreach (var spriteRenderer in _renderers) {
                spriteRenderer.material = materialToApplyOnceBitten;
                var exposure = gameObject.AddComponent<ExposeSpriteToShader>();
                exposure.SpriteRenderer = spriteRenderer;
            }

            // TODO: change render
        }
        
        public Sprite FacePhoto => facePhoto;
        public string FirstName => firstName;
        public string Name => name;

        public float Score {
            get => score;
            set => score = value;
        }
        public string Taste {
            get => taste;
            set => taste = value;
        }
        public string Judgment {
            get => judgment;
            set => judgment = value;
        }
        public string Desire {
            get => desire;
            set => desire = value;
        }
        public string Intention {
            get => intention;
            set => intention = value;
        }

        public bool HasBeenBitten() {
            return alreadyBitten;
        }
    }
}
