varying vec2 texcoordOut;
varying vec2 texcoord1;
varying vec2 texcoord2;
varying vec2 texcoord3;
varying vec2 texcoord4;
varying vec2 texcoord5;
varying vec2 texcoord6;
varying vec2 texcoord7;
varying vec2 texcoord8;
uniform sampler2D texture;
uniform sampler2D Pencil;
//uniform float a;

float calGray(vec4 color){
	return color.r*0.3+color.g*0.59+color.b*0.11;
}

void main(){
	float Gx,Gy;
	// sobel
	Gx=0.0;
	Gx+= -1.0*calGray(texture2D(texture,texcoord1));
	Gx+= -2.0*calGray(texture2D(texture,texcoord4));
	Gx+= -1.0*calGray(texture2D(texture,texcoord6));
	Gx+= 1.0*calGray(texture2D(texture,texcoord3));
	Gx+= 2.0*calGray(texture2D(texture,texcoord5));
	Gx+= 1.0*calGray(texture2D(texture,texcoord8));

	Gy=0.0;
	Gy+= -1.0*calGray(texture2D(texture,texcoord1));
	Gy+= -2.0*calGray(texture2D(texture,texcoord2));
	Gy+= -1.0*calGray(texture2D(texture,texcoord3));
	Gy+= 1.0*calGray(texture2D(texture,texcoord6));
	Gy+= 2.0*calGray(texture2D(texture,texcoord7));
	Gy+= 1.0*calGray(texture2D(texture,texcoord8));
	// lapulasi
	// Gx=0.0;
	// Gx+= 1.0*calGray(texture2D(texture,texcoord1));
	// Gx+= 1.0*calGray(texture2D(texture,texcoord2));
	// Gx+= 1.0*calGray(texture2D(texture,texcoord3));
	// Gx+= 1.0*calGray(texture2D(texture,texcoord4));
	// Gx+= -8.0*calGray(texture2D(texture,texcoordOut));
	// Gx+= 1.0*calGray(texture2D(texture,texcoord5));
	// Gx+= 1.0*calGray(texture2D(texture,texcoord6));
	// Gx+= 1.0*calGray(texture2D(texture,texcoord7));
	// Gx+= 1.0*calGray(texture2D(texture,texcoord8));
	
	
	
	float gray = calGray(texture2D(texture,texcoordOut));
	
	float GNum = sqrt(Gx*Gx+Gy*Gy);
	//float GNum = Gy;
	
	//if(GNum>1.0) GNum=1.0;
	
	//if(GNum>0.5) GNum=1.0;

	//GNum = (1.0-GNum);
	
	//GNum = GNum+(GNum*gray)/(1.0-gray);
	
	GNum = 1.0-GNum;
	
	if(gray<64.0/255.0) GNum=0.0;
	else if(gray>140.0/255.0) GNum=1.0;
	else GNum = 0.5*GNum+0.5*calGray(texture2D(Pencil,texcoordOut));
	
	//GNum = 0.5*GNum+0.5*calGray(texture2D(Pencil,texcoordOut));
	
	//GNum = gray;
	
	//GNum*=gray;
	
	
	//GNum*=gray;
	
	//GNum = 1.0-GNum;
	//GNum*=a;
	//GNum = gray;
	//GNum = mix(GNum,gray,0.5);
	//vec4 result = vec4(1.0-GNum+gray,1.0-GNum+gray,1.0-GNum+gray,1.0);
	vec4 result = vec4(GNum,GNum,GNum,1.0);
	//vec4 result = dither8x8(texcoordOut*vec2(400.0,300.0),vec4(vec3(GNum),1.0));
	gl_FragColor = result;
	//gl_FragColor = vec4(gray,gray,gray,1.0);
}