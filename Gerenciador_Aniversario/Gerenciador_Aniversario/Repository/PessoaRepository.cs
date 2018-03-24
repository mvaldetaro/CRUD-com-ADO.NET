using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Gerenciador_Aniversario.Domain;

namespace Gerenciador_Aniversario.Repository
{
    public class PessoaRepository : AbstractRepository<PessoaDomain, int>
    {
        string StringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\crud_ado_net\Gerenciador_Aniversario\Gerenciador_Aniversario\App_Data\Aniversarios_DB.mdf;Integrated Security=True";

        public override void Delete(PessoaDomain entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Pessoa Where PessoaId=@PessoaId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PessoaId", entity.PessoaID);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Pessoa Where PessoaID=@PessoaID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PessoaID", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override List<PessoaDomain> GetAll()
        {
            string sql = "Select PessoaID, Nome, Sobrenome, DtAniversario FROM Pessoa ORDER BY DtAniversario";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<PessoaDomain> list = new List<PessoaDomain>();
                PessoaDomain p = null;

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new PessoaDomain();
                            p.PessoaID = (int)reader["PessoaID"];
                            p.Nome = reader["Nome"].ToString();
                            p.Sobrenome = reader["Sobrenome"].ToString();
                            p.DtAniversario = Convert.ToDateTime(reader["DtAniversario"]);
                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return list;
            }
        }

        public override PessoaDomain GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, Nome, Sobrenome, DtAniversario FROM Pessoa WHERE PessoaID=@PessoaID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PessoaID", id);
                PessoaDomain p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new PessoaDomain();
                                p.PessoaID = (int)reader["PessoaID"];
                                p.Nome = reader["Nome"].ToString();
                                p.Sobrenome = reader["Sobrenome"].ToString();
                                p.DtAniversario = Convert.ToDateTime(reader["DtAniversario"]);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }

        public override void Save(PessoaDomain entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Pessoa (Nome, Sobrenome, DtAniversario) VALUES (@Nome, @Sobrenome, @DtAniversario)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", entity.Sobrenome);
                cmd.Parameters.AddWithValue("@DtAniversario", entity.DtAniversario);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void Update(PessoaDomain entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Pessoa SET Nome=@Nome, Sobrenome=@Sobrenome, DtAniversario=@DtAniversario Where PessoaID=@PessoaID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PessoaID", entity.PessoaID);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", entity.Sobrenome);
                cmd.Parameters.AddWithValue("@DtAniversario", entity.DtAniversario);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
    }
}