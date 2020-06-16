using System;
using System.Runtime.Remoting.Messaging;
using Tao.OpenGl;

namespace TareaGL
{
	public class Painting : Template
	{
		public static int ctr = 0;

		public Painting(Point3D center,double angle):base(center,angle)
		{
			yInc = 35;
			ctr++;
			//Console.WriteLine("ctr:"+ctr);
		}

		public Painting(Point3D center):this(center,0){}

		protected override void Particular(){
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("frame2"));
			if(ctr<4){
				GlUtils.GambarBangunUnstretched(40,35,1);
			}else{
				GlUtils.GambarBangunUnstretched(35,50,1);
			}
			Gl.glPushMatrix();
			Gl.glTranslated(0,-2,-30);
			Gl.glTranslated(0,2,35);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("paint"+ctr));			
		
			if(ctr<4){
				GlUtils.GambarBangunUnstretched(30,25,0.01);
			}else{
				GlUtils.GambarBangunUnstretched(25,45,0.01);
			}
			Gl.glPopMatrix();
		}
	}
}
