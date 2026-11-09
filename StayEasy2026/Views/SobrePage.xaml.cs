namespace StayEasy2026.Views;

public partial class SobrePage : ContentPage
{
    public SobrePage() => InitializeComponent();

    private async void OnVoltarClicked(object sender, EventArgs e) =>
        await Navigation.PopToRootAsync();
}
