using System;
using System.Drawing;

namespace ComputerVision
{
    class TransformImage
    {
        private Bitmap _bitImage;
        private int _countColors;
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
            _countColors = 256;
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

        private int[] GetColors(Func<Color, byte> myMethodName)
        {
            int[] colors = new int[_countColors];

            for (int i = 0; i < WidthImage; i++)
            {
                for (int j = 0; j < HeightImage; j++)
                {
                    colors[myMethodName(_bitImage.GetPixel(i, j))]++;
                }
            }

            return colors;
        }

        public int[] GetColorRed()
        {
            return GetColors(GetR);
        }

        public int[] GetColorGreen()
        {
            return GetColors(GetG);
        }

        public int[] GetColorBlue()
        {
            return GetColors(GetB);
        }

        public int[] GetAllColors()
        {
            int[] allColors = new int[_countColors];
            int[] colorR = GetColorRed();
            int[] colorG = GetColorGreen();
            int[] colorB = GetColorBlue();
            for (int i = 0; i < _countColors; i++)
            {
                allColors[i] = colorR[i] + colorG[i] + colorB[i];
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
            int size = width * heigth;
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

            return Color.FromArgb(countR / size, countG / size, countB / size);
        }

        public Image GetGrayWorld()
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

        public Image GetTransformToMainColor(Bitmap destination)
        {
            Bitmap result = new Bitmap(_bitImage);
            Color averageColorSouse = GetAverageColor(_bitImage);
            Color averageColorDestination = GetAverageColor(destination);

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

        public Image GetTransformByFunction()
        {
            return null;
        }

        public Bitmap GetNormalizationPhoto()
        {
            Bitmap grayPhoto = new Bitmap(GetGrayPhoto());
            TransformImage transformImage = new TransformImage(grayPhoto);
            var colors = transformImage.GetColorRed();

            int min = 0;
            int max = 0;
            for (int i = 0; i < _countColors; i++)
            {
                if (colors[i] != 0)
                {
                    min = i;
                    break;
                }
            }

            for (int i = _countColors - 1; i >= 0; i--)
            {
                if (colors[i] != 0)
                {
                    max = i;
                    break;
                }
            }

            int newMin = 0;
            int newMax = 255;
            double normalizationFactor = (newMax - newMin) / (double)(max - min);
            int newColor;
            Bitmap result = new Bitmap(WidthImage, HeightImage);
            for (int i = 0; i < WidthImage; i++)
            {
                for (int j = 0; j < HeightImage; j++)
                {
                    newColor = grayPhoto.GetPixel(i, j).R - min;
                    newColor = (newColor < 0) ? 0 : newColor;

                    newColor = Convert.ToInt32(newColor * normalizationFactor) + newMin;

                    newColor = (newColor > 255) ? 255 : newColor;
                    result.SetPixel(i, j, Color.FromArgb(newColor, newColor, newColor));
                }
            }
            return result;
        }

        public Bitmap GetEqualizationPhoto()
        {
            Bitmap grayPhoto = new Bitmap(GetGrayPhoto());
            TransformImage transformImage = new TransformImage(grayPhoto);
            var colors = transformImage.GetColorRed();
            int[] equalizationValues = new int[_countColors];

            equalizationValues[0] = colors[0];
            for (int i = 1; i < _countColors; i++)
            {
                equalizationValues[i] += equalizationValues[i - 1] + colors[i];
            }

            int newColor;
            Bitmap result = new Bitmap(WidthImage, HeightImage);
            for (int i = 0; i < WidthImage; i++)
            {
                for (int j = 0; j < HeightImage; j++)
                {
                    newColor = Convert.ToInt32(Math.Round(_countColors * equalizationValues[grayPhoto.GetPixel(i, j).R] / (double)Size));
                    newColor = (newColor > 255) ? 255 : newColor;
                    result.SetPixel(i, j, Color.FromArgb(newColor, newColor, newColor));
                }
            }
            return result;
        }
    }
}
