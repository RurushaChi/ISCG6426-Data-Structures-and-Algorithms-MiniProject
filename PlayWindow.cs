using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
//THIS CLASS RUNS THE GAME
namespace MiniProject
{
    internal class PlayWindow
    {
        private Sprite backgroundSprite;
        RenderWindow window;

        int windowWidth= 1126;
        int windowHeight=675;

        //USER GAME TYPE SELECTION
        int selection;

        //BASKET-PADDLE
        Basket basket;
        float playerSpeed = 0.1f;

        //FRUIT MANAGEMENT
        ManageFruitsPlayMode manageFruits;

        //LEARN OR PLAY MODE
        bool learnMode;

        //GameOver SPLASHSCREEN
        bool gameOver=false;
        splashScreen gameOverSplashScreen;

        //FINAL SCORE TEXT
        SFML.Graphics.Text finalScoreText;

        

        //THIS CONSTRUCTOR CREATES THE WINDOW AND INITIALISES SOME OF THE CLASS ATTRIBUTES
        public PlayWindow(int selection, bool learnMode)
        {
            MainWindow.backgroundMusic.Stop();
            
            //INITIALISE MODE
            this.learnMode = learnMode;
            //get user selection
            this.selection = selection;
            
            //Make window
            window = new RenderWindow(new VideoMode(1126, 675), "Fruit Drop");
            // Load background image
            Texture backgroundTexture = new Texture("images\\GameBackGround.png");

            //WINDOW CLOSE EVENT 
            window.Closed += (sender, e) => window.Close();

            // Sprite for the background image
            backgroundSprite = new Sprite(backgroundTexture);

            //CREATE BASKET OBJECT
            basket = new Basket(playerSpeed, windowWidth, windowHeight);

            //MANAGE FRUIT GAME
            manageFruits = new ManageFruitsPlayMode(windowWidth,selection);

            //GAMEOVER SPLASH SCREEN

            gameOverSplashScreen = new splashScreen(2);

            // Create a text object
            finalScoreText = new SFML.Graphics.Text("Score: " + manageFruits.score, manageFruits.font, 100); 
            finalScoreText.FillColor = Color.White; 
            finalScoreText.Position = new Vector2f((windowWidth/2)-180, (windowHeight/ 2));
        }

        //THIS METHOD LOADS THE LEARN MODE OF THE GAME
        public void playInteractionPlayMode()
        {
           
            Clock clock = new Clock(); // To manage time between frames
            
            //TO SELECT FRUIT
            window.MouseButtonPressed += (sender, e) =>
            {
                 if (e.Button == Mouse.Button.Left) // Check for left click
                 {
                  // Mouse position relative to the window
                  Vector2i mousePos = Mouse.GetPosition(window);
                  manageFruits.selectFruit(mousePos);
                 }

            };
            

            while (window.IsOpen)
            {
                // Handle events
                window.DispatchEvents();


                if (gameOver == false)
                {
                    //BASKET MOVEMENTS                 
                    Vector2i mousePosition = Mouse.GetPosition(window);// Check if the mouse is outside the window  
                    bool isMouseInsideWindow = mousePosition.X >= 0 && mousePosition.X <= window.Size.X && mousePosition.Y >= 0 && mousePosition.Y <= window.Size.Y;

                    if (isMouseInsideWindow)// If the mouse is inside the window use mouse for basket
                    {                       
                        basket.mouseMovement(mousePosition);
                    }

                    // Move basket left or right based on key presses if the mouse is outside the window
                    if (!isMouseInsideWindow)
                    {
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                        {
                            basket.keyLeftPressed(); // Move left
                        }

                        if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                        {
                            basket.keyRightPressed(); // Move right
                        }
                    }
                    // Spawn new fruit at regular intervals
                    // Get the elapsed time
                    float deltaTime = clock.Restart().AsSeconds();

                    // UPDATE FRUIT POSTION AS IT IS FALLING DOWN
                    manageFruits.updateFruitPosition(deltaTime);
                    manageFruits.spawnTimer += deltaTime;
                    
                    //CHECK FALLING FRUIT
                    //Global bounds of basket to check if it intersects with the falling fruit bounds
                    FloatRect basketBounds = basket.basket.GetGlobalBounds();
                    manageFruits.checkFallingFruit(windowHeight, basketBounds, learnMode);

                    gameOver = manageFruits.gameOver();
                }

                //CLEAR THE WINDOW
                window.Clear();

                //DRAW OBJECTS         
                //background sprite
                window.Draw(backgroundSprite);

                //fruit
                foreach (var fruit in manageFruits.fruits)
                {
                    if (!manageFruits.deletedFruits.Contains(fruit) && fruit.draw!=false)
                    {
                        window.Draw(fruit.fruit);
                    }
                }
                //basket-paddle
                window.Draw(basket.basket);

                if (gameOver == false)
                {
                    window.Draw(manageFruits.scoreText);
                }

                if (gameOver == true)
                {
                    finalScoreText.DisplayedString = "Score: " + manageFruits.score;
                    window.Draw(gameOverSplashScreen.background);
                    window.Draw(finalScoreText);
                }
                //DISPLAY WINDOW ITEMS
                window.Display();
            }
        }

    }

}



