Shader "Custom/BackgroundVideo"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Scale ("Scale", Vector) = (1, 1, 0, 0)
    }
    SubShader
    {
        Tags {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
        }

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
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float3 _Scale;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = float4(v.vertex.x * _Scale.x, v.vertex.y * _Scale.y, _Scale.z, 1);
                o.uv = v.uv;
                return o;
            }


            fixed4 frag (v2f i) : SV_Target
            {
                float4 tex = tex2D(_MainTex, i.uv);
                // return tex;
                return float4(1, 0, 0, 1);
            }
            ENDCG
        }
    }
}
