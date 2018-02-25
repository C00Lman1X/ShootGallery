Shader "Unlit/Hologram"
{
	Properties //то что видно в инспекторе
	{ 
		_MainTex ("Texture", 2D) = "while" {} //текстура
		_Color ("Color", Color) = (1, 0, 0, 1) //цвет
		_Bias ("Bias", Float) = 0 //ширина полос
		_ScanningFrequency ("Scanning Frequency", Float) = 100 //кол-во полос
		_ScanningSpeed ("Scanning Speed", Float) = 100 //скорость пробегания


	}
	SubShader 
	{
	     //метки для отображения шейдера
		Tags {"Queue" = "Transparent" "RenderType"="Transparent" } //прозрачность
		LOD 100 //Level of Detail 
		ZWrite off //Решает, записываются ли пиксели объекта в буфер глубины 
		Blend SrcAlpha One //смешивание каналов  
		Cull back // отсечение по нормалям 
		Pass
		{
			CGPROGRAM

			#pragma vertex vert //Vertex Shader-программа запускающаяся на каждой вершине модели. Данная директива указывает на название нашей vertex функции
			#pragma fragment frag // Fragment Shader - программа работающая на каждом пикселе. Так же указываем имя
			// make fog work
			//#pragma multi_compile_fog



			#include "UnityCG.cginc" //объявляет встроенные вспомогательный функции

			struct appdata
			{
				float4 vertex : POSITION; //позиция вершин
				float2 uv : TEXCOORD0; //Используются для обозначения произвольных данных высокой точности, таких как координаты и позиции текстуры.
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(2) 
				float4 vertex : SV_POSITION;
				float4 objVertex : TEXCOORD1;
			};
			//переменные для вводиммых значений с инспектора
			fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Bias;
			float _ScanningFrequency;
			float _ScanningSpeed;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.objVertex = mul(unity_ObjectToWorld, v.vertex); 
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				//fixed4 texColor = tex2D(_MainTex, i.uv);
				// apply fog
				//UNITY_APPLY_FOG(i.fogCoord, col);

				 col = col * _Color + _Color * min(0, cos(i.objVertex.y * _ScanningFrequency + _Time.x * _ScanningSpeed) + _Bias);
				return col;
			}
			ENDCG
		}
	}
}
