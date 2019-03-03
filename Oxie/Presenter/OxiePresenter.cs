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

            calculateUsage();
        }

        public void OnThicknessChanged(int thickness) {
            calc.Thickness = thickness;

            calculateUsage();
        }

        public void OnAppendButtonClicked() {
            appendUsage();
        }

        public void OnResetButtonClicked() {
            resetUsage();
        }

        private void calculateUsage() {
            try {
                view.SetOxygenUsage(calc.OxygenUsage);
                view.SetPropaneUsage(calc.PropaneUsage);
            } catch (InvalidThicknessError) {
                view.SetOxygenUsage(0);
                view.SetPropaneUsage(0);
            }
        }

        private void appendUsage() {
            try {
                setTotalOxygenUsage(totalOxygenUsage + calc.OxygenUsage);
                setTotalPropaneUsage(totalPropaneUsage + calc.PropaneUsage);

                view.ResetInputFields();
            } catch (InvalidThicknessError) {
                return;
            }
        }

        private void resetUsage() {
            setTotalOxygenUsage(0);
            setTotalPropaneUsage(0);

            view.ResetInputFields();
        }

        private void setTotalOxygenUsage(float usage) {
            totalOxygenUsage = usage;
            view.SetTotalOxygenUsage(usage);
        }

        private void setTotalPropaneUsage(float usage) {
            totalPropaneUsage = usage;
            view.SetTotalPropaneUsage(usage);
        }
    }
}
