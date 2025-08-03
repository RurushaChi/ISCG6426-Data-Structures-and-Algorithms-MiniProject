using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//THIS CLASS CREATES THE BASKET OBJECTS AND TAKES INPUT FROM THE MOUSE AND KEYS TO REPOSITION THE BASKET
namespace MiniProject
{
    class Basket
    {
        public RectangleShape basket;
        float  speed;
        public int windowWidth;
        public int windowHeight;
        public bool goLeft;
        public bool goRight;


        //BASKET CONSTRUCTOR - creates and positions basket
        public Basket(float playerSpeed, int windowWidth, int windowHeight)
        {
            speed = playerSpeed;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            goLeft = false;
            goRight = false;

            Texture basketTexture = new Texture("images\\basket.png");

            basket = new RectangleShape(new Vector2f(177f, 74));

            basket.Texture = basketTexture;
            
            basket.Position = new Vector2f(windowWidth / 2 - basket.Size.X / 2, windowHeight - 100);

        }

        //THIS METHOD REPOSITIONS THE BASKET BASED ON MOUSE MOVEMENTS
        public void mouseMovement(Vector2i mousePosition)
        {
            basket.Position = new Vector2f(Math.Clamp(mousePosition.X - basket.Size.X / 2, 0, windowWidth - basket.Size.X), basket.Position.Y);

            
        }

        //THIS METHOD REPOSITIONS THE BASKET BASED ON LEFT KEY PRESSED
        public void keyLeftPressed()
        {
            
            basket.Position = new Vector2f(Math.Clamp(basket.Position.X-speed,0, windowWidth - basket.Size.X),basket.Position.Y);
           
        }

        ///THIS METHOD REPOSITIONS THE BASKET BASED ON RIGHT KEY PRESSED
        public void keyRightPressed()
        {
            basket.Position = new Vector2f(Math.Clamp(basket.Position.X + speed, 0, windowWidth - basket.Size.X), basket.Position.Y);
            
        }
    }
}
