using Oxie.Model;
using Oxie.View;

namespace Oxie.Presenter {
    public sealed class OxiePresenter {
        private OxieView view;
        private OxieCalculator calc;

        private float totalOxygenUsage = 0;
        private float totalPropaneUsage = 0;

        public OxiePresenter(OxieView view) {
            calc = new OxieCalculator();
            this.view = view;

            view.SetOxygenUsage(0);
            view.SetPropaneUsage(0);

            view.SetTotalOxygenUsage(0);
            view.SetTotalPropaneUsage(0);            
        }

        public void OnCuttingLengthChanged(int length) {
            calc.CuttingLength = length;

            CalculateUsage();
        }

        public void OnThicknessChanged(int thickness) {
            calc.Thickness = thickness;

            CalculateUsage();
        }

        public void OnAppendButtonClicked() {
            AppendUsage();
        }

        private void CalculateUsage() {
            try {
                view.SetOxygenUsage(calc.OxygenUsage);
                view.SetPropaneUsage(calc.PropaneUsage);
            } catch (InvalidThicknessError) {
                view.SetOxygenUsage(0);
                view.SetPropaneUsage(0);
            }
        }

        private void AppendUsage() {
            try {
                totalOxygenUsage += calc.OxygenUsage;
                totalPropaneUsage += calc.PropaneUsage;
            } catch (InvalidThicknessError) {
                return;
            }

            view.SetTotalOxygenUsage(totalOxygenUsage);
            view.SetTotalPropaneUsage(totalPropaneUsage);
        }
    }
}
