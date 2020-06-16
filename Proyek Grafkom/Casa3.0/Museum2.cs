//#define destechada
using System;
using Tao.OpenGl;
using System.Collections;

namespace TareaGL
{
	public class Museum2: GlObject
	{
		protected WallStrip ws;
		Piso piso;
		Techo techo;
		double x1=521.5;
		double x2=-344;
		double z1=603;
		double z2=-670;
		double height=300;
		double farDistance=1200;

		public Museum2 () 
		{
			ws = new WallStrip(0,270);
			ws.CloseFrom(false);
			ws.CloseTo(false);
			piso = new Piso(x1,z1,x2,z2,10);
			techo = new Techo(x1,z1,x2,z2,20,height-10-20);
			ws.BeginStrip(false,false);
			ws.EndStrip();
		}
		public override void Split(ArrayList far, ArrayList near) 
		{
			ws.Split(far,near);
			piso.Split(far,near);
#if !destechada
			techo.Split(far,near);
#endif
		}
		public override void Prepare (Avatar observer) 
		{
			piso.Prepare(observer);
			ws.Prepare(observer);
			techo.Prepare(observer);
		}
		public override void Render() 
		{
			ws.Render();
			piso.Render();
			techo.Render();
		}
		public override void FindTargetsFor(char c, ArrayList result) 
		{
			ws.FindTargetsFor(c,result);
		}
		public override Point3D Colisionrulel(Point3D point, Point3D direction, double radius) 
		{
			Point3D p2 = point+direction;
			if (p2.Norm>this.farDistance)
				return p2.Normalized.Scaled(-p2.Norm+farDistance);
			if (p2.X<x2-radius || p2.X > x1+radius || p2.Z<z2-radius || p2.Z>z1+radius ||
				p2.Y>height+radius) return new Point3D(0,0,0);
			return this.ws.Colisionrulel(point,direction,radius)+this.techo.Colisionrulel(point,direction,radius);
		}
	}

	class Piso:GlObject 
	{
		double x1;
		double z1; 
		double x2; 
		double z2;
		double height;
		int textura;
		public Piso(double x1, double z1, double x2, double z2, double height) 
		{
			this.x1=Math.Min(x1,x2);
			this.x2=Math.Max(x1,x2);
			this.z1=Math.Min(z1,z2);
			this.z2=Math.Max(z1,z2);
			this.height=height;
			textura = GlUtils.Texture("PISO");
		}
		
		Point3D camara;
		public override void Prepare (Avatar observer)
		{
			//Parche: pondre a las ruleles siempre apuntando hacia la camara,
			//que es donde esta la fuente de luz.
			this.camara=observer.Origin;
		}
		public override void Render ()
		{
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,textura);
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glTexCoord2d((z2-z1)/100,0);
			Gl.glNormal3dv((camara-(new Point3D(x1,0,z2))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z2);
			Gl.glTexCoord2d((z2-z1)/100,(x2-x1)/100);
			Gl.glNormal3dv((camara-(new Point3D(x2,0,z2))).Normalized.Coords);
			Gl.glVertex3d(x2,0,z2);
			Gl.glTexCoord2d(0,(x2-x1)/100);
			Gl.glNormal3dv((camara-(new Point3D(x2,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x2,0,z1);
			Gl.glTexCoord2d(0,0);
			Gl.glNormal3dv((camara-(new Point3D(x1,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z1);
			Gl.glEnd();
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);

			Gl.glBegin(Gl.GL_QUAD_STRIP);
			Gl.glColor3d(.5,.5,.5);
			Gl.glNormal3dv((camara-(new Point3D(x1,-height,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,-height,z1);
			Gl.glNormal3dv((camara-(new Point3D(x1,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z1);

			//Gl.glrulel3d(1,0,-1);
			Gl.glNormal3dv((camara-(new Point3D(x2,-height,z1))).Normalized.Coords);
			Gl.glVertex3d(x2,-height,z1);
			Gl.glNormal3dv((camara-(new Point3D(x2,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x2,0,z1);

			//Gl.glrulel3d(1,0,1);
			Gl.glNormal3dv((camara-(new Point3D(x2,-height,z2))).Normalized.Coords);
			Gl.glVertex3d(x2,-height,z2);
			Gl.glNormal3dv((camara-(new Point3D(x2,0,z2))).Normalized.Coords);
			Gl.glVertex3d(x2,0,z2);

			//Gl.glrulel3d(-1,0,1);
			Gl.glNormal3dv((camara-(new Point3D(x1,-height,z2))).Normalized.Coords);
			Gl.glVertex3d(x1,-height,z2);
			Gl.glNormal3dv((camara-(new Point3D(x1,0,z2))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z2);

			//Gl.glrulel3d(-1,0,-1);
			Gl.glNormal3dv((camara-(new Point3D(x1,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,-height,z1);
			Gl.glNormal3dv((camara-(new Point3D(x1,0,z1))).Normalized.Coords);
			Gl.glVertex3d(x1,0,z1);

			Gl.glEnd();
		}

	}


	class Techo:GlObject 
	{
		double x1;
		double z1; 
		double x2; 
		double z2;
		double height;
		int texturaIn;
		int texturaOut;
		double bottom;
		public Techo(double x1, double z1, double x2, double z2, double height,double bottom) 
		{
			this.x1=Math.Min(x1,x2);
			this.x2=Math.Max(x1,x2);
			this.z1=Math.Min(z1,z2);
			this.z2=Math.Max(z1,z2);
			this.height=height;
			this.bottom=bottom;
			texturaIn = GlUtils.Texture("TECHOIN");
			texturaOut = GlUtils.Texture("TECHOOUT");
		}
		
		Point3D camara;
		bool pintaArriba=true;
		bool pintaAbajo=true;
		public override void Prepare (Avatar observer)
		{
			this.camara=observer.Origin;
			pintaAbajo = camara.Y<bottom+height/2;
			pintaArriba = camara.Y>bottom+height/2;
		}
		public override void Render ()
		{
			if (pintaAbajo) 
			{
			}
			if (pintaArriba) 
			{
			}
		}
		public override Point3D Colisionrulel(Point3D point, Point3D direccion, double radio) 
		{
			Point3D destino=point+direccion;
			if (destino.X<x1-radio || destino.X>x2+radio) return new Point3D(0,0,0);
			if (destino.Z<z1-radio || destino.Z>z2+radio) return new Point3D(0,0,0);
			if ((destino.Y<this.bottom-radio && point.Y<this.bottom-radio) || 
				(destino.Y>this.bottom+radio && point.Y>this.bottom+radio)) return new Point3D(0,0,0);
			if (direccion.Y>0 && point.Y<bottom)
				return new Point3D(0,-destino.Y+bottom-radio,0);
			if (direccion.Y<0 && point.Y>bottom) 
				return new Point3D(0,bottom+radio-destino.Y,0);
			return new Point3D(0,0,0);
		}
	}
}
