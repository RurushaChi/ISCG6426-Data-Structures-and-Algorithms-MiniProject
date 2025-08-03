using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace MiniProject
{
    internal class MainWindow
    {
        private Sprite backgroundSprite;
        RenderWindow window;

        Sign sign;
        RectangleShape appleSign;
        RectangleShape orangeSign;
        RectangleShape lemonSign;
        RectangleShape exitSign;

        bool appleSignSelected = false;
        bool lemonSignSelected = false;
        bool orangeSignSelected = false;
        bool signSelected = false;

        splashScreen splashScreen;

        //MUSIC PLAYER 
        static public Music backgroundMusic;

        //CONSTRUCTOR
        public MainWindow()
        {
            PlayIntroMusic();
            window = new RenderWindow(new VideoMode(1126, 675), "Fruit Drop");
            Texture backgroundTexture = new Texture("images\\MainGameBackGround.png");

            window.Closed += (sender, e) => window.Close();

            backgroundSprite = new Sprite(backgroundTexture);

            Sign sign = new Sign();

            appleSign = sign.appleSign;
            appleSign.Position = new Vector2f(317f, 259);

            orangeSign = sign.orangeSign;
            orangeSign.Position = new Vector2f(509f, 365);

            lemonSign = sign.lemonSign;
            lemonSign.Position = new Vector2f(305f, 465);

            exitSign = sign.exitSign;
            exitSign.Position = new Vector2f(524f, 567);

            splashScreen = new splashScreen(0);
        }

        //MAIN GAME INTERACTION
        public void mainInteraction()
        {
            window.MouseButtonPressed += OnMouseButtonPressed;

            Clock clock = new Clock();

            while (window.IsOpen)
            {
                Vector2i mousePosition = Mouse.GetPosition(window);

                window.DispatchEvents();

                window.Clear();

                window.Draw(backgroundSprite);
                window.Draw(lemonSign);
                window.Draw(appleSign);
                window.Draw(orangeSign);
                window.Draw(exitSign);

                if (signSelected == true)
                {
                    window.Draw(splashScreen.background);
                    window.Draw(splashScreen.playMode);
                }

                window.Display();
            }
        }

        //CHECKING CLICK EVENTS
        private void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                Vector2i mousePos = Mouse.GetPosition(window);

                if (!signSelected)
                {
                    CheckSignSelection(mousePos);
                }
                else
                {
                    CheckModeSelection(mousePos);
                }
            }
        }

        //SIGN SELECTION LOGIC
        private void CheckSignSelection(Vector2i mousePos)
        {
            FloatRect appleBounds = appleSign.GetGlobalBounds();
            FloatRect exitBounds = exitSign.GetGlobalBounds();
            FloatRect lemonBounds = lemonSign.GetGlobalBounds();
            FloatRect orangeBounds = orangeSign.GetGlobalBounds();

            if (appleBounds.Contains(mousePos.X, mousePos.Y))
            {
                appleSignSelected = true;
                signSelected = true;
            }
            else if (orangeBounds.Contains(mousePos.X, mousePos.Y))
            {
                signSelected = true;
                orangeSignSelected = true;
            }
            else if (lemonBounds.Contains(mousePos.X, mousePos.Y))
            {
                signSelected = true;
                lemonSignSelected = true;
            }
            else if (exitBounds.Contains(mousePos.X, mousePos.Y))
            {
                window.Close();
            }
        }

        //MODE SELECTION (previously seperated the game by learn and play mode)
        private void CheckModeSelection(Vector2i mousePos)
        {
            FloatRect playModeButton = splashScreen.playMode.GetGlobalBounds();

            if (playModeButton.Contains(mousePos.X, mousePos.Y))
            {
                bool learnMode = false; // No longer needed
                LaunchGame(learnMode);
            }
        }

        //LAUNCH GAME
        private void LaunchGame(bool learnMode)
        {
            if (appleSignSelected)
            {
                PlayWindow appleGame = new PlayWindow(1, learnMode);
                appleGame.playInteractionPlayMode();
            }
            else if (orangeSignSelected)
            {
                PlayWindow orangeGame = new PlayWindow(2, learnMode);
                orangeGame.playInteractionPlayMode();
            }
            else if (lemonSignSelected)
            {
                PlayWindow lemonGame = new PlayWindow(3, learnMode);
                lemonGame.playInteractionPlayMode();
            }

            ResetSelectionFlags();
        }

        //RESET FLAGS
        private void ResetSelectionFlags()
        {
            appleSignSelected = false;
            orangeSignSelected = false;
            lemonSignSelected = false;
            signSelected = false;
        }

        //PLAY INTRO MUSIC
        public static void PlayIntroMusic()
        {
            try
            {
                string filepath = "music\\backgroundMusic.wav";
                backgroundMusic = new Music(filepath);
                backgroundMusic.Loop = true;
                backgroundMusic.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
