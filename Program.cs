using System.Diagnostics.Contracts;
using System.Text;
using DesafioProjetoHospedagem.Models;
using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

// Pessoa p1 = new Pessoa(nome: "Hóspede 1");
// Pessoa p2 = new Pessoa(nome: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// // Cria a suíte
// Suite suite = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Console.WriteLine("\nBEM-VINDE AO SISTEMA DE RESERVAS\n");

string entrada = "";
int estadia = 0;
bool resultadoParse;

do
{
    Console.WriteLine("\nDigite por quantos dias ficará hospedado: ");
    entrada = Console.ReadLine();
    resultadoParse = int.TryParse(entrada, out estadia);
    if (!resultadoParse)
    {
        Console.WriteLine("Digite um número válido!");
    }
    else if (estadia <= 0)
    {
        Console.WriteLine("Digite um número maior que zero!");
    }
} while (!resultadoParse || estadia <= 0);


// Cria a nova reserva utilizando os dias dados em estadia
Reserva reserva = new Reserva(estadia);

Console.WriteLine("\nAS SUÍTES DISPONÍVEIS SÃO:\n");

Suite suite1 = new Suite("Single", 1, 50m);
Suite suite2 = new Suite("Double", 2, 100m);
Suite suite3 = new Suite("Triple", 3, 150m);
Suite suite4 = new Suite("Master", 5, 250m);
Suite suitePersonalizavel = new Suite("Personalizada", 10, 500m);

Console.WriteLine($"Opção A) Suíte {suite1.TipoSuite}, {suite1.Capacidade} pessoa, Preço: {suite1.ValorDiaria:C}");
Console.WriteLine($"Opção B) Suíte {suite2.TipoSuite}, {suite2.Capacidade} pessoas, Preço: {suite2.ValorDiaria:C}");
Console.WriteLine($"Opção C) Suíte {suite3.TipoSuite}, {suite3.Capacidade} pessoas, Preço: {suite3.ValorDiaria:C}");
Console.WriteLine($"Opção D) Suíte {suite4.TipoSuite}, {suite4.Capacidade} pessoas, Preço: {suite4.ValorDiaria:C}");
Console.WriteLine($"Opção E) Suíte {suitePersonalizavel.TipoSuite}, " +
                $"até {suitePersonalizavel.Capacidade} pessoas, Preço: {suitePersonalizavel.ValorDiaria:C}");

Console.WriteLine("\nESCOLHA SUA SUÍTE:\n");
string escolhaSuite = "";
escolhaSuite = Console.ReadLine().ToUpper();
int indice = 0;

switch (escolhaSuite)
{
    case "A":
        Console.Clear();
        Console.WriteLine($"Escolhida suíte {suite1.TipoSuite}");
        indice = suite1.Capacidade;
        reserva.CadastrarSuite(suite1);
        break;
    case "B":
        Console.Clear();
        Console.WriteLine($"Escolhida suíte {suite2.TipoSuite}");
        indice = suite2.Capacidade;
        reserva.CadastrarSuite(suite2);
        break;
    case "C":
        Console.Clear();
        Console.WriteLine($"Escolhida suíte {suite3.TipoSuite}");
        indice = suite3.Capacidade;
        reserva.CadastrarSuite(suite3);
        break;
    case "D":
        Console.Clear();
        Console.WriteLine($"Escolhida suíte {suite4.TipoSuite}");
        indice = suite4.Capacidade;
        reserva.CadastrarSuite(suite4);
        break;
    case "E":
        Console.Clear();
        Console.WriteLine($"Escolhida suíte {suitePersonalizavel.TipoSuite}");
        do
        {
            Console.WriteLine("Digite quantas pessoas ficarão hospedadas: ");
            indice = Convert.ToInt32(Console.ReadLine());
            if (indice <= 0 || indice > suitePersonalizavel.Capacidade)
            {
                Console.WriteLine("A capacidade máxima da suíte é 10 pessoas!");
            }
        } while (indice <= 0 || indice > suitePersonalizavel.Capacidade);
        reserva.CadastrarSuite(suitePersonalizavel);
        break;
    default:
        Console.Clear();
        Console.WriteLine("Digite uma opção válida!");
        break;
}

for (int contador = 0; contador < indice; contador++)
{
    Pessoa pessoa = new Pessoa();

    Console.WriteLine($"\nDados do hóspede {contador + 1}");

    Console.WriteLine("Nome: ");
    pessoa.Nome = Console.ReadLine();

    Console.WriteLine("Sobrenome: ");
    pessoa.Sobrenome = Console.ReadLine();

    hospedes.Add(pessoa);
}

// cadastra os hóspedes dados no laço for
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes, seus nomes e o valor da estadia
Console.Clear();
Console.WriteLine("\nReserva confirmada para:");
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()} \n");

foreach (Pessoa gente in hospedes)
{
    Console.WriteLine(gente);
}

Console.WriteLine($"\nValor total da estadia: {reserva.CalcularValorDiaria():C}");