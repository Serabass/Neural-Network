using CSCore.Streams;

namespace ANN
{
    public class StringNeuron : Neuron<string, int, byte>
    {
        public override byte GetMemValue(int indexer)
        {
            if (Memory.Length - 1 < indexer)
            {
                return 0;
            }

            return (byte) Memory[indexer];
        }

        public override byte GetInputValue(int indexer)
        {
            if (Input.Length - 1 < indexer)
            {
                return 0;
            }

            return (byte) Input[indexer];
        }
    }
}