using System;
using Tao.OpenGl;

namespace TareaGL
{
	public abstract class Wall : GlObject
	{
		public double Deep=1;
		protected double width;
		protected const int baseDeep=5;
		protected Point3D endSideNormal;
		protected Point3D frontSideNormal;

		public Wall(Point3D from, Point3D to, double bottom, double height)
		{
			this.from=from;
			this.to=to;
			this.frontSideNormal = this.planeRot(to-from,90).Normalized;
			this.endSideNormal = (to-from).Normalized;
			this.dirFrom = frontSideNormal;
			this.dirTo=this.dirFrom;
			this.bottom=bottom;
			this.height=height;
			this.width=(to-from).Norm;
			//this.calcPoints();
		}

		protected bool closeFrom = true;
		protected bool closeTo = true;

		protected Point3D planeRot(Point3D v, double angle) 
		{
			double ro = v.Norm;
			double senAlpha= Math.Sin(angle*Math.PI/180);
			double cosAlpha= Math.Cos(angle*Math.PI/180);
			double senSita = v.Z/ro;
			double cosSita = v.X/ro;
			return new Point3D(ro*(cosSita*cosAlpha-senSita*senAlpha),0,ro*(senSita*cosAlpha+cosSita*senAlpha));
		}

		protected Point3D from;
		protected Point3D to;
		public Point3D To { get {return to;}}
		public Point3D From { get {return from;}}
		protected double bottom;
		protected double height;
		public double Bottom { get {return bottom;}}
		public double Height { get {return height+600;}}
		public abstract Point3D before	{set;}
		public abstract Point3D after {set;}
		public virtual void CloseFrom(bool close){this.closeFrom=close;} 
		public virtual void CloseTo(bool close){closeTo=close;} 


		protected Point3D dirFrom;
		protected Point3D dirTo;

		public override Point3D Colisionrulel(Point3D point, Point3D direccion, double radius) 
		{
			Point3D point2 = point+direccion;
			if (point2.Y<this.bottom || point2.Y>this.bottom+this.height)
				return new Point3D(0,0,0); 
			point2 = new Point3D(point2.X,0,point2.Z);
			if (((to-from).Norm<radius/2)) 
				return new Point3D(0,0,0);
			if ((point2-(to-from).Scaled(.5)-from).Norm>(width+radius)/2) 
				return new Point3D(0,0,0);
			Point3D walldir = (to-from).Normalized;
			Point3D exto = to+walldir.Scaled(1.1);
			Point3D exfrom = from-walldir.Scaled(1.1);
			Point3D pos = (point2-exfrom).Normalized;
			double d=0;

			
			Point3D referencia;
			if ((from-point2).Norm>(to-point2).Norm)
				referencia=from;
			else
				referencia=to;

			Point3D pr = (to-from).CrossProduct(new Point3D(0,1,0)).Normalized;
			double d1 = this.distancePointRect(point.X,point.Z,from.X,from.Z,to.X,to.Z);
			double d2 = this.distancePointRect(point2.X,point2.Z,from.X,from.Z,to.X,to.Z);
			if (d1*d2<0) 
				return pr.Scaled(-Math.Sign(d2)*radius-d2);
			else 
				if (Math.Abs(d2)<radius)
					return pr.Scaled(Math.Sign(d2)*radius-d2);
			return new Point3D(0,0,0);
		}
		protected double distancePointRect(double x1, double y1, double x2,double y2, double x3, double y3) 
		{
			return (x1*y2-x1*y3-y1*x2+y1*x3+x2*y3-x3*y2)/Math.Sqrt((x2-x3)*(x2-x3)+(y2-y3)*(y2-y3));
		}
	}
}
