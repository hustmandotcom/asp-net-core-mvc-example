namespace asp_net_core_mvc_example.Services
{
    public interface IMatrixCalculationService
    {
        int[,] Calculate(int number);
    }
}