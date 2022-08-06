using uc9_prj.classes;


Console.WriteLine(@$"
=============================================================
|           Bem vindo ao Sistema de Cadastro de             |       
|              Pessoas Físicas e Jurídicas                  |
=============================================================
");


BarraCarregamento("Carregando", 200);
string? opcao;

do{
    Console.Clear();
    Console.WriteLine(@$"
=============================================================
|              Escolha uma das opções a seguir:             |
|___________________________________________________________|  
|                                                           |    
|                   1- Pessoa Física                        |
|                   2- Pessoa Jurídica                      |
|                   0- Sair                                 |
=============================================================
");

    opcao = Console.ReadLine();

    switch (opcao){
        case "1":
            Console.Clear();
            PessoaFisica novaPf = new PessoaFisica();
            Endereco novoEnd = new Endereco();
            PessoaFisica metodoPf = new PessoaFisica();

            novaPf.nome = "Carla";
            novaPf.dataNascimento = "15/10/1988";
            novaPf.cpf = "23212345674";
            novaPf.rendimento = 2000.5f;
            novoEnd.logradouro = "Avenida Capuava";
            novoEnd.numero = 565;
            novoEnd.complemento = "Casa";
            novoEnd.endComercial = false;
            novaPf.endereco = novoEnd;

            //o método .ToString sobrecarregado com a opção "C" retorna a moeda corrente baseado no sistema
            Console.WriteLine(@$"
            Nome: {novaPf.nome}
            Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
            Maior de Idade: {(metodoPf.ValidarDataNascimento(novaPf.dataNascimento) ? "Sim": "Não" )}
            Taxa de imposto a ser paga é: {metodoPf.PagarImposto(novaPf.rendimento).ToString("C")}
            ");
            Console.WriteLine($"Aperte 'Enter' para continuar");
            Console.ReadLine();
            break;
        case "2":
            Console.Clear();
            PessoaJuridica metodoPj = new PessoaJuridica();
            PessoaJuridica novaPj = new PessoaJuridica();
            Endereco novoEndPj = new Endereco();

            novaPj.nome = "NomePj";
            novaPj.cnpj = "00.000.000/0001-00";
            novaPj.razaoSocial = "Razao Social Pj";
            novaPj.rendimento = 8000.3f;
            novoEndPj.logradouro = "Avenida Capuava";
            novoEndPj.numero = 565;
            novoEndPj.complemento = "Comercial";
            novoEndPj.endComercial = true;
            novaPj.endereco = novoEndPj;

            Console.WriteLine(@$"
            Nome: {novaPj.nome}
            Razão Social: {novaPj.razaoSocial}
            CNPJ: {novaPj.cnpj}
            CNPJ é válido: {(metodoPj.ValidarCnpj(novaPj.cnpj) ? "Sim" : "Não")}
            Taxa de imposto a ser paga é: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C")}
            ");

            Console.WriteLine($"Aperte 'Enter' para continuar");
            Console.ReadLine();
            break;
        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema");
            BarraCarregamento("Finalizando", 100);
            break;
        default:
            Console.Clear();
            Console.WriteLine($"Opcção inválida, por favor digite outra opção ");
            Thread.Sleep(2000);
            break;
    }
} while (opcao != "0");


static void BarraCarregamento(string texto, int tempo){
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.ForegroundColor = ConsoleColor.DarkRed;

    Console.Write($"{texto} ");
    for (var contador = 0; contador < 25; contador++){
        Console.Write(". ");
        Thread.Sleep(tempo);
    }
    Console.ResetColor();
}



/*

novaPf.nome = "Carla";
Console.WriteLine("Nome: " + novaPf.nome);
Console.WriteLine($"Nome: {novaPf.nome}");

Console.WriteLine(novaPf.ValidarDataNascimento(new DateTime(2000,01,01)));

Console.WriteLine(novaPf.ValidarDataNascimento("15/10/2020"));

*/