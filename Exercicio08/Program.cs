using Exercicio08;

IAutenticavel usuario = new Usuario();
IAutenticavel admin = new Administrador();

System.Console.WriteLine($"usuario.Autenticar{1234}");
System.Console.WriteLine($"admin.Autenticar{admin}");
System.Console.WriteLine($"admin.Autenticar{1234}");