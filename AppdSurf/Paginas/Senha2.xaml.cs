using AppdSurf.Model;

namespace AppdSurf.Paginas;

public partial class Senha2 : ContentPage
{
    Senha _senha;
    public Senha2()
    {
        _senha = new Senha();
        this.BindingContext = _senha;
        InitializeComponent();
    }

    private async void btnConfirmar_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new Login());




    }
    bool isPasswordVisible = false;

    private void ImageButton_Clicked(object sender, EventArgs e)
    {

        isPasswordVisible = !isPasswordVisible;
        senhaview2.IsPassword = !isPasswordVisible;
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {

        isPasswordVisible = !isPasswordVisible;
        senhaview3.IsPassword = !isPasswordVisible;
    }
}