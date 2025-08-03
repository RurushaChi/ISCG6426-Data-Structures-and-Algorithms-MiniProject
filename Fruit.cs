using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//THIS CLASS CREATES FRUIT OBJECT BASED ON USER SELECTION 
namespace MiniProject
{
    internal class Fruit
    {
        public RectangleShape fruit;
        //Check if fruit has been already caught
        public bool isCaught = false;
        //Check if the fruit has been deleted
        public bool deletedFruit = false;
        //Check if the fruit is the last fruit
        public bool lastFruit = false;
        //Check if the last fruit is a bad fruit
        public bool badFruit_lastFruit = false;
        //Texture
        public static Texture badFruitTexture;
        //Traversal type
        //static public int[] traversalType;
        public bool draw = true;

        
        public Fruit(int type) 
        {
            Texture texture;
            if (type == 1)
            {
                texture = new Texture("images\\apple.png");

                
                badFruitTexture = new Texture("images\\badApple.png");
            }
            else if (type == 2)
            {
                texture = new Texture("images\\orange.png");
                
                badFruitTexture = new Texture("images\\badOrange.png");
            }

            else 
            {
                texture = new Texture("images\\lemon.png");
                
                badFruitTexture = new Texture("images\\badlemon.png");
            }
           
            
            //The box shape
            fruit = new RectangleShape(new Vector2f(60f, 60));
            //set image

            
            fruit.Texture = texture;

        }


    }
}
