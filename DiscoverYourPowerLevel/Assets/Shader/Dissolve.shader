Shader "Custom/Dissolve" {
    Properties 
    {
        _GlowThickness ("GlowThickness", Float) = 0.1
        _Size ("Size", Float) = 5
        _Speed ("Speed", Float) = 20
        _Emission ("Emission", Color) = (1, 1, 1)
        _Emission2 ("Emission2", Color) = (1, 1, 1)
        _Color ("Color", Color) = (1,1,1,1)
		_MainTex ("MainTex", 2D) = "white" {}

		_Flow ("Flow", Range(0,1)) = 0
    }
    SubShader {
        CGPROGRAM

        #pragma surface surf Standard addshadow vertex:vert 
        #pragma target 5.0
        #include "noiseSimplex.cginc"

        struct Input {
            float3 worldPos;
			float3 objPos;
			float2 uv_MainTex : TEXCOORD0;
        };

		void vert (inout appdata_full v, out Input o) {
            UNITY_INITIALIZE_OUTPUT(Input,o);
            o.objPos = v.vertex;
        }

        float _GlowThickness;
        float _Size;
        float _Speed;
        float3 _Emission;
        float3 _Emission2;
        float3 _Color;
		sampler2D _MainTex;

		float _Flow;

        void surf (Input i, inout SurfaceOutputStandard o) 
        {
            float noise = (snoise(i.worldPos * _Size) * 0.5 ) * (1 - _GlowThickness * 2) + _GlowThickness * 2;
            float time = 1 - _Flow * 2 + i.objPos.y;
            //float t = sin(time) * 0.5 + 0.5;

			float t = time;

            float v = noise - t * 2;
            clip(v);
            o.Albedo = tex2D(_MainTex, i.uv_MainTex).rgb;

            if (v < _GlowThickness) {
                o.Emission = _Emission;
            } else if (v < _GlowThickness * 2) {
                o.Emission = _Emission2;
            }
        }

        ENDCG
    }
}
