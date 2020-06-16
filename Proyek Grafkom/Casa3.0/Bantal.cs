using System;
using Tao.OpenGl;

namespace TareaGL
{
	/// <summary>
	/// Summary description for CojinGl.
	/// </summary>
	public class Bantal:Plantilla
	{
		public Bantal(Point3D center,double angle):base(center,angle){}

		public Bantal(Point3D center):this(center,0){}

		protected override void Particular()
		{
			//Gl.glColor3d(0.2,0.3,0);
			
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,GlUtils.Texture("rose"));
			Gl.glRotated(90,1,0,0);
			Gl.glRotated(45,0,0,1);
			Gl.glScaled(1,1,0.4);
			Glut.glutSolidTorus(0.5f*30,0.5*30,40,4);

			//Gl.glColor3d(0.3,1,0.2);
			Gl.glScaled(1,1,1.5);
			Glut.glutSolidTorus(0.3f*30,0.3f*30,40,40);
			
//			}
//			else if(objStruct.angle==2)
//			{
//				Glut.glutSolidTorus(0.18,0.18,40,40);
//				Gl.glColor3d(1-temp[0],1-temp[1],1-temp[2]);
//				Glut.glutSolidTorus(0.18,0.18,40,3);
//			}
				
			//Gl.glColor3d(0.2,0.5,0.3);
			Gl.glScaled(1,1,1);
			Glut.glutSolidSphere(0.2f*30,20,20);
			height = 6.6;
			Gl.glColor3d(1,1,1);
		}
	}
}
