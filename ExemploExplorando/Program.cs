using ExemploExplorando.Models;

Pessoa p1 = new Pessoa();

p1.Nome = "Carlos";
p1.Sobrenome = "Rocha";



Pessoa p2 = new Pessoa();

p2.Nome = "Eduardo";
p2.Sobrenome = "Dos Anjos Souza";


Curso cursoDeIngles = new Curso();

cursoDeIngles.Nome = "Inglês";
cursoDeIngles.Alunos = new List<Pessoa>();


cursoDeIngles.AdicionarAlunos(p1);
cursoDeIngles.AdicionarAlunos(p2);
cursoDeIngles.ListarAlunos();





