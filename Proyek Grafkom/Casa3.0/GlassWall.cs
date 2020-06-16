using System;
using Tao.OpenGl;
using System.Collections;

namespace TareaGL
{
	public class GlassWall:Wall, MetricObject
	{
		protected int divTexture;
		protected double glasshStep=50;
		protected double glassvStep=50;
		protected SolidWall muro;
		protected double baseHeight;
		protected int cristalId;
		public GlassWall(Point3D from, Point3D to, double bottom, double height):base(from, to, bottom, height)
		{
			divTexture = GlUtils.Texture("WOOD1");
			double len = (to-from).Norm;
			this.glasshStep = len/Math.Floor(len/glasshStep);
			baseHeight= height - glassvStep*Math.Floor(height/glassvStep);
			if (baseHeight < glassvStep) 
				baseHeight+=glassvStep;
			muro = new SolidWall(from,to,bottom,baseHeight);
			muro.CloseUp(true);
			cristalId = Gl.glGenLists(1);
			Gl.glNewList(cristalId,Gl.GL_COMPILE);
			pintaCristal();
			Gl.glEndList();
		}
		public override void Prepare (Avatar observer) 
		{
			muro.Prepare(observer);
			radius = Math.Ceiling(this.DistanceTo(observer.Origin)/700);
		}
		double radius = 1;
		public override void Render () 
		{
//			Gl.glColor3d(1,1,1);
			muro.Render();
			//pintaCristal();
			Gl.glCallList(this.cristalId);
		}
		protected void pintaCristal() 
		{
			Glu.GLUquadric q = Glu.gluNewQuadric();
			Point3D actual = new Point3D(from);
			Point3D dir = (to-from);
			double len = dir.Norm;
			dir = dir.Normalized;
			
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,divTexture);
			Glu.gluQuadricTexture(q,Gl.GL_TRUE);
			Gl.glColor3d(1,1,1);
			Glu.gluDeleteQuadric(q);
			
			int cullFace=0;
			Gl.glGetBooleanv(Gl.GL_CULL_FACE,out cullFace);
			Gl.glDisable(Gl.GL_CULL_FACE);
			if (cullFace!=Gl.GL_FALSE) 
				Gl.glEnable(Gl.GL_CULL_FACE);  
		}
		public override Point3D after { set {muro.after=value;}}
		public override Point3D before { set {muro.before=value;}}
		public override void Split(ArrayList far, ArrayList near)
		{
			near.Add(this);
		}
		public double DistanceTo(Point3D other) 
		{
			return (other-(to-from).Scaled(.5)-from).Norm;
		}
		public override void CloseTo(bool close) 
		{
			base.CloseTo(close);
			muro.CloseTo(close);
		}
		public override void CloseFrom(bool close) 
		{
			base.CloseFrom(close);
			muro.CloseFrom(close);
		}
	}
}
