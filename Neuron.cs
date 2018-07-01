using System.Collections.Generic;
using System.Drawing;

namespace ANN
{
    public abstract class Neuron<T>
    {
        public string name;

        public int output = 0;
        public int weight = 0;
        public T input;
        public T memory;

        public new string ToString()
        {
            return $"Name {name}; Weight: {weight}";
        }
    }
}