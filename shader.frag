#version 330 

layout (location = 0) out vec4 color;

out vec4 outputColor;

in vec2 texCoord;

uniform vec4 u_Color;
uniform sampler2D texture0;
uniform sampler2D texture1;

void main()
{
    outputColor =  u_Color;
}