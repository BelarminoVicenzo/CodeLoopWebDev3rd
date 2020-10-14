using Dapper;

using MySql.Data.MySqlClient;

using MySqlX.XDevAPI.Common;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Estudantes_CodeLopp_.Models.DAOs
{


    public class DAOSerieDeIngresso
    {

        public List<SerieDeIngresso> ObterTudo()
        {
            //List<SerieDeIngresso> serie;
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "select id, serie from seriedeingresso";
               return  db.Query<SerieDeIngresso>(sql, commandType: CommandType.Text).ToList();
            }
            
        }
        
        //Obtem apenas um registo
        public SerieDeIngresso Obter(SerieDeIngresso serie)
        {
           
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select id, serie from seriedeingresso where id={serie.Id}";
                return db.Query<SerieDeIngresso>(sql, commandType: CommandType.Text).FirstOrDefault();
            }
            
        }



        public int Inserir(SerieDeIngresso serie)
        {
            
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"INSERT INTO `estudantes`.`seriedeingresso` (serie) values ('{serie.Serie}')";
               return db.Execute(sql, commandType: CommandType.Text);
            }
           
        }

        public int Actualizar(SerieDeIngresso serie)
        {
            
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"update seriedeingresso set serie='{serie.Serie}' where id={serie.Id}";
               return db.Execute(sql, commandType: CommandType.Text);
            }
           
        }

        public int Eliminar(SerieDeIngresso serie)
        {
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"delete from  seriedeingresso where id={serie.Id}";
                return db.Execute(sql, commandType: CommandType.Text);
            }
        }



    }
}