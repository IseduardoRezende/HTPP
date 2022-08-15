using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json; //Converte objetos de texto para objetos C#;

namespace HTPP  //Converção de dados Json, dados WEB para variáveis e objetos C#;
{
    class Program
    {
        static void Main(string[] args)
        {
            ReqUnica();      //Puxa apenas uma tarefa em especifico;
            //ReqLista();    //Puxa todas as tarefas;
            
            Console.ReadLine();
        }

        static void ReqLista()
        {
            //Efetuando tipo de requisição GET:

            //Assim se faz uma requisição Web no C#: // Efetuando busca direta pela URL do site; 
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
            //Requisição Get, requisição direta = GET: 
            requisicao.Method = "GET";

            //Using estrutura que trabalha bem com requisições Web:
            //Facilita conexões com classes como WebRequest: Abre e fecha;

            var resposta = requisicao.GetResponse(); //Efetua requisição;
            using (resposta) //Trata da resposta da requisição:
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd(); //Dados da Resposta da requisição;

                //Lista de Dados de resposta Json convertidos para objetos C#;
                List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString()); //Respeitar os tipos para a converção C# Web dar certo;

                foreach (Tarefa tarefa in tarefas)
                {
                    tarefa.Exibir(); //Executando método através da converção de dados Json;
                }

                //Console.WriteLine(dados.ToString()); //Função Tostring = Converte objeto em string;

                Console.WriteLine(tarefas); //converter;

                stream.Close();
                resposta.Close();
            }

            //Nugget Repositório oficial de bibliotecas do C#;
            //Possível encontrar conversor de json para C# atráves do Nugget;
        }

        static void ReqUnica()
        {
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/199");
            requisicao.Method = "GET";
            var resposta = requisicao.GetResponse();
            using (resposta)
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                Tarefa tarefas = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());
                tarefas.Exibir();

                stream.Close();
                resposta.Close();
            }
        }
    }
}
