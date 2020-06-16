using System;
using Tao.OpenGl;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;

namespace TareaGL
{
	/// <summary>
	/// Summary description for GlUtils.
	/// </summary>
	public class GlUtils
	{

		public static void GambarBangun(double x, double y, double z) 
		{
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
			Gl.glTexCoord2d(x*2/100,0);
			Gl.glVertex3d(x,y,-z);
			Gl.glTexCoord2d(x*2/100,y*2/100);
			Gl.glVertex3d(x,-y,-z);
			Gl.glTexCoord2d(0,y*2/100);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,y,-z);

			Gl.glNormal3d(-1,0,0);
			Gl.glTexCoord2d(0,y*2/100);
			Gl.glVertex3d(-x,y,-z);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(z*2/100,0);
			Gl.glVertex3d(-x,-y,z);
			Gl.glTexCoord2d(z*2/100,y*2/100);
			Gl.glVertex3d(-x,y,z);

			Gl.glNormal3d(0,1,0);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,y,z);
			Gl.glTexCoord2d(x*2/100,0);
			Gl.glVertex3d(x,y,z);
			Gl.glTexCoord2d(x*2/100,z*2/100);
			Gl.glVertex3d(x,y,-z);
			Gl.glTexCoord2d(0,z*2/100);
			Gl.glVertex3d(-x,y,-z);

