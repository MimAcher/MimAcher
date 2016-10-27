using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Utilitarios
{
    public static class JsonParser
    {
        public static string MontarJsonItem(string nome_item)
        {
            return "{ \"listaitem\": [{ \"cod_item\": 1, \"nome\": \""+ nome_item + "\" }] }";
        }

        public static string MontarJsonUsuario(Participante participante)
        {
            return "{ \"listausuarioparticipante\": [ { \"e_mail\": \"" + participante.Email + "\", " +
                "\"senha\": \"" + participante.Senha + "\", \"cod_participante\": 1, \"cod_usuario\": 1, " +
                "\"cod_campus\": 1, \"nome\": \"" + participante.Nome + "\", \"telefone\": "+ participante.Telefone + ", " +
                "\"dt_nascimento\": \"" + participante.Nascimento + "\", \"latitude\": 0.0, \"longitude\": 0.0 } ] }";
        }

        private static string MontarJsonRelacaoItem(int codigo_item, TipoItem tipo)
        {
            return "vazio";
        }
    }
}