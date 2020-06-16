using System;
using Tao.OpenGl;

namespace TareaGL
{
	public class ObjetoDePrueba:GlObject
	{
		protected double[][] points;
		protected Point3D[] ruleles;
		protected double[][] texturas;
		public ObjetoDePrueba()
		{
		}
		double xscale;
		double yscale;
		protected void ponpoint(int i) 
		{
			Gl.glNormal3dv(ruleles[i-1].Normalized.Coords);
			Gl.glTexCoord2d(texturas[i-1][0]*xscale,texturas[i-1][1]*yscale);
	
			Gl.glVertex3dv(points[i-1]);
		}

		protected Point3D pointrulel(int point, params int[] others) 
		{
			Point3D rulel = new Point3D(0,0,0);
			for (int i =0; i<others.Length-1; i++)
				rulel+=this.planerulel(others[i],point,others[i+1]);
			return rulel.Normalized;
		}
		
		protected void ponpoints(params int[] p) 
		{
			for (int i =0; i < p.Length; i++)
				ponpoint(p[i]);
		}
		protected Point3D planerulel(int before, int center, int after) 
		{
			Point3D v1 = (new Point3D(points[before-1]))-new Point3D(points[center-1]);
			Point3D v2 = (new Point3D(points[after-1]))-new Point3D(points[center-1]);
			
			return v1.CrossProduct(v2).Normalized;
		}
		
		public void pintaColchon(double w, double h, double d) 
		{
			double l = 20;
			double e = 3;
			double a = 15;
			double p = 6;


			xscale = 1;
			yscale = 1;
		
			pinta();
		}
		public void pinta() 
		{

			Gl.glBegin(Gl.GL_TRIANGLE_FAN);
			ponpoints(20,1,2,3,4,5,6,1);
			Gl.glEnd();
			Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
			ponpoints(6,5,7,4,8,3);
			Gl.glEnd();

Gl.glDisable(Gl.GL_TEXTURE_2D);
Gl.glEnable(Gl.GL_TEXTURE_2D);

			Gl.glBegin(Gl.GL_QUAD_STRIP);
			ponpoints(6,11,7,9,8,10,3,14);
			Gl.glEnd();

Gl.glDisable(Gl.GL_TEXTURE_2D);
Gl.glEnable(Gl.GL_TEXTURE_2D);

			Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
			ponpoints(11,9,12,10,13,14);
			Gl.glEnd();

Gl.glDisable(Gl.GL_TEXTURE_2D);
Gl.glEnable(Gl.GL_TEXTURE_2D);

			Gl.glBegin(Gl.GL_TRIANGLE_FAN);
			ponpoints(19,14,16,15,11,6,3,14);
			Gl.glEnd();

Gl.glDisable(Gl.GL_TEXTURE_2D);
Gl.glEnable(Gl.GL_TEXTURE_2D);

			Gl.glBegin(Gl.GL_TRIANGLE_FAN);
			ponpoints(11,6,1,17,15);
			Gl.glEnd();

Gl.glDisable(Gl.GL_TEXTURE_2D);
Gl.glEnable(Gl.GL_TEXTURE_2D);

			Gl.glBegin(Gl.GL_QUADS);
			ponpoints(17,15,16,18);
			Gl.glEnd();

Gl.glDisable(Gl.GL_TEXTURE_2D);
Gl.glEnable(Gl.GL_TEXTURE_2D);

			Gl.glBegin(Gl.GL_TRIANGLE_FAN);
			ponpoints(14,3,2,18,16);
			Gl.glEnd();
		}
		public override void Render() 
		{
			Gl.glColor3d(1,1,1);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,GlUtils.Texture("COLCHON"));
			double h = 10;
			double d = 50;
			double w = 30;
			this.pintaColchon(w,h,d);
		}
	}
}
