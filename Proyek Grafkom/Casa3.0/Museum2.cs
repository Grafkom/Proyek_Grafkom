//#define destechada
using System;
using Tao.OpenGl;
using System.Collections;

namespace TareaGL
{
	
	public class Museum2: GlObject
	{
		protected WallStrip ws;
		Lantai Lantai;
		Atap Atap;
		double x1=521.5;
		double x2=-344;
		double z1=603;
		double z2=-670;
		double tinggi=300;
		double farDistance=1200;

		public Museum2 () 
		{
			ws = new WallStrip(0,270);
			ws.CloseFrom(false);
			ws.CloseTo(false);
			Lantai = new Lantai(x1,z1,x2,z2,10);
			Atap = new Atap(x1,z1,x2,z2,20,tinggi-10-20);
			#region Balkon
			//1
			ws.BeginStrip(false,true);
			ws.Add(491.5,-10,491.5,523,"glass");
			ws.AddTo(296,573,"glass");
			ws.CloseFrom(true);
			ws.AddTo(184,573);
			ws.CloseFrom(false);
			ws.AddTo(184,318);
			ws.EndStrip();
			#endregion

			#region ruangLukisan
			ws.BeginStrip(false,false);
			ws.Add(178,416,103,416,"reversed door");
			ws.AddTo(0,416);
			ws.AddTo(-103,318);
			ws.AddTo(-103,37);
			ws.AddTo(-103,-37,"passage");
			ws.EndStrip();
			#endregion

			#region luar			
			ws.BeginStrip(false,false);
			ws.Add(-103,-37,-103,-288);
			ws.EndStrip();

			ws.BeginStrip(false,false);
			ws.Add(-103,-125,-314,-125);
			ws.AddTo(-230,162);
			ws.AddTo(-103,162);
			ws.EndStrip();

			
			//6 kamar tengah
			ws.BeginStrip(false,true);
			ws.Add(-314,-125,-314,-215);
			ws.AddTo(-268,-215);
			ws.EndStrip();
			
			//5
			ws.BeginStrip(false,false);
			ws.Add(-314,-215,-314,-480,"glass woden");
			ws.EndStrip();
			
			//4
			ws.BeginStrip(false,true);
			ws.Add(-314,-480,-314,-640);
			ws.AddTo(126,-640); 
			ws.EndStrip();
			
			//3 ruang tunggu
			ws.BeginStrip(false,true);
			ws.Add(10,-640,491.5,-640,"glass woden");
			ws.AddTo(491.5,-325,"woden glass woden");
			ws.AddTo(71,-325);
			ws.EndStrip();
			ws.BeginStrip(false,false);
			ws.Add(88,-325,88,-230,"door");
			ws.EndStrip();
			ws.BeginStrip(false,false);
			ws.EndStrip();

			//2
			ws.BeginStrip(false,true);
			ws.Add(491.5,-325,491.5,-10,"woden glass woden");
			ws.AddTo(10,-5);
			ws.AddTo(10,-230);
			ws.AddTo(126,-230);
			ws.AddTo(126,-5); // Idealmente, esta seria otro tipo de pared, "walk in closet" o algo asi.
			ws.EndStrip();
			#endregion
			
			ws.BeginStrip(false,false);
			ws.EndStrip();
		}
		public override void Split(ArrayList far, ArrayList near) 
		{
			ws.Split(far,near);
			Lantai.Split(far,near);
#if !destechada
			Atap.Split(far,near);
#endif
		}
		public override void Prepare (Avatar posisiCamera) 
		{
			Lantai.Prepare(posisiCamera);
			ws.Prepare(posisiCamera);
			Atap.Prepare(posisiCamera);
		}
		public override void Render() 
		{
			ws.Render();
			Lantai.Render();
			Atap.Render();
		}
		public override void FindTargetsFor(char c, ArrayList result) 
		{
			ws.FindTargetsFor(c,result);
		}
		public override Point3D ColisionNormal(Point3D point, Point3D direction, double radius) 
		{
			Point3D p2 = point+direction;
			if (p2.Norm>this.farDistance)
				return p2.Normalized.Scaled(-p2.Norm+farDistance);
			if (p2.X<x2-radius || p2.X > x1+radius || p2.Z<z2-radius || p2.Z>z1+radius ||
				p2.Y>tinggi+radius) return new Point3D(0,0,0);
			return this.ws.ColisionNormal(point,direction,radius)+this.Atap.ColisionNormal(point,direction,radius);
		}
	}

