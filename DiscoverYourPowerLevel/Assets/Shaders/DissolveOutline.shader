Shader "Custom/Powerbar" {
    Properties 
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Flow ("Flow", Range(0,1)) = 0
        _Outline ("Outline", Color) = (1,1,1,1)
    }

    SubShader {

        Pass {

            Tags {"Queue" = "Transparent" "Rendertype"="Transparent"}
            Blend SrcAlpha OneMinusSrcAlpha
            Zwrite off
            Stencil {
                Ref 3
                Comp always
                Pass replace
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata_full v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_TARGET
            {
                return 0;
            }

            ENDCG
        }

        Pass {

            Stencil {
                Ref 3
                Comp notequal
                Pass keep
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata_full v) {
                v2f o;
                float4 tPos = v.vertex;
                tPos *= 1.1;
                o.pos = UnityObjectToClipPos(tPos);
                return o;
            }

            float4 _Outline;

            fixed4 frag (v2f i) : SV_TARGET
            {
                return _Outline;
            }

            ENDCG
        }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 pos : POSITION;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float4 objPos : TEXCOORD1;
            };

            v2f vert (appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.pos);
                o.objPos = v.pos;
                return o;
            }

            float4 _Color;
            float _Flow;

            fixed4 frag (v2f i) : SV_TARGET
            {
                float time = _Flow * 2 - 1 - i.objPos.y;
                clip(time);
                return fixed4(_Color.rgb, 1);
            }

            ENDCG
        }
    }
}
