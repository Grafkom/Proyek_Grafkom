using System;
using Tao.OpenGl;
namespace TareaGL
{
	/// <summary>
	/// Summary description for EstanteHorizontal.
	/// </summary>
	public class Resepsionis:Template
	{
		public Resepsionis(Point3D position, double angle):base(position,angle)
		{
			this.height=92;
			this.yInc=35+20;
		}
		public Resepsionis(Point3D position):this(position,0){}
		public Resepsionis():this(new Point3D(0,0,0)){}
		protected override void Particular() 
		{
			Gl.glColor3d(.7,.7,.7);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,GlUtils.Texture("rose"));
			Gl.glPushMatrix();
			Gl.glTranslated(-103.5,0,0);
			GlUtils.GambarBangun(1.5,55,33);
			Gl.glTranslated(103.5*2,0,0);
            GlUtils.GambarBangun(1.5,55,33);
			Gl.glTranslated(-103.5,0,-2);
			GlUtils.GambarBangun(82,1,20);
			Gl.glTranslated(0,-20,2);
			//Gl.glPopMatrix();
			GlUtils.GambarBangun(105,1.5,33);
			Gl.glTranslated(0,70,0);
			GlUtils.GambarBangun(105,1.5,33);
			Gl.glTranslated(0,-35,-20);
			GlUtils.GambarBangun(105,55,3);
			Gl.glTranslated(42,0,38);
			Gl.glColor3d(.5,.5,.5);
			GlUtils.GambarBangun(43,55,1.5);
			Gl.glTranslated(-70,0,3.5);
			GlUtils.GambarBangun(40,32,1.5);
			Gl.glPopMatrix();

			Gl.glPushMatrix();
			Glu.GLUquadric q = Glu.gluNewQuadric();
			Glu.gluQuadricTexture(q,Gl.GL_TRUE);
			Gl.glColor3d(.3,.3,.3);
			Gl.glTranslated(-70,-35,15);
			Gl.glRotated(90,1,0,0);
			//Glu.gluCylinder(q,5,2,20,20,20);
			Gl.glRotated(-90,1,0,0);
			Gl.glTranslated(0,0,-30);
			Gl.glRotated(90,1,0,0);
			//Glu.gluCylinder(q,5,2,20,20,20);
			Gl.glRotated(-90,1,0,0);
			Gl.glTranslated(140,0,0);
			Gl.glRotated(90,1,0,0);
			//Glu.gluCylinder(q,5,2,20,20,20);
			Gl.glRotated(-90,1,0,0);
			Gl.glTranslated(0,0,30);
			Gl.glRotated(90,1,0,0);
			//Glu.gluCylinder(q,5,2,20,20,20);
			Gl.glPopMatrix();

			Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);
		}
	}
}
