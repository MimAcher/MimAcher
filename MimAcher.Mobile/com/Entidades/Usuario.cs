using System;
using System.Collections.Generic;
using MimAcher.Mobile.com.Utilitarios;

namespace MimAcher.Mobile.com.Entidades
{

    public abstract class Usuario : PacoteAbstrato
    {
        protected Usuario(Dictionary<string, string> atributos)
        {
            if (atributos == null) throw new ArgumentNullException(nameof(atributos));
            Email = atributos["email"];
            Senha = atributos["senha"];
        }

        public string Email { get; private set; }

        public string Senha {get; private set;}


        public static bool Login( string email, string senha)
        {
            //chamar controller de valida��o de login
            return Validador.ValidadorDeLogin(email, senha) && CursorBd.Login(email, senha);
        }

        public void AlterarSenha(string senhaAtual, string novaSenha)
        {
            if (senhaAtual.Equals("senha"))
            {
                Senha = novaSenha;
            }
        }

        //TODO desativar conta
        public void DesativarConta()
        {
            //c�digo para excluir o usu�rio do banco
        }

    }
}