using System;
using System.Collections;
using Tao.OpenGl;

namespace TareaGL
{
	public class WallStrip : GlObject
	{
		protected GlObjectList walls = new GlObjectList(); 
		protected double bottom;
		protected double height;
		public WallStrip(double bottom, double height)
		{
			this.bottom=bottom;
			this.height=height;
		}


		public void AddTo (double x, double z, string type,bool invert) 
		{
			if (!stripping) throw new InvalidOperationException("Can't add wall: strip belum mulai.");
			if (!this.stripStarted) throw new InvalidOperationException("Can't add wall: butuh tembok untuk memulai strip");
			Wall last = this.last;
			Wall next;
			if (! invert )
				next = WallBuilder.BuildWall(last.To,new Point3D(x,0,z),bottom,height,type);
			else 
				next = new InvertedWall(WallBuilder.BuildWall(new Point3D(x,0,z),last.To,bottom,height,type));
			this.walls.Add(next);
			last.after=next.To;
			next.before=last.From;
			this.last=next;
			this.closewall();
		}

		public void AddTo (double x, double z, string type) 
		{
			this.AddTo(x,z,type,false);
		}


		public void Add (double fx, double fz, double tx, double tz, string type) 
		{
			if (!stripping) throw new InvalidOperationException("Can't add wall: strip belum dimulai");
			last = WallBuilder.BuildWall(new Point3D(fx,0,fz),new Point3D(tx,0,tz),bottom,height,type);
			walls.Add(last);
			this.closewall();
			if (!this.stripStarted) 
			{
				last.CloseFrom(this.stripCloseStart);
				this.stripStarted=true;
			}
		}
		protected void closewall() 
		{
			last.CloseFrom(this.closeFrom);
			last.CloseTo(this.closeTo);
		}
		
		protected Wall last=null;
		public void Add (Wall w)
		{
			if (!stripping) throw new InvalidOperationException("Can't add wall: strip belum dimulai");
			last=w;
			walls.Add(w);
			this.closewall();
		}

		public void AddTo (double x, double z) { this.AddTo(x,z,"solid");}
		public void Add (double fx, double fz, double tx, double tz) { this.Add(fx,fz,tx,tz,"solid");}

		public override void Split(ArrayList far, ArrayList near) 
		{
			this.walls.Split(far,near);
		}		
		public override void Prepare (Avatar observer) 
		{
			foreach (Wall w in walls)
				w.Prepare(observer);
		}
		public override void Render() 
		{
			foreach (Wall w in walls)
				w.Render();
		}
		


		protected bool stripStarted=false;
		protected bool stripCloseEnd=true;
		protected bool stripCloseStart=true;
		protected bool stripping = false;

		public virtual void BeginStrip(bool closeFrom, bool closeTo) 
		{
			if (stripping) throw new InvalidOperationException("WallStrip sudah dimulai");
			this.stripCloseStart=closeFrom;
			this.stripCloseEnd=closeTo;
			this.stripStarted=false;
			this.stripping=true;
		}

		public virtual void EndStrip() 
		{
			if (!stripping) throw new InvalidOperationException("WallStrip sudah berhenti");
			last.CloseTo(this.stripCloseEnd);
			this.stripping=false;
		}

		protected bool closeTo = true;
		protected bool closeFrom = true;
		public void CloseFrom(bool close) 
		{
			this.closeFrom=close;
		}
		public void CloseTo ( bool close) 
		{
			this.closeTo=close;
		}

		public override void FindTargetsFor(char c, ArrayList result) 
		{
			this.walls.FindTargetsFor(c,result);
		}	

		public override Point3D ColisionNormal(Point3D point, Point3D direction, double radius) 
		{
			return this.walls.ColisionNormal(point,direction,radius);
		}
	}
}
