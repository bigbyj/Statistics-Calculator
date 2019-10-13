using System.Collections.Generic;

namespace GiveMeSomeStats.Interface
{
    public interface ICalculate
    {
        double Calculate(int x, int y);
        double Calculate(List<int> values);
    }
}
