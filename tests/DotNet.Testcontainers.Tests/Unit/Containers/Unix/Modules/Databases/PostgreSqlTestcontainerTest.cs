namespace DotNet.Testcontainers.Tests.Unit
{
  using System.Data;
  using System.Threading.Tasks;
  using DotNet.Testcontainers.Tests.Fixtures;
  using Xunit;

  public sealed class PostgreSqlTestcontainerTest : IClassFixture<PostgreSqlFixture>
  {
    private readonly PostgreSqlFixture postgreSqlFixture;

    public PostgreSqlTestcontainerTest(PostgreSqlFixture postgreSqlFixture)
    {
      this.postgreSqlFixture = postgreSqlFixture;
    }

    [Fact]
    public async Task ConnectionEstablished()
    {
      // Given
      await using var connection = await this.postgreSqlFixture.GetConnection()
        .ConfigureAwait(false);

      // When
      await connection.OpenAsync()
        .ConfigureAwait(false);

      // Then
      Assert.Equal(ConnectionState.Open, connection.State);
    }
  }
}
