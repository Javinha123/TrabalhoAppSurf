using AppdSurf.Model;

namespace AppdSurf.Paginas;

public partial class Senha1 : ContentPage
{
    Usuario _usuario;
    public Senha1()
	{
        _usuario = new Usuario();
        this.BindingContext = _usuario;
        InitializeComponent();
    }

    private async void btnConfirmar_Clicked(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string nome = txtNome.Text;

        if (!string.IsNullOrWhiteSpace(email) || !string.IsNullOrWhiteSpace(nome))
        {
            var usuarioExiste = await App.BancoDados.UsuarioDataTable.RecuperaUsuario(email, nome);

            if (usuarioExiste != null)
            {
                await DisplayAlert("Sucesso", "Login efetuado com sucesso", "OK");
                await Navigation.PushAsync(new Senha2());
                App.Usuario = usuarioExiste;
            }
            else
            {
                await DisplayAlert("Erro", "Usuário ou Nome inválidos", "OK");
                return;
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                await DisplayAlert("Erro", "Preencha o campo de e-mail", "OK");
            }
            else if (string.IsNullOrWhiteSpace(nome))
            {
                await DisplayAlert("Erro", "Preencha o campo de senha", "OK");
            }
        }

    }

    private void btnlogin_Clicked(object sender, EventArgs e)
    {

    }

    private void btncadastro_Clicked(object sender, EventArgs e)
    {

    }
}