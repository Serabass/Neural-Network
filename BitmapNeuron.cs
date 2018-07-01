using System.Drawing;

namespace ANN
{
    public class BitmapNeuron : Neuron<Bitmap, Point, float>
    {
        public string fileName;

        public void LoadMemory()
        {
            Memory = (Bitmap) Bitmap.FromFile(fileName);
        }

        public void DisposeMemory()
        {
            Memory.Dispose();
        }

        public override float GetMemValue(Point indexer)
        {
            return Memory.GetPixel(indexer.X, indexer.Y).GetBrightness() * 255f;
        }

        public override float GetInputValue(Point indexer)
        {
            return Input.GetPixel(indexer.X, indexer.Y).GetBrightness() * 255f;
        }
        
        public new string ToString()
        {
            return $"Name {fileName}; Weight: {Weight}";
        }
    }
}