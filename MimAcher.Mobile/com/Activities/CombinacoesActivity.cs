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
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;

namespace MimAcher.Mobile.com.Activities
{
    [Activity(Label = "Combinacoes", Theme = "@style/Theme.Splash")]
    public class CombinacoesActivity : FabricaTelasComResultados
    {
        private readonly ListaItens combinacoes = new ListaItens();
        private ListView _listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //tenho q receber o item para gerar as combina��es a serem geradas
            //var participanteBundle = Intent.GetBundleExtra("member");
            //Participante = Participante.BundleToParticipante(participanteBundle);

            //combinacoes = lista de combina��es
            //Items = combinacoes.Itens
            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Combinacoes);

            //Iniciando as variaveis do contexto
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _listView = FindViewById<ListView>(Resource.Id.list);

            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.Title = "Combina��es";
            ActionBar.Subtitle = "Hobbies";

            //Recebendo e transformando o bundle(Objeto participante)
            //TODO tenho que pegar o item, e trazer o resultado do match para listar
            

            //TODO Listagem das combina��es            
            //Items = Participante.Aprender.Conteudo;
            _listView.Adapter = new ListAdapterHae(this, Items);
            // Create your application here
        }
    }
}