using System;
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
    public class PlayerBulletModel
    {
        private Texture2D texture;
        private Texture2D explodedTexture;

        public Texture2D Texture
        {
            get { return texture; }
        }
        public Texture2D ExplodedTexture
        {
            get { return explodedTexture; }
        }



        public PlayerBulletModel()
        {
        }
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("playerBullet");
            explodedTexture = content.Load<Texture2D>("explosion");
        }
    }
}
