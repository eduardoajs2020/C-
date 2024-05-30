using ExemploExplorando.Models;
using System.Globalization;
using Newtonsoft.Json;

//Serialização(Conversão em Json)

// DateTime dataAtual = DateTime.Now;

// List<Venda> listaVendas = new List<Venda>();

// Venda v1 = new Venda(1, "Material de Escritório", 25.00M, dataAtual);
// Venda v2 = new Venda(2, "Licença de Software", 110.00M, dataAtual);

// listaVendas.Add(v1);
// listaVendas.Add(v2);

// string serializado = JsonConvert.SerializeObject(listaVendas, Formatting.Indented);

// File.WriteAllText("Arquivos/vendas.json", serializado);

// Console.WriteLine(serializado);


string conteudoArquivo = File.ReadAllText("Arquivos/vendas.json");

List<Venda> listaVenda = JsonConvert.DeserializeObject<List<Venda>>(conteudoArquivo);

foreach (Venda venda in listaVenda)
{
    Console.WriteLine($"Id: {venda.Id}, Produto: {venda.Produto}\n" +
     $" Preco: {venda.Preco}, Data da venda: {venda.DataVenda.ToString("dd/MM/yyyy HH:mm")}");
}




























// int numero = 10;

// bool ehPar = false;

// ehPar = numero % 2 ==0;

// if (numero % 2 == 0)
// {
//     Console.WriteLine($"O numero {numero} é par");
// }
// else
// {
//     Console.WriteLine($"O numero {numero} é ímpar");
// }


//Ternario

//Console.WriteLine($"O número {numero} é " + (ehPar ? "par" : "impar"));



// //Desconstrutor
// Pessoa p1 = new Pessoa("Eduardo", "Souza");

// (string nome, string sobrenome) = p1;


// Console.WriteLine($"{nome} {sobrenome}");



// LeituraArquivo arquivo = new LeituraArquivo();

// var (sucesso, linhasArquivo, quantidadeLinhas) = arquivo.LerAquivo("Arquivos/arquivoLeitura.txt");

// if(sucesso)
// {
//     Console.WriteLine($"Quantidade linhas do arquivo: {quantidadeLinhas}");
//     foreach (string linha in linhasArquivo)
//     {
//         Console.WriteLine($"{linha}");
//     }
// }
// else
// {
//     Console.WriteLine($"Não foi possível ler o arquivo!");
// }






// //Tuplas

// (int Id, string Nome, string Sobrenome, decimal Altura) tupla = (1, "Eduardo", "Souza", 1.80M);

// Console.WriteLine($"id: {tupla.Id}");
// Console.WriteLine($"Nome: {tupla.Nome}");
// Console.WriteLine($"Sobrenome: {tupla.Sobrenome}");
// Console.WriteLine($"Altura: {tupla.Altura}");

// //Outra forma
// Console.WriteLine("****************************************************************");
// ValueTuple<int,string,string,decimal> outroExemploTupla = (1, "Eduardo", "Souza", 1.80M);

// Console.WriteLine($"id: {outroExemploTupla.Item1}");
// Console.WriteLine($"Nome: {outroExemploTupla.Item2}");
// Console.WriteLine($"Sobrenome: {outroExemploTupla.Item3}");
// Console.WriteLine($"Altura: {outroExemploTupla.Item4}");















// Dictionary<string, string> estados = new Dictionary<string, string>();

// estados.Add("SP", "São Paulo");
// estados.Add("RJ", "Rio de Janeiro");
// estados.Add("RS", "Rio Grande do Sul");

// foreach(KeyValuePair<string, string> item in estados)
// {
//     Console.WriteLine(item);
// }

// foreach(var item in estados)
// {
//     Console.WriteLine("_______________________________________");
//     Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
// }

// //remover
// estados.Remove("RJ");

// //Alterar
// estados["SP"] = "São Paulo - Valor Alterado";

// Console.WriteLine("*********************************");

// foreach(var item in estados)
// {
    
//     Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
// }

// Console.WriteLine("*********************************");
// estados.Add("MG", "Minas Gerais");

// foreach(var item in estados)
// {
    
//     Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
// }


// string chave = "BA";
// Console.WriteLine($"Verificando o elemento: {chave}");

// if(estados.ContainsKey(chave))

// {
    
//     Console.WriteLine($"Valor existente: {chave}");
// }
// else

// {
    
//     Console.WriteLine($"Valor não existe, É seguro adicionar a chave: {chave}");
// }

// Console.WriteLine($"Busca pelo Estado: {estados["MG"]}");







// Stack<int> pilha = new Stack<int>();

// pilha.Push(4);
// pilha.Push(6);
// pilha.Push(8);
// pilha.Push(10);

//  foreach(int item in pilha)
//  {
//     Console.WriteLine(item);
//  }

// Console.WriteLine($"Removendo o elemento do topo: {pilha.Pop()}");

// pilha.Push(20);

// foreach(int item in pilha)
//  {
//     Console.WriteLine(item);
//  }


// Queue<int> fila = new Queue<int>();

// fila.Enqueue(2);
// fila.Enqueue(4);
// fila.Enqueue(6);
// fila.Enqueue(8);

// foreach(int item in fila)
// {
//     Console.WriteLine(item);
// }

// Console.WriteLine($"Removendo o elemento: {fila.Dequeue()}");
// fila.Enqueue(10);

// foreach(int item in fila)
// {
//     Console.WriteLine(item);
// }




//new ExemploExcessao().Metodo1();










/* try
{
    string[] linhas = File.ReadAllLines("Arquivos/arquivo_leitura.txt");

        foreach (string linha in linhas)
        {
            Console.WriteLine(linha);
        }

}
catch(Exception ex)
{
    Console.WriteLine($"Ocorreu uma exceção Genérica: {ex.Message}");
}

finally
{
   Console.WriteLine ("Fim de processamento!"); 
}

 */























/* CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");


decimal valorMonetario = 1582.40M;

Console.WriteLine($"{valorMonetario:C}");

Console.WriteLine(valorMonetario.ToString("C4"));

Console.WriteLine(valorMonetario.ToString("N1"));


double porcentagem = .3421;

Console.WriteLine(porcentagem.ToString("P"));


int numero = 123456;

Console.WriteLine(numero.ToString("##-##-##"));


DateTime data = DateTime.Now;

Console.WriteLine($"{data}");

Console.WriteLine(data.ToString("dd/MM/yyyy HH:mm"));

Console.WriteLine(data.ToShortDateString());

Console.WriteLine(data.ToShortTimeString());


CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

DateTime data1 = DateTime.Parse("20/04/2024 18:00");

Console.WriteLine(data1);


string dataString = "2022-05-17 14:00";

bool sucesso = DateTime.TryParseExact(dataString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data2); 

if(sucesso)
{
    Console.WriteLine($"Conversão efetuada com sucesso! Data: {data2}");

}

else
{
    Console.WriteLine($"{dataString} Não é uma data válida!");

}
 */

//Pessoa p1 = new Pessoa(nome: "Carlos", sobrenome: "Rocha");
//Pessoa p2 = new Pessoa(nome: "Eduardo", sobrenome: "Dos Anjos Souza");

//Curso cursoDeIngles = new Curso();
//cursoDeIngles.Nome = "Inglês";
//cursoDeIngles.Alunos = new List<Pessoa>();

//cursoDeIngles.AdicionarAlunos(p1);
//cursoDeIngles.AdicionarAlunos(p2);
//cursoDeIngles.ListarAlunos();





