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


        Mae mae;
        public DAOMae()
        {
            mae = new Mae();

        }

        /// <summary>
        /// Para obter todos registos
        /// </summary>
        /// <returns></returns>
        public List<Mae> ObterTudo()
        {
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select {nameof(mae.Id)},{nameof(mae.NomeCompleto)},{nameof(mae.CPF)},{nameof(mae.DataPreferencialPagamento)}  from mae";
                return db.Query<Mae>(sql, commandType: CommandType.Text).ToList();
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

                string sql = $"SELECT {nameof(mae.Id)}, concat({nameof(mae.NomeCompleto)},' - ',{nameof(mae.CPF)})" +
                    $" '{nameof(mae.NomeCompleto)}' FROM estudantes.mae;";
                return db.Query<Mae>(sql, commandType: CommandType.Text).ToList();
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

                string sql = $"select {nameof(mae.Id)},{nameof(mae.NomeCompleto)},{nameof(mae.CPF)}," +
                    $"{nameof(mae.DataPreferencialPagamento)}  from mae where id={mae.Id}";
                return db.Query<Mae>(sql, commandType: CommandType.Text).FirstOrDefault();
            }

        }

        /// <summary>
        /// Para verificar pela existência do cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public bool VerificarExistenciaCPF(string cpf)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $" select count(*) from mae where cpf='cpf';";
                    var resultado=db.Query<int>(sql, commandType: CommandType.Text).FirstOrDefault();
                if (resultado>0)
                {
                    return true;
                }
                return false;
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

                string sql = $"INSERT INTO mae ({nameof(mae.NomeCompleto)}, {nameof(mae.CPF)}, {nameof(mae.DataPreferencialPagamento)})" +
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
                string sql = $"update mae set {nameof(mae.NomeCompleto)}='{mae.NomeCompleto}', {nameof(mae.CPF)}='{mae.CPF}'," +
                    $"{nameof(mae.DataPreferencialPagamento)}='{mae.DataPreferencialPagamento.Value.ToString("yyyy-MM-dd")}' " +
                    $" where {nameof(mae.Id)}={mae.Id}";
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
                string sql = $"delete from  mae where {nameof(mae.Id)}={mae.Id}";
                return db.Execute(sql, commandType: CommandType.Text);
            }
        }



    }
}