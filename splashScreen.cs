using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//THIS CLASS CREATES AND POSITIONS THE SPLASH SCREENS
namespace MiniProject
{
    internal class splashScreen
    {
        public RectangleShape background;
        public RectangleShape learnMode;
        public RectangleShape playMode;
        public RectangleShape exit;
        public RectangleShape replay;
        public RectangleShape play;

        int windowWidth = 1126;
        int windowHeight = 675;
        public splashScreen(int screen)
        {
            if (screen == 0)
            {
                GameMode();
                    
            }
            if (screen == 2)
            {
                GameOver();

            }


        }

        //GAMEOVER SPLASHSCREEN
        public void GameOver()
        {
            Texture backgroundTexture = new Texture("images\\gameOver.png");
            background = new RectangleShape(new Vector2f(679f, 679));
            background.Texture = backgroundTexture;

           
            background.Position = new Vector2f(windowWidth / 2 - background.Size.X / 2, windowHeight - background.Size.Y);
        }

        //GAME MODE SPLASH SCREEN
        public void GameMode()
        {
            Texture backgroundTexture = new Texture("images\\selectMode.png");
            background = new RectangleShape(new Vector2f(679f, 679));
            background.Texture = backgroundTexture;


            Texture learnTexture = new Texture("images\\learnButton.png");
            learnMode = new RectangleShape(new Vector2f(377f, 95));
            learnMode.Texture = learnTexture;

            Texture playTexture = new Texture("images\\altPlayButton.png");
            playMode = new RectangleShape(new Vector2f(377f, 95));
            playMode.Texture = playTexture;

            //Position
            background.Position = new Vector2f(windowWidth / 2 - background.Size.X / 2, windowHeight - background.Size.Y);
            learnMode.Position = new Vector2f(windowWidth / 2 - learnMode.Size.X / 2, background.Position.Y+250);
            playMode.Position = new Vector2f(windowWidth / 2 - playMode.Size.X / 2, background.Position.Y +400);       
           
        }

 
    }
}
