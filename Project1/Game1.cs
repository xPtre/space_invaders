using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D _PlayerTex;
        Texture2D _LaserTex;

        GameObject _Player;
        List<GameObject> lasers = new List<GameObject>();

        void Input(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _Player.Rotation -= 5 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _Player.Rotation += 5 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            _Player.IsAccelerating = Keyboard.GetState().IsKeyDown(Keys.Up);
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                GameObject tempLaser = new GameObject();
                tempLaser.Positions = _Player.Positions;
                tempLaser.Texture = _LaserTex;
                tempLaser.Rotation = _Player.Rotation;
                tempLaser.Velocity = new Vector2(
                    MathF.Cos(tempLaser.Rotation),
                    MathF.Sin(tempLaser.Rotation)) * 2000;
                lasers.Add(tempLaser);

            }



        }


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _PlayerTex = Content.Load<Texture2D>("playerShip1_blue");
            _LaserTex = Content.Load<Texture2D>("laserBlue02");


            _Player = new GameObject();
            _Player.Texture = _PlayerTex;
            _Player.Positions = new Vector2(960, 800);
            _Player.Velocity = new Vector2(0, 0);
            _Player.Rotation = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            Input(gameTime);
            if (_Player.IsAccelerating)
            {
                _Player.Velocity += new Vector2(
                MathF.Cos(_Player.Rotation),
                MathF.Sin(_Player.Rotation)) * 10;
            }

            _Player.Positions += _Player.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int a = 0; a < lasers.Count; a++)
            {
                lasers[a].Positions += lasers[a].Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _Player.Draw(_spriteBatch, gameTime);

            for (int a = 0; a < lasers.Count; a++)
            {
                lasers[a].Draw(_spriteBatch, gameTime);
            }



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
