﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorItem
    {
        private static Random _random = new Random();
        private static readonly List<string> TipoItem =
            new List<string>() { "futebol", "violao", "php", "c#", "xamarin", "teclado", "bateria",
            "uml", "analise de sistemas", "programacao", "cozinha", "cinema", "banco de dados",
            "cachorros", "medicina", "medicina alternativa", "psicologia", "livros de ficcao",
            "star wars", "star trek", "decoracao", "sociologia", "politica", "religiao",
            "volei", "tenis de mesa", "basquete", "NFL", "harry potter", "senhor dos aneis",
            "formula 1", "stock car", "sql", "linux", "windows", "direcao defensiva", "caminhada",
            "teoria musical", "ciencia da computacao", "calculo", "empreendedorismo"};

        public string GerarItem()
        {
            return TipoItem[_random.Next(0, TipoItem.Count)];
        }
    }
}
