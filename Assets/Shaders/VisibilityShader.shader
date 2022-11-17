// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/VisibilityShader"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0

        [PerRendererData] _MaskTargetX ("Mask Tartget X", Float) = 0
        [PerRendererData] _MaskTargetY ("Mask Target Y", Float) = 0
        [PerRendererData] _RenderDistance ("Render Distance", Float) = 1
        [PerRendererData] _MaskType ("Mask Type", Float) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
                fixed4 worldPos : WORLDPOS;
			};
			
			fixed4 _Color;
            float _MaskTargetX;
            float _MaskTargetY;
            float _RenderDistance;
            float _MaskType;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
                OUT.worldPos = mul(unity_ObjectToWorld, fixed4(IN.vertex.x, IN.vertex.y, 0, 1));
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;
			float _AlphaSplitEnabled;

			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);

#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
				if (_AlphaSplitEnabled)
					color.a = tex2D (_AlphaTex, uv).r;
#endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

				return color;
			}

			fixed4 frag(v2f IN) : SV_Target
			{	
				fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
                float dist = distance(IN.worldPos, fixed4(_MaskTargetX, _MaskTargetY, IN.worldPos.z, 1));

                if (_MaskType > 0) {
                    if (_MaskType <= 1) {
						if ( dist > _RenderDistance) {
							c.a = 0;
						}
						else {
							c.a = c.a*(1 - (dist/_RenderDistance)*(dist/_RenderDistance));
						}
					}
					else if (_MaskType <= 2){
						if ( dist <= _RenderDistance)  {
							c.a = c.a*(dist/_RenderDistance);
						}
					}
                    
                }
				c.rgb *= c.a;
				return c;
			}
		ENDCG
		}
	}
}