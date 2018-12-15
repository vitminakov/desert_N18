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
            double gas = S, lastStop = 0;
            yield return string.Format("Расстояние: {0:F4} | Топливо: {1:F4} | Джип отправляется с базы.", lastStop, gas);

            List<double> positions = new List<double>(), gases = new List<double>();
            int k;
            for (k = 1; k < N; k++)
            {
                for (int i = 0; i < positions.Count; i++)
                {
                   
                    var position = positions[i];
                    gas -= position;
                    if (i > 0) gas += positions[i - 1];

                    var taken = S / (2 * N - 2 * k + 2);
                    gases[i] -= taken;
                    gas += taken;

                    yield return string.Format("Расстояние: {0:F4} | Топливо: {1:F4} | Джип забрал {2:F4} топлива из бочки. Топлива в бочке: {3:F4}",
                        position, gas, taken, gases[i]);
                }

                var currentMove = 1.0 / (2 * N - 2 * k + 2);
                gas -= currentMove;

                var currentPosition = lastStop + currentMove;
                var leave = S * (N - k) / (N - k + 1);

                positions.Add(currentPosition);
                lastStop = currentPosition;
                gases.Add(leave);
                gas -= leave;

                yield return string.Format("Расстояние: {0:F4} | Топливо: {1:F4} | Джип оставил {2:F4} топлива в бочке.",
                    currentPosition, gas, leave);

                for (int i = positions.Count - 2; i >= 0; i--)
                {
                    var position = positions[i];
                    gas -= currentPosition - position;

                    var taken = S / (2 * N - 2 * k + 2);
                    gases[i] -= taken;
                    gas += taken;

                    yield return string.Format("Расстояние: {0:F4} | Топливо: {1:F4} | Джип забрал {2:F4} топлива из бочки. Топлива в бочке: {3:F4}",
                        position, gas, taken, gases[i]);

                    gas += currentPosition - position;
                }

                gas = S;
                yield return string.Format("Расстояние: 0.0000 | Топливо: {0:F4} | Джип достиг базы.", gas);
            }

            // Последняя поездка
            for (int i = 0; i < positions.Count; i++)
            {
                var position = positions[i];
                gas -= position;
                if (i > 0) gas += positions[i - 1];

                var taken = S / (2 * N - 2 * k + 2);
                gases[i] -= taken;
                gas += taken;

                yield return string.Format("Расстояние: {0:F4} | Топливо: {1:F4} | Джип забрал {2:F4} топлива из бочки. Топлива в бочке: {3:F4}",
                    position, gas, taken, gases[i]);
            }

            var lastMove = L - lastStop;
            gas -= lastMove;
            yield return string.Format("Расстояние: {0:F4} | Топливо: {1:F4} | 
    }
}