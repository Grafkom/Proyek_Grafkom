using System;
using Tao.OpenGl;

namespace TareaGL
{
	public class teko7:Template
	{

		protected override void setInitialParams(object[] InitialParams) 
		{
			yInc=0;
			height=100;
			tinggi=height/100;
		}
		public teko7(Point3D center, double angle): base(center,angle)
		{
			this.customRendering=true;
		}

		double panjang = 1.97 , tinggi, ancho = 0.54 , anchoF = 0.15 , anchoM = 0.05 ;
		double lead=1.7;
		
		protected double distance=0;
		public override void Prepare (Avatar observer) 
		{
			distance = (observer.Origin-this.center-new Point3D(panjang*100/2,tinggi*100,-ancho*100/2)).Norm;
		}

		protected override void customRenderer()
		{

			Gl.glCallList(this.idObject);

			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("AZULEJO"));
			Gl.glColor3d(0.1, 0.15, .1);

			double d = (int)this.distance / 50;
			Gl.glBegin(Gl.GL_QUADS);

			Gl.glEnd();
		}
		protected override void Particular() 
	 	{
			Gl.glColor3d(1, 1, 1);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("old8"));
			Gl.glPushMatrix();
			double tph = 10;
			Gl.glTranslated(panjang*100 / 4, Height + tph*.8, -ancho * 100 / 2);
			Gl.glRotated(30, 0, 1, 0);
			Glut.glutSolidTeapot(10);
			Gl.glPopMatrix();

		}
	}
}
