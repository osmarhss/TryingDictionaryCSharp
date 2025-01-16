using DictionaryCSharp;

// Testando a classe Dictionary, ainda há melhorias a serem feitas

Dictionary<int, Aluno> alunos = new Dictionary<int, Aluno>();

bool adicionar = true;

Console.WriteLine("Bem vindo! Iremos usar a classe Dictionary, as chaves servirão com identificador, e os valores serão objetos da classe Aluno");

for (int i = 1; adicionar; i++)
{
    Console.WriteLine("Insira um nome:");
    string? nome = Console.ReadLine();
    Console.WriteLine($"Agora insira a nota para o aluno {nome}");
    double nota = Convert.ToDouble(Console.ReadLine());

    try
    {
        alunos.Add(i, new Aluno(nome, nota));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    if (alunos.TryGetValue(i, out Aluno? aluno))
    {
        Console.WriteLine($"O aluno inserido possui nome: {aluno.Nome} e nota: {aluno.Nota}");
    }
    else
    {
        Console.WriteLine("O aluno não foi adicionado à coleção!");
    }

    Console.WriteLine("Deseja adicionar mais alunos? Digite 0 se sim, senão digite 1");
    int continuar = Convert.ToInt32(Console.ReadLine());

    if (continuar == 1)
    {
        adicionar = false;
    }
}

Console.WriteLine("Agora vamos exibir a coleção alunos<int, Aluno>");

foreach (var item in alunos)
{
    Console.WriteLine($"{item.Key} - {item.Value.Nome}, {item.Value.Nota}");
}

AlterarNota();
ExibirColecao(alunos);
RemoverAluno();
ExibirColecao(alunos);
AdicionarNovoAluno();
ExibirColecao(alunos);
OrdenarColecaoPelaChave(alunos);

void AlterarNota()
{
    Console.WriteLine("Vamos alterar uma nota de um aluno agora");
    Console.WriteLine("Digite o id(chave) do aluno");

    int chaveDigitada = Convert.ToInt32(Console.ReadLine());

    if (alunos.ContainsKey(chaveDigitada))
    {
        if (alunos.TryGetValue(chaveDigitada, out Aluno? value))
        {
            Console.WriteLine($"A nota corresponde ao aluno: {value.Nome} é: {value.Nota}");
            Console.WriteLine("Digite a nova nota do aluno:");

            double novaNota = Convert.ToDouble(Console.ReadLine());
            value.Nota = novaNota;
            var aluno = alunos.First(x => x.Key == chaveDigitada);

            Console.WriteLine($"Novo registro: {aluno.Key} - {aluno.Value.Nome}, {aluno.Value.Nota}");
        }
    }
    else
    { Console.WriteLine("Aluno não encontrado"); }
}

void RemoverAluno()
{
    Console.WriteLine("Vamos remover um aluno da coleção");
    Console.WriteLine("Digite o id(chave) do aluno");

    int chaveDigitada = Convert.ToInt32(Console.ReadLine());

    if (alunos.ContainsKey(chaveDigitada))
    {
        alunos.Remove(chaveDigitada);
    }
    else
    {
        Console.WriteLine("Aluno não encontrado a partir da chave digitada!");
    }
}

void AdicionarNovoAluno()
{
    var ultimoAluno = alunos.Last();

    Console.WriteLine("Digite o nome do aluno a ser adicionado");
    string? nome = Console.ReadLine();
    Console.WriteLine($"Digite a nota de {nome}");
    double nota = Convert.ToDouble(Console.ReadLine());

    int novaChave = ultimoAluno.Key + 1;
    if (alunos.TryAdd(novaChave, new Aluno(nome, nota)))
    {
        Console.WriteLine("Aluno inserido com sucesso!");
    }
    else
    {
        Console.WriteLine("Falha ao inserir o aluno!");
    }
}

void ExibirColecao(Dictionary<int, Aluno> alunos)
{
    Console.WriteLine("Agora vamos exibir a coleção alunos<int, Aluno>");

    foreach (var item in alunos)
    {
        Console.WriteLine($"{item.Key} - {item.Value.Nome}, {item.Value.Nota}");
    }
}

void OrdenarColecaoPelaChave(Dictionary<int, Aluno> alunos)
{
    Console.WriteLine("Ordenando a lista");
    var alunosOrdenados = alunos.OrderBy(x => x.Key).ToList();
    foreach (var item in alunosOrdenados)
    {
        Console.WriteLine($"{item.Key} - {item.Value.Nome}, {item.Value.Nota}");
    }
}