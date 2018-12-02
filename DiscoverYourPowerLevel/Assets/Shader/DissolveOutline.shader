Shader "Custom/DissolveOutline" {
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
				//o.pos += float4(v.normal.xyz,0);
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}

			float4 _Outline;

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
				//o.pos += float4(v.normal.xyz,0);
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
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 objPos : TEXCOORD1;
			};

			v2f vert (appdata v) {
				v2f o;
				//o.pos += float4(v.normal.xyz,0);
				o.pos = UnityObjectToClipPos(v.pos);
				o.objPos = v.pos;
				o.uv = v.uv;
				return o;
			}

			float _GlowThickness;
			float _Size;
			float _Speed;
			float3 _Emission;
			float3 _Emission2;
			float3 _Color;
			sampler2D _MainTex;
			float _Flow;

			fixed4 frag (v2f i) : SV_TARGET
			{
				float4 tex = tex2D(_MainTex, i.uv);

				float time = _Flow * 2  - 1 - i.objPos.y;
				clip(time);
				return tex;
			}

			ENDCG
		}

       /* #pragma surface surf Standard vertex:vert NoLighting noambient
        #pragma target 5.0
        #include "noiseSimplex.cginc"

        struct Input {
            float3 worldPos;
			float3 objPos;
			float2 uv_MainTex : TEXCOORD0;
        };

		      fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
     {
         fixed4 c;
         c.rgb = s.Albedo;
         c.a = s.Alpha;
         return c;
     }

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
            float noise = (snoise(i.worldPos * _Size) * 0.5) * (1 - _GlowThickness * 2) + _GlowThickness * 2;
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
        }*/

        
		
		
	}
}
