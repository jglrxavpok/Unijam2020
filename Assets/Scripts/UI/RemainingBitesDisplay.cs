using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Text))]
    public class RemainingBitesDisplay : MonoBehaviour {

        [SerializeField] private string prefix;
        private Text _text;

        private void Start() {
            _text = GetComponent<Text>();
            BitingSystem.Instance.BiteCountChange += UpdateText;
        }

        private void OnDestroy() {
            BitingSystem.Instance.BiteCountChange -= UpdateText;
        }

        private void UpdateText(int count) {
            _text.text = $"{prefix} {count}";
        }
    }
}
