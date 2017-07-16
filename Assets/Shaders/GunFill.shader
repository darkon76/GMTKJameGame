Shader "Unlit/GunFill"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_SecodaryTex ("Texture2", 2D) = "white" {}

		_ChargeColorTex ("ChargeColor", 2D) = "white"{}

		_Cutoff("Cutoff", Range(0, 1)) = 0
		_ChargeColor("Charge Color", Color) = (1,1,1,1)
		_Color("UnCharge Color", Color) = (1,1,1,1)
		_Speed1("Speed1", Range(0, 1)) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }

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

			sampler2D _MainTex;
			sampler2D _SecodaryTex;
			sampler2D _ChargeColorTex;
			float _Cutoff;
			fixed4 _Color;
			fixed4 _ChargeColor;
			float _Speed1;
			float _Speed2;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				if(i.uv.y > _Cutoff)
					return _Color;

				// sample the texture
				float2 displace;
				displace.x = sin(_Time.g);
				displace.y = sin(_Time.g);
				fixed4 col = _ChargeColor;
				fixed4 FirstText = tex2D(_MainTex, i.uv + displace);
				displace.x = _Time.g;
				displace.y = _Time.g;
				fixed4  SecondText = tex2D(_SecodaryTex, i.uv + displace);

				col += (FirstText * SecondText);


				return col;
			}
			ENDCG
		}
	}
}
