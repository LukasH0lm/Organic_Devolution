using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using System.Text;
using Pastel;

namespace Organic_Devolution;

public class GifDisplayer
{

    public void displayGif(string name, string color)
    {
        {
            Image image = Image.FromFile(@"../../../\gifs\" + name + ".gif");
            FrameDimension dimension = new FrameDimension(
                image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);
            StringBuilder sb;

            // Remember cursor position
            int left = Console.WindowLeft, top = Console.WindowTop;

            char[] chars = { '#', '#', '@', '%', '=', '+', 
                '*', ':', '-', '.', ' ' };
            for (int i = 0; ; i = (i + 1) % frameCount)
            {
                sb = new StringBuilder();
                image.SelectActiveFrame(dimension, i);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Color cl = ((Bitmap)image).GetPixel(w, h);
                        int gray = (cl.R + cl.G + cl.B) / 3;
                        int index = (gray * (chars.Length - 1)) / 255;

                        sb.Append(chars[index]);
                    }
                    sb.Append('\n');
                }

                Console.SetCursorPosition(left, top);
                if (color == "red")
                {
                    Console.Write(sb.ToString().Pastel(Color.Firebrick));
                }
                else
                {
                    Console.Write(sb.ToString());
                }

                System.Threading.Thread.Sleep(100);
            }
        }
    }
    
}