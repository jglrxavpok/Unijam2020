Shader "Unlit/SpiderMaterial"
{
    Properties
    {
        [PerRendererData]_MainTex ("Texture", 2D) = "white" {}
        [PerRendererData]_VertexColor ("VertexColor", Color) = (1,1,1,1)
        _OutlineWidth ("Width", Float) = 0.2
        _OutlineColor ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        ZWrite Off
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        LOD 100
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            float _OutlineWidth;
            float4 _OutlineColor;
            float4 _VertexColor;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _MainTex_TexelSize;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag (v2f IN) : SV_Target
            {
                // sample the texture

                // sobel filter
                // based on https://github.com/James-Jones/HLSLCrossCompiler/blob/master/tests/apps/shaders/generic/postProcessing/sobel.hlsl (MIT)
                const float2 texel = _MainTex_TexelSize.xy*_OutlineWidth;
                const float2 texAddrOffsets[8] = {
                            int2(-1, -1), 
                            int2( 0, -1),
                            int2( 1, -1),
                            int2(-1,  0),
                            int2( 1,  0),
                            int2(-1,  1),
                            int2( 0,  1),
                            int2( 1,  1),
                    };

                float4 colors[8];
                for(int i = 0;i<8;i++)
                {
                    colors[i] = tex2D(_MainTex, IN.uv+texel*texAddrOffsets[i]);
                }

                float4 gx = colors[0] + 2 * colors[3] + colors[5] - colors[2] - 2 * colors[4] - colors[7];
                float4 gy = colors[0] + 2 * colors[1] + colors[2] - colors[5] - 2 * colors[6] - colors[7];

                float4 edge = sqrt(gx*gx + gy*gy);

                float4 originalColor = tex2D(_MainTex, IN.uv);

                if(originalColor.a > 0.8)
                {
                    return originalColor * _VertexColor;
                }
                if(edge.a > 0.001)
                {
                    return float4(_OutlineColor.rgb, edge.a);
                }

                discard;
                return 0;
            }
            ENDCG
        }
    }
}