			Gl.glNormal3d(0,-1,0);
			Gl.glTexCoord2d(0,z*2/100);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(x*2/100,z*2/100);
			Gl.glVertex3d(x,-y,-z);
			Gl.glTexCoord2d(x*2/100,0);
			Gl.glVertex3d(x,-y,z);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,-y,z);
			Gl.glEnd();
		}

		public static void GambarBangunUnstretched(double x, double y, double z) 
		{
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glNormal3d(0,0,1);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,y,z);
			Gl.glTexCoord2d(0,1);
			Gl.glVertex3d(-x,-y,z);
			Gl.glTexCoord2d(1,1);
			Gl.glVertex3d(x,-y,z);
			Gl.glTexCoord2d(1,0);
			Gl.glVertex3d(x,y,z);

			Gl.glNormal3d(1,0,0);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(x,y,z);				
			Gl.glTexCoord2d(0,1);
			Gl.glVertex3d(x,-y,z);
			Gl.glTexCoord2d(1,1);
			Gl.glVertex3d(x,-y,-z);
			Gl.glTexCoord2d(1,0);
			Gl.glVertex3d(x,y,-z);

			Gl.glNormal3d(0,0,-1);
			Gl.glTexCoord2d(1,0);
			Gl.glVertex3d(x,y,-z);
			Gl.glTexCoord2d(1,1);
			Gl.glVertex3d(x,-y,-z);
			Gl.glTexCoord2d(0,1);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,y,-z);

			Gl.glNormal3d(-1,0,0);
			Gl.glTexCoord2d(0,1);
			Gl.glVertex3d(-x,y,-z);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(1,0);
			Gl.glVertex3d(-x,-y,z);
			Gl.glTexCoord2d(1,1);
			Gl.glVertex3d(-x,y,z);

			Gl.glNormal3d(0,1,0);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,y,z);
			Gl.glTexCoord2d(1,0);
			Gl.glVertex3d(x,y,z);
			Gl.glTexCoord2d(1,1);
			Gl.glVertex3d(x,y,-z);
			Gl.glTexCoord2d(0,1);
			Gl.glVertex3d(-x,y,-z);

			Gl.glNormal3d(0,-1,0);
			Gl.glTexCoord2d(0,1);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(1,1);
			Gl.glVertex3d(x,-y,-z);
			Gl.glTexCoord2d(1,0);
			Gl.glVertex3d(x,-y,z);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,-y,z);
			Gl.glEnd();
		}

		public static void GambarBangunFlat(double x, double y, double z){ GambarBangun(x,y,z);}
		public static void GambarBangunSmooth(double x, double y, double z) 
		{
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glNormal3d(-1,1,1);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,y,z);
			Gl.glNormal3d(-1,-1,1);
			Gl.glTexCoord2d(0,y*2/100);
			Gl.glVertex3d(-x,-y,z);
			Gl.glTexCoord2d(x*2/100,y*2/100);
			Gl.glNormal3d(1,-1,1);
			Gl.glVertex3d(x,-y,z);
			Gl.glTexCoord2d(x*2/100,0);
			Gl.glNormal3d(1,1,1);
			Gl.glVertex3d(x,y,z);

			Gl.glNormal3d(1,1,1);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(x,y,z);				
			Gl.glTexCoord2d(0,y*2/100);
			Gl.glNormal3d(1,-1,1);
			Gl.glVertex3d(x,-y,z);
			Gl.glTexCoord2d(z*2/100,y*2/100);
			Gl.glNormal3d(1,-1,-1);
			Gl.glVertex3d(x,-y,-z);
			Gl.glTexCoord2d(z*2/100,0);
			Gl.glNormal3d(1,1,-1);
			Gl.glVertex3d(x,y,-z);

			Gl.glNormal3d(1,1,-1);
			Gl.glTexCoord2d(x*2/100,0);
			Gl.glVertex3d(x,y,-z);
			Gl.glNormal3d(1,-1,-1);
			Gl.glTexCoord2d(x*2/100,y*2/100);
			Gl.glVertex3d(x,-y,-z);
			Gl.glNormal3d(-1,-1,-1);
			Gl.glTexCoord2d(0,y*2/100);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(0,0);
			Gl.glNormal3d(-1,1,-1);
			Gl.glVertex3d(-x,y,-z);

			Gl.glNormal3d(-1,1,-1);
			Gl.glTexCoord2d(0,y*2/100);
			Gl.glVertex3d(-x,y,-z);
			Gl.glTexCoord2d(0,0);
			Gl.glNormal3d(-1,-1,-1);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glTexCoord2d(z*2/100,0);
			Gl.glNormal3d(-1,-1,1);
			Gl.glVertex3d(-x,-y,z);
			Gl.glTexCoord2d(z*2/100,y*2/100);
			Gl.glNormal3d(-1,1,1);
			Gl.glVertex3d(-x,y,z);

			Gl.glNormal3d(-1,1,1);
			Gl.glTexCoord2d(0,0);
			Gl.glVertex3d(-x,y,z);
			Gl.glNormal3d(1,1,1);
			Gl.glTexCoord2d(x*2/100,0);
			Gl.glVertex3d(x,y,z);
			Gl.glTexCoord2d(x*2/100,z*2/100);
			Gl.glNormal3d(1,1,-1);
			Gl.glVertex3d(x,y,-z);
			Gl.glTexCoord2d(0,z*2/100);
			Gl.glNormal3d(-1,1,-1);
			Gl.glVertex3d(-x,y,-z);

			Gl.glNormal3d(-1,-1,-1);
			Gl.glTexCoord2d(0,z*2/100);
			Gl.glVertex3d(-x,-y,-z);
			Gl.glNormal3d(1,-1,-1);
			Gl.glTexCoord2d(x*2/100,z*2/100);
			Gl.glVertex3d(x,-y,-z);
			Gl.glNormal3d(1,-1,1);
			Gl.glTexCoord2d(x*2/100,0);
			Gl.glVertex3d(x,-y,z);
			Gl.glTexCoord2d(0,0);
			Gl.glNormal3d(-1,-1,1);
			Gl.glVertex3d(-x,-y,z);
			Gl.glEnd();
		}

		public static void GambarBangun(double x, double y, double z,bool smooth) 
		{
			if (smooth) GambarBangunSmooth(x,y,z);
			else GambarBangunFlat(x,y,z);
		}

		public static int CreateTexture(string filename) 
		{
			int res; 
			PBitmap pBitmap= new PBitmap("textures\\"+filename);

			Gl.glGenTextures(1, out res);
			Gl.glPixelStorei (Gl.GL_UNPACK_ALIGNMENT, 1);

			Gl.glBindTexture(Gl.GL_TEXTURE_2D, res);

			Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, 3, pBitmap.Width, pBitmap.Height, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pBitmap.data);

	
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D,Gl.GL_TEXTURE_MAG_FILTER,Gl.GL_LINEAR_MIPMAP_LINEAR);

			pBitmap=null;
			return res;
		}
		
		protected static Hashtable KnownTextures = new Hashtable();
		public static int Texture(string name) 
		{
			try 
			{
				return (int) GlUtils.KnownTextures[name];
			}
			catch (Exception) 
			{
				GlUtils.KnownTextures[name]=GlUtils.LoadTextureByName(name);
				return (int) GlUtils.KnownTextures[name];
			}
		}
		protected static int LoadTextureByName(string name) 
		{
			switch (name) 
			{
                case "WOOD1": return CreateTexture("MADERA2B.jpg"); break;
				case "WOOD2": return CreateTexture("MADERA1B.jpg"); break;
				case "ROSEGOLD": return CreateTexture("rose.jpg"); break;
				case "WALL": return CreateTexture("PARED1.jpg"); break;
				case "PISO": return CreateTexture("creame.jpg"); break;
				case "TECHOOUT": return CreateTexture("madera9.jpg"); break;
				case "TECHOIN": return CreateTexture("PARED2.jpg"); break;
				case "BISAGRA": return CreateTexture("bisagra.jpg"); break;
				case "PUERTA": return Texture("WOOD2"); break;
				case "KNOB": return Texture("WOOD1"); break;
				case "ESTANTE" : return Texture("WOOD2");
				case "COLCHON": return CreateTexture("tela1.jpg");
				case "ALUMINIO": return CreateTexture("ALUMINIO.jpg"); break;
				case "AZULEJO": return CreateTexture("AZULEJO.jpg"); break;
				default: 
				{
					try 
					{
						try 
						{
							return CreateTexture(name);
						} 
						catch (Exception) 
						{
							return CreateTexture(name+".jpg");
						}
					} 
					catch ( Exception) {return 0;}
				}
			}
			return 0;
		}
		
		public static double VectorAngle2D(Point3D vector) 
		{
			Point3D dir = (new Point3D(vector.X,0,vector.Z)).Normalized;
			double sinalpha= dir.Z;
			double cosalpha= dir.X;
			double alpha=0;
			if (sinalpha>=0)
				alpha= Math.Acos(cosalpha)*180/Math.PI;
			else
				alpha= -Math.Acos(cosalpha)*180/Math.PI;
			return alpha;
		}
		public static void Beep() 
		{
			Platform.Windows.WinApi.Beep(900,2);
		}
	}
	public class PBitmap 
	{
		public int Width;
		public int Height;
		public byte[] data;
		public PBitmap(string filename) 
		{
			Bitmap bmp = new Bitmap(filename);
			Width=bmp.Width;
			Height=bmp.Height;
			if (!bmp.PixelFormat.Equals(PixelFormat.Format24bppRgb)) 
			{
				Bitmap aux = new Bitmap(Width,Height,PixelFormat.Format24bppRgb);
				Graphics.FromImage(aux).DrawImage(bmp,0,0);
				bmp=aux;
			}
			int bytesPerPixel=3;
			BitmapData bmd = bmp.LockBits(new Rectangle(0,0,Width,Height),ImageLockMode.ReadOnly, bmp.PixelFormat);
			data=new byte[Width*Height*bytesPerPixel];

			for(int i=0; i<bmd.Height; i++)
			{
				int y=bmd.Height-i-1;
				IntPtr row = new IntPtr(bmd.Scan0.ToInt32()+i*bmd.Stride);
				System.Runtime.InteropServices.Marshal.Copy(row,data,Width*y*bytesPerPixel,Width*bytesPerPixel);
			}
			for (int i=0; i<data.Length;i+=3)
				Array.Reverse(data,i,3);
			bmp.UnlockBits(bmd);
			bmp.Dispose();
		}
	}

}
