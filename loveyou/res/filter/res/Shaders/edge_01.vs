attribute vec3 position;
attribute vec2 texcoord;
varying vec2 texcoordOut;
varying vec2 texcoord1;
varying vec2 texcoord2;
varying vec2 texcoord3;
varying vec2 texcoord4;
varying vec2 texcoord5;
varying vec2 texcoord6;
varying vec2 texcoord7;
varying vec2 texcoord8;
uniform mat4 mvpMatrix;
uniform float offsetX;
uniform float offsetY;

void main(){
	texcoordOut=vec2(texcoord.x,texcoord.y);
	texcoord1=vec2(texcoord.x-offsetX,texcoord.y-offsetY);
	texcoord2=vec2(texcoord.x,texcoord.y-offsetY);
	texcoord3=vec2(texcoord.x+offsetX,texcoord.y-offsetY);
	texcoord4=vec2(texcoord.x-offsetX,texcoord.y);
	texcoord5=vec2(texcoord.x+offsetX,texcoord.y);
	texcoord6=vec2(texcoord.x-offsetX,texcoord.y+offsetY);
	texcoord7=vec2(texcoord.x,texcoord.y+offsetY);
	texcoord8=vec2(texcoord.x+offsetX,texcoord.y+offsetY);
	gl_Position = mvpMatrix * vec4(position,1.0);
}