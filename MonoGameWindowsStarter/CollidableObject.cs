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
    public abstract class CollidableObject
    {
        public abstract void handleCollision(CollidableObject collidableObject);
        public abstract Rectangle RectBounds();
    }
}
