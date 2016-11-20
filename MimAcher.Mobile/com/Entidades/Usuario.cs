using System;
using System.Collections.Generic;
using MimAcher.Mobile.com.Utilitarios;
using MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidadeValidador;

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
            return Validador.ValidadorDeLogin(email, senha);
            //comparar com informacao no banco
            //retornar true e o usuario em caso de sucesso e false em caso de falha
            //TODO chamar autentica��o
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