using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ANN
{
    public class BitmapTest
    {
        private static List<BitmapNeuron> All = new List<BitmapNeuron>();

        private static Bitmap input = new Bitmap("input.bmp");

        private static void init()
        {
            //
            var files = Directory
                .GetFiles(@".\img")
                .Where(file => file.EndsWith(".bmp"));
            foreach (var file in files)
            {
                All.Add(new BitmapNeuron
                {
                    fileName = file
                });
            }
        }

        public static void Run()
        {
            init();
            int index = 0;
            int max = 0;
            int i = 0;

            foreach (var neuron in All)
            {
                neuron.LoadMemory();
                neuron.Input = input;
                for (var x = 0; x < neuron.Memory.Width; x++)
                {
                    for (int y = 0; y < neuron.Memory.Height; y++)
                    {
                        var memValue = neuron.GetMemValue(new Point(x, y));
                        var inputValue = neuron.GetInputValue(new Point(x, y));

                        if (Math.Abs(memValue - inputValue) < 200f)
                        {
                            if (memValue < 250f)
                            {
                                neuron.Weight++;
                            }

                            if (memValue != 0)
                            {
                                if (memValue < 250f)
                                {
                                    inputValue = (float) Math.Round((inputValue + (inputValue + memValue) / 2f) / 2f);
                                    neuron.Memory.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                }
                            }
                            else if (inputValue != 0)
                            {
                                if (memValue < 250f)
                                {
                                    inputValue = (float) Math.Round((inputValue + (inputValue + memValue) / 2f) / 2f);
                                    neuron.Memory.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                }
                            }
                        }
                    }
                }

                if (neuron.Weight > max)
                {
                    max = neuron.Weight;
                    index = i;
                }

                i++;
                neuron.DisposeMemory();
                neuron.Input = null;
            }

            All.Sort((a, b) => a.Weight > b.Weight ? -1 : 1);
            var maxWeight = All.Max(n => n.Weight);
            var minWeight = All.Min(n => n.Weight);
            var weights = string.Join(';', All.Select(n => n.Weight.ToString()));
            var mNeurons = All.Where(n => n.Weight == maxWeight).ToArray();

            Debugger.Break();
        }
    }
}