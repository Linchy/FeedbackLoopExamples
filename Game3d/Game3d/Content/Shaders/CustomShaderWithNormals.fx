// Lithiums shader Example
#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_2_0
#define PS_SHADERMODEL ps_2_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

float4x4 WorldViewProjection;
//Texture2D Texture : register(t0);

//sampler TextureSampler : register(s0)
//{
//    Texture = (Texture);
//};

struct VertexShaderInput
{
    float4 Position : POSITION0;
	float3 Normal : NORMAL0;
    //float4 Color : COLOR0;
    //float2 TexureCoordinate : TEXCOORD0;
};

struct VertexShaderOutput
{
    float4 Position : SV_Position;
    //float4 Color : COLOR0;
    //float2 TexureCoordinate : TEXCOORD0;
};

struct PixelShaderOutput
{
    float4 Color : COLOR0;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
    VertexShaderOutput output;
    output.Position = mul(input.Position, WorldViewProjection);
    //output.Color = input.Color;
    //output.TexureCoordinate = input.TexureCoordinate;
    return output;
}

PixelShaderOutput PixelShaderFunction(VertexShaderOutput input)
{
    PixelShaderOutput output;
	output.Color = float4(0, 0, 1, 1);// tex2D(TextureSampler, input.TexureCoordinate) * input.Color;
    return output;
}

technique first
{
    pass
    {
        VertexShader = compile VS_SHADERMODEL VertexShaderFunction();
        PixelShader = compile PS_SHADERMODEL PixelShaderFunction();
    }
}