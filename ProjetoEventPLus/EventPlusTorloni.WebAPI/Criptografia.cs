namespace EventPlusTorloni.WebAPI;

public static class Criptografia
{
    public static string GerarHash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    public static bool Comparar(string senhaInformada, string senhaBanco)
    {
        return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaBanco);
    }


}
