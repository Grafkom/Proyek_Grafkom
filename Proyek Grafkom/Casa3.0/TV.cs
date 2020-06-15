using System;
using System.Runtime.Remoting.Messaging;
using Tao.OpenGl;

namespace TareaGL
{
	/// <summary>
	/// Summary description for TV.
	/// </summary>
    /// 
	public class TV : Plantilla
	{
		public static int ctr = 0;

		public TV(Point3D center,double angle):base(center,angle)
		{
			yInc = 35;
			ctr++;
			Console.WriteLine("ctr:"+ctr);
		}

		public TV(Point3D center):this(center,0){}

		protected override void Particular(){
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("frame2"));
			GlUtils.PintaOrtoedroUnstretched(40,35,1);
			Gl.glPushMatrix();
			Gl.glTranslated(0,-2,-30);
			Gl.glTranslated(0,2,35);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, GlUtils.Texture("paint"+ctr));			
		
			GlUtils.PintaOrtoedroUnstretched(30,25,0.3);
			Gl.glPopMatrix();
		}
	}
}
