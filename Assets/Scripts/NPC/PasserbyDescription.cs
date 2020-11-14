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
    }
}
