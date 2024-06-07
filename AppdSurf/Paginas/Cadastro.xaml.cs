using AppdSurf.Model;

namespace AppdSurf.Paginas;

public partial class Cadastro : ContentPage
{
    Usuario _usuario;
    public Cadastro()
	{
        _usuario = new Usuario();
        this.BindingContext = _usuario;
        InitializeComponent();
    }

    private void btncadastro_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnlogin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();

    }

    private async void btnCadastrese_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_usuario.Email) && string.IsNullOrEmpty(_usuario.Senha) && string.IsNullOrEmpty(_usuario.Nome))
        {
            await DisplayAlert("Erro", "Preencha todas as informações", "Fechar");
            return;
        }
        var cadastro = await App.BancoDados.UsuarioDataTable.SalvarUsuario(_usuario);

        if (cadastro > 0)
        {
            await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso", "Fechar");
            await Navigation.PopAsync();
        }

    }
    bool isPasswordVisible = false;

   

    private void olho_Clicked_1(object sender, EventArgs e)
    {
        isPasswordVisible = !isPasswordVisible;
        senhaview2.IsPassword = !isPasswordVisible;
    }
}