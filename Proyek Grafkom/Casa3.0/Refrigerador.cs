using System;
using Tao.OpenGl;

namespace TareaGL
{
	/// <summary>
	/// Summary description for RefrigeradorGl.
	/// </summary>
	public class Refrigerador : Plantilla
	{
		public Refrigerador(Point3D center,double angle):base(center,angle){}

		public Refrigerador(Point3D center):this(center,0){}
		
		protected override void Particular()
		{
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,GlUtils.Texture("rose"));
			Glu.GLUquadric q = Glu.gluNewQuadric();
			Glu.gluQuadricNormals(q,Glu.GLU_SMOOTH);
			Glu.gluQuadricTexture(q,Gl.GL_TRUE);
			
			GlUtils.PintaOrtoedro(0.7f*5,1.0f*160,0.7f*10);

			Gl.glPopMatrix();

			Gl.glEnable(Gl.GL_TEXTURE_2D);
			yInc = 20; 

	
		}
	}
}
