using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ANN
{
    public class StringTest 
    {
        private static List<StringNeuron> All = new List<StringNeuron>();

        private static string input = "А.bmp";

        private static void init()
        {
            //
            var files = Directory
                .GetFiles(@".\img")
                .Where(file => file.EndsWith(".bmp"));
            foreach (var file in files)
            {
                All.Add(new StringNeuron
                {
                    Memory = file
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
                neuron.Input = input;
                for (var id = 0; id < neuron.Memory.Length; id++)
                {
                        var memValue = neuron.GetMemValue(i);
                        var inputValue = neuron.GetInputValue(i);

                        if (Math.Abs((float)memValue - (float)inputValue) < 200f)
                        {
                            if (memValue < 250f)
                            {
                                neuron.Weight++;
                            }

                            if (memValue != 0)
                            {
                                if (memValue < 250f)
                                {
                                    //inputValue = (float) Math.Round((inputValue + (inputValue + memValue) / 2f) / 2f);
                                    //neuron.memory.SetPixel(i, y, Color.FromArgb(0, 0, 0));
                                }
                            }
                            else if (inputValue != 0)
                            {
                                if (memValue < 250f)
                                {
                                    //inputValue = (float) Math.Round((inputValue + (inputValue + memValue) / 2f) / 2f);
                                    //neuron.memory.SetPixel(i, y, Color.FromArgb(0, 0, 0));
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
                // neuron.DisposeMemory();
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