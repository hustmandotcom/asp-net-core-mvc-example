using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_core_mvc_example.Services
{
    public class SpiralMatrixCalculationService : IMatrixCalculationService
    {
        public int[,] Calculate(int number)
        {
            var matrix = new int[number, number];
            FillMatrix(matrix, number);
            return matrix;
        }

        private void FillMatrix(int[,] matrix, int n)
        {
            int positionX = n / 2; 
            int positionY = n % 2 == 0 ? (n / 2) - 1 : (n / 2);
            int direction = 0; 
            int stepsCount = 1;
            int stepPosition = 0;
            int stepChange = 0;

            for (int i = 0; i < n * n; i++)
            {
                matrix[positionY, positionX] = i;
                if (stepPosition < stepsCount)
                {
                    stepPosition++;
                }
                else
                {
                    stepPosition = 1;
                    if (stepChange == 1)
                    {
                        stepsCount++;
                    }
                    stepChange = (stepChange + 1) % 2;
                    direction = (direction + 1) % 4;
                }

                switch (direction)
                {
                    case 0:
                        positionY++;
                        break;
                    case 1:
                        positionX--;
                        break;
                    case 2:
                        positionY--;
                        break;
                    case 3:
                        positionX++;
                        break;
                }
            }
        }
    }
}