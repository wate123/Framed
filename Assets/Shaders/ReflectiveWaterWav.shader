Shader "Custom/ReflectiveWaterWav"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Flip ("Flip", Vector) = (1, -1, 1, 1)
		_NoiseTex("Noise Texture", 2D) = "white" {}
		_WaveSpeed("Wave Speed", float) = 1.0
		_WaveAmp("Wave Amp", float) = 0.2

		_Color("Color", Color) = (1, 1, 1, .5)
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

			//Properties

			sampler2D _MainTex;
			sampler2D _NoiseTex;

			float4 _Color;

			float4 _Flip;
			float _WaveSpeed;
			float _WaveAmp;

            struct vertexInput
            {
                float4 vertex : POSITION;
                float3 texCoord : TEXCOORD0;
            };

            struct vertexOutput
            {
                float4 pos : SV_POSITION;
                float3 texCoord : TEXCOORD0;
            };

            vertexOutput vert (vertexInput input)
            {
                vertexOutput output;

                output.pos = UnityObjectToClipPos(input.vertex);
				output.texCoord = input.texCoord;

				//applies the flip of the image reflected
				output.pos.xy *= _Flip.xy;

				//do the wavey thing
				float noiseSample = tex2Dlod(_NoiseTex, float4(input.texCoord.xy, 0, 0));
				output.pos.x += cos(_Time*_WaveSpeed*noiseSample)*_WaveAmp;

				return output;
			}

            float4 frag(vertexOutput input) : COLOR
			{
				// sample texture for color
				float4 albedo = tex2D(_MainTex, input.texCoord.xy);
				return albedo;

				// _LightColor0 provided by Unity
				float3 rgb = albedo.rgb * _Color.rgb;
				return float4(rgb, 1.0);
			}
            ENDCG
        }
    }
}
