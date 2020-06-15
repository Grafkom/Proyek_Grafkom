using System;
using Tao.OpenGl;

namespace TareaGL
{
	/// <summary>
	/// Summary description for MesetaConFregadero.
	/// </summary>
	public class teko3:Plantilla
	{

		protected override void setInitialParams(object[] InitialParams) 
		{
			yInc=0;
			height=100;
			alto=height/100;
		}
		public teko3(Point3D center, double angle): base(center,angle)
		{
			this.customRendering=true;
		}

		double largo = 1.97 , alto, ancho = 0.54 , anchoF = 0.15 , anchoM = 0.05 ;
		double lead=1.7;
		
		protected double distance=0;
		public override void Prepare (Avatar observer) 
		{
			distance = (observer.Origin-this.center-new Point3D(largo*100/2,alto*100,-ancho*100/2)).Norm;
		}

		protected override void customRenderer()
		{

			Gl.glCallList(this.idObject);

			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("AZULEJO"));
			Gl.glColor3d(0.1, 0.15, .1);

			double d = (int)this.distance / 50;
			Gl.glBegin(Gl.GL_QUADS);

			//pared

			//Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(0,0);Gl.glVertex3d(0,alto*100,-ancho*100+d);
			//Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(12,0);Gl.glVertex3d(largo*100,alto*100,-ancho*100+d);
			//Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(12,5);Gl.glVertex3d(largo*100,(alto+0.5)*100,-ancho*100+d);
			//Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(0,5);Gl.glVertex3d(0,(alto+0.5)*100,-ancho*100+d);

			//pared derecha

			//Gl.glNormal3d(-1,0,0);Gl.glTexCoord2d(0,0);Gl.glVertex3d(largo*100-d,alto*100,-ancho*100);
			//Gl.glNormal3d(-1,0,0);Gl.glTexCoord2d(5,0);Gl.glVertex3d(largo*100-d,alto*100,0);
			//Gl.glNormal3d(-1,0,0);Gl.glTexCoord2d(5,5);Gl.glVertex3d(largo*100-d,(alto+0.5)*100,0);
			//Gl.glNormal3d(-1,0,0);Gl.glTexCoord2d(0,5);Gl.glVertex3d(largo*100-d,(alto+0.5)*100,-ancho*100);

			//pared izquierda

			//Gl.glNormal3d(1,0,0);Gl.glTexCoord2d(0,5);Gl.glVertex3d(d,(alto+0.5)*100,-ancho*100);
			//Gl.glNormal3d(1,0,0);Gl.glTexCoord2d(5,5);Gl.glVertex3d(d,(alto+0.5)*100,0);
			//Gl.glNormal3d(1,0,0);Gl.glTexCoord2d(5,0);Gl.glVertex3d(d,alto*100,0);
			//Gl.glNormal3d(1,0,0);Gl.glTexCoord2d(0,0);Gl.glVertex3d(d,alto*100,-ancho*100);

			//if (lead>0) 
			//{
			// Gl.glNormal3d(1,0,0);Gl.glTexCoord2d(0,6);Gl.glVertex3d(d,(alto)*100,0);
			// Gl.glNormal3d(1,0,0);Gl.glTexCoord2d(lead*5,6);Gl.glVertex3d(d,(alto)*100,lead*100);
			// Gl.glNormal3d(1,0,0);Gl.glTexCoord2d(lead*5,0);Gl.glVertex3d(d,0,lead*100);
			// Gl.glNormal3d(1,0,0);Gl.glTexCoord2d(0,0);Gl.glVertex3d(d,0,0);
			//}

			Gl.glEnd();
		}
		protected override void Particular() 
	 	{
			Gl.glColor3d(1, 1, 1);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("old4"));
			Gl.glPushMatrix();
			double tph = 10;
			Gl.glTranslated(largo*100 / 4, Height + tph*.8, -ancho * 100 / 2);
			Gl.glRotated(30, 0, 1, 0);
			Glut.glutSolidTeapot(10);
			Gl.glPopMatrix();

		}
	}
}
