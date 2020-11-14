using UnityEngine;

namespace Player {
    [RequireComponent(typeof(SpriteRenderer))]
    public class ExposeSpriteToShader : MonoBehaviour {

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Material shader;

        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        private void Update() {
            var texture = _spriteRenderer.sprite.texture;
            shader.SetTexture(MainTex, texture);
        }
    }
}
