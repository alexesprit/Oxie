using System.Collections.Generic;

namespace Oxie.Model {
    public sealed class OxieCalculator {
        public int Thickness { get; set; }

        public int CuttingLength { get; set; }

        public float OxygenUsage {
            get {
                if (oxygen.ContainsKey(Thickness)) {
                    return oxygen[Thickness] * CuttingLength / 1000 * 1.33f;
                }
                throw new InvalidThicknessError();
            }
        }
        public float PropaneUsage {get {
                if (propane.ContainsKey(Thickness)) {
                    return propane[Thickness] * CuttingLength / 1000;
                }
                throw new InvalidThicknessError();
            }
        }

        private Dictionary<int, float> oxygen = new Dictionary<int, float>() {
            { 6, 0.160f },
            { 8, 0.199f },
            { 10, 0.242f },
            { 12, 0.283f },
            { 14, 0.376f },
            { 16, 0.398f },
            { 20, 0.431f },
            { 25, 0.546f },
            { 30, 0.608f }
        };
        private Dictionary<int, float> propane = new Dictionary<int, float>() {
            { 6, 0.032f },
            { 8, 0.041f },
            { 10, 0.048f },
            { 12, 0.058f },
            { 14, 0.066f },
            { 16, 0.071f },
            { 20, 0.084f },
            { 25, 0.098f },
            { 30, 0.106f }
        };
    }
}
