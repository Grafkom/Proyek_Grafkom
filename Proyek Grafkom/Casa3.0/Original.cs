using System;
using Tao.OpenGl;

namespace TareaGL
{
	
	public class Original:GlObject
	{
		public Original()
		{
		}
		public override void Render() 
		{
			Gl.glColor3d(1,0,0);
			Glu.GLUquadric q = Glu.gluNewQuadric();
			Glu.gluSphere(q,2,20,20);
		}
	}
}
