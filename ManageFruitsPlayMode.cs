using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MiniProject
{
    internal class ManageFruitsPlayMode
    {
        //FRUIT LISTS AND FRUIT DROP TRACKING   
        public List<Fruit> fruits = new List<Fruit>();
        public List<Fruit> deletedFruits = new List<Fruit>();
        public List<Fruit> fallingFruits = new List<Fruit>();

        //Last Fruit Falling Check
        public bool lastFruitFalling = false;

        //Checking previous fruit position
        Fruit previousFruit;
        
        float fallSpeed = 100f; // Initial speed of fruit

        public float spawnInterval = 1f; // Interval in seconds for spawning new fruit
        public float spawnTimer = 0f; // Timer for spawning fruit
        public bool canDrop = true; // Flag to check if a new fruit can spawn

        //Text and Font for score
        public SFML.Graphics.Text scoreText;
        public SFML.Graphics.Font font;
        public int score;

        // Traversal Ordrer
        public int[] traversalIndexes;
        public int removeFruitCounter = 0;

        //Music PLAYER 
        private Music soundEffect;

        int pleaseLord = 0;

        //THIS IS THE CONSTRUCTOR WHICH SETS FRUIT POSITION AND INTIALISES SOME OF THE CLASS VARIABLES
        public ManageFruitsPlayMode(int windowWidth, int selection)
        {
           
            //BINARYTREE
            int[] binaryTree = BinaryTree.GenerateBinaryTreeArray(15);
            //SET TRAVERSAL INDEXES BASED ON SELECTION           
            traversalIndexes = BinaryTree.generateTraversalIndexes(selection,  binaryTree);
            
            //TO ACCESS BINARY TREE WHEN MAKING PHYSICAL TREE
            int binaryTreeCounter = 0;

            //CREATE AND POSITION FRUIT
            int rows = 4;
            int top = 60;

            int screenWidth = ((windowWidth) / 2) - 30;
            int left = ((windowWidth) / 2) - 30;

            for (int i = 0; i < rows; i++) // Loop for rows
            {
                // Reset left to start position for the next row
                if (i == 0)
                {
                    left = screenWidth; 
                }
                else if (i == 1)
                {
                    left = screenWidth - 120;
                }
                else if (i == 2)
                {
                    left = screenWidth - 160; 
                }
                else
                {
                    left = screenWidth - 205; 
                }

                for (int j = 0; j < Math.Pow(2, i); j++) // Number of apples per row
                {
                    if (binaryTree[binaryTreeCounter] != -1) //if -1 do not print the fruit
                    {
                        // Create a new fruit (apple)
                        Fruit fruit = new Fruit(selection);
                        //PictureBox apple = makeApple.fruit;
                        fruits.Add(fruit);
                        // Set the position of the apple
                        fruit.fruit.Position = new Vector2f(left, top);
                    }
                    if (binaryTree[binaryTreeCounter] == -1) //if -1 do not print the fruit
                    {
                        // Create a new fruit (apple)
                        Fruit fruit = new Fruit(selection);
                        fruit.draw = false;
                        //PictureBox apple = makeApple.fruit;
                        fruits.Add(fruit);
                        // Set the position of the apple
                        fruit.fruit.Position = new Vector2f(left, top);
                    }

                    binaryTreeCounter++;

                    // Move  left position for the next apple in the row depending on row number

                    if (i == 0)
                    {
                        left = left + 200;
                    }
                    else if (i == 1)
                    {
                        left = left + 220;
                    }
                    else if (i == 2)
                    {
                        left = left + 110;
                    }
                    else
                    {
                        left = left + 60;
                    }
                }

               
                top = top + 65; // Increase top position for next row
                
            }
            

            //SET SCORE
            score = 0;

            //SET FONT
            font = new SFML.Graphics.Font("Fonts\\LoveDays.ttf");

            // Create  text object
            scoreText = new SFML.Graphics.Text("Score: "+score, font, 36); // Text content, font, and size
            scoreText.FillColor = Color.Black; // Set text color
            scoreText.Position = new Vector2f(0, 0); // Set text position

            
        } 
        
        //THIS METHOD IS USED  TO UPDATE POSITION OF FALLING FRUIT USING THE FALLINGFRUITLIST
        public void updateFruitPosition(float deltaTime)
        {
            foreach (var fruit in fallingFruits)
            {
                fruit.fruit.Position += new Vector2f(0f, fallSpeed * deltaTime);
            }
        }

       
        
        //THIS METHOD IS USED BY BOTH LEARN AND PLAY MODE TO CHECKS IF THE FALLING FRUIT HAS INTERSECTED WITH THE BASKET OR HAS GONE BELOW THE SCREEN & ADDS IT TO THE DELETED FRUIT LIST IF SO
        public void checkFallingFruit(int windowHeight, FloatRect basketBounds, bool learnMode)
        {
            if (fallingFruits.Count > 0)
            {

                foreach (Fruit fruit in fallingFruits)
                {
                    FloatRect fruitBounds = fruit.fruit.GetGlobalBounds();

                    // REMOVE FRUIT IF IT GOES OUT OF BOUNDS
                    if (fruit.fruit.Position.Y + fruit.fruit.Size.Y > windowHeight)  // Check if the fruit's bottom goes past the screen
                    {
                        if (fruit.deletedFruit == false)
                        {
                            PlayFailMusic();
                            deletedFruits.Add(fruit);  // Add to deleted list if fruit intersects basket
                            fruit.deletedFruit = true;
                            scoreText.DisplayedString = "Score: " + score;
                        }

                    }

                    // REMOVE FRUIT IF INTERSECTS WITH BASKET
                    if (fruitBounds.Intersects(basketBounds) && !fruit.isCaught)
                    {
                        fruit.isCaught = true;

                        if (fruit.deletedFruit == false)
                        {
                            PlaySuccessMusic();
                            deletedFruits.Add(fruit);  // Add to deleted list if fruit intersects basket
                            fruit.deletedFruit = true;
                            score = score + 10;
                            scoreText.DisplayedString = "Score: " + score;
                        }



                    }

                }
            }
           
        
        }

        /*THIS METHOD CHECKS IS THE CORRECT FRUIT WAS SELECTED FOR THE LEARN MODE THEN ADDS IT TO THE FALLINGFRUIT LIST TRUE, CHANGES THE FRUIT TEXTURE IF FALSE AND THE CONDITION OF THE LAST FRUIT
         */
        public void selectFruit(Vector2i mousePos)
        {
            
            if (removeFruitCounter < traversalIndexes.Length)
            {
                
                bool clickedOnFruit = false; //to detect if a fruit was clicked on
                bool fruitFound = false;
                for (int i = 0; i < fruits.Count; i++)
                {                                     
                    FloatRect fruitBounds = fruits[i].fruit.GetGlobalBounds();
                    if (fruitBounds.Contains(mousePos.X, mousePos.Y) && fruits[i].draw == true)
                    {
                        clickedOnFruit = true;

                        if (i == traversalIndexes[removeFruitCounter])
                        {
                            fruitFound = true;
                            PlaySuccessMusic();
                            fruits[i].fruit.Position += new Vector2f(0, fallSpeed * 1 / 60); // Move down based on frame rate
                            fallingFruits.Add(fruits[i]);
                            previousFruit = fruits[i];


                            //CHECK IF IT IS THE LAST FRUIT
                            if (i == traversalIndexes[traversalIndexes.Length - 1])
                            {
                                fallingFruits[fallingFruits.Count-1].lastFruit = true;
                            }

                            removeFruitCounter++;
                        }
                    }
                }
                if (!fruitFound && clickedOnFruit) 
                {
                    PlayFailMusic();
                    fruits[traversalIndexes[removeFruitCounter]].fruit.Texture = Fruit.badFruitTexture; //change the fruit to represent that the user has selected the wrong fruit
                    if (traversalIndexes[removeFruitCounter] == traversalIndexes[traversalIndexes.Length - 1]) //Check if this was the last fruit that was clicked on
                    {
                        fruits[traversalIndexes[removeFruitCounter]].badFruit_lastFruit = true; 
                    }
                    removeFruitCounter++;
                }
            }
            
        }

        //THIS METHOD CHECKS IF A GAME IS OVER 
        public bool gameOver()
        {
            bool isBadFruit = false;
            //check if the last fruit is in the deletedFruitList
            foreach (var fruit in deletedFruits)
            {
                if (fruit.lastFruit == true) { lastFruitFalling = true; }
            }

            //if the last fruit selected was a bad fruit
            foreach (var fruit in fruits)
            {
                if (fruit.badFruit_lastFruit == true) { isBadFruit = true; }
            }

            
            if (deletedFruits.Count == traversalIndexes.Length || removeFruitCounter == traversalIndexes.Length && lastFruitFalling ==true || removeFruitCounter == traversalIndexes.Length && isBadFruit == true)

            {
                MainWindow.backgroundMusic.Play();
                return true;
            }
            
            return false;
        }

        public void PlayFailMusic()
        {
            try
            {

                string filepath = "music\\fail.wav";
                soundEffect = new Music(filepath);
                soundEffect.Loop = false; // Set the music to loop
                soundEffect.Play();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void PlaySuccessMusic()
        {
            try
            {
                string filepath = "music\\success.wav";
                // Initialize SFML music
                soundEffect = new Music(filepath);
                soundEffect.Loop = false; // Set the music to loop
                soundEffect.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
