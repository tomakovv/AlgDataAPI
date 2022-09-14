using AlgorithmAPI.Client;

namespace CalculationAPI.Calculation.Messaging.Send
{
    public interface ICalculationResultSender
    {
        void SendCalculationResult(string data);
    }
}