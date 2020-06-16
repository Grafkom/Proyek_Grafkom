using System;
using Tao.OpenGl;

namespace TareaGL
{
	public class Pillar : Template
	{
		public Pillar(Point3D center,double angle):base(center,angle){}

		public Pillar(Point3D center):this(center,0){}
		
		protected override void Particular()
		{
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,GlUtils.Texture("cream"));
			Glu.GLUquadric q = Glu.gluNewQuadric();
			Glu.gluQuadricNormals(q,Glu.GLU_SMOOTH);
			Glu.gluQuadricTexture(q,Gl.GL_TRUE);
			Gl.glColor3d(1, 1, 1);

			GlUtils.PintaOrtoedro(0.7f*5,1.0f*160,0.7f*10);

			Gl.glPopMatrix();

			Gl.glEnable(Gl.GL_TEXTURE_2D);
			yInc = 20; 

	
		}
	}
}
