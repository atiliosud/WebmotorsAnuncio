using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using WebmotorsAnuncio.Models.Domain;

namespace WebmotorsAnuncio.Repositories
{
    public class AnuncioRepository 
    {
        private string _connectionString;
        public AnuncioRepository()
        {
            string _connectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        }

        public SqlConnection OpenDbConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public Anuncio Select(int ID)
        {
            using (var sqlConnection = OpenDbConnection())
            {
                try
                {

                    string sql = "SELECT * FROM tb_AnuncioWebmotors WHERE ID=@ID";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.CommandType = CommandType.Text;

                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read()) return null;

                    return new Anuncio()
                    {
                        ID = reader.GetInt32(0),
                        Marca = reader.GetString(1),
                        Modelo = reader.GetString(2),
                        Versao = reader.GetString(3),
                        Ano = reader.GetInt32(4),
                        Quilometragem = reader.GetInt32(5),
                        Observacao = reader.GetString(6)
                    };
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public int Insert(Anuncio anuncio)
        {
            using (var sqlConnection = OpenDbConnection())
            {
                try
                {

                    string sql = "INSERT INTO tb_AnuncioWebmotors (marca, modelo, versao, ano, quilometragem, observacao) " +
                    " VALUES (@Marca , @Modelo , @Versao , @Ano , @Quilometragem , @Observacao ) ";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("@ID", anuncio.ID);
                    cmd.Parameters.AddWithValue("@Marca", anuncio.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", anuncio.Modelo);
                    cmd.Parameters.AddWithValue("@Versao", anuncio.Versao);
                    cmd.Parameters.AddWithValue("@Ano", anuncio.Ano);
                    cmd.Parameters.AddWithValue("@Quilometragem", anuncio.Quilometragem);
                    cmd.Parameters.AddWithValue("@Observacao", anuncio.Observacao);
                    cmd.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public int Update(Anuncio anuncio)
        {
            using (var sqlConnection = OpenDbConnection())
            {
                try
                {

                    string sql = "UPDATE tb_AnuncioWebmotors SET marca=@Marca, modelo=@Modelo, versao = @Versao," +
                    " ano = @Ano, quilometragem=@Quilometragem, observacao=@Observacao WHERE ID=@ID ";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("@ID", anuncio.ID);
                    cmd.Parameters.AddWithValue("@Marca", anuncio.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", anuncio.Modelo);
                    cmd.Parameters.AddWithValue("@Versao", anuncio.Versao);
                    cmd.Parameters.AddWithValue("@Ano", anuncio.Ano);
                    cmd.Parameters.AddWithValue("@Quilometragem", anuncio.Quilometragem);
                    cmd.Parameters.AddWithValue("@Observacao", anuncio.Observacao);
                    cmd.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public int Delete(int ID)
        {
            using (var sqlConnection = OpenDbConnection())
            {
                try
                {

                    string sql = "DELETE FROM tb_AnuncioWebmotors WHERE ID=@ID";
                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}