using System.Collections.Generic;

namespace JeepDesert
{
    internal class Model
    {
        // S - сумма объема бака и канистр, L - расстояние, N - количество поездок
        private double S, L;
        private int N;

        public Model(double s, double l)
        {
            S = s;
            L = l;

            N = CalcTrips(s, l);
        }

        private int CalcTrips(double s, double l)
        {
            double _l = 0;
            for (int n = 1; ; n++)
            {
                _l += S / n;
                if (_l >= l) return n;
            }
        }

        public IEnumerable<string> GetMoves()
        {

        }
    }
}