using Android.App;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace MimAcher.Mobile.Utilitarios
{
    public static class Mensagens
    {
        public static void MensagemDeInformacaoInvalidaPadrao(Context contexto, string informacao)
        {
            var toast = $"Informa��o Invalida: {informacao}";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeConfirmarSenhaInvalido(Context contexto)
        {
            const string toast = "As senhas n�o conferem!";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeSenhaInvalida(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Senha Invalida");
            alert.SetMessage("A senha deve ser composta de no min�mo 8 caracteres");
            alert.SetPositiveButton("Ok", (senderAlert, args) => {
                
                Toast.MakeText(contexto, "Favor, inserir uma senha v�lida!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public static bool MensagemDeRegistrarGeolocalizacao(Context contexto)
        {
            var r = true;
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Voc� deseja registrar sua localiza��o?");
            alert.SetMessage("Registre para gente o local onde voc� mora para que possamos sugerir as pessoas que est�o mais pr�ximas de voc�");
            alert.SetPositiveButton("Sim", (senderAlert, args) =>
            {
                Toast.MakeText(contexto, "Sua localiza��o ser� registrada!", ToastLength.Short).Show();
            });

            alert.SetNegativeButton("N�o", (senderAlert, args) => {
                Toast.MakeText(contexto, "Ok, sua localiza��o n�o ser� registrada", ToastLength.Short).Show();
                r = false;
            });

            Dialog dialog = alert.Create();
            dialog.Show();
            return r;
        }


        public static void MensagemDeDataInvalida(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Data de Nascimento Invalida");
            alert.SetMessage("A Data de Nascimento deve estar de acordo com o modelo: 30/06/2002");
            alert.SetPositiveButton("Ok", (senderAlert, args) => {
                Toast.MakeText(contexto, "Favor, inserir uma data v�lida!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}