Shader "Custom/Dissolve" {
    Properties 
    {
        _GlowThickness ("GlowThickness", Float) = 0.1
        _Size ("Size", Float) = 5
        _Speed ("Speed", Float) = 20
        _Emission ("Emission", Color) = (1, 1, 1)
        _Emission2 ("Emission2", Color) = (1, 1, 1)
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader {
        CGPROGRAM

        #pragma surface surf Standard addshadow
        #pragma target 5.0
        #include "noiseSimplex.cginc"

        struct Input {
            float3 worldPos;
        };

        float _GlowThickness;
        float _Size;
        float _Speed;
        float3 _Emission;
        float3 _Emission2;
        float3 _Color;

        void surf (Input i, inout SurfaceOutputStandard o) 
        {
            float noise = (snoise(i.worldPos * _Size) * 0.5 + 0.5) * (1 - _GlowThickness * 2) + _GlowThickness * 2;
            float time = (_Time.x) * _Speed - i.worldPos.y * 2;
            float t = sin(time) * 0.5 + 0.5;

            float v = noise - t;
            clip(v);
            o.Albedo = _Color;

            if (v < _GlowThickness) {
                o.Emission = _Emission;
            } else if (v < _GlowThickness * 2) {
                o.Emission = _Emission2;
            }
        }

        ENDCG
    }
}
