using AppdSurf.Model;

namespace AppdSurf.Paginas;

public partial class Perfil : ContentPage
{

    



    private Usuario _usuario;
    public Perfil(Usuario usuario)
    {
       InitializeComponent();
        _usuario = usuario;
        txtNome.Text = _usuario.Nome;
        txtEmail.Text = _usuario.Email;

        

}






    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home(_usuario));
    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Prancha(_usuario));

    }

    private async void ImageButton_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Surfistas(_usuario));

    }

    private async void ImageButton_Clicked_3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Perfil(_usuario));

    }

    private async void imageButton_Clicked_4(object sender, EventArgs e)
    {

    }
}