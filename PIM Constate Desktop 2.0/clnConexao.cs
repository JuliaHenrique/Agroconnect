using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_Constate_Desktop_2._0
{
    public class clnConexao
    {
        private SqlConnection connection;

        // Construtor que aceita a string de conexão
        public clnConexao(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        // Método para abrir a conexão
        public void Open()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Método para fechar a conexão
        public void Close()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Método para obter a conexão
        public SqlConnection GetConnection()
        {
            return connection;
        }

        // Método para inserir o produto no banco de dados
        public bool InserirProduto(string nome, string quantidade, decimal preco, string categoria, string codigo)
        {
            // Verificar se os valores não são nulos ou vazios
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(categoria) || string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Campos obrigatórios não podem estar vazios.");
                return false;
            }

            try
            {
                // Abrir a conexão
                Open();

                // Adicionar o comando SQL
                string query = "INSERT INTO Produtos (NomeProduto, QuantidadeProduto, PrecoProduto, CategoriaProduto, CodigoProduto) " +
                               "VALUES (@NomeProduto, @QuantidadeProduto, @PrecoProduto, @CategoriaProduto, @CodigoProduto)";

                // Criar o comando SQL
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Verifique os valores antes de adicionar os parâmetros
                    MessageBox.Show($"NomeProduto: {nome}, QuantidadeProduto: {quantidade}, PrecoProduto: {preco}, CategoriaProduto: {categoria}, CodigoProduto: {codigo}");

                    // Adicionar os parâmetros de forma segura
                    cmd.Parameters.AddWithValue("@NomeProduto", nome);
                    cmd.Parameters.AddWithValue("@QuantidadeProduto", (object)quantidade ?? DBNull.Value); // Para lidar com NULL se vazio
                    cmd.Parameters.AddWithValue("@PrecoProduto", preco);
                    cmd.Parameters.AddWithValue("@CategoriaProduto", categoria);
                    cmd.Parameters.AddWithValue("@CodigoProduto", codigo);

                    // Executar o comando
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true se a inserção foi bem-sucedida
                }
            }
            catch (SqlException sqlEx)
            {
                // Exibir a mensagem de erro SQL
                MessageBox.Show($"Erro ao inserir o produto no banco de dados: {sqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Exibir a mensagem de erro
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Fechar a conexão ao final
                Close();
            }
        }

        public bool alterarProduto(string nome, string quantidade, decimal preco, string categoria, string codigo)
        {
            // Verificar se os valores não são nulos ou vazios
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(categoria) || string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Campos obrigatórios não podem estar vazios.");
                return false;
            }

            try
            {
                // Abrir a conexão
                Open();

                // Adicionar o comando SQL
                string query = "UPDATE Produtos " +
                                "SET NomeProduto = @NomeProduto, " +
                                "    QuantidadeProduto = @QuantidadeProduto, " +
                                "    PrecoProduto = @PrecoProduto, " +
                                "    CategoriaProduto = @CategoriaProduto " +
                                "WHERE CodigoProduto = @CodigoProduto";

                // Criar o comando SQL
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Verifique os valores antes de adicionar os parâmetros
                    MessageBox.Show($"NomeProduto: {nome}, QuantidadeProduto: {quantidade}, PrecoProduto: {preco}, CategoriaProduto: {categoria}, CodigoProduto: {codigo}");

                    // Adicionar os parâmetros de forma segura
                    cmd.Parameters.AddWithValue("@NomeProduto", nome);
                    cmd.Parameters.AddWithValue("@QuantidadeProduto", (object)quantidade ?? DBNull.Value); // Para lidar com NULL se vazio
                    cmd.Parameters.AddWithValue("@PrecoProduto", preco);
                    cmd.Parameters.AddWithValue("@CategoriaProduto", categoria);
                    cmd.Parameters.AddWithValue("@CodigoProduto", codigo);

                    // Executar o comando
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true se a inserção foi bem-sucedida
                }
            }
            catch (SqlException sqlEx)
            {
                // Exibir a mensagem de erro SQL
                MessageBox.Show($"Erro ao inserir o produto no banco de dados: {sqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Exibir a mensagem de erro
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Fechar a conexão ao final
                Close();
            }
        }

        public bool InserirFuncionario(string nomeCompleto, string cpf, DateTime dataNascimento, string endereco, string email,
                               string cargo, decimal salario, string usuario, string senha, int status)
        {
            // Verificar se os campos obrigatórios não estão vazios ou nulos
            if (string.IsNullOrEmpty(nomeCompleto) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(cargo) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Campos obrigatórios não podem estar vazios.");
                return false;
            }

            try
            {
                // Abrir a conexão
                Open();

                // Comando SQL de inserção
                string query = "INSERT INTO tb_funcionario (nome_completo_funcionario, cpf_funcionario, data_nascimento_funcionario, " +
                               "endereco_funcionario, email_funcionario, cargo_funcionario, salario_funcionario, usuario_funcionario, " +
                               "senha_funcionario, status_funcionario) " +
                               "VALUES (@NomeCompleto, @Cpf, @DataNascimento, @Endereco, @Email, @Cargo, @Salario, @Usuario, @Senha, @Status)";

                // Criar o comando SQL
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Adicionar os parâmetros de forma segura
                    cmd.Parameters.AddWithValue("@NomeCompleto", nomeCompleto);
                    cmd.Parameters.AddWithValue("@Cpf", cpf);
                    cmd.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                    cmd.Parameters.AddWithValue("@Endereco", (object)endereco ?? DBNull.Value); // Caso o campo "endereco" seja vazio, usa DBNull
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Cargo", cargo);
                    cmd.Parameters.AddWithValue("@Salario", salario);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    cmd.Parameters.AddWithValue("@Status", status);

                    // Executar o comando
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true se a inserção foi bem-sucedida
                }
            }
            catch (SqlException sqlEx)
            {
                // Exibir a mensagem de erro SQL
                MessageBox.Show($"Erro ao inserir o funcionário no banco de dados: {sqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Exibir a mensagem de erro
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Fechar a conexão ao final
                Close();
            }
        }
    }
}