using CSCore.Streams;

namespace ANN
{
    public class StringNeuron : Neuron<string, int, float?>
    {
        public override float? GetMemValue(int indexer)
        {
            if (Memory.Length - 1 < indexer)
            {
                return 0;
            }

            return (byte) Memory[indexer] / 255;
        }

        public override float? GetInputValue(int indexer)
        {
            if (Input.Length - 1 < indexer)
            {
                return 0;
            }

            return (byte) Input[indexer] / 255;
        }
    }
}