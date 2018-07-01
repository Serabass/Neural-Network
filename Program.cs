using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace ANN
{
    class Program
    {
        static byte I = 255;
        static byte X = 128;
        static byte _ = 0;

        public static List<N> All = new List<N>();

        public static Bitmap input = new Bitmap("input.bmp");

        static void Main(string[] args)
        {
            init();
            int index = 0;
            int max = 0;
            int i = 0;

            Debugger.Break();
            foreach (var neuron in All)
            {
                neuron.LoadMemory();
                for (var x = 0; x < neuron.memory.Width; x++)
                {
                    for (int y = 0; y < neuron.memory.Height; y++)
                    {
                        var m = neuron.memory.GetPixel(x, y).GetBrightness() * 255f;
                        var n = input.GetPixel(x, y).GetBrightness() * 255f;

                        if (Math.Abs(m - n) < 120f)
                        {
                            if (m < 250f)
                            {
                                neuron.weight++;
                            }

                            if (m != 0)
                            {
                                if (m < 250f)
                                {
                                    n = (float) Math.Round((n + (n + m) / 2f) / 2f);
                                    //neuron.memory.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                }
                            }
                            else if (n != 0)
                            {
                                if (m < 250f)
                                {
                                    n = (float) Math.Round((n + (n + m) / 2f) / 2f);
                                    //neuron.memory.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                }
                            }
                        }
                    }
                }

                if (neuron.weight > max)
                {
                    max = neuron.weight;
                    index = i;
                }

                i++;
                // neuron.DisposeMemory();
            }

            var maxWeight = All.Max(n => n.weight);
            var minWeight = All.Min(n => n.weight);

            var weights = string.Join(';', All.Select(n => n.weight.ToString()));

            var mNeurons = All.Where(n => n.weight == maxWeight).ToArray();

            Debugger.Break();
        }

        public static void init()
        {
            var files = Directory.GetFiles("img").Where(file => file.EndsWith(".bmp"));
            foreach (var file in files)
            {
                All.Add(new N
                {
                    name = file
                });
            }
        }
    }
}