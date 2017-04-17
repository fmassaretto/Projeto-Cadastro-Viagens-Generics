using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjetoViagens.DB.Base;
using System.Collections;

namespace ProjetoViagens.Data
{
    public class Repository<T> : Connection where T : class
    {
        public T Atualizar(T entidade, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            Dictionary<string, dynamic> listaPropValues = new Dictionary<string, dynamic>();

            foreach (var prop in entidade.GetType().GetProperties())
            {
                listaPropValues.Add(prop.Name, prop.GetValue(entidade));
            }

            foreach (var item in listaPropValues)
            {
                comando.Parameters.AddWithValue("@"+item.Key, item.Value);
                //Console.WriteLine("@" + item.Key + " " + item.Value);
            }

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("");
                Console.WriteLine("********************************");
                Console.WriteLine(reader["msgSucesso"]);
                Console.WriteLine("********************************");
                Console.WriteLine("");
            }

            return entidade;
        }

        public void Excluir(int id, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("");
                Console.WriteLine("********************************");
                Console.WriteLine(reader["msgSucesso"]);
                Console.WriteLine("********************************");
                Console.WriteLine("");
            }
        }

        public T Incluir(T entidade, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            Dictionary<string, dynamic> listaPropValues = new Dictionary<string, dynamic>();

            foreach (var prop in entidade.GetType().GetProperties())
            {
                listaPropValues.Add(prop.Name, prop.GetValue(entidade));               
            }

            foreach (var item in listaPropValues)
            {
                if (item.Key != "Id")
                {
                    comando.Parameters.AddWithValue("@" + item.Key, item.Value);
                    //Console.WriteLine("@" + item.Key + " " + item.Value);
                }
            }

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("");
                Console.WriteLine("********************************");
                Console.WriteLine(reader["msgSucesso"]);
                Console.WriteLine("********************************");
                Console.WriteLine("");
            }

            return entidade;
        }

        public List<T> Listar(string procedure)
        {
            List<T> lista = new List<T>();

            SqlCommand comando = GetSqlCommand(procedure);

            SqlDataReader reader = comando.ExecuteReader();
            
            while (reader.Read())
            {
                var Objeto = Activator.CreateInstance<T>();
                foreach (var propriedade in typeof(T).GetProperties())
                {
                    if (propriedade.Name != null)
                    {
                        propriedade.SetValue(Objeto, reader[propriedade.Name]);
                        //Console.WriteLine(propriedade);
                    }                  
                }
                lista.Add(Objeto);
            }
            return lista;
        }

        public List<T> Obter(int id, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@Id", id);

            List<T> lista = new List<T>();

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                var Objeto = Activator.CreateInstance<T>();
                foreach (var propriedade in typeof(T).GetProperties())
                {
                    if (propriedade.Name != null)
                    {
                        propriedade.SetValue(Objeto, reader[propriedade.Name]);
                        //Console.WriteLine(propriedade);
                    }
                }
                lista.Add(Objeto);
            }
            return lista;
        }

    }
}
