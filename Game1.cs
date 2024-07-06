using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaGame.Content;

namespace NinjaGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Entity _player;

        // look to condense these variables into one struct
        private Texture2D _playerTexture;
        private int counter;
        private int activeFrame;
        private int numFrames;
        private int PLAYER_LENGTH = 16;
        private int PLAYER_WIDTH = 16;

        private PlayerAnimationManager pam;
        // ========

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // =======
            // player animation block
            _playerTexture = Content.Load<Texture2D>("SpriteSheet");
            counter = 0;
            activeFrame = 0;
            numFrames = 4;
            _player = new Player("Mu", 1, 1, new Vector2(100, 100), _playerTexture);
            pam = new(_player, 4, new Vector2(16, 16));

            // end of block
            // =======
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // =======
            // player animation block
            /*
            counter++;
            if (counter > 29)
            {
                counter = 0;
                activeFrame++;

                if (activeFrame == numFrames)
                {
                    activeFrame = 0;
                }
            }
            */

            pam.Update();
            // end of block
            // =======

            _player.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // =======
            // SpriteBatch Drawing block
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _spriteBatch.Draw(
                _player.texture,
                _player.Rect,
                //new Rectangle(0, activeFrame * PLAYER_LENGTH, 16, 16),
                pam.GetFrame(),
                Color.White
                );

            _spriteBatch.End();
            // end of block
            // =======

            base.Draw(gameTime);
        }
    }
}
