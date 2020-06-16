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
			casa.Add(new Museum2());

			casa.Add(new RakPajangan(new Point3D(210, 0, -318), 0));
			casa.Add(new RakPajangan(new Point3D(210, RakPajangan.Height + .3, -318), 0));
			casa.Add(new TV(new Point3D(310, 135, -33), 180));

			casa.Add(new Lamp(new Point3D(60,270,190),70));
            casa.Add(new Lamp(new Point3D(300,270,350),70));
            casa.Add(new Lamp(new Point3D(350,270,-500),70));
            casa.Add(new Lamp(new Point3D(350,270,-150),70));
            casa.Add(new Lamp(new Point3D(-220,270,-300),70));
            casa.Add(new Lamp(new Point3D(-180,270,90),70));

			casa.Add(new RakPajangan(new Point3D(-145, 0, -170), 0)); 
			casa.Add(new RakPajangan(new Point3D(-145, RakPajangan.Height, -170), 180));
			casa.Add(new teko(new Point3D(-175, 4, -125),0));
			casa.Add(new teko1(new Point3D(-215, 24, -125),0));
			casa.Add(new teko3(new Point3D(-215, -18, -125),0));

			casa.Add(new RakPajangan(new Point3D(-225, 0, -170), 0));
			casa.Add(new RakPajangan(new Point3D(-225, RakPajangan.Height, -170), 180));
			casa.Add(new Cangkir(new Point3D(-225, 125, -165), 0));
			casa.Add(new Cangkir(new Point3D(-245, 105, -165), 0));
			casa.Add(new Cangkir(new Point3D(-205, 105, -165), 0));
			casa.Add(new Cangkir(new Point3D(-225, 85, -165), 0));

			casa.Add(new RakPajangan(new Point3D(400, 0, -635), 180));
			casa.Add(new RakPajangan(new Point3D(400, RakPajangan.Height, -635), 0));
			casa.Add(new teko5(new Point3D(430, 4, -638), 180));
			casa.Add(new teko2(new Point3D(470, 24, -638), 180));
			casa.Add(new teko4(new Point3D(470, -18, -638), 180));

			casa.Add(new RakPajangan(new Point3D(-235, 0, -635), 180));
			casa.Add(new RakPajangan(new Point3D(-235, RakPajangan.Height, -635), 0));
			casa.Add(new teko(new Point3D(-205, 4, -638), 180));
			casa.Add(new teko4(new Point3D(-165, 24, -638), 180));
			casa.Add(new teko2(new Point3D(-165, -18, -638), 180));

			casa.Add(new Pillar(new Point3D(-180,70,-620),180));
			casa.Add(new Pillar(new Point3D(-170,60,-610),180));
			casa.Add(new Pillar(new Point3D(-160,50,-600),180));
			casa.Add(new Pillar(new Point3D(-150,40,-590),180));
			casa.Add(new Pillar(new Point3D(-140,30,-580),180));
			casa.Add(new Pillar(new Point3D(-130,20,-570),180));
			casa.Add(new Pillar(new Point3D(-120,10,-560),180));
			casa.Add(new Pillar(new Point3D(-110,0,-550),180));
			casa.Add(new Pillar(new Point3D(-100,-10,-550),180));
			casa.Add(new Pillar(new Point3D(-90,-20,-550),180));
			casa.Add(new Pillar(new Point3D(-80,-30,-550),180));
			casa.Add(new Pillar(new Point3D(-70,-40,-550),180));
			

			casa.Add(new Pillar(new Point3D(-60,-40,-550),180));
			casa.Add(new Pillar(new Point3D(-50,-30,-550),180));
			casa.Add(new Pillar(new Point3D(-40,-20,-550),180));
			casa.Add(new Pillar(new Point3D(-30,-10,-550),180));
			casa.Add(new Pillar(new Point3D(-20,0,-550),180));
			casa.Add(new Pillar(new Point3D(-10,10,-560),180));
			casa.Add(new Pillar(new Point3D(0,20,-570),180));
			casa.Add(new Pillar(new Point3D(10,30,-580),180));
			casa.Add(new Pillar(new Point3D(20,40,-590),180));
			casa.Add(new Pillar(new Point3D(30,50,-600),180));
			casa.Add(new Pillar(new Point3D(40,60,-610),180));
			casa.Add(new Pillar(new Point3D(50,70,-620),180));
			casa.Add(new Pillar(new Point3D(60,80,-630),180));
			casa.Add(new Pillar(new Point3D(70,70,-620),180));
			casa.Add(new Pillar(new Point3D(80,60,-610),180));
			casa.Add(new Pillar(new Point3D(90,50,-600),180));
			casa.Add(new Pillar(new Point3D(100,40,-590),180));
			casa.Add(new Pillar(new Point3D(110,30,-580),180));
			casa.Add(new Pillar(new Point3D(120,20,-570),180));
			casa.Add(new Pillar(new Point3D(130,10,-560),180));
			casa.Add(new Pillar(new Point3D(140,0,-550),180));
			casa.Add(new Pillar(new Point3D(150,-10,-550),180));
			casa.Add(new Pillar(new Point3D(160,-20,-550),180));
			casa.Add(new Pillar(new Point3D(170,-30,-550),180));
			casa.Add(new Pillar(new Point3D(180,-40,-550),180));
			
			casa.Add(new Pillar(new Point3D(190,-40,-550),180));
			casa.Add(new Pillar(new Point3D(200,-30,-550),180));
			casa.Add(new Pillar(new Point3D(210,-20,-550),180));
			casa.Add(new Pillar(new Point3D(220,-10,-550),180));
			casa.Add(new Pillar(new Point3D(230,0,-550),180));
			casa.Add(new Pillar(new Point3D(240,10,-560),180));
			casa.Add(new Pillar(new Point3D(250,20,-570),180));
			casa.Add(new Pillar(new Point3D(260,30,-580),180));
			casa.Add(new Pillar(new Point3D(270,40,-590),180));
			casa.Add(new Pillar(new Point3D(280,50,-600),180));
			casa.Add(new Pillar(new Point3D(290,60,-610),180));
			casa.Add(new Pillar(new Point3D(300,70,-620),180));

			
			Template obj = new Meja(new Point3D(380,0,200));
			casa.Add(obj);


			casa.Add(new Painting(new Point3D(-240,100,80),110));
			casa.Add(new Painting(new Point3D(-270,100,-20),110));
			casa.Add(new Painting(new Point3D(-200,100,-100),0));
			casa.Add(new Painting(new Point3D(-170,100,150),180));
			casa.Add(new Painting(new Point3D(60,100,-590),0));
			casa.Add(new Painting(new Point3D(-90,40,-530),0));
			casa.Add(new Painting(new Point3D(210,40,-530),0));
			casa.Add(new Painting(new Point3D(-300, 100, -500), 90));


			casa.Add(new Clock(new Point3D(160,200,0),0));
			obj = new Resepsionis(new Point3D(160,0,50),180);
			casa.Add(obj);

			
			casa.Add(new Bantal(new Point3D(220,65,450),120));
			casa.Add(new Bantal(new Point3D(220,65,380),120));
			casa.Add(new Bantal(new Point3D(220,65,520),120));

			casa.Add(new Kursi(new Point3D(220,0,380),180));
			casa.Add(new Kursi(new Point3D(220,0,450),180));
			casa.Add(new Kursi(new Point3D(220,0,520),180));

			casa.Add(new Piring(new Point3D(380,108,200)));

			casa.Add(new MejaDisplay(new Point3D(455,0,-380),-90));
			casa.Add(new Piring1(new Point3D(455,95,-380),-90));
			casa.Add(new MejaDisplay(new Point3D(355,0,-380),-90));
			casa.Add(new Piring5(new Point3D(355,88,-380),-90));
			casa.Add(new MejaDisplay(new Point3D(255,0,-380),-90));
			casa.Add(new Piring3(new Point3D(255,88,-380),-90));
			casa.Add(new MejaDisplay(new Point3D(155,0,-380),-90));
			casa.Add(new Piring4(new Point3D(155,88,-380),-90));
			
			obj = new MejaDisplay(new Point3D(330,0,-70),180);
			casa.Add(obj);
			
			casa.Add(new Sofa(new Point3D(350, 0, -280), 0, 2));		

			
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



