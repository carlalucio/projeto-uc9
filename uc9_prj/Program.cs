using uc9_prj.classes;
Console.Clear();

Console.WriteLine(@$"
=============================================================
|           Bem vindo ao Sistema de Cadastro de             |       
|              Pessoas Físicas e Jurídicas                  |
=============================================================
");


BarraCarregamento("Carregando", 150);

//List<PessoaFisica> listaPF = new List<PessoaFisica>();
//List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

string? opcao;

do
{
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

    switch (opcao)
    {
        //Opção cadastrar Pessoa física
        case "1":
            PessoaFisica metodoPf = new PessoaFisica();
            string? opcaoPF;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
    =============================================================
    |              Escolha uma das opções a seguir:             |
    |___________________________________________________________|  
    |                                                           |    
    |               1- Cadastar Pessoa Física                   |
    |               2- Mostrar Pessoa Física                    |
    |               0- Sair                                     |
    =============================================================
    ");
                opcaoPF = Console.ReadLine();

                switch (opcaoPF)
                {
                    case "1":
                        Console.Clear();
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.WriteLine($"Digite o Nome da Pessoa Física que deseja Cadastrar: ");
                        novaPf.nome = Console.ReadLine();

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a Data de Nascimento (Ex: DD/MM/AAA:) ");
                            string dataNasc = Console.ReadLine();
                            dataValida = metodoPf.ValidarDataNascimento(dataNasc);

                            if (dataValida)
                            {
                                novaPf.dataNascimento = dataNasc;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada é inválida. Não é possível cadastrar Menores de 18 anos. Por favor, digite uma data válida");
                                Console.ResetColor();
                            }
                        } while (dataValida == false);

                        Console.WriteLine($"Digite o número CPF: ");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o Rendimento Mensal:  (Digite apenas números)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o Logradouro: ");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número: ");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o Complemento: (aperte ENTER para vazio)");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é Comercial? S ou N ");
                        //ToUpper converte as letras em maiúsculas
                        string endCom = Console.ReadLine().ToUpper();
                        //pega a variavel endCom e transforma em um array de string com o método ToString, para pegar a posição 0 para atribuir a variável resposta
                        string resposta = endCom[0].ToString();
                        if (resposta == "S")
                            novoEnd.endComercial = true;
                        else
                            novoEnd.endComercial = false;

                        novaPf.endereco = novoEnd;
                        metodoPf.Inserir(novaPf);
                        
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro Realizado com Sucesso");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        break;

                    //opção de imiprimir Pessoa Física Cadastrada
                    case "2":
                        Console.Clear();
                        List<PessoaFisica> listaPf = metodoPf.Ler();
                        
                            foreach (PessoaFisica cadaItem in listaPf){
                            Console.Clear();

                             //o método .ToString sobrecarregado com a opção "C" retorna a moeda corrente, baseado no sistema
                            Console.WriteLine(@$"
                            Nome: {cadaItem.nome}
                            Data de Nascimento: {cadaItem.dataNascimento}
                            CPF: {cadaItem.cpf}
                            Taxa de imposto a ser paga é: {metodoPf.PagarImposto(cadaItem.rendimento).ToString("C")}
                            ");
                                                          
                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                        }                      
                        break;

                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção");
                        Thread.Sleep(1500);
                        break;
                }
            } while (opcaoPF != "0");
            break;


        case "2":

            PessoaJuridica metodoPj = new PessoaJuridica();
            string opcaoPJ;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"
    =============================================================
    |              Escolha uma das opções a seguir:             |
    |___________________________________________________________|  
    |                                                           |    
    |               1- Cadastar Pessoa Jurídica                 |
    |               2- Mostrar Pessoa Jurídica                  |
    |               0- Sair                                     |
    =============================================================
    ");

                opcaoPJ = Console.ReadLine();

                switch (opcaoPJ)
                {
                    case "1":
                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco novoEndPj = new Endereco();

                        Console.Clear();
                        Console.WriteLine($"Digite o Nome da Pessoa Jurídica que deseja Cadastrar: ");
                        novaPj.nome = Console.ReadLine();

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o número do CNPJ");
                            string cnpj = Console.ReadLine();

                            cnpjValido = metodoPj.ValidarCnpj(cnpj);

                            if (cnpjValido)
                                novaPj.cnpj = cnpj;
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"CNPJ inválido, por favor digite um CNPJ válido");
                                Console.ResetColor();
                            }
                        } while (cnpjValido == false);

                        Console.WriteLine($"Digite a Razão Social: ");
                        novaPj.razaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (digite apenas números)");
                        novaPj.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEndPj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEndPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte ENTER para vazio)");
                        novoEndPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S ou N");
                        //ToUpper converte as letras em maiúsculas
                        string endCom = Console.ReadLine().ToUpper();
                        //pega a variavel endCom e transforma em um array de string com o método ToString, para pegar a posição 0 para atribuir a variável resposta
                        string resposta = endCom[0].ToString();

                        if (resposta == "S")
                            novoEndPj.endComercial = true;
                        else
                            novoEndPj.endComercial = false;

                        novaPj.endereco = novoEndPj;

                        //metodo da classe PessoaJurídica que insere a pj cadastrada no arquivo .csv
                        metodoPj.Inserir(novaPj);


                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro Realizado com Sucesso!!!");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        break;

                    case "2":
                        Console.Clear();
                        List<PessoaJuridica> listaPj = metodoPj.Ler();

                        foreach (PessoaJuridica cadaItem in listaPj)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
                            Nome: {cadaItem.nome}
                            Razão Social: {cadaItem.razaoSocial}
                            CNPJ: {cadaItem.cnpj} 
                            Taxa de imposto a ser paga é: {metodoPj.PagarImposto(cadaItem.rendimento).ToString("C")}                           
                            ");
                                                        
                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                        }
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção");
                        Thread.Sleep(1500);
                        break;
                }
            } while (opcaoPJ != "0");
            break;
        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema");
            BarraCarregamento("Finalizando", 100);
            break;
        default:
            Console.Clear();
            Console.WriteLine($"Opcção inválida, por favor digite outra opção ");
            Thread.Sleep(1500);
            break;
    }
} while (opcao != "0");


static void BarraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.DarkGray;
    //Console.ForegroundColor = ConsoleColor.DarkRed;

    Console.Write($"{texto} ");
    for (var contador = 0; contador < 25; contador++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }
    Console.ResetColor();
}



/*

novaPf.nome = "Carla";
Formas de impressão:
Concateçao:  Console.WriteLine("Nome: " + novaPf.nome);
Interpolação: Console.WriteLine($"Nome: {novaPf.nome}");
Passando atributo DN com formato Date: Console.WriteLine(novaPf.ValidarDataNascimento(new DateTime(2000,01,01)));
Passando atributo DN com formato String: Console.WriteLine(novaPf.ValidarDataNascimento("15/10/2020"));
*/