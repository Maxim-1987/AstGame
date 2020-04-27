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
        private static Bullet __Bullet;
        private static SpaceShip __SpaceShip;

        /// <summary>Ширина игрового поля</summary>
        public static int Width { get; private set; }

        /// <summary>Высота игрового поля</summary>
        public static int Height { get; private set; }

        /// <summary>Инициализация игровой логики</summary>
        /// <param name="form">Игровая форма</param>
        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;
            if (Width < 0 || Height < 0)
                throw new ArgumentOutOfRangeException("Ширина и длина игрового поля не должны быть отрицательными");
            if (Width > 1000 || Height > 1000)
                throw new ArgumentOutOfRangeException("Ширина и длина игрового поля не должны принимать значение больше 1000");
            
            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = __TimerInterval };
            timer.Tick += OnVimerTick;
            timer.Start();
        }
        private static void OnVimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }
        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var game_object in __GameObjects)
                game_object?.Draw(g);
            
            __Bullet?.Draw(g);

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
            var rnd = new Random();
            const int asteroid_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;
            for (var i = 0; i < asteroid_count; i++)
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0),
                    asteroid_size));

            game_objects.Add(new Asteroid(new Point(Width/2, 200), new Point(-asteroid_max_speed, 0), asteroid_size));

            __Bullet = new Bullet(200);
            __GameObjects = game_objects.ToArray();
        }
        public static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object?.Update();

            __Bullet?.Update();
            if (__Bullet is null || __Bullet.Rect.Left > Width)
            {
                var rnd = new Random();
                __Bullet = new Bullet(rnd.Next(0, Height));
            }

            for (var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    if (__Bullet != null)
                        if (__Bullet.CheckCollision(collision_object))
                        {
                            __Bullet = null;
                            __GameObjects[i] = null;
                            System.Media.SystemSounds.Beep.Play();
                        }
                }
            }
        }
    }
}
