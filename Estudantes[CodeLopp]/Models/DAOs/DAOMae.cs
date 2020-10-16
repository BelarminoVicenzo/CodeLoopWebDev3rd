using Dapper;

using MySql.Data.MySqlClient;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Estudantes_CodeLopp_.Models.DAOs
{


    public class DAOMae
    {
        /// <summary>
        /// Para obter todos registos
        /// </summary>
        /// <returns></returns>
        public List<Mae> ObterTudo()
        {
           //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "select id, nomeCompleto, cpf,  dataPreferencialPagamento  from mae";
               return  db.Query<Mae>(sql, commandType: CommandType.Text).ToList();
            }
            
        }
        
        /// <summary>
        /// Para obter todos nomes e cpfs
        /// </summary>
        /// <returns></returns>
        public List<Mae> ObterNomeECPF()
        {
           //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "SELECT id, concat(nomeCompleto,' - ',cpf) 'nomeCompleto' FROM estudantes.mae;";
               return  db.Query<Mae>(sql, commandType: CommandType.Text).ToList();
            }
            
        }

        /// <summary>
        /// Para obter um único registo de acordo ao id
        /// </summary>
        /// <param name="mae"></param>
        /// <returns></returns>
        public Mae ObterPeloId(Mae mae)
        {
           
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select id, nomeCompleto, cpf, dataPreferencialPagamento  from mae where id={mae.Id}";
                return db.Query<Mae>(sql, commandType: CommandType.Text).FirstOrDefault();
            }
            
        }


        /// <summary>
        /// Para inserir um novo registo
        /// </summary>
        /// <param name="mae"></param>
        /// <returns></returns>
        public int Inserir(Mae mae)
        {
            
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"INSERT INTO mae (nomeCompleto, cpf, dataPreferencialPagamento)" +
                    $" VALUES ('{mae.NomeCompleto}', '{mae.CPF}', '{mae.DataPreferencialPagamento.Value.ToString("yyyy-MM-dd")}')";

               return db.Execute(sql, commandType: CommandType.Text);
            }
           
        }
        /// <summary>
        /// Para actualizar um registo existente de acordo ao id
        /// </summary>
        /// <param name="mae"></param>
        /// <returns></returns>
        public int Actualizar(Mae mae)
        {
            
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"update mae set nomeCompleto='{mae.NomeCompleto}', cpf='{mae.CPF}'," +
                    $"dataPreferencialPagamento='{mae.DataPreferencialPagamento.Value.ToString("yyyy-MM-dd")}'  where id={mae.Id}";
               return db.Execute(sql, commandType: CommandType.Text);
            }
           
        }

        /// <summary>
        /// Para eliminar um registo existente de acordo ao id
        /// </summary>
        /// <param name="mae"></param>
        /// <returns></returns>
        public int Eliminar(Mae mae)
        {
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"delete from  mae where id={mae.Id}";
                return db.Execute(sql, commandType: CommandType.Text);
            }
        }



    }
}