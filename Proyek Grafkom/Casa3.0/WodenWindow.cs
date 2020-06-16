//#define drawCenter
using System;
using Tao.OpenGl;

namespace TareaGL
{
	public class WodenWindow:Window,InteractiveObject
	{
		protected static int id = -1;
		protected static int textureIndex=-1;
		protected double minAngle = 12;
		protected double maxAngle = 80;
		protected double pangle=12;
		protected static int idPersiana = -1;
		protected static int idMarco = -1;
		protected double xscale=.8;
		protected double yscale=.8;
		public WodenWindow()
		{
			pangle=minAngle;
			if (idPersiana < 0 )
			{
				textureIndex = GlUtils.Texture("WOOD1");
				idPersiana = Gl.glGenLists(1);
				Gl.glNewList(idPersiana,Gl.GL_COMPILE);
				pintaPersiana();
				Gl.glEndList();

				idMarco = Gl.glGenLists(1);
				Gl.glNewList(idMarco,Gl.GL_COMPILE);
				pintaMarco();
				Gl.glEndList();
			}
		}

		protected void pintaPersiana() 
		{
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,textureIndex);
			GlUtils.PintaOrtoedro(45,10,2,true);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);

		}
		
		protected void pintaMarco() 
		{
			Gl.glColor3d(0.8,0.8,0.8);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,textureIndex);
			Gl.glBegin(Gl.GL_QUAD_STRIP);
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(0,1);Gl.glVertex3d(-0.5*100,0.75*100,0.05*100);
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(0,0);Gl.glVertex3d(-0.5*100,-0.75*100,0.05*100);

			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(0.25,1);Gl.glVertex3d(-0.45*100,0.75*100,0.05*100);
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(0.25,0);Gl.glVertex3d(-0.45*100,-0.75*100,0.05*100);

			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0.5,1);Gl.glVertex3d(-0.45*100,0.75*100,-0.05*100);
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0.5,0);Gl.glVertex3d(-0.45*100,-0.75*100,-0.05*100);

			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(1,1);Gl.glVertex3d(-0.5*100,0.75*100,-0.05*100);
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(1,0);Gl.glVertex3d(-0.5*100,-0.75*100,-0.05*100);
			Gl.glEnd();

			Gl.glBegin(Gl.GL_QUAD_STRIP);
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0,1);Gl.glVertex3d(0.5*100,0.75*100,-0.05*100);
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0,0);Gl.glVertex3d(0.5*100,-0.75*100,-0.05*100);
				
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0.25,1);Gl.glVertex3d(0.45*100,0.75*100,-0.05*100);
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0.25,0);Gl.glVertex3d(0.45*100,-0.75*100,-0.05*100);
				
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(0.5,1);Gl.glVertex3d(0.45*100,0.75*100,0.05*100);
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(0.5,0);Gl.glVertex3d(0.45*100,-0.75*100,0.05*100);
				
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(1,1);Gl.glVertex3d(0.5*100,0.75*100,0.05*100);
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(1,0);Gl.glVertex3d(0.5*100,-0.75*100,0.05*100);
			Gl.glEnd();

			Gl.glBegin(Gl.GL_QUAD_STRIP);
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0,1);Gl.glVertex3d(0.45*100,-0.75*100,-0.05*100);
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0,0);Gl.glVertex3d(-0.45*100,-0.75*100,-0.05*100);
				
			Gl.glNormal3d(0,0.7,-0.7);Gl.glTexCoord2d(0.25,1);Gl.glVertex3d(0.45*100,-0.70*100,-0.05*100);
			Gl.glNormal3d(0,0.7,-0.7);Gl.glTexCoord2d(0.25,0);Gl.glVertex3d(-0.45*100,-0.70*100,-0.05*100);
				
			Gl.glNormal3d(0,0.7,0.7);Gl.glTexCoord2d(0.5,1);Gl.glVertex3d(0.45*100,-0.70*100,0.05*100);
			Gl.glNormal3d(0,0.7,0.7);Gl.glTexCoord2d(0.5,0);Gl.glVertex3d(-0.45*100,-0.70*100,0.05*100);
				
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(1,1);Gl.glVertex3d(0.45*100,-0.75*100,0.05*100);
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(1,0);Gl.glVertex3d(-0.45*100,-0.75*100,0.05*100);
			Gl.glEnd();

			Gl.glBegin(Gl.GL_QUAD_STRIP);
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0,0);Gl.glVertex3d(-0.45*100,0.75*100,-0.05*100);
			Gl.glNormal3d(0,0,-1);Gl.glTexCoord2d(0,1);Gl.glVertex3d(0.45*100,0.75*100,-0.05*100);
				
			Gl.glNormal3d(0,-0.7,-0.7);Gl.glTexCoord2d(0.25,0);Gl.glVertex3d(-0.45*100,0.70*100,-0.05*100);
			Gl.glNormal3d(0,-0.7,-0.7);Gl.glTexCoord2d(0.25,1);Gl.glVertex3d(0.45*100,0.70*100,-0.05*100);
				
			Gl.glNormal3d(0,-0.7,0.7);Gl.glTexCoord2d(0.5,0);Gl.glVertex3d(-0.45*100,0.70*100,0.05*100);
			Gl.glNormal3d(0,-0.7,0.7);Gl.glTexCoord2d(0.5,1);Gl.glVertex3d(0.45*100,0.70*100,0.05*100);
				
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(1,0);Gl.glVertex3d(-0.45*100,0.75*100,0.05*100);
			Gl.glNormal3d(0,0,1);Gl.glTexCoord2d(1,1);Gl.glVertex3d(0.45*100,0.75*100,0.05*100);
			Gl.glEnd();
		}
		#region Width and Height
		public override double Width 
		{
			get { return 98*xscale; }
		}
		public override double Height 
		{
			get { return 75*2*yscale; }
		}
		#endregion
		protected void renderWindow() 
		{
			Gl.glColor3d(0.95,0.95,0.95);
			int id = Gl.glGenLists(1);
			Gl.glNewList(id,Gl.GL_COMPILE);
#region Haciendo una persiana
			Gl.glPushMatrix();
			Gl.glRotated(pangle, 1, 0, 0);
			Gl.glCallList(idPersiana);
			Gl.glPopMatrix();
			Gl.glEndList();
#endregion
			Gl.glEndList();

			Gl.glCallList(idMarco);

			Gl.glPushMatrix();
			Gl.glTranslated(0,0.2*100,0);
			Gl.glCallList(id);
			Gl.glTranslated(0,0.2*100, 0);
			Gl.glCallList(id);
			Gl.glTranslated(0,0.2*100, 0);
			Gl.glCallList(id);
			Gl.glTranslated(0,-0.6*100,0);
			Gl.glCallList(id);
			Gl.glTranslated(0,-0.2*100, 0);
			Gl.glCallList(id);
			Gl.glTranslated(0,-0.2*100, 0);
			Gl.glCallList(id);
			Gl.glTranslated(0,-0.2*100, 0);
			Gl.glCallList(id);
			Gl.glPopMatrix();
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
			Gl.glDeleteLists(id,1);
		}

		#region Prepare and Render
		public override void Prepare (Avatar observer) 
		{
		}
		public override void Render () 
		{
			Gl.glPushMatrix();
			Gl.glTranslated(start.X,start.Y,start.Z);
			Gl.glRotated(angle,0,-1,0);
			Gl.glTranslated(Width/2,Height/2,0);
			Gl.glScaled(xscale,yscale,1);
			this.renderWindow();
			Gl.glPopMatrix();
		}
		#endregion
		public double DistanceTo(Point3D other) 
		{
			return (other - this.start - (new Point3D(this.Width*Math.Cos(Angle*Math.PI/180),Height,Width*Math.Sin(Angle*Math.PI/180))).Scaled(.5)).Norm;
		}
		public bool HasActionFor(char c) 
		{
			return (c=='a'||c=='z');
		}
		protected double angleInc=5;
		public void Act(char c) 
		{
			if (c=='z' && this.pangle<this.maxAngle)
				this.pangle=Math.Min(pangle+angleInc,maxAngle);
			else if (c=='a' && this.pangle>this.minAngle)
				this.pangle=Math.Max(pangle-angleInc,minAngle);
		}
	}
}

