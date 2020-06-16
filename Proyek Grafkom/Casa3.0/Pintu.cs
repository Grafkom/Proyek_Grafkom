//#define showCenterPoint
using System;
using Tao.OpenGl;
using System.Collections;

namespace TareaGL
{
	public class Pintu : GlObject, InteractiveObject
	{
		protected int idPintu = -1;
		protected static int textureIndex=-1;
		public double Apertura = 0;
		public bool SoloMarco=false;
		public bool IsOpened 
		{
			get 
			{
				return SoloMarco || this.aperturaActual==this.Apertura && this.Apertura>0; 
			}
		}
		public Pintu():this(new Point3D(0,0,0),0)
		{
		}
		protected Point3D position;
		protected double angle;
		protected int texturaBisagra;
		protected int texturaPuerta;
		protected int texturaKnob;
		protected bool rev = true;
		public bool reversed 
		{
			get 
			{
				return rev;
			}
			set 
			{
				rev=value;
				Gl.glNewList(idPintu,Gl.GL_COMPILE);
				this.pintaPuerta();
				Gl.glEndList();
			}
		}
		public Pintu(Point3D position, double angle)
		{
			textureIndex=GlUtils.Texture("ROSEGOLD");
			texturaBisagra=GlUtils.Texture("BISAGRA");
			texturaPuerta=GlUtils.Texture("PUERTA");
			texturaKnob=GlUtils.Texture("ROSEGOLD");
			this.position=position;
			this.angle=angle;
			if (idPintu==-1) 
			{
				idPintu=Gl.glGenLists(2);
				Gl.glNewList(idPintu,Gl.GL_COMPILE);
				this.pintaPuerta();
				Gl.glEndList();
				Gl.glNewList(idPintu+1,Gl.GL_COMPILE);
				this.pintaBisagra();
				Gl.glEndList();
			}
		}

		public Point3D Location { get {return position;} set {position=value;}}
		public double Angle {get { return angle;} set {angle=value;}}
		protected bool far = false;
		public override void Prepare (Avatar observer) 
		{
			double elapsed = observer.CurrentTime.Subtract(this.inicio).TotalSeconds;
			if (this.opening && this.aperturaActual!=this.Apertura)
				this.aperturaActual=Math.Min(this.Apertura,this.velocidad*elapsed);
			if (this.closing && this.aperturaActual!=0)
				this.aperturaActual=Math.Max(0,this.Apertura-this.velocidad*elapsed);
			far = this.DistanceTo(observer.Origin)>500;
		}
		protected double width=74;
		protected double height=200;
		protected double deep=10;
		protected double border=4;
		public double Height { get { return height;} }
		public double Width { 
			get { return width;}
			set 
			{
				width=value;
			}
		}
		public override void Render () 
		{

			Gl.glPushMatrix();
			Gl.glTranslated(position.X,position.Y,position.Z);
			Gl.glRotated(angle,0,-1,0);

			Gl.glPushMatrix();
			Gl.glTranslated(width/2,height/2,0);
			Gl.glPopMatrix();
			if (!SoloMarco) 
			{
				Gl.glPushMatrix();
				if (!reversed)
					Gl.glTranslated(border+.5,0,-deep/2+.5);
				else 
					Gl.glTranslated(border+.5,0,deep/2-.5);
				Gl.glCallList(this.idPintu+1);
				Gl.glPushMatrix();
				Gl.glColor3d(1,1,1);
				Gl.glRotated(reversed?-this.aperturaActual:this.aperturaActual,0,1,0);
				Gl.glCallList(idPintu);
				Gl.glPopMatrix();
				Gl.glPopMatrix();
			}
			Gl.glPopMatrix();
			//Gl.glDisable(Gl.GL_CULL_FACE);
		}
		protected void pintaBisagra() 
		{

		}
		protected void pintaPuerta() 
		{

		}
		protected void pintaCaja(double x, double y, double z) 
		{
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,this.texturaPuerta);
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glNormal3d(0,0,1);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,y,z);
			Gl.glTexCoord2d(0,y*2/100);
			Gl.glVertex3d(-x,-y,z);
			Gl.glTexCoord2d(x*2/100,y*2/100);
			Gl.glVertex3d(x,-y,z);
			Gl.glTexCoord2d(x*2/100,0);
			Gl.glVertex3d(x,y,z);

