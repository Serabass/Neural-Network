
namespace ANN
{
    public abstract class Neuron<T, TI, TV>
    {
        public int Output = 0;
        public int Weight = 0;
        public T Input;
        public T Memory;

        public abstract TV GetMemValue(TI indexer);
        public abstract TV GetInputValue(TI indexer);
    }
}