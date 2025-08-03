using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//THIS CLASS CREATES THE SIGNS/ BUTTONS NEEDED FOR THE MAIN PAGE
namespace MiniProject
{
    internal class Sign
    {
        public RectangleShape appleSign;
        public RectangleShape orangeSign;
        public RectangleShape lemonSign;
        public RectangleShape exitSign;
        public Sign()
        {

            Texture appleTexture = new Texture("images\\appleSign.png");
            //The box shape
            appleSign = new RectangleShape(new Vector2f(287f, 81f));
            //set image
            appleSign.Texture = appleTexture;


            Texture orangeTexture = new Texture("images\\orangeSign.png");
            //The box shape
            orangeSign = new RectangleShape(new Vector2f(287f, 81f));
            //set image
            orangeSign.Texture = orangeTexture;

            Texture lemonTexture = new Texture("images\\lemonSign.png");
            //The box shape
            lemonSign = new RectangleShape(new Vector2f(287f, 81f));
            //set image
            lemonSign.Texture = lemonTexture;

            Texture exitTexture = new Texture("images\\exitSign.png");
            //The box shape
            exitSign = new RectangleShape(new Vector2f(287f, 81f));
            //set image
            exitSign.Texture = exitTexture;
        }

        

    }
}
