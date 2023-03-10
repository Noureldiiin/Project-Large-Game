using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_MM__Large_Game_
{
    public class Pics
    {
        public int X, Y, W, H;
        public Bitmap img;
        public List<Bitmap> ImgList;
    }
    public class ElevatorAct
    {
        public int X, Y, W, H;
    }
    public class Act
    {
        public int X, Y, W, H;
    }
    public partial class Form1 : Form
    {
        int BossIsMayt = 0;
        int CountSword = 0;
        int p = 0;
        int t = 0;
        int CountBossDead = 0;
        int PosEnemy3X = 6800;
        int PosEnemy3Y = 855;
        int FlagDestinationIsLeft = 0;
        int FlagDestinationIsRight = 0;
        int FlagHeroAndStairs = 0;
        int YofHeroBeforeJump;
        int FLagHeroInStairs = 0;
        int Flag = 0;
        int FlagIsCoinCollected = 0;
        int FlagBossDead = 0;
        int HowManyCoinsHeroCollected = 0;
        int PosCoinsX = 4000;
        int PressEElevator2 = 0;
        int Enemy2Disappear = 0;
        int FlagElevator2 = 0;
        int FlagELevator2Selected = 0;
        int FlagELevator1Selected = 0;
        int ct2 = 0;
        int FLagIsEnemy2Dead = 0;
        int HowManyBulletHitEnemy2 = 0;
        int CountThrowWeapon1 = 0;
        int FlagWeaponEnemy2 = -1;
        int PosEnemy2X;
        int PosEnemy2Y;
        int count = 0;
        int FlagEnemy2SeeHero = 0;
        int ct = 0;
        int PosEnemy1X = 4100;
        int PosEnemy1Y = 868;
        int CountHeroDeath = 100;
        int FLagHeroCrossBoard = 0;
        int CountDeadEnemies = 0;
        int CountThrowAxes = 0;
        int CountOFAxes = 0;
        int flag = 0;
        string TextTime;
        int Counter = 6;
        int R = 100;
        int CountPressE = 0;
        int FlagEnemy3Dead = 0;
        int FLagEnemy1IsDead = 0;
        int CountHittenEnemy1 = 0;
        int FlagEnemy1MovingLeft = 1;
        int FlagEnemy1MovingRight = 0;
        Random random = new Random();
        Timer ttWelcome = new Timer();
        Timer TBullet = new Timer();
        Timer TAxe = new Timer();
        int FLagTimerCLosed = 0;
        int FlagElevator1 = 0;
        int FlagFirstAidTaken = 0;
        int CountEnemy3Dead = 0;
        int FlagHeroDead = 0;
        int FLagMovingELevator = 0;
        int CountEnter = 0;
        int PostionHeroY;
        int LandX = 1;
        int LandX2 = 1550;
        int LandX3 = 1;
        int FLagSingleBullet = 0;
        string BulletTextStatus;
        int FLagCounter = 0;
        int FLagGravity = 0;
        int BulletCount = 0;
        bool IsBulletSingle = false;
        bool IsBulletMulti = false;
        int FLagEnemy1Disappear = 0;
        int XS;
        int YS;
        int FLagEnemy1 = 0;
        int FlagEnemy2 = 0;
        int FlagEnemy3 = 0;
        Bitmap off;
        List<Pics> Door = new List<Pics>();
        List<Pics> Hero = new List<Pics>();
        List<Pics> Land = new List<Pics>();
        List<Pics> Land2 = new List<Pics>();
        List<Pics> Land3 = new List<Pics>();
        List<Pics> CLouds = new List<Pics>();
        List<Pics> FirstAidList = new List<Pics>();
        List<Pics> Bullet = new List<Pics>();
        List<ElevatorAct> Elevator = new List<ElevatorAct>();
        List<ElevatorAct> Elevator2 = new List<ElevatorAct>();
        List<Pics> Enemy1 = new List<Pics>();
        List<Pics> Enemy1DeadBody = new List<Pics>();
        List<Pics> Enemy2 = new List<Pics>();
        List<Pics> Enemy2DeadBody = new List<Pics>();
        List<Pics> Axes = new List<Pics>();
        List<Pics> Sword = new List<Pics>();
        List<Pics> CoinsPic = new List<Pics>();
        List<Pics> CoinCollect = new List<Pics>();
        List<Pics> Enemy2Weapon = new List<Pics>();
        List<Pics> Boss = new List<Pics>();
        List<ElevatorAct> BlockElevator = new List<ElevatorAct>();
        List<ElevatorAct> BlockElevator2 = new List<ElevatorAct>();
        public List<int> randomList = new List<int>();
        List<Pics> Block1 = new List<Pics>();
        List<Pics> Stairs = new List<Pics>();
        List<Pics> Enemy3 = new List<Pics>();
        List<Pics> FinalDoor = new List<Pics>();
        SoundPlayer sound = new SoundPlayer(@"E:\Multimedia\Project Multimedia\Project MM (Large Game)\Project MM (Large Game)\bin\Debug\CoinSound.wav");
        Bitmap BG = new Bitmap("Background.jpg");
        List<Pics> BigCoinsPic = new List<Pics>();
        List<Act> Lazer = new List<Act>();
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            ttWelcome.Tick += new EventHandler(tt_Tick);
            ttWelcome.Interval = 1000;
            ttWelcome.Start();
            TBullet.Tick += new EventHandler(tt_Bullet);
        }
        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (FLagSingleBullet == 1)
            {
                IsBulletSingle = true;
            }
            DrawDubbLevelOne(this.CreateGraphics());
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (FLagCounter == 1)
            {
                if (e.KeyCode == Keys.N)            //SwitchSingleToMulti or SwitchMutliToSingle
                {
                    BulletCount++;
                    if (BulletCount == 0)       //Single
                    {
                        IsBulletSingle = true;
                        IsBulletMulti = false;
                        FLagSingleBullet = 1;
                        BulletTextStatus = "Single";
                    }
                    if (BulletCount == 1)       //Multi
                    {
                        IsBulletSingle = false;
                        IsBulletMulti = true;
                        FLagSingleBullet = 0;
                        BulletTextStatus = "Multi";
                        BulletCount = -1;
                    }

                }
                if (e.KeyCode == Keys.Enter)
                {
                    CountEnter++;
                    if (CountEnter == 1)
                        LoadLevelOne();
                    ttWelcome.Stop();
                }
                for (int l = 0; l < Land.Count; l++)
                {
                    PostionHeroY = Hero[0].Y;
                    if (e.KeyCode == Keys.Right)
                    {
                        YofHeroBeforeJump = Hero[0].Y;
                        FlagDestinationIsRight = 1;
                        FlagDestinationIsLeft = 0;

                        if (Hero[0].Y + 100 >= Land[l].Y + 10 || Hero[0].Y <= Elevator[0].Y)
                        {
                            int des = FinalDoor[0].X - Hero[0].X;
                            if (Hero[0].X < 450 || des < 1000)
                            {
                                Hero[0].X += 1;
                            }
                            else
                            {
                                if (FLagHeroInStairs == 1 && FlagHeroAndStairs == 0)
                                {
                                    if (Flag == 0)
                                    {
                                        Hero[0].Y -= 3;
                                        YofHeroBeforeJump = Hero[0].Y;
                                        Flag = 1;
                                    }
                                    else
                                    {
                                        YofHeroBeforeJump = Hero[0].Y;
                                        Flag = 0;
                                        Hero[0].X += 1;
                                    }
                                }
                                FinalDoor[0].X -= 1;
                                Boss[0].X -= 1;
                                XS += 1;
                                Enemy3[0].X -= 1;
                                Stairs[0].X -= 1;
                                for (int w = 0; w < CLouds.Count; w++)
                                {
                                    CLouds[w].X -= 1;
                                }
                                Block1[0].X -= 1;
                                BlockElevator2[0].X -= 1;
                                Elevator2[0].X -= 1;
                                Enemy1[0].X -= 1;
                                Enemy2[0].X -= 1;
                                for (int c = 0; c < CoinsPic.Count; c++)
                                {
                                    CoinsPic[c].X -= 1;
                                }
                                for (int m = 0; m < Land.Count; m++)
                                {
                                    Land[m].X -= 1;
                                }
                                for (int m = 0; m < Land2.Count; m++)
                                {
                                    Land2[m].X -= 1;
                                }
                                BlockElevator[0].X -= 1;
                                Elevator[0].X -= 1;
                                Door[0].X -= 1;
                                FirstAidList[0].X -= 1;
                            }
                            FLagGravity = 0;
                        }
                        else
                        {
                            FLagGravity = 1;
                            CheckGravity();
                        }
                        TBullet.Start();
                    }
                    if (e.KeyCode == Keys.Left)
                    {
                        YofHeroBeforeJump = Hero[0].Y;
                        FlagDestinationIsLeft = 1;
                        FlagDestinationIsRight = 0;
                        if (Hero[0].Y + 100 >= Land[l].Y + 10 || Hero[0].Y <= Elevator[0].Y)
                        {
                            int des = FinalDoor[0].X - Hero[0].X;
                            if (Hero[0].X < Elevator[0].X - 150 || des < 1000)
                            {

                                Hero[0].X -= 1;
                            }
                            else
                            {
                                FinalDoor[0].X += 1;
                                Boss[0].X += 1;
                                XS -= 1;
                                Enemy3[0].X += 1;
                                Stairs[0].X += 1;
                                Block1[0].X += 1;
                                BlockElevator2[0].X += 1;
                                Elevator2[0].X += 1;
                                Enemy1[0].X += 1;
                                Enemy2[0].X += 1;
                                for (int w = 0; w < CLouds.Count; w++)
                                {
                                    CLouds[w].X += 1;
                                }
                                for (int c = 0; c < CoinsPic.Count; c++)
                                {
                                    CoinsPic[c].X += 1;
                                }
                                for (int m = 0; m < Land.Count; m++)
                                {
                                    Land[m].X += 1;
                                }
                                for (int m = 0; m < Land2.Count; m++)
                                {
                                    Land2[m].X += 1;
                                }
                                BlockElevator[0].X += 1;
                                Elevator[0].X += 1;
                                Door[0].X += 1;
                                FirstAidList[0].X += 1;
                            }
                            FLagGravity = 0;
                        }
                        else
                        {
                            FLagGravity = 1;
                            CheckGravity();
                        }
                        TBullet.Start();
                    }
                    if (e.KeyCode == Keys.A)
                    {
                        for (int i = 0; i < Land.Count; i++)
                        {
                            if (i == 90)
                                MessageBox.Show(Land[i].X.ToString());
                        }
                        MessageBox.Show(Boss[0].X.ToString());
                    }
                    if (e.KeyCode == Keys.Space)
                    {
                        if (Hero[0].Y <= Elevator[0].Y)
                        {
                            FLagGravity = 0;
                        }
                        Hero[0].Y -= 1;
                        FLagGravity = 1;
                        TBullet.Start();
                    }
                }
                if (e.KeyCode == Keys.B)
                {
                    if (IsBulletMulti)
                    {
                        if (FlagDestinationIsRight == 1)
                        {
                            CreateBullet();
                            MovingBulletMulti();
                        }
                    }
                    if (IsBulletSingle)
                    {
                        if (FlagDestinationIsRight == 1)
                        {
                            CreateBullet();
                            MovingBulletMulti();
                        }
                        IsBulletSingle = false;
                    }
                    MovingBulletSingle();


                }
                if (e.KeyCode == Keys.E)
                {
                    if (Hero[0].X > Elevator[0].X && Hero[0].X < Elevator[0].X + 220)
                    {
                        CountPressE++;
                        FlagELevator2Selected = 0;
                        FlagELevator1Selected = 1;
                    }
                    if (Hero[0].X > Elevator2[0].X && Hero[0].X < Elevator2[0].X + 300)
                    {

                        PressEElevator2++;
                        FlagELevator1Selected = 0;
                        FlagELevator2Selected = 1;
                    }
                }
                if (e.KeyCode == Keys.Escape)
                {
                    System.Windows.Forms.Application.Exit();
                }
                TBullet.Start();
            }

        }
        void LoadLevelOne()
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CreateFinalDoor();
            CreateBoss();
            CreateBlock1();
            CollecCoins();
            Coins();
            CreateFirstAid();
            CreateLand();
            CreateElevator1();
            CreateElevator2();
            CreateDoor();
            CreateHero();
            CreateBlockElevator();
            CreateBlockElevator2();
            CreateEnemy1();
            CreateEnemy2();
            CreateEnemy3();
            CreateClouds();
            SecondLand();
            CreateStairs();
            if (BulletCount == 0)       //Single
            {
                IsBulletSingle = true;
                IsBulletMulti = false;
                FLagSingleBullet = 1;
                BulletTextStatus = "Single";
            }
            DrawDubbLevelOne(this.CreateGraphics());
        }
        void CreateFinalDoor()
        {
            Pics pnn = new Pics();
            pnn.X = 8800;
            pnn.Y = 760;
            pnn.img = new Bitmap("Door.png");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            FinalDoor.Add(pnn);
        }
        void CreateSword()
        {
            Pics Swordpic;
            Swordpic = new Pics();
            Swordpic.X = Enemy3[0].X;
            Swordpic.Y = Enemy3[0].Y;
            Swordpic.ImgList = new List<Bitmap>();
            for (int i = 1; i <= 4; i++)
            {
                Bitmap Player = new Bitmap("Sword" + i.ToString() + ".png");
                Player.MakeTransparent(Player.GetPixel(0, 0));
                Swordpic.ImgList.Add(Player);
            }
            Sword.Add(Swordpic);
        }
        void CreateEnemy3()
        {
            Pics Enemies3;
            Enemies3 = new Pics();
            Enemies3.X = PosEnemy3X;
            Enemies3.Y = PosEnemy3Y;
            Enemies3.ImgList = new List<Bitmap>();
            for (int i = 0; i <= 1; i++)
            {
                Bitmap Player = new Bitmap("Enemy3" + i.ToString() + ".png");
                Player.MakeTransparent(Player.GetPixel(0, 0));
                Enemies3.ImgList.Add(Player);
            }
            Enemy3.Add(Enemies3);
        }
        void CreateStairs()
        {
            Pics pnn = new Pics();
            pnn.X = 1000;
            pnn.Y = 450;
            pnn.img = new Bitmap("Stairs.png");
            Stairs.Add(pnn);
        }
        void CreateBlock1()
        {
            Pics pnn = new Pics();
            pnn.X = 4700;
            pnn.Y = 50;
            pnn.img=new Bitmap("Wall.jpg");
            Block1.Add(pnn);
        }
        void CreateFirstAid()
        {
            Pics pnn = new Pics();
            pnn.img = new Bitmap("FirstAid.jpg");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            pnn.X = 5000;
            pnn.Y = 900;
            FirstAidList.Add(pnn);
        }
        void IfFirstAidNextToHero()
        {
            int des = FirstAidList[0].Y - Hero[0].Y;
            if (Hero[0].X >= FirstAidList[0].X && CountHeroDeath != 100)
            {
                FlagFirstAidTaken = 1;
                CountHeroDeath += 15;
                if (CountHeroDeath != 100)
                {
                    if (CountHeroDeath >= 100)
                    {
                        CountHeroDeath = 100;
                    }
                }
            }
        }
        void CreateBlockElevator()
        {
            ElevatorAct pnn = new ElevatorAct();
            pnn.X = 900;
            pnn.Y = 500;
            BlockElevator.Add(pnn);
        }
        void CreateBlockElevator2()
        {
            ElevatorAct pnn = new ElevatorAct();
            pnn.X = 3500;
            pnn.Y = 500;
            BlockElevator2.Add(pnn);
        }
        void CreateEnemy1()
        {
            Pics Enemies1;
            Enemies1 = new Pics();
            Enemies1.X = PosEnemy1X;
            Enemies1.Y = PosEnemy1Y;
            Enemies1.ImgList = new List<Bitmap>();
            for (int i = 0; i <= 1; i++)
            {
                Bitmap Player = new Bitmap("Enemy1" + i.ToString() + ".png");
                Player.MakeTransparent(Player.GetPixel(0, 0));
                Enemies1.ImgList.Add(Player);
            }
            Enemy1.Add(Enemies1);
        }
        void CreateEnemy2()
        {
            Pics Enemies2;
            Enemies2 = new Pics();
            Enemies2.X = Land[30].X;
            Enemies2.Y = 378;
            Enemies2.ImgList = new List<Bitmap>();
            for (int i = 0; i <= 1; i++)
            {
                Bitmap Player = new Bitmap("Enemy2" + i.ToString() + ".png");
                Player.MakeTransparent(Player.GetPixel(0, 0));
                Enemies2.ImgList.Add(Player);
            }
            Enemy2.Add(Enemies2);
        }
        void CreateBoss()
        {
            Pics Enemies4;
            Enemies4 = new Pics();
            Enemies4.X = 8500;
            Enemies4.Y = 780;
            Enemies4.ImgList = new List<Bitmap>();
            for (int i = 1; i <= 2; i++)
            {
                Bitmap Player = new Bitmap("BigEnemy" + i.ToString() + ".png");
                Player.MakeTransparent(Player.GetPixel(0, 0));
                Enemies4.ImgList.Add(Player);
            }
            Boss.Add(Enemies4);
        }
        void BulletHitten()
        {
            for (int b = 0; b < Bullet.Count; b++)
            {
                if (Bullet[b].X >= Enemy1[0].X && Hero[0].Y == Enemy1[0].Y)
                {
                    CountHittenEnemy1++;
                    Bullet.RemoveAt(b);
                    if (CountHittenEnemy1 == 2) 
                    {
                        FLagEnemy1Disappear = 1;
                        FLagEnemy1IsDead = 1;
                    }
                }
                if (CountHittenEnemy1 == 2)
                {
                    break;
                }
            }
        }
        void CreateElevator1()
        {
            ElevatorAct pnn = new ElevatorAct();
            pnn.X = 630;
            pnn.Y = 950;
            Elevator.Add(pnn);
        }
        void CreateElevator2()
        {
            ElevatorAct pnn = new ElevatorAct();
            pnn.X = 3550;
            pnn.Y = 465;
            Elevator2.Add(pnn);
        }
        void MovingElevator()
        {
            if (Hero[0].X > Elevator[0].X && Hero[0].X < Elevator[0].X + 220)
            {
                FlagElevator1 = 1; 
                if (FlagELevator1Selected == 1)
                {
                    ConnectHeroWithElevator1();
                }
            }
            else
            {
                FlagElevator1 = 0;
            }
            if (Hero[0].X > Elevator2[0].X && Hero[0].X < Elevator2[0].X + 300)
            {
                FlagElevator2 = 1;
                if (FlagELevator2Selected == 1)
                {
                    ConnectHeroWithElevator2();
                }
            }
            else
            {
                FlagElevator2 = 0;
            }
        }
        void ConnectHeroWithElevator2()
        {
            FlagElevator2 = 0;
            if (PressEElevator2 == 1)
            {
                YofHeroBeforeJump = Elevator2[0].Y;
                if (Elevator2[0].Y < 950)
                {
                    Elevator2[0].Y += 10;
                    Hero[0].Y += 10;
                }
            }
            else
            {
                YofHeroBeforeJump = Elevator2[0].Y;
                if (Elevator2[0].Y > 465)
                {
                    Elevator2[0].Y -= 10;
                    Hero[0].Y -= 10;
                }
                PressEElevator2 = 0;
            }
            
        }
        void ConnectHeroWithElevator1()
        {
            if (CountPressE == 1)
            {
                FlagElevator1 = 0;
                if (Elevator[0].Y > 465)
                {
                    Elevator[0].Y -= 10;
                    Hero[0].Y -= 10;
                }
                else
                {
                    FLagMovingELevator = 0;
                }
            }
            else
            {
                if (Elevator[0].Y < 950)
                {
                    Elevator[0].Y += 10;
                    Hero[0].Y += 10;
                }
                else
                {
                    FLagMovingELevator = 0;
                }
                CountPressE = 0;
            }
        }
        void Enemy1Dead()
        {
            Pics pnn = new Pics();
            pnn.X = Enemy1[0].X;
            pnn.Y = Enemy1[0].Y + 5;
            pnn.img = new Bitmap("Enemy1Dead.png");
            Enemy1DeadBody.Add(pnn);
            
            Axes.Clear();
        }
        void CreateBullet()
        {
            Pics pnn = new Pics();
            pnn.X = Hero[0].X + 50;
            pnn.Y = Hero[0].Y + 30;
            pnn.img = new Bitmap("Bullet.png");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            Bullet.Add(pnn);
            
        }
        void MovingBulletMulti()
        {
            for (int b = 0; b < Bullet.Count; b++)
            {
                int r = random.Next(20, 60);
                Bullet[b].X += r;
                int Des = Bullet[b].X - Hero[0].X;
                if (Bullet[b].X > Stairs[0].X + 65 && Hero[0].X < Stairs[0].X)
                {
                    Bullet.RemoveAt(b);
                }
                if (Des > 1000)
                {
                    Bullet.RemoveAt(b);
                }
            }
        }
        void MovingBulletSingle()
        {
            for (int b = 0; b < Bullet.Count; b++)
            {
                int r = random.Next(20, 60);
                Bullet[b].X += r;
            }
        }
        void SecondLand()
        {
            for (int i = 0; i < 20; i++)
            {
                Pics pnn = new Pics();
                pnn.X = LandX2;
                pnn.Y = 450;
                pnn.W = 10;
                pnn.H = 60;
                pnn.img = new Bitmap("Land.bmp");
                pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                Land2.Add(pnn);
                LandX2 += 100;
            }
            LandX2 += 300;
            for (int i = 0; i < 20; i++)
            {
                Pics pnn = new Pics();
                pnn.X = LandX2;
                pnn.Y = 450;
                pnn.W = 10;
                pnn.H = 60;
                pnn.img = new Bitmap("Land.bmp");
                pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                Land2.Add(pnn);
                LandX2 += 100;
            }
        }
        void CreateClouds()
        {
            Random r = new Random();
            for (int c = 0; c < 6; c++)
            {
                Pics pnn = new Pics();
                pnn.X = R;
                pnn.Y = 100;
                pnn.W = 10;
                pnn.H = 60;
                pnn.img = new Bitmap("CLoud.png");
                pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                CLouds.Add(pnn);
                R += 250;
            }
        }
        void CreateLand()
        {
            for (int i = 0; i < 90; i++)
            {
                Pics pnn = new Pics();
                pnn.X = LandX;
                pnn.Y = 950;
                pnn.W = 10;
                pnn.H = 60;
                pnn.img = new Bitmap("Land.bmp");
                pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                Land.Add(pnn);
                LandX += 100;
            }
        }
        void CheckGravity()
        {
            Hero[0].Y += 5;
            if (Hero[0].Y == YofHeroBeforeJump) 
            {
                FLagGravity = 0;
                PostionHeroY = 0;
            }
        }
        void CreateAxe()
        {
            Pics Axe;
            Axe = new Pics();
            Axe.X = Enemy1[0].X;
            Axe.Y = Enemy1[0].Y;
            Axe.ImgList = new List<Bitmap>();
            for (int i = 1; i <= 3; i++)
            {
                Bitmap Player = new Bitmap("Axe" + i.ToString() + ".png");
                Player.MakeTransparent(Player.GetPixel(0,0));
                Axe.ImgList.Add(Player);
            }
            Axes.Add(Axe);
        }
        void tt_Tick(object sender, EventArgs e)
        {
            Counter--;
            if (Counter == 0)
            {
                FLagCounter = 1;
            }
            TextTime = Counter.ToString();
            if (FLagCounter == 0)
            {
                DrawDubbWelcome(this.CreateGraphics());
            }
            if (FLagCounter == 1)
            {
                ShowStringToPlay(this.CreateGraphics());
                FLagTimerCLosed = 1;
            }
            
        }
        void CoinCollected()
        {
            Pics pnn = new Pics();
            pnn.X = Hero[0].X;
            pnn.Y = Hero[0].Y - 80 ;
            pnn.img = new Bitmap("Coins.png");
            CoinCollect.Add(pnn);
        }
        void MovingSword()
        {
            for (int i = 0; i < Sword.Count; i++)
            {
                Sword[i].X -= 50;
                FlagEnemy3++;
                if (FlagEnemy3 == 4)
                {
                    FlagEnemy3 = 0;
                }
                
            }
        }
        void BulletHitEnemy3()
        {
            for (int i = 0; i < Bullet.Count; i++)
            {
                if (Bullet[i].X > Enemy3[0].X - 10)
                {
                    Bullet.RemoveAt(i);
                    CountEnemy3Dead++;
                    if (CountEnemy3Dead == 8)
                    {
                        CountDeadEnemies++;
                        FlagEnemy3Dead = 1;
                    }
                }
            }
        }
        void CreateLazer()
        {
            Act pnn = new Act();
            pnn.X = Boss[0].X;
            pnn.Y = Boss[0].Y+100;
            Lazer.Add(pnn);
        }
        void BulletHitBoss()
        {
            for (int i = 0; i < Bullet.Count; i++)
            {
                if (Bullet[i].X > Boss[0].X - 10)
                {
                    Bullet.RemoveAt(i);
                    CountBossDead++;
                    if(CountBossDead==16)
                    {
                        CountDeadEnemies++;
                        FlagBossDead = 1;
                    }
                }
            }
        }
        void BossDeath()
        {
            Boss[0].Y -= 1;
            if (Boss[0].Y >= 100)
            {
                BossIsMayt = 1;
            }
        }
        void tt_Bullet(object sender, EventArgs e)
        {
            if (BossIsMayt != 1)
                BulletHitBoss();
            int desbetweenheroandboss = Boss[0].X - Hero[0].X;
            if (FlagHeroDead != 1)
            {
                if (desbetweenheroandboss < 600 && BossIsMayt != 1)
                {
                    if (count < 5)
                    {
                        CreateLazer();
                        CountHeroDeath -= 10;
                        if (CountHeroDeath <= 0)
                        {
                            FlagHeroDead = 1;
                        }
                    }
                    if (count == 6)
                    {
                        Lazer.Clear();
                    }
                    if (count == 20)
                    {
                        count = 1;
                    }
                    count++;
                }
            }
            BulletHitEnemy3();
            int destinationbetweenheroandenemy3 = Enemy3[0].X - Hero[0].X;
            if (CountSword == 10 && destinationbetweenheroandenemy3 < 1000)  
            {
                CreateSword();
            }
            CountSword++;
            if (CountSword > 10 && FlagEnemy3Dead != 1)
            {
                CountSword = 0;
            }
            if (Sword != null && FlagEnemy3Dead != 1)
            {
                MovingSword();
            }
            if (FlagHeroAndStairs == 0)
            {
                if (Hero[0].Y + 71 > Land2[0].Y && Hero[0].X > Stairs[0].X - 30)
                {
                    FLagHeroInStairs = 1;
                }
                else
                {
                    if (FLagHeroInStairs == 1)
                    {
                        Hero[0].Y = 378;
                        FlagHeroAndStairs = 1;
                    }
                    
                    FLagHeroInStairs = 0;
                }
            }
            CollectCoins();
            if (FlagIsCoinCollected == 1)
            {
                CoinCollected();
            }
            if (FLagHeroCrossBoard == 1)
            {
                if (FLagEnemy1IsDead == 0)
                {
                    if (CountThrowAxes == 20)
                    {
                        CreateAxe();
                    }
                }
            }
            
            CountThrowAxes++;
            if (CountThrowAxes > 20)
            {
                CountThrowAxes = 0;
            }
            if (Enemy2Disappear != 1)
            CheckIsHeroNearOfEnemy2();
            
            if (FlagEnemy2SeeHero == 1&& CountThrowWeapon1 % 20 == 0)
            {
                PosEnemy2X = Enemy2[0].X;
                PosEnemy2Y = Enemy2[0].Y;
                CreateEnemy2Weapon();
            }
            CountThrowWeapon1++;
            if (IsBulletMulti)
            {
                MovingBulletMulti();
            }
            if (IsBulletSingle)
            {
                MovingBulletSingle();
            }
            MovingElevator();
            if (FLagEnemy1IsDead == 0)
            {
                CheckHeroCrossBoard();
            }
            if (CountHittenEnemy1 < 2)
            {
                BulletHitten();
            }
            if (HowManyBulletHitEnemy2 <= 5)
            {
                BulletHitEnemy2();
            }
            if (FLagEnemy1IsDead == 1)
            {
                if (ct == 0)
                {
                    if (t == 0) 
                    {
                        CountDeadEnemies++;
                        t = 1;
                    }
                    Enemy1Dead();
                    FLagHeroCrossBoard = 0;
                    FLagEnemy1IsDead = 1;
                }
            }
            if (FLagIsEnemy2Dead == 1)
            {
                if (ct2 == 0)
                {
                    if (p == 0)
                    {
                        CountDeadEnemies++;
                        p = 1;
                    }
                    CreateEnemy2DeadBody();
                    Enemy2Disappear = 1;
                    FlagEnemy2SeeHero = 0;
                    FLagIsEnemy2Dead = 0;
                }
            }
            if (destinationbetweenheroandenemy3 < 1000) 
            {
                Enemy3[0].X -= 50;
            }
            if (Enemy2Weapon != null) 
            {
                MoveWeapon2();
            }
            if (Axes != null) 
            {
                MoveAxe();
            }
            if (FLagGravity == 1)
            {
                CheckGravity();
            }
            CheckHeroIsDead();
            if (FlagHeroDead == 0)
            {
                DrawDubbLevelOne(this.CreateGraphics());
            }
            else
            {
                TBullet.Stop();
                DrawDubbGameOver(this.CreateGraphics());
                TBullet.Stop();
            }
            if (FlagFirstAidTaken == 0)
            IfFirstAidNextToHero();
            MovingEnemy1();
            if (FlagEnemy1MovingLeft == 1)
            {
                Enemy1[0].X -= 10;
                FLagEnemy1 = 0;
            }
            if (FlagEnemy1MovingLeft == 0)
            {
                Enemy1[0].X += 10;
                FLagEnemy1 = 1;
            }
            if (Hero[0].X > FinalDoor[0].X - 20)
            {
                TBullet.Stop();
                DrawDubbWinner(this.CreateGraphics());
                TBullet.Stop();
            }
            else
            {
                DrawDubbLevelOne(this.CreateGraphics());
            }
        }
        void CollectCoins()
        {
            for (int i = 0; i < CoinsPic.Count; i++)
            {
                if (Hero[0].X >= CoinsPic[i].X && Hero[0].Y == CoinsPic[i].Y) 
                {
                    FlagIsCoinCollected = 1;
                    CoinsPic.RemoveAt(i);
                    HowManyCoinsHeroCollected++;
                    sound.Play();
                }
            }
        }
        void CollecCoins()
        {
            Pics pnn = new Pics();
            pnn.X = 190;
            pnn.Y = 35;
            pnn.img = new Bitmap("Collection coins.png");
            BigCoinsPic.Add(pnn);
        }
        void Coins()
        {
            for (int i = 0; i < 3; i++)
            {
                Pics pnn = new Pics();
                pnn.X = PosCoinsX;
                pnn.Y = 378;
                pnn.img = new Bitmap("Coins.png");
                CoinsPic.Add(pnn);
                PosCoinsX += 200;
            }
        }
        void CreateEnemy2DeadBody()
        {
            Pics pnn = new Pics();
            pnn.X = Enemy2[0].X;
            pnn.Y = Enemy2[0].Y + 5;
            pnn.img = new Bitmap("Enemy2Dead.png");
            Enemy2DeadBody.Add(pnn);
        }
        void BulletHitEnemy2()
        {
            for (int b = 0; b < Bullet.Count; b++)
            {
                for (int i = 0; i < Enemy2.Count; i++)
                {
                    if (Bullet[b].X > Enemy2[0].X && Bullet[b].Y == Enemy2[0].Y + 30)
                    {
                        HowManyBulletHitEnemy2++;
                        Bullet.RemoveAt(b);
                    }
                    if (HowManyBulletHitEnemy2 == 5)
                    {
                        FLagIsEnemy2Dead = 1;
                    }
                }
            }
        }
        void MoveWeapon2()
        {
            for (int w = 0; w < Enemy2Weapon.Count; w++)
            {
                FlagWeaponEnemy2++;
                if (FlagWeaponEnemy2 == 4)
                {
                    FlagWeaponEnemy2 = 0;
                }
                Enemy2Weapon[w].X -= 80;
            }
        }
        void CreateEnemy2Weapon()
        {
            Pics Weapon2;
            Weapon2 = new Pics();
            Weapon2.X = PosEnemy2X;
            Weapon2.Y = PosEnemy2Y;
            Weapon2.ImgList = new List<Bitmap>();
            for (int i = 1; i <= 4; i++)
            {
                Bitmap Player = new Bitmap("MorningStar" + i.ToString() + ".png");
                Player.MakeTransparent(Player.GetPixel(0, 0));
                Weapon2.ImgList.Add(Player);
            }
            Enemy2Weapon.Add(Weapon2);
        }
        void CheckIsHeroNearOfEnemy2()
        {
            if (Hero[0].X>Land[20].X)
            {
                Enemy2[0].X -= 25;
                FlagEnemy2 = 0;
                FlagEnemy2SeeHero = 1;
            }
            else
            {
                if (FlagEnemy2SeeHero == 1)
                {
                    FlagEnemy2 = 1;
                    if (Enemy2[0].X < Land[30].X)
                    {
                        Enemy2[0].X += 10;
                    }
                    FlagEnemy2SeeHero = 0;
                }
            }
        }
        void MovingEnemy1()
        {
            for (int i = 0; i < Land.Count; i++)
            {
                if (FlagEnemy1MovingRight == 0)
                {
                    if (Enemy1[0].X <= Land[40].X)
                    {
                        FlagEnemy1MovingLeft = 0;
                        FlagEnemy1MovingRight = 1;
                    }
                }
                if (FlagEnemy1MovingLeft == 0)
                {
                    if (Enemy1[0].X >= Land[50].X)
                    {
                        FlagEnemy1MovingLeft = 1;
                        FlagEnemy1MovingRight = 0;
                    }
                }
            }
        }
        void CheckHeroCrossBoard()
        {
            if (Hero[0].X <= Enemy1[0].X - 500 && Hero[0].Y == Enemy1[0].Y)
            {
                
                if (FLagEnemy1IsDead == 0)
                {
                    FLagHeroCrossBoard = 1;
                    flag = 1;
                }
            }
            else
            {
                FLagHeroCrossBoard = 0;
                if (flag == 1)
                {
                    MoveAxe();
                }
            }
        }
        void CheckHeroIsDead()
        {
            for (int q = 0; q < Axes.Count; q++)
            {
                if (Axes[q].X <= Hero[0].X && Axes[q].Y == Hero[0].Y)
                {
                    Axes.RemoveAt(q);
                    CountHeroDeath -= 30;
                    DrawDubbLevelOne(this.CreateGraphics());
                    if (CountHeroDeath <= 0)
                    {
                        CountHeroDeath = 0;
                        FlagHeroDead = 1;
                    }
                }
            }
            for (int i = 0; i < Enemy2Weapon.Count; i++)
            {
                if (Hero[0].X >= Enemy2Weapon[i].X)
                {
                    Enemy2Weapon.RemoveAt(i);
                    CountHeroDeath -= 40;
                    DrawDubbLevelOne(this.CreateGraphics());
                    if (CountHeroDeath <= 0)
                    {
                        CountHeroDeath = 0;
                        FlagHeroDead = 1;
                    }
                }
            }
            for (int v = 0; v < Sword.Count; v++)
            {
                if (Sword[v].X < Hero[0].X + 30)
                {
                    Sword.RemoveAt(v);
                    CountHeroDeath -= 60;
                    DrawDubbLevelOne(this.CreateGraphics());
                    if (CountHeroDeath <= 0)
                    {
                        CountHeroDeath = 0;
                        FlagHeroDead = 1;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            DrawDubbWelcome(this.CreateGraphics());
        }
        void CreateHero()
        {
            Pics pnn = new Pics();
            pnn.X = 150;
            pnn.Y = 870;
            pnn.W = 10;
            pnn.H = 60;
            pnn.img = new Bitmap("Hero.png");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            Hero.Add(pnn);
            YofHeroBeforeJump = pnn.Y;
        }
        void MoveAxe()
        {
            for (int a = 0; a < Axes.Count; a++)
            {
                CountOFAxes++;
                if (CountOFAxes == 3) 
                {
                    CountOFAxes = 0;
                }
                Axes[a].X -= 20;
            }
        }
        void CreateDoor()
        {
            Pics pnn = new Pics();
            pnn.X = 10;
            pnn.Y = 760;
            pnn.img = new Bitmap("Door.png");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            Door.Add(pnn);
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubbWelcome(e.Graphics);
        }
        void DrawSceneWinner(Graphics g)
        {
            g.Clear(Color.WhiteSmoke);
            g.DrawString("You are..", new Font(FontFamily.GenericMonospace, 50, FontStyle.Bold),
            new SolidBrush(Color.Black), 300, 300);
            g.DrawString("Winner", new Font(FontFamily.GenericMonospace, 200, FontStyle.Bold),
            new SolidBrush(Color.Black), 250, 400);
        }
        void DrawDubbWinner(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawSceneWinner(g2);
            g.DrawImage(off, 0, 0);
        }
        void DrawSceneGameOver(Graphics g)
        {
            g.Clear(Color.WhiteSmoke);
            g.DrawString("You are dead.", new Font(FontFamily.GenericMonospace, 50, FontStyle.Bold),
            new SolidBrush(Color.Black), 300, 300);
            g.DrawString("Gameover", new Font(FontFamily.GenericMonospace, 200, FontStyle.Bold),
            new SolidBrush(Color.Black), 250, 400);
        }
        void DrawDubbGameOver(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawSceneGameOver(g2);
            g.DrawImage(off, 0, 0);
        }
        void DrawSceneLevelOne(Graphics g)
        {
            g.Clear(Color.LightBlue);
            Rectangle rcDst = new Rectangle(0, 0, 3800, 3800);
            Rectangle rcScr = new Rectangle(XS, YS, this.ClientSize.Width, this.ClientSize.Height);
            g.DrawImage(BG, rcDst, rcScr, GraphicsUnit.Pixel);
            g.DrawImage(FinalDoor[0].img, FinalDoor[0].X, FinalDoor[0].Y, 200, 200);
            Pen pen = new Pen(Color.Red, 2);
            if (BossIsMayt != 1)
            {
                for (int i = 0; i < Lazer.Count; i++)
                {
                    g.DrawLine(pen, Lazer[i].X, Lazer[i].Y, 0, 880);
                }

                for (int i = 0; i < Boss.Count; i++)
                {
                    g.DrawImage(Boss[i].ImgList[0], Boss[i].X, Boss[i].Y, 200, 200);
                }
            }
            if (FlagEnemy3Dead != 1)
            {
                for (int i = 0; i < Sword.Count; i++)
                {
                    g.DrawImage(Sword[i].ImgList[FlagEnemy3], Sword[i].X, Sword[i].Y, 100, 100);
                }
            }
            g.DrawImage(BigCoinsPic[0].img, BigCoinsPic[0].X, BigCoinsPic[0].Y, 50, 50);
            if (FlagIsCoinCollected == 1)
            {
                for (int i = 0; i < CoinCollect.Count; i++)
                {
                    g.DrawImage(CoinCollect[i].img, CoinCollect[i].X, CoinCollect[i].Y, 80, 80);
                }
                FlagIsCoinCollected = 0;
            }
            for (int i = 0; i < CoinsPic.Count; i++)
            {
                g.DrawImage(CoinsPic[i].img, CoinsPic[i].X, CoinsPic[i].Y, 80, 80);
            }
            g.DrawString(HowManyCoinsHeroCollected.ToString(), new Font(FontFamily.GenericMonospace, 30, FontStyle.Bold),
            new SolidBrush(Color.Gold), 230, 40);
            if (FlagFirstAidTaken == 0)
            {
                g.DrawImage(FirstAidList[0].img, FirstAidList[0].X, FirstAidList[0].Y, 60, 50);
            }
            string Hp = CountHeroDeath.ToString();
            g.DrawString("HP : " + Hp, new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold),
            new SolidBrush(Color.Black), 60, 75);
            g.DrawString(" - Kill all enemies, collect all coins and get the key to win. ", new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold),
            new SolidBrush(Color.Black), 20, 20);
            g.FillRectangle(Brushes.Black, BlockElevator2[0].X, BlockElevator2[0].Y, 50, 500);
            g.DrawString("Kills: " + CountDeadEnemies + "/4", new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold),
            new SolidBrush(Color.Black), 60, 50);
            g.DrawString("Bullet status : " + BulletTextStatus, new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold),
            new SolidBrush(Color.Black), 1640, 50);
            g.DrawString("Press N to change bullet Status", new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold),
            new SolidBrush(Color.Black), 1530, 20);
            for (int i = 0; i < Door.Count; i++)
            {
                g.DrawImage(Door[i].img, Door[i].X, Door[i].Y, 200, 200);
            }
            for (int i = 0; i < Hero.Count; i++)
            {
                g.DrawImage(Hero[i].img, Hero[i].X, Hero[i].Y, 70, 100);
            }
            
            if (FLagEnemy1Disappear != 1)
            {
                for (int i = 0; i < Enemy1.Count; i++)
                {
                    g.DrawImage(Enemy1[i].ImgList[FLagEnemy1], Enemy1[i].X, Enemy1[i].Y, 100, 110);
                }
            }
            if (Enemy2Disappear != 1)
            {
                for (int i = 0; i < Enemy2.Count; i++)
                {
                    g.DrawImage(Enemy2[i].ImgList[FlagEnemy2], Enemy2[i].X, Enemy2[i].Y, 100, 120);
                }
            }
            if (FlagEnemy3Dead != 1)
            {
                for (int i = 0; i < Enemy3.Count; i++)
                {
                    g.DrawImage(Enemy3[i].ImgList[0], Enemy3[i].X, Enemy3[i].Y, 110, 120);
                }
            }
            if (Enemy2Disappear != 1)
            {
                for (int i = 0; i < Enemy2Weapon.Count; i++)
                {
                    g.DrawImage(Enemy2Weapon[i].ImgList[FlagWeaponEnemy2], Enemy2Weapon[i].X, Enemy2Weapon[i].Y, 50, 50);
                }
            }
            g.FillRectangle(Brushes.Black, Elevator2[0].X, Elevator2[0].Y, 320, 30);
            
            for (int i = 0; i < Land2.Count; i++)
            {
                g.DrawImage(Land2[i].img, Land2[i].X, Land2[i].Y, 100, 100);
            }
            for (int i = 0; i < Stairs.Count; i++)
            {
                g.DrawImage(Stairs[i].img, Stairs[i].X, Stairs[i].Y, 700, 560);
            }
            for (int i = 0; i < Land.Count; i++)
            {
                g.DrawImage(Land[i].img, Land[i].X, Land[i].Y, 100, 100);
            }
            g.DrawImage(Block1[0].img, Block1[0].X, Block1[0].Y, 3000, 500);
            for (int i = 0; i < CLouds.Count; i++)
            {
                g.DrawImage(CLouds[i].img, CLouds[i].X, CLouds[i].Y, 150, 70);
            }
            for (int i = 0; i < Bullet.Count; i++)
            {
                g.DrawImage(Bullet[i].img, Bullet[i].X, Bullet[i].Y, 50, 30);
            }
            if (FlagElevator1 == 1 || FlagElevator2 == 1)
            {
                g.DrawString("Press E to use the elevator.", new Font(FontFamily.GenericMonospace, 20, FontStyle.Bold),
                new SolidBrush(Color.Black), 600, Hero[0].Y - 50);
            }
            for (int i = 0; i < Axes.Count; i++)
            {
                g.DrawImage(Axes[i].ImgList[CountOFAxes], Axes[i].X, Axes[i].Y, 50, 50);
            }
            if (FLagEnemy1IsDead == 1)
            {
                ct++;
                if (ct == 1)
                    g.DrawImage(Enemy1DeadBody[0].img, Enemy1DeadBody[0].X, Enemy1DeadBody[0].Y, 100, 110);
            }
            if (FLagIsEnemy2Dead == 1)
            {
                ct2++;
                if (ct2 == 1)
                {
                    g.DrawImage(Enemy2DeadBody[0].img, Enemy2DeadBody[0].X, Enemy2DeadBody[0].Y, 100, 110);
                }
                
            }
        }
        void DrawDubbLevelOne(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawSceneLevelOne(g2);
            g.DrawImage(off, 0, 0);
        }
        void ShowStringToPlay(Graphics g)
        {
            g.Clear(Color.White);
            g.DrawString("Press Enter to start the game...", new Font(FontFamily.GenericMonospace, 20, FontStyle.Bold),
            new SolidBrush(Color.Black), 350, 600);
            g.DrawString("Welcome!", new Font(FontFamily.GenericMonospace, 200, FontStyle.Regular),
            new SolidBrush(Color.Black), 300, 350);
        }
        void DrawDubbWelcome(Graphics g)
        {
            Graphics g2 = this.CreateGraphics();
            WelcomeScreen(g2);
        }
        void WelcomeScreen(Graphics g)
        {
            g.Clear(Color.White);
            g.DrawString(TextTime, new Font(FontFamily.GenericMonospace, 50, FontStyle.Regular),
            new SolidBrush(Color.Black), 900, 600);
            g.DrawString("Welcome!", new Font(FontFamily.GenericMonospace, 200, FontStyle.Regular),
            new SolidBrush(Color.Black), 300, 350);
        }
    }
}
