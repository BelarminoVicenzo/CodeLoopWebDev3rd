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

        public List<Endereco> ObterTudo()
        {
            //
            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = "select id, cep, rua, numeroDaResidencia, complemento, bairro, cidade, estado  from Endereco";
                return db.Query<Endereco>(sql, commandType: CommandType.Text).ToList();
            }

        }

        //Obtem apenas um registo
        public Endereco Obter(Endereco end)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"select id, cep, rua, numeroDaResidencia, complemento, bairro, cidade, estado  from Endereco where id={end.Id}";
                return db.Query<Endereco>(sql, commandType: CommandType.Text).FirstOrDefault();
            }

        }



        public int Inserir(Endereco end)
        {

            using (var db = new MySqlConnection(ConfigurationManager.ConnectionStrings["estudantescn"].ConnectionString))
            {

                string sql = $"INSERT INTO endereco (cep, rua, numeroDaResidencia, complemento, bairro, cidade, estado) " +
                    $"VALUES({end.CEP},{end.Rua},{end.NumeroDaResidencia}," +
                    $"{end.Complemento},{end.Bairro},{end.Cidade},{end.Estado}; ";

                return db.Execute(sql, commandType: CommandType.Text);
            }

        }

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