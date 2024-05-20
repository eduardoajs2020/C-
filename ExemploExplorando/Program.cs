using ExemploExplorando.Models;

Pessoa p1 = new Pessoa(nome: "Carlos", sobrenome: "Rocha");
Pessoa p2 = new Pessoa(nome: "Eduardo", sobrenome: "Dos Anjos Souza");

Curso cursoDeIngles = new Curso();
cursoDeIngles.Nome = "Inglês";
cursoDeIngles.Alunos = new List<Pessoa>();

cursoDeIngles.AdicionarAlunos(p1);
cursoDeIngles.AdicionarAlunos(p2);
cursoDeIngles.ListarAlunos();





