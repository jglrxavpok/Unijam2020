using System;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(SpriteRenderer))]
    public class ExposeSpriteToShader : MonoBehaviour {

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        public SpriteRenderer SpriteRenderer {
            get => _spriteRenderer;
            set => _spriteRenderer = value;
        }

        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        private static readonly int VertexColor = Shader.PropertyToID("_VertexColor");
        
        private MaterialPropertyBlock properties;

        private void OnEnable() {
            properties = new MaterialPropertyBlock();
        }

        private void Update() {
            var texture = _spriteRenderer.sprite.texture;
            _spriteRenderer.GetPropertyBlock(properties);
            properties.SetTexture(MainTex, texture);
            properties.SetColor(VertexColor, _spriteRenderer.color);
            _spriteRenderer.SetPropertyBlock(properties);
        }
    }
}
