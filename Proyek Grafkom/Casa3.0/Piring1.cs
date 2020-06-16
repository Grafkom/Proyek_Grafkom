using System;
using Tao.OpenGl;

namespace TareaGL
{
    public class Piring1 : Template
    {
		public Piring1(Point3D center, double angle) : base(center, angle) { }

		public Piring1(Point3D center) : this(center, 0) { }

		protected override void Particular()
		{
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("old2"));
			Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, 1);

			Glu.GLUquadric q = Glu.gluNewQuadric();
			Glu.gluQuadricTexture(q, Gl.GL_TRUE);
			Gl.glColor3d(1, 1, 1);
			Gl.glPushMatrix();
			Gl.glRotated(90, 1, 4, 0);
			//bawah piring
			Glu.gluDisk(q, 0, 5 * 3, 20, 20);
			Gl.glRotated(180, 1, 0, 0);
			//pinggiran
			Glu.gluCylinder(q, 5 * 3, 8 * 3, 3 * 3, 20, 20);
			Gl.glTranslated(0, 0, 2.5 * 3);
			Gl.glColor3d(0, 0, 0);

			Gl.glTranslated(0, 0, -2.5 * 3);
			Gl.glRotated(90, 1, 4, 0);
			Gl.glPopMatrix();
			yInc = 0;
			Gl.glColor3d(1, 1, 1);
			Glu.gluDeleteQuadric(q);
			Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, 0);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
		}
	}
}