			Gl.glNormal3d(1,0,0);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(x,y,z);
			Gl.glTexCoord2d(0,y*2/100);	
			Gl.glVertex3d(x,-y,z);
			Gl.glTexCoord2d(z*2/100,y*2/100);
			Gl.glVertex3d(x,-y,-z);
			Gl.glTexCoord2d(z*2/100,0);
			Gl.glVertex3d(x,y,-z);

			Gl.glNormal3d(0,0,-1);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(x,y,-z);
			Gl.glTexCoord2d(0,y*2/100);
			Gl.glVertex3d(x,-y,-z);
			Gl.glTexCoord2d(x*2/100,y*2/100);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(x*2/100,0);
			Gl.glVertex3d(-x,y,-z);

			Gl.glNormal3d(-1,0,0);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,y,-z);
			Gl.glTexCoord2d(0,y*2/100);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(z*2/100,y*2/100);
			Gl.glVertex3d(-x,-y,z);
			Gl.glTexCoord2d(z*2/100,0);
			Gl.glVertex3d(-x,y,z);

			Gl.glNormal3d(0,1,0);
			Gl.glVertex3d(-x,y,z);
			Gl.glVertex3d(x,y,z);
			Gl.glVertex3d(x,y,-z);
			Gl.glVertex3d(-x,y,-z);
			Gl.glEnd();
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,this.texturaPuerta);
		}
		protected void doorKnob() 
		{
			int cullFace;
			Gl.glGetBooleanv(Gl.GL_CULL_FACE,out cullFace);
			Gl.glDisable(Gl.GL_CULL_FACE);

			Glu.GLUquadric q = Glu.gluNewQuadric();
			Gl.glColor3d(1,1,0);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,this.texturaKnob);
			Glu.gluQuadricTexture(q,Gl.GL_TRUE);
			Glu.gluQuadricNormals(q,Gl.GL_SMOOTH);
			Gl.glPushMatrix();
			Glu.gluCylinder(q,5,1,1,15,3);
			Glu.gluCylinder(q,1,1,4,10,1);
			Gl.glPushMatrix();
			Gl.glTranslated(0,0,5);
			Gl.glScaled(1,1,.5);
			Glu.gluSphere(q,4,10,10);
			Gl.glPopMatrix();
			Gl.glPopMatrix();
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);
			Glu.gluDeleteQuadric(q);

			if (cullFace!=Gl.GL_FALSE) 
				Gl.glEnable(Gl.GL_CULL_FACE); 
		}

		public double DistanceTo(Point3D other) 
		{
			return (other - position - (new Point3D(width*Math.Cos(Angle*Math.PI/180),height,width*Math.Sin(Angle*Math.PI/180))).Scaled(.5)).Norm;
		}
		public bool HasActionFor(char c) 
		{
			return (c==' ' && !this.SoloMarco);
		}

		protected DateTime inicio;
		protected double aperturaActual;
		protected double velocidad=60;
		protected bool opening=false;
		protected bool closing=false;

		public void Act (char c) 
		{
			double elapsed = DateTime.Now.Subtract(this.inicio).TotalSeconds;
			if (elapsed < this.Apertura/velocidad) return;
			if (HasActionFor(c) && this.Apertura!=0) 
			{
				this.inicio=DateTime.Now;
				if (this.aperturaActual==this.aperturaActual)
				{
					closing=true;
					opening=false;
				}
				if (this.aperturaActual==0)
				{
					closing=false;
					opening=true;
				}
			}
			if (HasActionFor(c) && this.Apertura==0) 
			{
				GlUtils.Beep();
			}
		}
		public override void FindTargetsFor(char c, ArrayList result) 
		{
			if (this.HasActionFor(c))
				result.Add(this);
		}
	}
}
