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
        int NUM_CELLS = 10, CELL_SIZE_X = 108 , CELL_SIZE_Y = 72;
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
            foreach(KeyValuePair<int,int> entry in grid.Keys)
            {
                List <CollidableObject>currentCell = grid[entry];
                List<CollidableObject> leftCell;
                List<CollidableObject> rightCell;
                List<CollidableObject> topCell;
                List<CollidableObject> bottomCell;
                //left cell
                if (grid.ContainsKey(new KeyValuePair<int, int>(entry.Key - 1, entry.Value)))
                {
                    leftCell = grid[new KeyValuePair<int, int>(entry.Key - 1, entry.Value)];
                }
                else
                {
                    leftCell = new List<CollidableObject>();
                }
                //right cell
                if (grid.ContainsKey(new KeyValuePair<int, int>(entry.Key + 1, entry.Value)))
                {
                    rightCell = grid[new KeyValuePair<int, int>(entry.Key + 1, entry.Value)];
                }
                else
                {
                    rightCell = new List<CollidableObject>();
                }
                //top cell
                if (grid.ContainsKey(new KeyValuePair<int, int>(entry.Key, entry.Value - 1)))
                {
                    topCell = grid[new KeyValuePair<int, int>(entry.Key, entry.Value - 1)];
                }
                else
                {
                    topCell = new List<CollidableObject>();
                }
                //bottom cell
                if (grid.ContainsKey(new KeyValuePair<int, int>(entry.Key, entry.Value + 1)))
                {
                    bottomCell = grid[new KeyValuePair<int, int>(entry.Key, entry.Value + 1)];
                }
                else
                {
                    bottomCell = new List<CollidableObject>();
                }

                foreach(CollidableObject collidedObject in currentCell)
                {
                    foreach(CollidableObject collidableObjectleft in leftCell)
                    {
                        if()
                    }
                    foreach (CollidableObject collidableObjectright in rightCell)
                    {

                    }
                    foreach (CollidableObject collidableObjecttop in topCell)
                    {

                    }
                    foreach (CollidableObject collidableObjectbottom in bottomCell)
                    {

                    }
                }
            }
        }
    }
}
