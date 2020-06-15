//#define testingObjects
using System;
using Tao.OpenGl;
using Platform.Windows;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace TareaGL
{
	/// <summary>
	/// Summary description for Main.
	/// </summary>
	public class MainClass
	{

		protected bool running=true;
		protected int Width=1024;
		protected int Height=768;

		protected Glut.PassiveMotionCallback PassiveMotionFunc = null;
		protected Avatar observer;
		public MainClass(string[] args) 
		{
			GlControl ViewPort = new GlControl(Width,Height);
			GlObjectList world = new GlObjectList();
			world.Add(new LightSource());
		#if !testingObjects
			world.Add(new TranslatedObject(new Point3D(0,-10,0),new SkyBox()));
			GlObjectList casa = new GlObjectList();
			casa.Add(new Casa2());

			casa.Add(new RakPajangan(new Point3D(210, 0, -318), 0));
			casa.Add(new RakPajangan(new Point3D(210, RakPajangan.Height + .3, -318), 0));
			casa.Add(new Lamp(new Point3D(60,270,190),70));
            casa.Add(new Lamp(new Point3D(300,270,350),70));
            casa.Add(new Lamp(new Point3D(350,270,-500),70));
            casa.Add(new Lamp(new Point3D(350,270,-150),70));
            casa.Add(new Lamp(new Point3D(-120,270,-550),70));
            casa.Add(new Lamp(new Point3D(-220,270,-300),70));
            casa.Add(new Lamp(new Point3D(-180,270,90),70));

			casa.Add(new RakPajangan(new Point3D(-145, 0, -170), 0)); 
			casa.Add(new RakPajangan(new Point3D(-145, RakPajangan.Height, -170), 180));
			casa.Add(new teko(new Point3D(-175, 4, -125),0));
			casa.Add(new teko1(new Point3D(-215, 24, -125),0));
			casa.Add(new teko3(new Point3D(-215, -18, -125),0));

			casa.Add(new RakPajangan(new Point3D(400, 0, -635), 180));
			casa.Add(new RakPajangan(new Point3D(400, RakPajangan.Height, -635), 0));
			casa.Add(new teko5(new Point3D(430, 4, -638), 180));
			casa.Add(new teko2(new Point3D(470, 24, -638), 180));
			casa.Add(new teko4(new Point3D(470, -18, -638), 180));

			casa.Add(new Refrigerador(new Point3D(-60,-40,-550),180));
			casa.Add(new Refrigerador(new Point3D(-50,-30,-550),180));
			casa.Add(new Refrigerador(new Point3D(-40,-20,-550),180));
			casa.Add(new Refrigerador(new Point3D(-30,-10,-550),180));
			casa.Add(new Refrigerador(new Point3D(-20,0,-550),180));
			casa.Add(new Refrigerador(new Point3D(-10,10,-560),180));
			casa.Add(new Refrigerador(new Point3D(0,20,-570),180));
			casa.Add(new Refrigerador(new Point3D(10,30,-580),180));
			casa.Add(new Refrigerador(new Point3D(20,40,-590),180));
			casa.Add(new Refrigerador(new Point3D(30,50,-600),180));
			casa.Add(new Refrigerador(new Point3D(40,60,-610),180));
			casa.Add(new Refrigerador(new Point3D(50,70,-620),180));
			casa.Add(new Refrigerador(new Point3D(60,80,-630),180));
			casa.Add(new Refrigerador(new Point3D(70,70,-620),180));
			casa.Add(new Refrigerador(new Point3D(80,60,-610),180));
			casa.Add(new Refrigerador(new Point3D(90,50,-600),180));
			casa.Add(new Refrigerador(new Point3D(100,40,-590),180));
			casa.Add(new Refrigerador(new Point3D(110,30,-580),180));
			casa.Add(new Refrigerador(new Point3D(120,20,-570),180));
			casa.Add(new Refrigerador(new Point3D(130,10,-560),180));
			casa.Add(new Refrigerador(new Point3D(140,0,-550),180));
			casa.Add(new Refrigerador(new Point3D(150,-10,-550),180));
			casa.Add(new Refrigerador(new Point3D(160,-20,-550),180));
			casa.Add(new Refrigerador(new Point3D(170,-30,-550),180));
			casa.Add(new Refrigerador(new Point3D(180,-40,-550),180));
			casa.Add(new Refrigerador(new Point3D(180,-40,-550),180));




			//casa.Add(new Cama(new Point3D(370,0,-250),0,100,70));
			//casa.Add(new Cama(new Point3D(370,0,-480),0,100,60));
			//casa.Add(new Cama(new Point3D(-210,0,-420),0,90,40));
			casa.Add(new Estante(new Point3D(-210,170,-108)));
			Plantilla obj = new Mesa(new Point3D(380,0,200));
			casa.Add(obj);
			casa.Add(new Painting(new Point3D(-90,100,150),90));
			casa.Add(new Painting(new Point3D(-30,100,350),140));


			//resepsionis
			casa.Add(new Clock(new Point3D(160,200,50),0));
			obj = new EstanteHorizontal(new Point3D(160,0,50),180);
			casa.Add(obj);

			
			//Cushion
			casa.Add(new Cojin(new Point3D(220,65,450),120));
			casa.Add(new Cojin(new Point3D(220,65,380),120));
			casa.Add(new Cojin(new Point3D(220,65,520),120));

			//Kursi
			casa.Add(new Silla(new Point3D(220,0,380),180));
			casa.Add(new Silla(new Point3D(220,0,450),180));
			casa.Add(new Silla(new Point3D(220,0,520),180));

			casa.Add(new Plato(new Point3D(380,108,200)));

			//casa.Add(new Vaso(new Point3D(380,obj.Height+.2,230)));
			//casa.Add(new MesitaDeNoche(new Point3D(455,0,-140),-90));
			casa.Add(new MesitaDeNoche(new Point3D(455,0,-380),-90));
			casa.Add(new Piring1(new Point3D(455,95,-380),-90));
			casa.Add(new MesitaDeNoche(new Point3D(355,0,-380),-90));
			casa.Add(new Piring5(new Point3D(355,88,-380),-90));
			casa.Add(new MesitaDeNoche(new Point3D(255,0,-380),-90));
			casa.Add(new Piring3(new Point3D(255,88,-380),-90));
			casa.Add(new MesitaDeNoche(new Point3D(155,0,-380),-90));
			casa.Add(new Piring4(new Point3D(155,88,-380),-90));
			//casa.Add(new MesitaDeNoche(new Point3D(455,0,-380),-90));
			//casa.Add(new MesitaDeNoche(new Point3D(455,0,-580),-90));
			//casa.Add(new MesitaDeNoche(new Point3D(-280,0,-340),90));
			obj = new MesitaDeNoche(new Point3D(330,0,-70),180);
			casa.Add(obj);
			
			casa.Add(new Butaca(new Point3D(350, 0, -280), 0, 2));
			//casa.Add(new Butaca(new Point3D(-30,0,200),90,2));
			//casa.Add(new Butaca(new Point3D(200,0,270),250,1));
			//casa.Add(new Butaca(new Point3D(200,0,110),-70,1));

			casa.Add(new teko(new Point3D(-307,0,-64),0));			

			
			GlObject c = new TranslatedObject(new Point3D(0,0,-70),casa);
			world.Add(c);
		#endif

			observer=new Avatar(ViewPort, world);
			Glut.glutDisplayFunc(new Glut.DisplayCallback(observer.Look));
			Glut.glutIdleFunc(new Glut.IdleCallback(observer.Look));
			Glut.glutMainLoop();
		}

		public static void Main(string[] args) 
		{
			new MainClass(args);
		}


	}




}



