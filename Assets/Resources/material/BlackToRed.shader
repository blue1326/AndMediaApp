Shader "Custom/transparent/BlackToRed"
{
    Properties
    {
		_Color("ColorTint (A=Opacity)", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
		Tags {"Queue" = "Transparent" "IgnoreProjector" = "True"}
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		//Tags { "RenderType" = "Opaque" }
        //// No culling or depth
        //Cull Off ZWrite Off ZTest Always

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
			fixed4 _Color;
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) *_Color;
                
				if (col.r < 0.7)
				{
					col.r = 1;
				}
				//col.a = 0.5;
				//col*_Color;
                return col;
            }
            ENDCG
        }
    }
}
