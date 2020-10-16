using Dapper;

using MySql.Data.MySqlClient;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Estudantes_CodeLopp_.Models.DAOs
{


    public class DAOSerieDeIngresso
    {

        /// <summary>
        /// Para obter todos registos
        /// </summary>
        /// <returns></returns>
        public List<SerieDeIngresso> ObterTudo()
        {
            

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "select id, serie from seriedeingresso";
                return db.Query<SerieDeIngresso>(sql, commandType: CommandType.Text).ToList();
            }

        }


        /// <summary>
        /// Para obter um único registo de acordo ao id
        /// </summary>
        /// <param name="serie"></param>
        /// <returns></returns>
        public SerieDeIngresso ObterPeloId(SerieDeIngresso serie)
        {
            
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select id, serie from seriedeingresso where id={serie.Id}";
                return db.Query<SerieDeIngresso>(sql, commandType: CommandType.Text).FirstOrDefault();
            }

        }


        /// <summary>
        /// Para inserir um novo registo
        /// </summary>
        /// <param name="serie"></param>
        /// <returns></returns>
        public int Inserir(SerieDeIngresso serie)
        {
            
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"INSERT INTO `estudantes`.`seriedeingresso` (serie) values ('{serie.Serie}')";
                return db.Execute(sql, commandType: CommandType.Text);
            }

        }

        /// <summary>
        /// Para actualizar um registo existente de acordo ao id
        /// </summary>
        /// <param name="serie"></param>
        /// <returns></returns>
        public int Actualizar(SerieDeIngresso serie)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"update seriedeingresso set serie='{serie.Serie}' where id={serie.Id}";
                return db.Execute(sql, commandType: CommandType.Text);
            }

        }

        /// <summary>
        /// Para eliminar um registo existente de acordo ao id
        /// </summary>
        /// <param name="serie"></param>
        /// <returns></returns>
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