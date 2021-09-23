using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerVision
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        //public void CountColorsAndAddToChart(Image inputImage)
        //{
        //    ClearChart();
        //    Bitmap image = new Bitmap(inputImage);
        //    uint countColors = 255;
        //    Dictionary<uint, uint> colorsRed = new Dictionary<uint, uint>();
        //    Dictionary<uint, uint> colorsGreen = new Dictionary<uint, uint>();
        //    Dictionary<uint, uint> colorsBlue = new Dictionary<uint, uint>();
        //    Dictionary<uint, uint> colorsAll = new Dictionary<uint, uint>();
        //    for (uint i = 0; i <= countColors; i++)
        //    {
        //        colorsRed.Add(i, 0);
        //        colorsGreen.Add(i, 0);
        //        colorsBlue.Add(i, 0);
        //        colorsAll.Add(i, 0);
        //    }

        //    Color pixel;
        //    for (int i = 0; i < image.Width; i++)
        //    {
        //        for (int j = 0; j < image.Height; j++)
        //        {
        //            pixel = image.GetPixel(i, j);
        //            colorsRed[pixel.R]++;
        //            colorsGreen[pixel.G]++;
        //            colorsBlue[pixel.B]++;
        //        }
        //    }

        //    for (uint i = 0; i <= countColors; i++)
        //    {
        //        colorsAll[i] = colorsRed[i] + colorsGreen[i] + colorsBlue[i];
        //    }

        //    AddPointsToChart("SeriesRed", colorsRed);
        //    AddPointsToChart("SeriesGreen", colorsGreen);
        //    AddPointsToChart("SeriesBlue", colorsBlue);
        //    AddPointsToChart("SeriesAll", colorsAll);
        //}

        private void ClearChart()
        {
            chartRGB.Series["SeriesRed"].Points.Clear();
            chartRGB.Series["SeriesGreen"].Points.Clear();
            chartRGB.Series["SeriesBlue"].Points.Clear();
            chartRGB.Series["SeriesAll"].Points.Clear();
        }

        //private Image GetGrayPhoto(Image inputImage)
        //{
        //    Bitmap imageGray = new Bitmap(inputImage);
        //    //Bitmap imageGray2 = new Bitmap(inputImage);
        //    Color pixel;
        //    int grayColor;
        //    //int grayColor2;
        //    for (int i = 0; i < imageGray.Width; i++)
        //    {
        //        for (int j = 0; j < imageGray.Height; j++)
        //        {
        //            pixel = imageGray.GetPixel(i, j);
        //            grayColor = Convert.ToInt16(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
        //            //grayColor2 = Convert.ToInt16((pixel.R + pixel.G + pixel.B) / 3.0);
        //            imageGray.SetPixel(i, j, Color.FromArgb(grayColor, grayColor, grayColor));
        //            //imageGray2.SetPixel(i, j, Color.FromArgb(grayColor, grayColor, grayColor));
        //        }
        //    }
        //    return imageGray;
        //}

        //private Color GetAverage(Image sourse)
        //{
        //    Bitmap image = new Bitmap(sourse);
        //    int countR = 0;
        //    int countG = 0;
        //    int countB = 0;

        //    int width = image.Width;
        //    int height = image.Height;
        //    int size = width * height;

        //    Color pixel;
        //    for (int i = 0; i < width; i++)
        //    {
        //        for (int j = 0; j < height; j++)
        //        {
        //            pixel = image.GetPixel(i, j);
        //            countR += pixel.R;
        //            countG += pixel.G;
        //            countB += pixel.B;
        //        }
        //    }
        //    countR /= size;
        //    countG /= size;
        //    countB /= size;

        //    return Color.FromArgb(countR, countG, countB);
        //}

        //private Image GetTransformGrayWorld(string pathPhoto)
        //{
        //    Bitmap image = new Bitmap(pathPhoto);

        //    int width = image.Width;
        //    int height = image.Height;

        //    Color averageColor = GetAverage(image);

        //    double avg = (averageColor.R + averageColor.G + averageColor.B) / 3.0;
        //    double avgR = avg / averageColor.R;
        //    double avgG = avg / averageColor.G;
        //    double avgB = avg / averageColor.B;

        //    Color pixel;
        //    int minR = 0;
        //    int minG = 0;
        //    int minB = 0;
        //    for (int i = 0; i < width; i++)
        //    {
        //        for (int j = 0; j < height; j++)
        //        {
        //            pixel = image.GetPixel(i, j);
        //            minR = GetMin(Convert.ToInt16(pixel.R * avgR));
        //            minG = GetMin(Convert.ToInt16(pixel.G * avgG));
        //            minB = GetMin(Convert.ToInt16(pixel.B * avgB));
        //            image.SetPixel(i, j, Color.FromArgb(minR, minG, minB));
        //        }
        //    }

        //    return image;
        //}

        //private int GetMin(int number)
        //{
        //    return (number > 255) ? 255 : number;
        //}

        //public Image GetTransformToMainColor(string pathPhoto, Image sourse)
        //{
        //    Bitmap image = new Bitmap(pathPhoto);

        //    int width = image.Width;
        //    int height = image.Height;

        //    Color averageColorSouse = GetAverage(image);
        //    Color averageColorDestination = GetAverage(sourse);

        //    double aveR = averageColorDestination.R / Convert.ToDouble(averageColorSouse.R);
        //    double aveG = averageColorDestination.G / Convert.ToDouble(averageColorSouse.G);
        //    double aveB = averageColorDestination.B / Convert.ToDouble(averageColorSouse.B);

        //    int minR = 0;
        //    int minG = 0;
        //    int minB = 0;
        //    Color pixel;
        //    for (int i = 0; i < width; i++)
        //    {
        //        for (int j = 0; j < height; j++)
        //        {
        //            pixel = image.GetPixel(i, j);
        //            minR = GetMin(Convert.ToInt16(pixel.R * aveR));
        //            minG = GetMin(Convert.ToInt16(pixel.G * aveG));
        //            minB = GetMin(Convert.ToInt16(pixel.B * aveB));
        //            image.SetPixel(i, j, Color.FromArgb(minR, minG, minB));
        //        }
        //    }
        //    return image;
        //}

        //private Color GetColorFromFunction(Color colorInput)
        //{
        //    return Color.FromArgb(TransformValue(colorInput.R), TransformValue(colorInput.G), TransformValue(colorInput.B));
        //}

        //private int TransformValue(double number)
        //{
        //    int newValue = 0;
        //    if (number >= 0 && number < 50)
        //    {
        //        newValue = 25;
        //    }
        //    else if (number >= 50 && number < 100)
        //    {
        //        newValue = 75;
        //    }
        //    else if (number >= 100 && number < 150)
        //    {
        //        newValue = 125;
        //    }
        //    else if (number >= 150 && number < 200)
        //    {
        //        newValue = 175;
        //    }
        //    else
        //    {
        //        newValue = 200;
        //    }

        //    //if (number >= 0 && number < 85)
        //    //{
        //    //    newValue = 42;
        //    //}
        //    //else if (number >= 85 && number < 170)
        //    //{
        //    //    newValue = 127;
        //    //}
        //    //else
        //    //{
        //    //    newValue = 212;
        //    //}

        //    //if (number >= 0 && number < 127)
        //    //{
        //    //    newValue = 64;
        //    //}
        //    //else
        //    //{
        //    //    newValue = 127;
        //    //}

        //    //if (number < 100)
        //    //{
        //    //    number = 0;
        //    //}
        //    //else if (number > 200)
        //    //{
        //    //    number = 200;
        //    //}
        //    //else
        //    //{
        //    //    newValue = Convert.ToInt32(number);
        //    //}

        //    return newValue;
        //}

        //public Image GetTransformByFunction(string pathPhoto)
        //{
        //    Bitmap image = new Bitmap(pathPhoto);

        //    int width = image.Width;
        //    int height = image.Height;

        //    Color pixel;
        //    int minR = 0;
        //    int minG = 0;
        //    int minB = 0;
        //    for (int i = 0; i < width; i++)
        //    {
        //        for (int j = 0; j < height; j++)
        //        {
        //            pixel = image.GetPixel(i, j);

        //            image.SetPixel(i, j, GetColorFromFunction(pixel));
        //        }
        //    }

        //    return image;
        //}

        private void InvokeMethodByName(string name, PictureBox input, PictureBox output = null)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string pathToFile = "";
            Image newImage;
            Image imageInput;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile = openFileDialog.FileName;
                newImage = Image.FromFile(pathToFile);
                imageInput = newImage;
                switch (name)
                {
                    case "CountColorsAndAddToChart":
                        //CountColorsAndAddToChart(imageInput);
                        break;
                    case "GetGrayPhoto":
                        //newImage = GetGrayPhoto(imageInput);
                        break;
                    case "GetTransformGrayWorld":
                        //newImage = GetTransformGrayWorld(pathToFile);
                        output.Image = newImage;
                        break;
                    case "GetTransformToMainColor":
                        //newImage = GetTransformToMainColor(pathToFile, pictureBoxLaba2MainColorSourse.Image);
                        break;
                    case "GetTransformByFunction":
                        //newImage = GetTransformByFunction(pathToFile);
                        break;
                    default:

                        MessageBox.Show("Error in InvokeMethodByName.");
                        break;
                }
                if (output != null)
                {
                    output.Image = newImage;
                }
            }
        }

        private void MainInvoke(string nameMethod, PictureBox pictureSourse)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string pathToFile = "";
            Image newImage;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile = openFileDialog.FileName;
                newImage = Image.FromFile(pathToFile);
                pictureSourse.Image = newImage;
                TransformImage transformImage = new TransformImage(newImage);
                switch (nameMethod)
                {
                    case "CountColorsAndAddToChart":
                        ClearChart();
                        var colorR = transformImage.GetDictionaryColoRed();
                        var colorG = transformImage.GetDictionaryColorGreen();
                        var colorB = transformImage.GetDictionaryColorBlue();
                        var colorAll = transformImage.GetDictionaryAllColors();
                        for (int i = 0; i <= 255; i++)
                        {
                            chartRGB.Series["SeriesRed"].Points.AddXY(i, colorR[i]);
                            chartRGB.Series["SeriesGreen"].Points.AddXY(i, colorG[i]);
                            chartRGB.Series["SeriesBlue"].Points.AddXY(i, colorB[i]);
                            chartRGB.Series["SeriesAll"].Points.AddXY(i, colorAll[i]);
                        }
                        break;
                    case "GetGrayPhoto":
                        pictureBoxOutputImageLaba2Gray.Image = transformImage.GetGrayPhoto();
                        break;
                    case "GetTransformToMainColor":
                        pictureBoxLaba2MainColorOutput.Image = transformImage.GetTransformToMainColor(new Bitmap(pictureBoxLaba2MainColorSourse.Image));
                        break;

                    case "GetTransformGrayWorld":
                        pictureBoxLaba2GrayWorldOutput.Image = transformImage.GetTransformGrayWorld();
                        break;

                    default:
                        Console.WriteLine();
                        throw new Exception($"Undefined name {nameMethod}");
                }
            }
        }

        private void pictureBoxInputImageLaba1_Click(object sender, EventArgs e)
        {
            MainInvoke("CountColorsAndAddToChart", pictureBoxLaba1Input);
        }

        private void pictureBoxInputImageLaba2Gray_Click(object sender, EventArgs e)
        {
            MainInvoke("GetGrayPhoto", pictureBoxInputImageLaba2Gray);
        }

        private void pictureBoxLaba2MainColorInput_Click(object sender, EventArgs e)
        {
            MainInvoke("GetTransformToMainColor", pictureBoxLaba2MainColorInput);
        }

        private void pictureBoxLaba2GrayWorldInput_Click(object sender, EventArgs e)
        {
            MainInvoke("GetTransformGrayWorld", pictureBoxLaba2GrayWorldInput);
        }

        private void pictureBoxLaba2TransformByFunctionInput_Click(object sender, EventArgs e)
        {
            //InvokeMethodByName("GetTransformByFunction", pictureBoxLaba2TransformByFunctionInput, pictureBoxLaba2TransformByFunctionOutput);
        }

        private void pictureBoxLaba2MainColorSourse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string pathToFile = "";
            Image newImage;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile = openFileDialog.FileName;
                newImage = Image.FromFile(pathToFile);
                pictureBoxLaba2MainColorSourse.Image = newImage;

            }
        }

        private void pictureBoxLaba2NormaGistogramma_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string pathToFile = "";
            Image newImage;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile = openFileDialog.FileName;
                newImage = Image.FromFile(pathToFile);
                pictureBoxLaba2NormaGistogramma.Image = newImage;

            }
        }
    }
}
