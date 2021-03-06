﻿using ProjetoViagens.Data;
using ProjetoViagens.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Telas
{
    class MostrarConsulta
    {
        #region MostraTodosTransportes
        public static void MostraTodosTransportes()
        {
            TransporteRepository repoTransporte = new TransporteRepository();

            foreach (var item in repoTransporte.Listar("transporteTodos_sps"))
            {
                Console.WriteLine("");
                Console.WriteLine("ID: {0} - Transporte: {1} | Terreno: {2}", item.Id, item.Nome, item.Terreno);
                Console.WriteLine("*********************************************************************");
            }
        }
        #endregion

        #region ConsultaTodasViagensDisponiveis
        public static void MostraTodasViagensDisponiveis()
        {
            ViagemDiponivelRepository repoViagem = new ViagemDiponivelRepository();
            foreach (var item in repoViagem.Listar("viagensDispTodos_sps"))
            {
                Console.WriteLine("");
                Console.WriteLine("ID: {0} - Planeta Origem: {1} | Planeta Destino: {2} | Valor: {3} | Distancia: {4} Anos-luz",
                    item.Id, item.PlanetaOrigem, item.PlanetaDestino, item.Valor, item.Tempo);
                Console.WriteLine("*********************************************************************");
            }
        }
        #endregion

        #region ConsultaBookingTodos
        public static void ConsultaBookingTodos()
        {
            BookingRepository repoBooking = new BookingRepository();

            Console.WriteLine("*****************************CONSULTA RESERVA********************************************");
            foreach (var item in repoBooking.Listar("viagemClienteTodos_sps"))
            {
                Console.WriteLine("*****************************************************************************************");
                Console.WriteLine("Codigo da Reserva: {0} - Cliente: {1} | Dodumento: {2}", item.CodigoReserva, item.clientes.Nome,
                    item.clientes.Documento);
                Console.WriteLine("De: {0} - Para: {1} | Valor: ${2} - Distancia: {3} Anos-Luz", item.viagemDispo.PlanetaOrigem,
                    item.viagemDispo.PlanetaDestino, item.viagemDispo.Valor, item.viagemDispo.Tempo);
                Console.WriteLine("Meio de Transporte: {0} - Terreno: {1}", item.transportes.Nome, item.transportes.Terreno);
                Console.WriteLine("");
            }
        }
        #endregion

        #region ConsultaBookingPorId
        public static void ConsultaBookingPorId()
        {
            Console.WriteLine("Qual o ID do Cliente?");
            int id = Convert.ToInt32(Console.ReadLine());

            bool cond = true;
            BookingRepository repoBooking = new BookingRepository();
            foreach (var item in repoBooking.ObterPorId(id, "viagemClientePorId_sps"))
            {
                if (cond == true)
                    Console.WriteLine("O Cliente: {0}, tem as seguintes reservas:", item.clientes.Nome);

                Console.WriteLine("Codigo da Reserva: {0} - (De: {1} - Para: {2}) Valor: ${3} - Distancia: {4} Anos-Luz",
                    item.CodigoReserva, item.viagemDispo.PlanetaOrigem, item.viagemDispo.PlanetaDestino, item.viagemDispo.Valor, item.viagemDispo.Tempo);
                Console.WriteLine("Meio de Transporte: {0} - Terreno: {1}", item.transportes.Nome, item.transportes.Terreno);

                Console.WriteLine("");
                cond = false;
            }
        }
        #endregion
    }
}
