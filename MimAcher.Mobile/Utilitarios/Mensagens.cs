using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MimAcher.Mobile.Entidades;
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

        public static AlertDialog.Builder MensagemDeRegistrarGeolocalizacao(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Voc� deseja registrar sua localiza��o?");
            alert.SetMessage(
                "Registre para gente o local onde voc� mora para que possamos sugerir as pessoas que est�o mais pr�ximas de voc�");

            return alert;
        }

        private static async Task<string> MethodAsync()
        {
            await Task.Delay(10000);
            return "";
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