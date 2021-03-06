﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameWindowsStarter
{
    public class City: CollidableObject
    {
        Game1 game;
        Texture2D texture;
        BoundingRectangle bounds;
        bool isVisible = true;
        Grid grid;
        public City(Game1 game, int xBounds, CityModel model, ContentManager content, Grid grid)
        {
            this.game = game;
            bounds.X = xBounds;
            LoadContent(model, grid, content);
        }
        public override bool visiblity()
        {
            return isVisible;
        }
        public override Rectangle RectBounds()
        {
            return (Rectangle)bounds;
        }
        public bool IsVisible
        {
            get { return isVisible; }
        }
        public void LoadContent(CityModel cityModel, Grid grid, ContentManager content)
        {
            this.grid = grid;
            bounds.Width = 128;
            bounds.Height = 128;
            bounds.Y = game.GraphicsDevice.Viewport.Height - 128;
            texture = cityModel.Texture;
            grid.Add(this, new Vector2(bounds.X, bounds.Y));
        }
        
        public void Update(GameTime gameTime)
        {

        }
        public override void handleCollision(CollidableObject collidedObject)
        {
            if(collidedObject.GetType() == typeof(EnemyBullet))
            {
                EnemyBullet bullet = (EnemyBullet)collidedObject;
                if(bullet.IsVisible)
                {
                    isVisible = false;
                }

            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
        
    }
}
