using System;
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

        [SerializeField] private ThoughtManager _thoughtManager;

        private void Start() {
            LoadRandom();
        }

        public void LoadRandom() {
            // TODO
        }
        
        public float Score => score;
        public Sprite FacePhoto => facePhoto;
        public string FirstName => firstName;
        public string Name => name;
        public string Taste => taste;
        public string Judgment => judgment;
        public string Desire => desire;
        public string Intention => intention;
    }
}
