using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaGame.Content;

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
        // ========

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
            // Player Animation Block
            _playerTexture = Content.Load<Texture2D>("SpriteSheet");
            pam = new(_player, 4, new Vector2(16, 16));

            // End of Block
            // =======
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // =======
            // Player Animation Block

            pam.Update();
            // End of Block
            // =======

            _player.Update(gameTime);


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

            _spriteBatch.End();
            // end of block
            // =======

            base.Draw(gameTime);
        }
    }
}
