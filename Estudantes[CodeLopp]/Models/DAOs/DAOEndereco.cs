using Dapper;

using MySql.Data.MySqlClient;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Estudantes_CodeLopp_.Models.DAOs
{


    public class DAOEndereco
    {

        /// <summary>
        /// Para obter todos registos
        /// </summary>
        /// <returns></returns>
        public List<Endereco> ObterTudo()
        {
            //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "select id, cep, rua, numeroDaResidencia, complemento, bairro, cidade, estado  from Endereco";
                return db.Query<Endereco>(sql, commandType: CommandType.Text).ToList();
            }

        }

        /// <summary>
        /// Para obter um único registo de acordo ao id
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public Endereco ObterPeloId(Endereco end)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select id, cep, rua, numeroDaResidencia, complemento, bairro, cidade, estado  from Endereco where id={end.Id}";
                return db.Query<Endereco>(sql, commandType: CommandType.Text).FirstOrDefault();
            }

        }


        /// <summary>
        /// Para inserir um novo registo
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public int Inserir(Endereco end)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"INSERT INTO endereco (cep, rua, numeroDaResidencia, complemento, bairro, cidade, estado) " +
                    $"VALUES('{end.CEP}','{end.Rua}',{end.NumeroDaResidencia}," +
                    $"'{end.Complemento}','{end.Bairro}','{end.Cidade}','{end.Estado}'); ";

                return db.Execute(sql, commandType: CommandType.Text);
            }

        }

        /// <summary>
        /// Para actualizar um registo existente de acordo ao id
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public int Actualizar(Endereco end)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"update endereco set cep='{end.CEP}', rua='{end.Rua}'," +
                    $"numeroDaResidencia={end.NumeroDaResidencia}, complemento='{end.Complemento}'," +
                    $" bairro='{end.Bairro}', cidade='{end.Cidade}', estado='{end.Estado}'  where id={end.Id}";
                return db.Execute(sql, commandType: CommandType.Text);
            }

        }

        /// <summary>
        /// Para eliminar um registo existente de acordo ao id
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public int Eliminar(Endereco end)
        {
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"delete from  Endereco where id={end.Id}";
                return db.Execute(sql, commandType: CommandType.Text);
            }
        }



    }
}