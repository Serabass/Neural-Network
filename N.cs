using System.Drawing;

namespace ANN
{
    public class N : Neuron<Bitmap>
    {
        public void LoadMemory()
        {
            memory = (Bitmap) Bitmap.FromFile(name);
        }

        public void DisposeMemory()
        {
            memory.Dispose();
        }
    }
}