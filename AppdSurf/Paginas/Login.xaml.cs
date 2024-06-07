using AppdSurf.Model;

namespace AppdSurf.Paginas;

public partial class Login : ContentPage
{



    public Login()
	{
        InitializeComponent();

    }

    private async void btnSenha_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Senha1());

    }

    private async void btncadastro_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cadastro());
    }

    private async  void btnEntrar_Clicked(object sender, EventArgs e)
    {

        string email = txtEmail.Text;
        string senha = senhaview.Text;

        if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha))
        {
            var usuario = await App.BancoDados.UsuarioDataTable.ObtemUsuario(email, senha);

            if (usuario != null)
            {
                await DisplayAlert("Sucesso", "Login efetuado com sucesso", "OK");
                await Navigation.PushAsync(new Home(usuario));
                App.Usuario = usuario;
            }
            else
            {
                await DisplayAlert("Erro", "Usuário ou senha inválidos", "OK");
                return;
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                await DisplayAlert("Erro", "Preencha o campo de e-mail", "OK");
            }
            else if (string.IsNullOrWhiteSpace(senha))
            {
                await DisplayAlert("Erro", "Preencha o campo de senha", "OK");
            }
        }
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnCadastro1_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cadastro());

    }

    

    bool isPasswordVisible = false;

    private void imagemolho_Clicked(object sender, EventArgs e)
    {
        isPasswordVisible = !isPasswordVisible;
        senhaview.IsPassword = !isPasswordVisible;
    }
}



