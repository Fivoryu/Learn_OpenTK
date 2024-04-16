#version 330 
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in vec3 aColor;

out vec2 texCoord;

out vec3 ourColor;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform mat4 viewprojection;

void main(void)
{
    texCoord = aTexCoord;
    ourColor = aColor;

    gl_Position = vec4(aPosition, 1.0f) * viewprojection;
}
