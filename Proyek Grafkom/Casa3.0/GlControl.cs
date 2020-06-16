using System;
using Tao.OpenGl;

namespace TareaGL
{
	public class GlControl
	{
		protected int height;
		protected int width;
		public int Height {get {return height;}}
		public int Width {get {return width;}}
		public GlControl(int Width, int Height)
		{
			this.width=Width;
			this.height=Height;
			Glut.glutInit();
			Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE| Glut.GLUT_RGB|Glut.GLUT_DEPTH);
			Glut.glutInitWindowSize(Width,Height);
			Glut.glutInitWindowPosition(0,0);
			Glut.glutCreateWindow("Tarea OpenGL");
			Init();
		}

		protected void Init() 
		{
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Glu.gluPerspective(90,1,1,8000);
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glDepthFunc(Gl.GL_LEQUAL);
			Gl.glEnable(Gl.GL_TEXTURE_2D);
			Gl.glEnable(Gl.GL_FRONT_AND_BACK);
			Gl.glEnable(Gl.GL_NORMALIZE);
			Gl.glShadeModel(Gl.GL_SMOOTH);
			Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER,1);

			Gl.glEnable(Gl.GL_CULL_FACE);
			Gl.glCullFace(Gl.GL_BACK);

			Gl.glEnable(  Gl.GL_LIGHTING );
			Gl.glEnable(Gl.GL_COLOR_MATERIAL);
			Gl.glBlendFunc(Gl.GL_SRC_ALPHA,Gl.GL_ONE_MINUS_SRC_ALPHA);

		}


	}
}
