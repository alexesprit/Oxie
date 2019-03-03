namespace Oxie.View {
    public interface OxieView {
        void SetOxygenUsage(float usage);
        void SetPropaneUsage(float usage);

        void SetTotalOxygenUsage(float usage);
        void SetTotalPropaneUsage(float usage);

        void ResetInputFields();
    }
}
