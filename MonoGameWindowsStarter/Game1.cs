using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        CityModel cityModel;
        EnemyModel enemyModel;
        Grid grid;
        List<City> citiesList = new List<City>(); //to change later for spacial pattern
        List<EnemyBullet> bulletList = new List<EnemyBullet>();
        MouseCursor mouseCursor;
        bool playing = true;
        SpriteFont scoreFont;
        SpriteFont gameOverFont;
        public int score;
        double enemySpawnTimer = 0;
        Random random;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            player = new Player(this);
            cityModel = new CityModel();
            enemyModel = new EnemyModel();
            mouseCursor = new MouseCursor(this);

            random = new Random();
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1080;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            grid = new Grid(this);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            player.LoadContent(Content, grid);
            cityModel.LoadContent(Content);
            enemyModel.LoadContent(Content);
            mouseCursor.LoadContent(Content);
            scoreFont = Content.Load<SpriteFont>("scoreFont");
            gameOverFont = Content.Load<SpriteFont>("gameOverFont");
            for (int i = 0; i < 4; i++)
            {
                citiesList.Add(new City(this, i * 300, cityModel, Content, grid));
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (playing)
            {

                grid.CheckCollisions();
                enemySpawnTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                player.Update(gameTime);
                mouseCursor.Update(gameTime);

                if (enemySpawnTimer > 2000)
                {
                    enemySpawnTimer = 0;
                    bulletList.Add(new EnemyBullet(this, enemyModel, Content, random, grid));
                }

                for (int i = bulletList.Count - 1; i >= 0; i--)
                {
                    bulletList[i].Update(gameTime);
                    if (!bulletList[i].IsVisible)
                    {
                        bulletList.RemoveAt(i);
                    }
                }
                if (citiesList.Count == 0)
                {
                    playing = false;
                }
                for (int i = citiesList.Count - 1; i >= 0; i--)
                {
                    if (!citiesList[i].IsVisible)
                    {
                        citiesList.RemoveAt(i);
                    }
                }
                grid.CheckCollisions();
                grid.clean();
            }
            else
            {
                score = 0;
                int i = 0;
                bulletList.Clear();
                grid.Reset();
                while(citiesList.Count < 5)
                {
                    citiesList.Add(new City(this, i * 300,cityModel,Content, grid));
                    i++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    playing = true;
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.TransparentBlack);
            spriteBatch.Begin();
            if (playing)
            {
                spriteBatch.DrawString(scoreFont, "Score: " + score, new Vector2(0, 0), Color.White);
                mouseCursor.Draw(spriteBatch);
                player.Draw(spriteBatch);
                foreach (City city in citiesList)
                {
                    city.Draw(spriteBatch);
                }
                foreach (EnemyBullet bullet in bulletList)
                {
                    bullet.Draw(spriteBatch);
                }
            }
            else
            {
                spriteBatch.DrawString(gameOverFont, "Game Over: Press Spacebar to Play Again", new Vector2(400, 360), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
