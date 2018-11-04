using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class Galaxy
    {
        private int[,] matrix;

        public Galaxy(int rows, int cols)
        {
            this.Matrix = new int[rows, cols];
            this.FillMatrix();
        }

        public int[,] Matrix {
            get => matrix;
            set => matrix = value;
        }

        private void FillMatrix()
        {
            int value = 0;
            for (int i = 0; i < this.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.Matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        public bool IsInGalaxy(int row, int col)
        {
            return row >= 0 && row < Matrix.GetLength(0) && col >= 0 && col < Matrix.GetLength(1);
        }
    }
}
