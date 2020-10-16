using Dapper;

using Estudantes_CodeLopp_.Models.DTOs;

using MySql.Data.MySqlClient;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Estudantes_CodeLopp_.Models.DAOs
{


    public class DAOAluno
    {
        Aluno _aluno;
        public DAOAluno()
        {
            _aluno = new Aluno();
        }
        /// <summary>
        /// Para obter todos registos
        /// </summary>
        /// <returns></returns>
        public List<Aluno> ObterTudo()
        {
            //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select {nameof(_aluno.Id)}, {nameof(_aluno.NomeCompleto)}," +
                    $"{nameof(_aluno.IdSerieDeIngresso)},{nameof(_aluno.IdMae)},{nameof(_aluno.IdEndereco)}  from Aluno";
                return db.Query<Aluno>(sql, commandType: CommandType.Text).ToList();
            }

        }
        /// <summary>
        /// Para obter todos registos com base nas tabelas relacionadas (mae,seriedeingresso e endereco)
        /// </summary>
        /// <returns></returns>
        public List<DTOAluno> ObterTudoDTO()
        {
            //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "select a.id, m.id 'idMae', e.id 'idEndereco',a.nomeCompleto,s.serie,m.nomeCompleto 'nomecompletomae'," +
                    "e.cep, e.rua, e.numeroDaResidencia, e.complemento, e.bairro, e.estado, " +
                    "e.cidade  from aluno a, mae m, seriedeingresso s, endereco e" +
                    "  where a.idMae = m.id and a.idSerieDeIngresso = s.id " +
                    "and a.idEndereco = e.id; ";
                return db.Query<DTOAluno>(sql, commandType: CommandType.Text).ToList();
            }

        }

        /// <summary>
        /// Para obter um único registo de acordo ao id
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public Aluno ObterPeloId(Aluno aluno)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select {nameof(_aluno.Id)}, {nameof(_aluno.NomeCompleto)}," +
                    $"{nameof(_aluno.IdSerieDeIngresso)},{nameof(_aluno.IdMae)},{nameof(_aluno.IdEndereco)}" +
                    $" from Aluno where {nameof(_aluno.Id)}='{aluno.Id}'";
                return db.Query<Aluno>(sql, commandType: CommandType.Text).FirstOrDefault();
            }

        }


        /// <summary>
        /// Para obter um único registo com base nas tabelas relacionadas (mae,seriedeingresso e endereco)
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public DTOAluno ObterDTO(Aluno aluno)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "select a.id, m.id 'idMae', e.id 'idEndereco',a.nomeCompleto,s.serie,m.nomeCompleto 'nomecompletomae'," +
                    "e.cep, e.rua, e.numeroDaResidencia, e.complemento, e.bairro, e.estado, " +
                    "e.cidade  from aluno a, mae m, seriedeingresso s, endereco e" +
                    "  where a.idMae = m.id and a.idSerieDeIngresso = s.id " +
                    $"and a.idEndereco = e.id and a.id='{aluno.Id}'; ";
                return db.Query<DTOAluno>(sql, commandType: CommandType.Text).FirstOrDefault();
            }

        }


        /// <summary>
        /// Para inserir um novo registo
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public int Inserir(Aluno aluno)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"INSERT INTO aluno ({nameof(_aluno.NomeCompleto)},{nameof(_aluno.IdSerieDeIngresso)}," +
                    $"{nameof(_aluno.IdMae)},{nameof(_aluno.IdEndereco)}) VALUES('{aluno.NomeCompleto}'," +
                    $"{aluno.IdSerieDeIngresso},{aluno.IdMae}, {aluno.IdEndereco} );";

                return db.Execute(sql, commandType: CommandType.Text);
            }

        }

        /// <summary>
        /// Para actualizar um registo existente de acordo ao id
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public int Actualizar(Aluno aluno)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"update Aluno  set {nameof(_aluno.NomeCompleto)}='{aluno.NomeCompleto}', " +
                    $"{nameof(_aluno.IdSerieDeIngresso)}={aluno.IdSerieDeIngresso}," +
                    $"{nameof(_aluno.IdMae)}={aluno.IdMae}, {nameof(_aluno.IdEndereco)}={aluno.IdEndereco} " +
                    $" where {nameof(_aluno.Id)}='{aluno.Id}'";
                return db.Execute(sql, commandType: CommandType.Text);
            }

        }

        /// <summary>
        /// Para eliminar um registo existente de acordo ao id
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public int Eliminar(Aluno aluno)
        {
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"delete from  Aluno where {nameof(_aluno.Id)}='{aluno.Id}'";
                return db.Execute(sql, commandType: CommandType.Text);
            }
        }



    }
}