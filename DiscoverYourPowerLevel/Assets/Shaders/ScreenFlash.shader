Shader "Custom/ScreenFlash"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color", color) = (0,0,0,0)
		_ColorIntensity("Color Intensity", Range(0,1)) = 1
		_Strength("Strength", Range(0,1)) = 1
		_StrengthCutoff("Strength Cutoff", Range(0,1)) = 0
		_ZoomStrength("Zoom Strength", Range(0,0.5)) = 0
		_ZoomCutoff("Zoom Cutoff", Range(0,1)) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float4 _Color;
			float _Strength;
			float _StrengthCutoff;
			float _ZoomStrength;
			float _ZoomCutoff;
			float _ColorIntensity;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 newV = i.uv - float2(0.5,0.5);
				newV *= (1 - clamp((_Strength - _ZoomCutoff) / (1- _ZoomCutoff) , 0,1) * _ZoomStrength);
				newV += float2(0.5,0.5);
				fixed4 col = tex2D(_MainTex, newV);
				col += clamp((_Strength - _StrengthCutoff) / (1- _StrengthCutoff) , 0,1) *  _Color * _ColorIntensity;
				return col;
			}
			ENDCG
		}
	}
}
