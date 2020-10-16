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

        Endereco _end;
        public DAOEndereco()
        {
            _end = new Endereco();
        }

        /// <summary>
        /// Para obter todos registos
        /// </summary>
        /// <returns></returns>
        public List<Endereco> ObterTudo()
        {
            //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select {nameof(_end.Id)}, {nameof(_end.CEP)}, {nameof(_end.Rua)}, {nameof(_end.NumeroDaResidencia)}" +
                    $", {nameof(_end.Complemento)}, {nameof(_end.Bairro)}, {nameof(_end.Cidade)}, {nameof(_end.Estado)}  from Endereco";
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

                string sql = $"select {nameof(_end.Id)}, {nameof(_end.CEP)}, {nameof(_end.Rua)}," +
                    $" {nameof(_end.NumeroDaResidencia)}, {nameof(_end.Complemento)}, {nameof(_end.Bairro)}," +
                    $" {nameof(_end.Cidade)}, {nameof(_end.Estado)}  from Endereco where {nameof(_end.Id)}={end.Id}";
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

                string sql = $"INSERT INTO endereco ({nameof(_end.CEP)}, {nameof(_end.Rua)}, {nameof(_end.NumeroDaResidencia)}," +
                    $" {nameof(_end.Complemento)}, {nameof(_end.Bairro)}, {nameof(_end.Cidade)}," +
                    $" {nameof(_end.Estado)}) VALUES('{end.CEP}','{end.Rua}',{end.NumeroDaResidencia}," +
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
                string sql = $"update endereco set {nameof(_end.CEP)}='{end.CEP}', {nameof(_end.Rua)}='{end.Rua}'," +
                    $"{nameof(_end.NumeroDaResidencia)}={end.NumeroDaResidencia}, " +
                    $"{nameof(_end.Complemento)}='{end.Complemento}', {nameof(_end.Bairro)}='{end.Bairro}'," +
                    $" {nameof(_end.Cidade)}='{end.Cidade}', {nameof(_end.Estado)}='{end.Estado}'  where {nameof(_end.Id)}={end.Id}";
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
                string sql = $"delete from  Endereco where {nameof(_end.Id)}={end.Id}";
                return db.Execute(sql, commandType: CommandType.Text);
            }
        }



    }
}