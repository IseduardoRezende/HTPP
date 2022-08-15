using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTPP
{
    class Tarefa  //Traduzimos dados Json para uma Classe C#;
    {
        public int userId;  //Dados exatamente iguais ao dados Json para tradução correta;
        public int id;
        public string title;
        public bool completed;

        public void Exibir()  //MÉTODO da Classe Tarefa:
        {
            Console.WriteLine("");
            Console.WriteLine("Objeto Tarefa");
            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Título: {title}");
            Console.WriteLine($"Finalizou ? {completed}");
            Console.WriteLine("");
            Console.WriteLine("================================");
        }
    }
}
