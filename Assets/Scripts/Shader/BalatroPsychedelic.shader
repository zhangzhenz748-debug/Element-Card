Shader "Custom/BalatroPsychedelic"
{
Properties
    {
        _MainTex ("桌子纹理 (Wood/Stone)", 2D) = "white" {}
        _TableColor ("桌子底色调", Color) = (0.5, 0.4, 0.3, 1)
        _CenterLight ("中心亮度", Range(1, 3)) = 1.2
        _VignetteRange ("暗角范围 (牌桌聚光感)", Range(0, 1)) = 0.5
        _Grain ("颗粒感 (做旧)", Range(0, 0.1)) = 0.02
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

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _TableColor;
            float _CenterLight;
            float _VignetteRange;
            float _Grain;

            // 简单的伪随机函数做颗粒
            float rand(float2 co){
                return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
            }

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                // 1. 采样桌子纹理并混合色调
                fixed4 col = tex2D(_MainTex, i.uv) * _TableColor;

                // 2. 核心：计算聚光灯效果
                // 离中心越近越亮，模拟牌桌正上方的灯光
                float dist = distance(i.uv, float2(0.5, 0.5));
                float light = smoothstep(_VignetteRange + 0.5, _VignetteRange - 0.2, dist);
                col.rgb *= (light * _CenterLight);

                // 3. 增加一点点杂色，模拟木头或石头的粗糙质感
                col.rgb += rand(i.uv + _Time.x) * _Grain;

                return col;
            }
            ENDCG
        }
    }
}
