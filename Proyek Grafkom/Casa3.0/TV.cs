using System;
using Tao.OpenGl;

namespace TareaGL
{
	
	public class TV : Template 
	{
		public TV(Point3D center,double angle):base(center,angle)
		{
			yInc = 35;
		}

		public TV(Point3D center):this(center,0){}

		protected override void Particular(){
			
			Gl.glColor3d(0.421875,0.421875,0.421875);
			GlUtils.GambarBangunUnstretched(150,95,5);
			Gl.glPushMatrix();
			Gl.glTranslated(0,-2,-30);
			Gl.glTranslated(0,2,40);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("paint"));			
			Gl.glColor3d(0,0,0);
			GlUtils.GambarBangunUnstretched(145,90,0.5);
			Gl.glPopMatrix();
			Gl.glPushMatrix();
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

			Gl.glColor3d(0,0,0);
			GlUtils.GambarBangun(3,2,1);
			Gl.glTranslated(0,2,0);
			Gl.glTranslated(0,-2,0);
			Gl.glPushMatrix();
			Gl.glColor3d(0.421875,0.421875,0.421875);
			Gl.glTranslated(-35,Math.Sqrt(3.0)*35+2,0);
			Gl.glRotated(0,0,0,0);
			Gl.glRotated(0,0,0,0);
			
			Glu.gluDisk(Glu.gluNewQuadric(),0,0.3,10,10);
			Gl.glTranslated(0,0,1);
			Glu.gluDisk(Glu.gluNewQuadric(),0,0.3,10,10);
			Gl.glRotated(30,0,1,0);
			Gl.glRotated(90,1,0,0);
			Gl.glPopMatrix();
			Gl.glPopMatrix();

			Gl.glPushMatrix();
			Gl.glTranslated(0,35,-30);
			Gl.glColor3d(0,0,0);
			Gl.glRotated(90,1,0,0);
			Gl.glRotated(60,0,1,0);
			Gl.glRotated(-60,0,1,0);
			Gl.glRotated(90,1,0,0);
			Gl.glPopMatrix();

			Gl.glTranslated(Math.Sqrt(3.0)*35,70,-30);
			Gl.glRotated(-90,1,0,0);
			Gl.glRotated(60,0,1,0);
			Gl.glColor3d(0.421875,0.421875,0.421875);
			Glu.gluDisk(Glu.gluNewQuadric(),0,0.3,10,10);
			Gl.glTranslated(0,0,1);
			Glu.gluDisk(Glu.gluNewQuadric(),0,0.3,10,10);
			Gl.glRotated(-60,0,1,0);
			Gl.glRotated(90,1,0,0);
			
			Gl.glColor3d(1,1,1);
		}
	}
}
