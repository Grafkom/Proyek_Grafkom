using System;
using Tao.OpenGl;

namespace TareaGL
{
	public class Kursi : Template
	{
		public Kursi(Point3D center,double angle):base(center,angle){}

		public Kursi(Point3D center):this(center,0){}
	
		protected override void Particular()
		{

Gl.glBindTexture(Gl.GL_TEXTURE_2D,GlUtils.Texture("rose"));		
			Gl.glPushMatrix();
			Gl.glColor3d(1,1,1);
			Gl.glTranslatef(0,-0.05f*70,0);
			GlUtils.PintaOrtoedro(0.4f*70,0.05f*70,0.4f*70,true);
			Gl.glPopMatrix();

Gl.glBindTexture(Gl.GL_TEXTURE_2D,GlUtils.Texture("madera"));
			Gl.glColor3d(.5,.5,.5);
			Gl.glPushMatrix();
			Gl.glTranslatef(-0.3f*70,-0.5f*70,0.3f*70);
			GlUtils.PintaOrtoedro(0.05f*70,0.4f*70,0.05f*70);
			Gl.glPopMatrix();

			Gl.glPushMatrix();
			Gl.glTranslatef(0.3f*70,-0.5f*70,0.3f*70);
			GlUtils.PintaOrtoedro(0.05f*70,0.4f*70,0.05f*70);
			Gl.glPopMatrix();
			Gl.glPushMatrix();
			Gl.glTranslatef(0.3f*70,-0.5f*70,-0.3f*70);
			GlUtils.PintaOrtoedro(0.05f*70,0.4f*70,0.05f*70);
			Gl.glPopMatrix();
			Gl.glPushMatrix();
			Gl.glTranslatef(-0.3f*70,-0.5f*70,-0.3f*70);
			GlUtils.PintaOrtoedro(0.05f*70,0.4f*70,0.05f*70);
			Gl.glPopMatrix();
			
			Gl.glPushMatrix();
			Gl.glTranslatef(0.3f*70,0.2f*70,0.3f*70);
			GlUtils.PintaOrtoedro(0.02f*70,0.2f*70,0.05f*70);
			Gl.glPopMatrix();
			Gl.glPushMatrix();
			Gl.glTranslatef(0.3f*70,0.2f*70,-0.3f*70);
			GlUtils.PintaOrtoedro(0.02f*70,0.2f*70,0.05f*70);
			Gl.glPopMatrix();

			Gl.glBindTexture(Gl.GL_TEXTURE_2D,GlUtils.Texture("rose"));		
			Gl.glColor3d(1,1,1);
			Gl.glPushMatrix();
			Gl.glTranslatef(0.3f*70,0.6f*70,0);
			GlUtils.PintaOrtoedro(0.05f*70,0.2f*70,0.4f*70);
			Gl.glColor3d(1,1,1);
			yInc = 0.9*70;
			Gl.glPopMatrix();

			Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);
		}
	}
}
