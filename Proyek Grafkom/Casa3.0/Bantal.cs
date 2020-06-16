using System;
using Tao.OpenGl;

namespace TareaGL
{
	public class Bantal:Template
	{
		public Bantal(Point3D center,double angle):base(center,angle){}

		public Bantal(Point3D center):this(center,0){}

		protected override void Particular()
		{
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,GlUtils.Texture("rose"));
			Gl.glRotated(90,1,0,0);
			Gl.glRotated(45,0,0,1);
			Gl.glScaled(1,1,0.4);
			Glut.glutSolidTorus(0.5f*30,0.5*30,40,4);

			Gl.glScaled(1,1,1.5);
			Glut.glutSolidTorus(0.3f*30,0.3f*30,40,40);
			
			Gl.glScaled(1,1,1);
			Glut.glutSolidSphere(0.2f*30,20,20);
			height = 6.6;
			Gl.glColor3d(1,1,1);
		}
	}
}
