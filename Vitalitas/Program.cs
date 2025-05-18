using Microsoft.Data.SqlClient;

var connectionString = "Server=SLIPPER\\SLQEXPRESS,1433;Database=TESTE_CRIACAO;User Id=usuarioapi;Password=Senha123456;TrustServerCertificate=True;";

try
{
    using var connection = new SqlConnection(connectionString);
    connection.Open();
    Console.WriteLine("✅ Conexão bem-sucedida!");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Erro ao conectar: {ex.Message}");
}
