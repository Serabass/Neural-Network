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

        private static string input = @"Losum";

        private static void init()
        {
            All.Add(new StringNeuron {Memory = "Lorem"});
            All.Add(new StringNeuron {Memory = "Ipsum"});
            All.Add(new StringNeuron {Memory = "Dolor"});
            All.Add(new StringNeuron {Memory = "Obama"});
            All.Add(new StringNeuron {Memory = "Neuro"});
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
                    var memValue = (float) neuron.GetMemValue(id);
                    var inputValue = (float) neuron.GetInputValue(id);

                    if (Math.Abs(memValue - inputValue) < 3)
                    {
                        neuron.Weight++;
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