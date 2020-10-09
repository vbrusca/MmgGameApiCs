using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MmgGameApiCs
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager g;
        private SpriteBatch pen;

        private bool visible = true;
        private string name = "";

        public Game1()
        {
            g = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void setSize(int w, int h)
        {
            g.PreferredBackBufferWidth = w;
            g.PreferredBackBufferHeight = h;
            g.ApplyChanges();            
        }

        public void setResizable(bool b)
        {
            Window.AllowUserResizing = b;
        }

        public void setName(string n)
        {
            name = n;
        }

        public void setVisible(bool b)
        {
            visible = b;
        }

        public void setTitle(string s)
        {
            Window.Title = s;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            pen = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
