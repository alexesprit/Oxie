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
        }

        public void SetOxygenUsage(float usage) {
            oxygenUsageLabel.Content = "Oxygen usage: " + usage.ToString() + " kg";
        }

        public void SetPropaneUsage(float usage) {
            propaneUsageLabel.Content = "Propane usage: " + usage.ToString() + " kg";
        }

        public void SetTotalOxygenUsage(float usage) {
            totalOxygenLabel.Content = "Total oxygen usage: " + usage.ToString() + " kg";
        }

        public void SetTotalPropaneUsage(float usage) {
            totalPropaneLabel.Content = "Total propane usage: " + usage.ToString() + " kg";
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
        }
    }
}
