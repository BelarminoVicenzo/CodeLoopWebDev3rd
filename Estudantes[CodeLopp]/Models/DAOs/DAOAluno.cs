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

        public List<Aluno> ObterTudo()
        {
            //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "select id, nomeCompleto,idSerieDeIngresso,idMae,idEndereco  from Aluno";
                return db.Query<Aluno>(sql, commandType: CommandType.Text).ToList();
            }

        }
        
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

        //Obtem apenas um registo
        public Aluno Obter(Aluno aluno)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select id, nomeCompleto,idSerieDeIngresso,idMae,idEndereco from Aluno where id='{aluno.Id}'";
                return db.Query<Aluno>(sql, commandType: CommandType.Text).FirstOrDefault();
            }

        }
       
        //Obtem apenas um registo de todas tabelas interligadas
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



        public int Inserir(Aluno aluno)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"INSERT INTO aluno (nomeCompleto,idSerieDeIngresso,idMae,idEndereco) " +
                    $"VALUES('{aluno.NomeCompleto}',{aluno.IdSerieDeIngresso},{aluno.IdMae}," +
                    $"{aluno.IdEndereco} );";

                return db.Execute(sql, commandType: CommandType.Text);
            }

        }

        public int Actualizar(Aluno aluno)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"update Aluno  set nomeCompleto='{aluno.NomeCompleto}', idSerieDeIngresso={aluno.IdSerieDeIngresso}," +
                    $"idMae={aluno.IdMae}, idEndereco={aluno.IdEndereco}  where id='{aluno.Id}'";
                return db.Execute(sql, commandType: CommandType.Text);
            }

        }

        public int Eliminar(Aluno aluno)
        {
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {
                string sql = $"delete from  Aluno where id='{aluno.Id}'";
                return db.Execute(sql, commandType: CommandType.Text);
            }
        }



    }
}