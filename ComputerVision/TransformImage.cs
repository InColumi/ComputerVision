using System;
using System.Collections.Generic;
using System.Drawing;

namespace ComputerVision
{
    class TransformImage
    {
        private Bitmap _bitImage;
        public Image ImageInput { get; private set; }
        public int WidthImage { get; private set; }
        public int HeightImage { get; private set; }
        public int Size { get; private set; }

        public TransformImage(Image imageInput)
        {
            ImageInput = imageInput;
            WidthImage = imageInput.Width;
            HeightImage = imageInput.Height;
            Size = WidthImage * HeightImage;
            _bitImage = new Bitmap(ImageInput);
        }

        private int GetMin(int number)
        {
            return (number > 255) ? 255 : number;
        }

        private byte GetR(Color color)
        {
            return color.R;
        }

        private byte GetG(Color color)
        {
            return color.G;
        }

        private byte GetB(Color color)
        {
            return color.G;
        }

        private Dictionary<int, uint> GetDictionaryColor(Func<Color, byte> myMethodName)
        {
            uint countColors = 255;
            Dictionary<int, uint> color = new Dictionary<int, uint>();
            for (int i = 0; i <= countColors; i++)
            {
                color.Add(i, 0);
            }

            for (int i = 0; i < WidthImage; i++)
            {
                for (int j = 0; j < HeightImage; j++)
                {
                    color[myMethodName(_bitImage.GetPixel(i, j))]++;
                }
            }

            return color;
        }

        public Dictionary<int, uint> GetDictionaryColoRed()
        {
            return GetDictionaryColor(GetR);
        }

        public Dictionary<int, uint> GetDictionaryColorGreen()
        {
            return GetDictionaryColor(GetG);
        }

        public Dictionary<int, uint> GetDictionaryColorBlue()
        {
            return GetDictionaryColor(GetB);
        }

        public Dictionary<int, uint> GetDictionaryAllColors()
        {
            Dictionary<int, uint> allColors = new Dictionary<int, uint>();
            Dictionary<int, uint> colorR = GetDictionaryColoRed();
            Dictionary<int, uint> colorG = GetDictionaryColorGreen();
            Dictionary<int, uint> colorB = GetDictionaryColorBlue();
            uint countColors = 255;
            for (int i = 0; i <= countColors; i++)
            {
                allColors.Add(i, colorR[i] + colorG[i] + colorB[i]);
            }

            return allColors;
        }

        public Image GetGrayPhoto()
        {
            Bitmap result = new Bitmap(_bitImage);
            Color pixel;
            int grayColor;
            //int grayColor2;
            for (int i = 0; i < WidthImage; i++)
            {
                for (int j = 0; j < HeightImage; j++)
                {
                    pixel = _bitImage.GetPixel(i, j);
                    grayColor = Convert.ToInt16(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    //grayColor2 = Convert.ToInt16((pixel.R + pixel.G + pixel.B) / 3.0);
                    result.SetPixel(i, j, Color.FromArgb(grayColor, grayColor, grayColor));
                    //imageGray2.SetPixel(i, j, Color.FromArgb(grayColor, grayColor, grayColor));
                }
            }
            return result;
        }

        public Color GetAverageColor(Bitmap bitImage)
        {
            int countR = 0;
            int countG = 0;
            int countB = 0;

            int width = bitImage.Width;
            int heigth = bitImage.Height;

            Color pixel;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    pixel = bitImage.GetPixel(i, j);
                    countR += pixel.R;
                    countG += pixel.G;
                    countB += pixel.B;
                }
            }

            return Color.FromArgb(countR / Size, countG / Size, countB / Size);
        }

        public Image GetTransformGrayWorld()
        {
            Bitmap result = new Bitmap(_bitImage);
            Color averageColor = GetAverageColor(_bitImage);

            double avg = (averageColor.R + averageColor.G + averageColor.B) / 3.0;
            
            double avgR = avg / averageColor.R;
            double avgG = avg / averageColor.G;
            double avgB = avg / averageColor.B;

            Color pixel;
            int minR = 0;
            int minG = 0;
            int minB = 0;
            for (int i = 0; i < WidthImage; i++)
            {
                for (int j = 0; j < HeightImage; j++)
                {
                    pixel = _bitImage.GetPixel(i, j);
                    minR = GetMin(Convert.ToInt16(pixel.R * avgR));
                    minG = GetMin(Convert.ToInt16(pixel.G * avgG));
                    minB = GetMin(Convert.ToInt16(pixel.B * avgB));
                    result.SetPixel(i, j, Color.FromArgb(minR, minG, minB));
                }
            }

            return result;
        }

        public Image GetTransformToMainColor(Bitmap sourse)
        {
            Bitmap result = new Bitmap(_bitImage);
            Color averageColorSouse = GetAverageColor(_bitImage);
            Color averageColorDestination = GetAverageColor(sourse);

            double aveR = averageColorDestination.R / Convert.ToDouble(averageColorSouse.R);
            double aveG = averageColorDestination.G / Convert.ToDouble(averageColorSouse.G);
            double aveB = averageColorDestination.B / Convert.ToDouble(averageColorSouse.B);

            int minR = 0;
            int minG = 0;
            int minB = 0;
            Color pixel;
            for (int i = 0; i < WidthImage; i++)
            {
                for (int j = 0; j < HeightImage; j++)
                {
                    pixel = _bitImage.GetPixel(i, j);
                    minR = GetMin(Convert.ToInt16(pixel.R * aveR));
                    minG = GetMin(Convert.ToInt16(pixel.G * aveG));
                    minB = GetMin(Convert.ToInt16(pixel.B * aveB));
                    result.SetPixel(i, j, Color.FromArgb(minR, minG, minB));
                }
            }
            return result;
        }
    }
}
