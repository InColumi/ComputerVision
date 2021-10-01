using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ComputerVision
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }
        private void ClearChart(Chart chart)
        {
            foreach (var serie in chart.Series)
            {
                chart.Series[serie.Name].Points.Clear();
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
                        ClearChart(chartRGB);
                        var colorR = transformImage.GetColorRed();
                        var colorG = transformImage.GetColorGreen();
                        var colorB = transformImage.GetColorBlue();
                        var colorAll = transformImage.GetAllColors();
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
                    case "GetTransformByFunction":
                        pictureBoxLaba2TransformByFunctionOutput.Image = newImage;
                        break;
                    case "NormaHistogramma":
                        ClearChart(chartLaba2NormalHistorammaBefore);
                        ClearChart(chartLaba2NormalHistorammaAfter);
                        colorAll = transformImage.GetAllColors();
                        for (int i = 0; i <= 255; i++)
                        {
                            chartLaba2NormalHistorammaBefore.Series["SeriesAll"].Points.AddXY(i, colorAll[i]);
                        }

                        var normalizationPhoto = transformImage.GetNormalizationPhoto();
                        pictureBoxLaba2NormaHistogrammaOutput.Image = normalizationPhoto;

                        TransformImage image = new TransformImage(normalizationPhoto);
                        var normalizatonHist = image.GetAllColors();
                        for (int i = 0; i <= 255; i++)
                        {
                            chartLaba2NormalHistorammaAfter.Series["SeriesAll"].Points.AddXY(i, normalizatonHist[i]);
                        }
                        break;
                    case "EqualizationHistogramma":
                        ClearChart(chartLaba2EqualizationHistorammaBefore);
                        ClearChart(chartLaba2EqualizationHistorammaAfter);
                        colorAll = transformImage.GetAllColors();
                        for (int i = 0; i <= 255; i++)
                        {
                            chartLaba2EqualizationHistorammaBefore.Series["SeriesAll"].Points.AddXY(i, colorAll[i]);
                        }

                        var equalizationPhoto = transformImage.GetEqualizationPhoto();
                        pictureBoxLaba2EqualizationHistogrammaOutput.Image = equalizationPhoto;

                        image = new TransformImage(equalizationPhoto);
                        var allColors = image.GetAllColors();
                        for (int i = 0; i <= 255; i++)
                        {
                            chartLaba2EqualizationHistorammaAfter.Series["SeriesAll"].Points.AddXY(i, allColors[i]);
                        }
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
            MainInvoke("GetTransformByFunction", pictureBoxLaba2TransformByFunctionInput);
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
            MainInvoke("NormaHistogramma", pictureBoxLaba2NormaHistogrammaInput);
        }

        private void pictureBoxLaba2EqualizationHistogrammaInput_Click(object sender, EventArgs e)
        {
            MainInvoke("EqualizationHistogramma", pictureBoxLaba2EqualizationHistogrammaInput);
        }
    }
}
