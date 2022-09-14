using AlgorithmAPI.Client;
using CalculationAPI.Calculation.Messaging.Send;

namespace CalculationAPI.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculationResultSender _calculationResultSender;

        public CalculationService(ICalculationResultSender calculationResultSender)
        {
            _calculationResultSender = calculationResultSender;
        }

        public void CalculateData(DataSetRead data)
        {
            var size = data.Values.Count;
            Thread.Sleep(1000 * size);
            _calculationResultSender.SendCalculationResult($"Calculation took {size} seconds");
        }
    }
}