using ProjetoViagens.Data;
using ProjetoViagens.Menus;
using ProjetoViagens.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Telas
{
    class TelaConsultar
    {
        public static void ShowTelaConsultar(string nomeEntidade)
        {
            Repository<Planetas> repoPlaneta = new Repository<Planetas>();
            Repository<Clientes> repoCliente = new Repository<Clientes>();
            TransporteRepository repoTransporte = new TransporteRepository();
            ViagemDiponivelRepository repoViagem = new ViagemDiponivelRepository();

            string opcaoConsultar = MenuConsultarOpcao.ShowMenuOpcaoConsultar(nomeEntidade);
            if (opcaoConsultar == "1")
            {
                if (nomeEntidade.ToLower() == "planeta")
                {
                    // CONSULTA TODOS PLANETAS
                    List<Planetas> listaPlanetas = repoPlaneta.Listar("planetasTodos_sps");
                    MostarConsultaPlaneta(listaPlanetas);
                }
                else if (nomeEntidade.ToLower() == "cliente")
                {
                    // CONSULTA TODOS CLIENTES

                    List<Clientes> listaClientes = repoCliente.Listar("clientesTodos_sps");
                    MostrarConsultCliente(listaClientes);
                }
                else if (nomeEntidade.ToLower() == "transporte")
                {
                    // CONSULTA TODOS TRANSORTES
                    

                    foreach (var item in repoTransporte.Listar("transporteTodos_sps"))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ID: {0} - Transporte: {1} | Terreno: {2}", item.Id, item.Nome, item.Terreno);
                        Console.WriteLine("*********************************************************************");
                    }
                }
                else if (nomeEntidade.ToLower() == "viagem")
                {
                    // CONSULTA TODAS VIAGENS DISPONIVEIS
                    
                    foreach (var item in repoViagem.Listar("viagensDispTodos_sps"))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ID: {0} - Planeta Origem: {1} | Planeta Destino: {2} | Valor: {3} | Distancia: {4} Anos-luz",
                            item.Id, item.PlanetaOrigem, item.PlanetaDestino, item.Valor, item.Tempo);
                        Console.WriteLine("*********************************************************************");
                    }
                }
            }
            else if (opcaoConsultar == "2")
            {

                if (nomeEntidade.ToLower() == "planeta")
                {
                    // CONSULTA PLANETA POR ID
                    Console.WriteLine("Qual o ID do(a) {0}?", nomeEntidade);
                    int id = Convert.ToInt32(Console.ReadLine());

                    List<Planetas> listaPlanetas = repoPlaneta.Obter(id, "planetasPorId_sps");
                    MostarConsultaPlaneta(listaPlanetas);

                }
                else if (nomeEntidade.ToLower() == "cliente")
                {
                    // CONSULTA CLIENTE POR ID
                    Console.WriteLine("Qual o ID do(a) {0}?", nomeEntidade);
                    int id = Convert.ToInt32(Console.ReadLine());

                    List<Clientes> listaClientes = repoCliente.Obter(id, "clientesPorId_sps");
                    MostrarConsultCliente(listaClientes);
                }
                else if (nomeEntidade.ToLower() == "transporte")
                {
                    // CONSULTA TRANSPORTE POR NOME
                    Console.WriteLine("Qual o nome do(a) {0}", nomeEntidade);
                    string nome = Console.ReadLine();

                    Transportes transporte = repoTransporte.Obter(nome, "transportePorNome_sps");

                    Console.WriteLine("");
                    Console.WriteLine("ID: {0} - Transporte: {1} - Terreno: {2}", transporte.Id, transporte.Nome, transporte.Terreno);
                    Console.WriteLine("*********************************************************************");

                }
                else if (nomeEntidade.ToLower() == "viagem")
                {
                    // CONSULTA VIAGEM POR NOME
                    Console.WriteLine("Informe o planeta de origem ou destino:");
                    string planeta = Console.ReadLine();

                    foreach (var item in repoViagem.ObterViagens(planeta, "viagensDispPorNome_sps"))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ID: {0} - Planeta Origem: {1} | Planeta Destino: {2} | Valor: {3} | Distancia: {4} Anos-luz",
                            item.Id, item.PlanetaOrigem, item.PlanetaDestino, item.Valor, item.Tempo);
                        Console.WriteLine("*********************************************************************");
                    }
                }
            }
        }

        private static void MostrarConsultCliente(List<Clientes> listaClientes)
        {
            foreach (var item in listaClientes)
            {
                Console.WriteLine("");
                Console.WriteLine("ID: {0} - Cliente: {1} | Especie: {2} | Documento: {3}", item.Id, item.Nome, item.Especie, item.Documento);
                Console.WriteLine("Cor: {0} | {1} Braço(s) | {2} Perna(s) | {3} Cabeça(s)", item.Cor, item.QtdBracos, item.QtdPernas, item.QtdCabeca);
                Console.WriteLine("Respira? {0}", item.Respira == true ? "Sim" : "Não");
                Console.WriteLine("*********************************************************************");
            }
        }

        private static void MostarConsultaPlaneta(List<Planetas> listaPlanetas)
        {
            foreach (var item in listaPlanetas)
            {
                Console.WriteLine("");
                Console.WriteLine("ID: {0} - Planeta: {1}", item.Id, item.Nome);
                Console.WriteLine("Descrição: {0}", item.Descricao);
                Console.WriteLine("Possui Oxiênio? {0}", item.PossuiOxigenio == true ? "Sim" : "Não");
                Console.WriteLine("*********************************************************************");
            }
        }
    }
}
