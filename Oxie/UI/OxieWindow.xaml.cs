using System;
using System.Windows;

using Oxie.Presenter;
using Oxie.View;

namespace Oxie {
    public partial class MainWindow : Window, OxieView {
        private OxiePresenter presenter;

        public MainWindow() {
            InitializeComponent();
            presenter = new OxiePresenter(this);

            thicknessTextBox.Focus();
        }

        public void SetOxygenUsage(float usage) {
            oxygenUsageLabel.Content = String.Format("Oxygen usage: {0} kg", UsageToStr(usage));
        }

        public void SetPropaneUsage(float usage) {
            propaneUsageLabel.Content = String.Format("Propane usage: {0} kg", UsageToStr(usage));
        }

        public void SetTotalOxygenUsage(float usage) {
            totalOxygenLabel.Content = String.Format("Total oxygen usage: {0} kg", UsageToStr(usage));
        }

        public void SetTotalPropaneUsage(float usage) {
            totalPropaneLabel.Content = String.Format("Total propane usage: {0} kg", UsageToStr(usage));
        }

        public void ResetInputFields() {
            thicknessTextBox.Text = string.Empty;
            cuttingLengthTextBox.Text = string.Empty;

            SetOxygenUsage(0);
            SetPropaneUsage(0);
        }

        private void OnCuttingLengthChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            int cuttingLength;
            try {
                cuttingLength = int.Parse(cuttingLengthTextBox.Text);
            } catch (FormatException) {
                return;
            }
            presenter.OnCuttingLengthChanged(cuttingLength);
        }

        private void OnThicknessChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            int thickness;
            try {
                thickness = int.Parse(thicknessTextBox.Text);
            } catch (FormatException) {
                return;
            }
            presenter.OnThicknessChanged(thickness);
        }

        private void OnAppendButtonClicked(object sender, RoutedEventArgs e) {
            presenter.OnAppendButtonClicked();

            thicknessTextBox.Focus();
        }

        private string UsageToStr(float usage) {
            return Math.Round(usage, 2).ToString();
        }

        private void OnResetButtonClicked(object sender, RoutedEventArgs e) {
            presenter.OnResetButtonClicked();
        }
    }
}
