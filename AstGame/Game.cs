using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsteroidGame.VisualObjects;

namespace AsteroidGame
{
    /// <summary>Класс игровой логики</summary>
    internal static class Game
    {
        /// <summary>Интервал времени таймера формирования кадра игры</summary>
        private const int __TimerInterval = 100;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects;
        private static readonly List<Bullet> __Bullets = new List<Bullet>();
        private static SpaceShip __SpaceShip;
        private static MedicineChest __MedicineChest;
        private static Timer __Timer;
        private static Random rnd;
        private delegate void Logger(string str);
        private static Logger __Logger;
        public static int Score { get; set; } = -1;

        /// <summary>Ширина игрового поля</summary>
        public static int Width { get; private set; }

        /// <summary>Высота игрового поля</summary>
        public static int Height { get; private set; }

        /// <summary>Инициализация игровой логики</summary>
        /// <param name="form">Игровая форма</param>
        public static void Initialize(Form form)
        {
            rnd = new Random();
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            __Timer = new Timer { Interval = __TimerInterval };
            __Timer.Tick += OnVimerTick;
            __Timer.Start();

            form.KeyDown += OnFormKeyDown;
        }

        private static void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    __Bullets.Add(new Bullet(__SpaceShip.Rect.Y));
                    break;

                case Keys.Up:
                    __SpaceShip.MoveUp();
                    break;

                case Keys.Down:
                    __SpaceShip.MoveDown();
                    break;
            }
        }

        private static void OnVimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Draw()
        {
            if (__SpaceShip.Energy <= 0) return;

            Graphics g = __Buffer.Graphics;

            g.Clear(Color.Black);

            foreach (var game_object in __GameObjects)
                game_object?.Draw(g);

            __SpaceShip.Draw(g);
            __Bullets.ForEach(bullet => bullet.Draw(g));

            g.DrawString( $"Energy: {__SpaceShip.Energy}, Score: {Score}",
                new Font(FontFamily.GenericSerif, 14, FontStyle.Italic),
                Brushes.White,
                10,
                Game.Height - 70);

            if (!__Timer.Enabled) return;
            __Buffer.Render();
        }

        public static void Load()
        {            
            List<VisualObject> game_objects = new List<VisualObject>();

            for (var i = 0; i < 10; i++)
            {
                game_objects.Add(new Star(
                    new Point(600, (int)(i / 2.0 * 20)),
                    new Point(-i, 0),
                    10));
            }
            
            const int asteroid_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;
            for (var i = 0; i < asteroid_count; i++)
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0),
                    asteroid_size));

            const int med_count = 10;
            for (var i = 0; i < med_count; i++)
            {
                game_objects.Add(__MedicineChest = new MedicineChest(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(1, asteroid_max_speed), 0),
                    new Size(30, 30)));
            }

            game_objects.Add(new Asteroid(new Point(Width / 2, 200), new Point(-asteroid_max_speed, 0), asteroid_size));
            
            __GameObjects = game_objects.ToArray();

            __SpaceShip = new SpaceShip(new Point(10, 400), new Point(5, 5), new Size(10, 10));
            __SpaceShip.Destroyed += OnShipDestroyed;
            __Logger += LoggerConsole;
            __Logger += LoggerFile;
        }

        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            g.Clear(Color.DarkBlue);
            g.DrawString("Game over!!!", new Font(FontFamily.GenericSerif, 60, FontStyle.Bold), Brushes.Red, 200, 100);
            __Logger("Игра окончена");
            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object?.Update();

            __Bullets.ForEach(b => b.Update());

            foreach (var bullet_to_remove in __Bullets.Where(b => b.Rect.Left > Width).ToArray())
                __Bullets.Remove(bullet_to_remove);

            for (var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;

                    __SpaceShip.CheckCollision(collision_object);
                    __MedicineChest.CheckCollision(collision_object);

                    foreach (var bullet in __Bullets.ToArray())
                    {
                        if (bullet.CheckCollision(collision_object))
                        {
                            Score++;
                            __Logger("Сбит объект");
                            __Bullets.Remove(bullet);
                            __GameObjects[i] = null;
                            System.Media.SystemSounds.Beep.Play();
                            __Logger("Астероид уничтожен");
                        }
                        if (__SpaceShip.CheckCollision(collision_object) && collision_object is MedicineChest medicinechest)
                        {
                            __GameObjects[i] = null;
                        }
                    }                        
                }
            }
        }
        private static void LoggerConsole(string v)
        {
            Console.WriteLine("{v}");
        }
        private static void LoggerFile(string message)
        {
            System.IO.File.AppendAllText("console.txt", $"{message}\r\n");
        }
    }
}
