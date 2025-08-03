using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Diagnostics;
using System.Reflection.Metadata;
using System;
using System.Drawing;

namespace MiniProject
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Create an instance of the Program class
            MainWindow  mainWindow = new MainWindow();

            // Call the GameWindow method on the instance
            mainWindow.mainInteraction();          

            float boxSpeed = 200f; // Initial speed of bricks
            int caughtBoxCount = 0; // Counter for caught bricks
            float spawnInterval = 1f; // Interval in seconds for spawning new bricks
            float spawnTimer = 0f; // Timer for spawning bricks
            bool canSpawn = true; // Flag to check if a new brick can spawn

            Clock clock = new Clock(); // To manage time between frames

            /*
            while (window.IsOpen)
            {
                // Get the elapsed time
               // float deltaTime = clock.Restart().AsSeconds();

                // Update chef position based on mouse position
                Vector2i mousePosition = Mouse.GetPosition(window);
                //chef.Position = new Vector2f(Math.Clamp(mousePosition.X - chef.Size.X / 2, 0, 1700 - chef.Size.X), chef.Position.Y);
                // Process events

                // Render the game
                window.Clear();
                window.DispatchEvents();
                // Draw the background sprite
                window.Draw(backgroundSprite);
                //window.Draw(chef);
                //window.Draw(driver); // Draw the truck
               // window.Draw(appl)

                // Display the contents of the window
                window.Display();
            }
            */

        }

            static void UnloadBrick(List<RectangleShape> stackedBricks)
            {

                if (stackedBricks.Count == 0)
                {
                    Console.WriteLine("No bricks left to unload.");
                    return; // Exit the method early if there are no bricks
                }

                Console.WriteLine($"Before unload: {stackedBricks.Count} bricks in the list.");
                stackedBricks.RemoveAt(stackedBricks.Count - 1); // Remove the last stacked brick
                Console.WriteLine($"After unload: {stackedBricks.Count} bricks in the list.");
            }

       



    }
}
