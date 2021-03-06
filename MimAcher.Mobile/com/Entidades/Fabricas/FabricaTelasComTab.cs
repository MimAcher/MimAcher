﻿using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using MimAcher.Mobile.com.Activities;

namespace MimAcher.Mobile.com.Entidades.Fabricas
{
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public class FabricaTelasComTab : TabActivity, IFabricaTelas
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        public void IniciarAlterarSenha(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarEditarPerfil(Context contexto, PacoteAbstrato pacote)
        {
            var editaractivity = new Intent(contexto, typeof(EditarPerfilActivity));
            IniciarOutraTela(editaractivity, pacote);
        }

        public void IniciarEscolherFoto(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarHobbies(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarHome(Context contexto, PacoteAbstrato pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(HomeActivity));
            IniciarOutraTela(resultadoctivity, pacote);
        }

        public Task IniciarInscrever()
        {
            throw new NotImplementedException();
        }

        public void IniciarMain(Context contexto)
        {
            var mainctivity = new Intent(contexto, typeof(MainActivity));
            StartActivity(mainctivity);
        }

        public void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var participante = (Participante)pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        public void IniciarQueroAprenderActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarQueroEnsinarActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        //Cria os tabs
        protected void CreateTab(Type activityType, string label, Participante participante)
        {

            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.PutExtra("member", participante.ParticipanteToBundle());
            var spec = TabHost.NewTabSpec(label);
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            var drawableIcon = Resources.GetDrawable(Resource.Drawable.abc_tab_indicator_material);
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            spec.SetIndicator(label, drawableIcon);
            spec.SetContent(intent);
            TabHost.AddTab(spec);
        }
    }
}