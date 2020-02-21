using System;
namespace MatrixCalculator.Models
{
    internal struct Position
    {
        public int Row;
        public int Column;
        internal Position(int i, int j)
        {
            Row = i;
            Column = j;
        }
    }
    public class Matrix
    {
        public int NumberOfRows { get; private set; }
        public int NumberOfColumns { get; private set; }

        private Position _nextFreePosition;
        private double[,] _data;


        public Matrix(int rows, int columns, double[,] data)
        {
            NumberOfRows = rows;
            NumberOfColumns = columns;
            _data = data;
            _nextFreePosition = new Position(-1, -1);
        }

        public Matrix(int rows, int columns)
        {
            _data = new double[rows, columns];
            _nextFreePosition = new Position(0, 0);
        }

        public void AddItem(double item)
        {
            if (_nextFreePosition.Row == -1 && _nextFreePosition.Column == -1)
            {
                _nextFreePosition.Row = 0;
                _nextFreePosition.Column = 0;
            }

            _data[_nextFreePosition.Row, _nextFreePosition.Column++] = item;

            // quantidade maxima de colunas atingida
            if(_nextFreePosition.Column == NumberOfColumns)
            {

                if (_nextFreePosition.Row < NumberOfRows)
                {
                    _nextFreePosition.Column = 0;
                    _nextFreePosition.Row++;
                }
                // quantidade maxima de linhas atingida
                else
                {
                    _nextFreePosition.Row = -1;
                    _nextFreePosition.Column = -1;
                }
            }
        }
        
        public double GetItem(int i, int j) => _data[i, j];

        public void RemoveItem(int i, int j)
        {
            double[,] data = new double[NumberOfRows, NumberOfColumns];
            int newRow = 0, newColumn = 0;

            for(int oldRow = 0; oldRow < NumberOfRows; oldRow++)
            {
                for(int oldColumn = 0; oldColumn < NumberOfColumns; oldColumn++)
                {
                    if (oldRow == i && oldColumn == j) continue;
                                   
                    data[newRow, newColumn++] = _data[i, j];

                    if (newColumn == NumberOfColumns)
                    {
                        newColumn = 0;
                        newRow++;
                    }
                    
                }
            }

            _data = data;
        }

        public void SetItem(int i, int j, double value)
        {
            if (i >= NumberOfRows || j >= NumberOfColumns)
                throw new IndexOutOfRangeException();
            _data[i, j] = value;
        }
     
        
    }
}
