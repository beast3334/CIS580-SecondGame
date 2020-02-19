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
    public class Grid
    {
        Game1 game;
        int NUM_CELLS = 20, CELL_SIZE_X = 54 , CELL_SIZE_Y = 36;
        Dictionary<KeyValuePair<int,int>, List<CollidableObject>> grid;
        public Grid(Game1 game)
        {
            this.game = game;

            grid = new Dictionary<KeyValuePair<int, int>, List<CollidableObject>>();
        }
        public void Add(CollidableObject data, Vector2 bounds)
        {
            KeyValuePair<int, int> value = new KeyValuePair<int, int>(((int)bounds.X / CELL_SIZE_X), ((int)bounds.Y / CELL_SIZE_Y));
            if (!grid.ContainsKey(value))
            {
                grid.Add(value, new List<CollidableObject> { data });
                
            }
            else
            {
                grid[value].Add(data);
            }
        }
        public void Remove(CollidableObject data, Vector2 bounds)
        {

        }
        public void Move(CollidableObject data, Vector2 oldbounds, Vector2 bounds)
        {
            KeyValuePair<int, int> oldValue = new KeyValuePair<int, int>((int)oldbounds.X / CELL_SIZE_X, (int)oldbounds.Y / CELL_SIZE_Y);
            KeyValuePair<int, int> newValue = new KeyValuePair<int, int>((int)bounds.X / CELL_SIZE_X, (int)bounds.Y / CELL_SIZE_Y);
            if(!oldValue.Equals(newValue))
            {
                grid[oldValue].Remove(data);
                Add(data, bounds);
            }
        }

        public void CheckCollisions()
        {
            foreach(List<CollidableObject> objectList in grid.Values)
            {
                for (int i = 0; i < objectList.Count; i++)
                {
                    for (int j = i + 1; j < objectList.Count; j++)
                    {
                        Rectangle Rect1 = objectList[i].RectBounds();
                        Rectangle Rect2 = objectList[j].RectBounds();
                        if(Rect1.Intersects(Rect2))
                        {
                            objectList[i].handleCollision(objectList[j]);
                            objectList[j].handleCollision(objectList[i]);
                            
                        }
                    }
                }
            }
        }
    }
}
