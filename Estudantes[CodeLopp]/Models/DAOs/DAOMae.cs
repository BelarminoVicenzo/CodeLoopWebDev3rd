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

        public List<Mae> ObterTudo()
        {
           //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "select id, nomeCompleto, cpf,  dataPreferencialPagamento  from mae";
               return  db.Query<Mae>(sql, commandType: CommandType.Text).ToList();
            }
            
        }
        
        public List<Mae> ObterNomeECPF()
        {
           //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "SELECT id, concat(nomeCompleto,' - ',cpf) 'nomeCompleto' FROM estudantes.mae;";
               return  db.Query<Mae>(sql, commandType: CommandType.Text).ToList();
            }
            
        }
        
        //Obtem apenas um registo
        public Mae Obter(Mae mae)
        {
           
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select id, nomeCompleto, cpf, dataPreferencialPagamento  from mae where id={mae.Id}";
                return db.Query<Mae>(sql, commandType: CommandType.Text).FirstOrDefault();
            }
            
        }



        public int Inserir(Mae mae)
        {
            
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"INSERT INTO mae (nomeCompleto, cpf, dataPreferencialPagamento)" +
                    $" VALUES ('{mae.NomeCompleto}', '{mae.CPF}', '{mae.DataPreferencialPagamento.Value.ToString("yyyy-MM-dd")}')";

               return db.Execute(sql, commandType: CommandType.Text);
            }
           
        }

        public int Actualizar(Mae mae)
        {
            
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"update mae set nomeCompleto='{mae.NomeCompleto}', cpf='{mae.CPF}'," +
                    $"dataPreferencialPagamento='{mae.DataPreferencialPagamento.Value.ToString("yyyy-MM-dd")}'  where id={mae.Id}";
               return db.Execute(sql, commandType: CommandType.Text);
            }
           
        }

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