using AlgorithmAPI.Client;

namespace AlgorithmAPI.Algorithm.Messaging.Send
{
    public interface ICalculationSender
    {
        void SendCalculation(DataSetRead data);
    }
}