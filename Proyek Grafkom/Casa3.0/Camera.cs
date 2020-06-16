using System;
using Tao.OpenGl;

using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.Drawing.Drawing2D;

namespace TareaGL
{
	
	public class Camera 
	{
		public Point3D Origin {get {return origin;}}
		public Point3D Direction {get {return direction;}}
		public Point3D Up {get {return up;}}
		public Point3D origin;
		protected Point3D center 
		{
			get 
			{
				return origin+direction;
			}
			set 
			{
				direction=value-origin;
			}
		}
		protected Point3D up; 
		protected Point3D direction; 
		protected Point3D right 
		{
			get {return direction.CrossProduct(up).Normalized;}
			set {up=value.CrossProduct(direction).Normalized; }
		}

		public Camera (Point3D origin, Point3D center, Point3D up)
		{
			this.origin=origin;
			this.center=center;
			this.up=up;
		}
		public void Look() 
		{
			Glu.gluLookAt(origin.X,origin.Y,origin.Z,center.X,center.Y,center.Z,up.X,up.Y,up.Z);

		}

		public void Translate(Point3D direction) 
		{
			this.origin.Translate(direction);
			this.center.Translate(direction);
		}
        	
		public void MoveTo(Point3D location) 
		{
			Translate(location-origin);
		}
		public void Frame(Point3D direction) 
		{
			this.Translate(FrameDir(direction));
		}
		public Point3D FrameDir(Point3D direction) 
		{
			Point3D Xvector = right.Normalized;
			Point3D Yvector = up.Normalized;
			Point3D Zvector = this.direction.Normalized;
			return Xvector.Scaled(direction.X)+Yvector.Scaled(direction.Y)+Zvector.Scaled(direction.Z);
		}
		public void Pan(double angleY, double angleZ) 
		{
			Point3D upt = new Point3D(0,1,0);
			Point3D dir=direction.Rotated(angleY,upt);
			right=right.Rotated(angleY,upt).Normalized;
			direction=dir.Rotated(angleZ,this.right).Normalized;
		}
	}
}