	class Lantai:GlObject 
	{
		double x1;
		double z1; 
		double x2; 
		double z2;
		double tinggi;
		int textura;
		public Lantai(double x1, double z1, double x2, double z2, double tinggi) 
		{
			this.x1=Math.Min(x1,x2);
			this.x2=Math.Max(x1,x2);
			this.z1=Math.Min(z1,z2);
			this.z2=Math.Max(z1,z2);
			this.tinggi=tinggi;
			textura = GlUtils.Texture("FLOOR");
		}
		
		Point3D camera;
		public override void Prepare (Avatar posisiCamera)
		{
			this.camera=posisiCamera.Origin;
		}
		public override void Render ()
		{
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,textura);
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glTexCoord2d((z2-z1)/100,0);
			Gl.glNormal3dv((camera-(new Point3D(x1,0,z2))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z2);
			Gl.glTexCoord2d((z2-z1)/100,(x2-x1)/100);
			Gl.glNormal3dv((camera-(new Point3D(x2,0,z2))).Normalized.Coords);
			Gl.glVertex3d(x2,0,z2);
			Gl.glTexCoord2d(0,(x2-x1)/100);
			Gl.glNormal3dv((camera-(new Point3D(x2,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x2,0,z1);
			Gl.glTexCoord2d(0,0);
			Gl.glNormal3dv((camera-(new Point3D(x1,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z1);
			Gl.glEnd();
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);

			Gl.glBegin(Gl.GL_QUAD_STRIP);
			Gl.glColor3d(.5,.5,.5);
			Gl.glNormal3dv((camera-(new Point3D(x1,-tinggi,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,-tinggi,z1);
			Gl.glNormal3dv((camera-(new Point3D(x1,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z1);

			Gl.glNormal3dv((camera-(new Point3D(x2,-tinggi,z1))).Normalized.Coords);
			Gl.glVertex3d(x2,-tinggi,z1);
			Gl.glNormal3dv((camera-(new Point3D(x2,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x2,0,z1);

			Gl.glNormal3dv((camera-(new Point3D(x2,-tinggi,z2))).Normalized.Coords);
			Gl.glVertex3d(x2,-tinggi,z2);
			Gl.glNormal3dv((camera-(new Point3D(x2,0,z2))).Normalized.Coords);
			Gl.glVertex3d(x2,0,z2);

			Gl.glNormal3dv((camera-(new Point3D(x1,-tinggi,z2))).Normalized.Coords);
			Gl.glVertex3d(x1,-tinggi,z2);
			Gl.glNormal3dv((camera-(new Point3D(x1,0,z2))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z2);

			Gl.glNormal3dv((camera-(new Point3D(x1,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,-tinggi,z1);
			Gl.glNormal3dv((camera-(new Point3D(x1,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z1);

			Gl.glEnd();
		}

	}


	class Atap:GlObject 
	{
		double x1;
		double z1; 
		double x2; 
		double z2;
		double tinggi;
		int texturaIn;
		int texturaOut;
		double bawah;
		public Atap(double x1, double z1, double x2, double z2, double tinggi,double bawah) 
		{
			this.x1=Math.Min(x1,x2);
			this.x2=Math.Max(x1,x2);
			this.z1=Math.Min(z1,z2);
			this.z2=Math.Max(z1,z2);
			this.tinggi=tinggi;
			this.bawah=bawah;
			texturaIn = GlUtils.Texture("ROOFIN");
			texturaOut = GlUtils.Texture("ROOFOUT");
		}
		
		Point3D camera;
		bool pintaArriba=true;
		bool pintaAbajo=true;
		public override void Prepare (Avatar posisiCamera)
		{
			this.camera=posisiCamera.Origin;
			pintaAbajo = camera.Y<bawah+tinggi/2;
			pintaArriba = camera.Y>bawah+tinggi/2;
		}
		public override void Render ()
		{
			if (pintaAbajo) 
			{

			#region Atapabajo
				Gl.glBindTexture(Gl.GL_TEXTURE_2D,texturaIn);
				Gl.glBegin(Gl.GL_QUADS);
				Gl.glTexCoord2d(0,0);
				Gl.glNormal3dv((camera-(new Point3D(x1,bawah,z1))).Normalized.Coords);
				Gl.glVertex3d(x1,bawah,z1);
				Gl.glTexCoord2d(0,(x2-x1)/100);
				Gl.glNormal3dv((camera-(new Point3D(x2,bawah,z1))).Normalized.Coords);
				Gl.glVertex3d(x2,bawah,z1);		
				Gl.glTexCoord2d((z2-z1)/100,(x2-x1)/100);
				Gl.glNormal3dv((camera-(new Point3D(x2,bawah,z2))).Normalized.Coords);
				Gl.glVertex3d(x2,bawah,z2);			
				Gl.glTexCoord2d((z2-z1)/100,0);
				Gl.glNormal3dv((camera-(new Point3D(x1,bawah,z2))).Normalized.Coords);
				Gl.glVertex3d(x1,bawah,z2);			
				Gl.glEnd();
				Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);
			#endregion
			}

			#region Ataplados
			Gl.glBegin(Gl.GL_QUAD_STRIP);
			Gl.glNormal3dv((camera-(new Point3D(x1,bawah,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,bawah,z1);
			Gl.glNormal3dv((camera-(new Point3D(x1,bawah+tinggi,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,bawah+tinggi,z1);

			Gl.glNormal3dv((camera-(new Point3D(x2,bawah,z1))).Normalized.Coords);
			Gl.glVertex3d(x2,bawah,z1);
			Gl.glNormal3dv((camera-(new Point3D(x2,bawah+tinggi,z1))).Normalized.Coords);
			Gl.glVertex3d(x2,bawah+tinggi,z1);

			Gl.glNormal3dv((camera-(new Point3D(x2,bawah,z2))).Normalized.Coords);
			Gl.glVertex3d(x2,bawah,z2);
			Gl.glNormal3dv((camera-(new Point3D(x2,bawah+tinggi,z2))).Normalized.Coords);
			Gl.glVertex3d(x2,bawah+tinggi,z2);

			Gl.glNormal3dv((camera-(new Point3D(x1,bawah,z2))).Normalized.Coords);
			Gl.glVertex3d(x1,bawah,z2);
			Gl.glNormal3dv((camera-(new Point3D(x1,bawah+tinggi,z2))).Normalized.Coords);
			Gl.glVertex3d(x1,bawah+tinggi,z2);

			Gl.glNormal3dv((camera-(new Point3D(x1,bawah,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,bawah,z1);
			Gl.glNormal3dv((camera-(new Point3D(x1,bawah,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,bawah+tinggi,z1);

			Gl.glEnd();
			#endregion
			if (pintaArriba) 
			{
			#region Ataparriba
				Gl.glBindTexture(Gl.GL_TEXTURE_2D,texturaOut);
				Gl.glBegin(Gl.GL_QUADS);
				Gl.glTexCoord2d((z2-z1)/100,0);
				Gl.glNormal3dv((camera-(new Point3D(x1,bawah+tinggi,z2))).Normalized.Coords);
				Gl.glVertex3d(x1,bawah+tinggi,z2);
				Gl.glTexCoord2d((z2-z1)/100,(x2-x1)/100);
				Gl.glNormal3dv((camera-(new Point3D(x2,bawah+tinggi,z2))).Normalized.Coords);
				Gl.glVertex3d(x2,bawah+tinggi,z2);
				Gl.glTexCoord2d(0,(x2-x1)/100);
				Gl.glNormal3dv((camera-(new Point3D(x2,bawah+tinggi,z1))).Normalized.Coords);
				Gl.glVertex3d(x2,bawah+tinggi,z1);
				Gl.glTexCoord2d(0,0);
				Gl.glNormal3dv((camera-(new Point3D(x1,bawah+tinggi,z1))).Normalized.Coords);
				Gl.glVertex3d(x1,bawah+tinggi,z1);
				Gl.glEnd();
				Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);
			#endregion
			}
		}
		public override Point3D ColisionNormal(Point3D point, Point3D arah, double radius) 
		{
			Point3D pos=point+arah;
			if (pos.X<x1-radius || pos.X>x2+radius) return new Point3D(0,0,0);
			if (pos.Z<z1-radius || pos.Z>z2+radius) return new Point3D(0,0,0);
			if ((pos.Y<this.bawah-radius && point.Y<this.bawah-radius) || 
				(pos.Y>this.bawah+radius && point.Y>this.bawah+radius)) return new Point3D(0,0,0);
			if (arah.Y>0 && point.Y<bawah)
				return new Point3D(0,-pos.Y+bawah-radius,0);
			if (arah.Y<0 && point.Y>bawah) 
				return new Point3D(0,bawah+radius-pos.Y,0);
			return new Point3D(0,0,0);
		}
	}
}
