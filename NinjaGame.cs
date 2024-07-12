using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NinjaGame
{
    public class NinjaGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;

        // =======
        // Player Animation Block
        private Texture2D _playerTexture;
        private PlayerAnimationManager pam;
        // end of block
        // =======


        // =======
        // Player Animation Block
        private Texture2D _snakeTexture;
        private SnakeAnimationManager sam;
        // end of block
        // =======

        private Snake _snake;
        public NinjaGame()
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
            // Player Creation Block
            _playerTexture = Content.Load<Texture2D>("SpriteSheet");
            _player = new Player("Mu", new EntityStats(1, 1, 1), new Vector2(100, 100), _playerTexture);
            pam = new(_player, 4, new Vector2(16, 16));

            // End of Block
            // =======

            // =======
            // Snake Creation Block
            _snakeTexture = Content.Load<Texture2D>("Snake");
            _snake = new Snake("Puu", new EntityStats(1, 1, 1), new Vector2(200, 50), _snakeTexture, _player);
            sam = new(_snake, 4, new Vector2(16, 16));

            // End of Block
            // =======

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // =======
            // Player Block
            pam.Update();
            _player.Update(gameTime);
            // End of Block
            // =======

            // =======
            // Snack Block
            sam.Update();
            _snake.Update(gameTime);
            // End of Block
            // =======


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // =======
            // SpriteBatch Drawing Block
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _spriteBatch.Draw(
                _player.texture,
                _player.Rect,
                pam.GetFrame(),
                Color.White
                );

            _spriteBatch.Draw(
                _snake.texture,
                _snake.Rect,
                sam.GetFrame(),
                Color.White 
                );

            _spriteBatch.End();
            // end of block
            // =======

            base.Draw(gameTime);
        }
    }
}
