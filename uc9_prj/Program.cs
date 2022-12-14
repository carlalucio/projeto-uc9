
using uc9_prj.classes;

Console.Clear();

Console.WriteLine(@$"
=============================================================
|           Bem vindo ao Sistema de Cadastro de             |       
|              Pessoas Físicas e Jurídicas                  |
=============================================================
");

BarraCarregamento("Carregando", 100);

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
        //submenu pessoa física  
        string? opcaoPF;
            do{
                PessoaFisica metodoPf = new PessoaFisica();  
                PessoaFisica novaPf = new PessoaFisica();
                Endereco novoEnd = new Endereco();              
                Console.Clear();
                Console.WriteLine(@$"
    =============================================================
    |              Escolha uma das opções a seguir:             |
    |___________________________________________________________|  
    |                                                           |    
    |               1- Cadastar Pessoa Física                   |
    |               2- Mostrar Pessoa Física                    |
    |               0- Retornar ao menu anterior                |
    =============================================================
    ");
                opcaoPF = Console.ReadLine();


                switch (opcaoPF) {
                    case "1":
                    //case cadastrar pessoa física
                        Console.Clear();                       

                        Console.WriteLine($"Digite o Nome da Pessoa Física que deseja Cadastrar: ");
                        novaPf.nome = Console.ReadLine();
                        
                        Console.WriteLine($"Digite o número CPF: ");
                        novaPf.cpf = Console.ReadLine();

                        bool dataValida;
                        do{
                            Console.WriteLine($"Digite a Data de Nascimento (Ex: DD/MM/AAA:) ");
                            string dataNasc = Console.ReadLine();
                            dataValida = metodoPf.ValidarDataNascimento(dataNasc);

                            if (dataValida) 
                                novaPf.dataNascimento = dataNasc;                           
                            else{
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada é inválida. Não é possível cadastrar Menores de 18 anos. Por favor, digite uma data válida");
                                Console.ResetColor();
                            }

                        } while (dataValida == false);
                       

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
                    case "2":
                    //mostrar pessoa física
                        Console.Clear();
                        List<PessoaFisica> listaPf = metodoPf.Ler();
                        
                        foreach (PessoaFisica cadaItem in listaPf){
                            Console.Clear();

                                //o método .ToString sobrecarregado com a opção "C" retorna a moeda corrente, baseado no sistema
                            Console.WriteLine(@$"
                            Nome: {cadaItem.nome}
                            Data de Nascimento: {cadaItem.dataNascimento}
                            CPF: {cadaItem.cpf}
                            Rendimento:{cadaItem.rendimento}                            
                            Logradouro: {cadaItem.endereco.logradouro}, {cadaItem.endereco.numero}
                            Complemento: {cadaItem.endereco.complemento}                          
                            Endereço Comercial? {((cadaItem.endereco.endComercial)? "Sim" : "Não")}
                            Taxa de imposto a ser paga é: {metodoPf.PagarImposto(cadaItem.rendimento).ToString("C")}
                            ");
                                                            
                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                        } 
                        break;

                    case "0":
                    //essa opção retorna para o menu anterior

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
        //submenu pessoa jurídica
            PessoaJuridica metodoPj = new PessoaJuridica();
            PessoaJuridica novaPj = new PessoaJuridica();
            Endereco novoEndPj = new Endereco();
            string opcaoPJ;

            do {
                Console.Clear();
                Console.WriteLine(@$"
    =============================================================
    |              Escolha uma das opções a seguir:             |
    |___________________________________________________________|  
    |                                                           |    
    |               1- Cadastar Pessoa Jurídica                 |
    |               2- Mostrar Pessoa Jurídica                  |
    |               0- Retornar ao menu anterior                |
    =============================================================
    ");

                opcaoPJ = Console.ReadLine();

                switch (opcaoPJ) {
                    case "1":
                     //case cadastrar pessoa jurídica
                        Console.Clear();                 
                        Console.WriteLine($"Digite o Nome da Pessoa Jurídica que deseja Cadastrar: ");
                        novaPj.nome = Console.ReadLine();

                        bool cnpjValido;
                        do{
                            Console.WriteLine($"Digite o número do CNPJ Ex: xx.xxx.xxx/0001-xx ou xxxxxxxx0001xx");
                            string cnpj = Console.ReadLine();

                            cnpjValido = metodoPj.ValidarCnpj(cnpj);

                            if (cnpjValido){
                                novaPj.cnpj = cnpj;
                            }
                            else{
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
                        break;
                    case "2":
                        //mostrar pessoa jurídica
                        Console.Clear();
                        List<PessoaJuridica> listaPj = metodoPj.Ler();

                        foreach (PessoaJuridica cadaItem in listaPj) {
                                Console.Clear();
                                Console.WriteLine(@$"
                                Nome: {cadaItem.nome}
                                CNPJ: {cadaItem.cnpj} 
                                Razão Social: {cadaItem.razaoSocial}
                                Rendimento:{cadaItem.rendimento}                            
                                Logradouro: {cadaItem.endereco.logradouro}, {cadaItem.endereco.numero}
                                Complemento: {cadaItem.endereco.complemento}                          
                                Endereço Comercial? {((cadaItem.endereco.endComercial)? "Sim" : "Não")}
                                Taxa de imposto a ser paga é: {metodoPj.PagarImposto(cadaItem.rendimento).ToString("C")} 
                                ");
                                                            
                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();
                            }

                        break;
                    case "0":
                    //essa opção retorna para o menu anterior
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opcção inválida, por favor digite outra opção ");
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
            Console.WriteLine($"Opção inválida, por favor digite outra opção ");
            Thread.Sleep(1500);
            break;
    } 

} while (opcao != "0");






















static void BarraCarregamento(string texto, int tempo){
    Console.BackgroundColor = ConsoleColor.DarkGray;
    //Console.ForegroundColor = ConsoleColor.DarkRed;

    Console.Write($"{texto} ");
    for (var contador = 0; contador < 25; contador++) {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }
    Console.ResetColor();
}