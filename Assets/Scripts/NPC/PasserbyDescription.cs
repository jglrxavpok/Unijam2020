using UnityEngine;

namespace NPC {
    public class PasserbyDescription : MonoBehaviour {
        [SerializeField] private string firstName;
        [SerializeField] private string name;
        [SerializeField] private string thought;
        [SerializeField] private Sprite facePhoto;
        public Sprite FacePhoto => facePhoto;
        public string FirstName => firstName;
        public string Name => name;
        public string Thought => thought;

        void Start()
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(firstName))
            {
                var fullName = NpcBuilder.GetRandomName();
                firstName = fullName.Split(' ')[0];
                name = fullName.Split(' ')[1];
            }
        }
    }
}
