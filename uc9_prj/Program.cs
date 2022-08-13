using uc9_prj.classes;
Console.Clear();

Console.WriteLine(@$"
=============================================================
|           Bem vindo ao Sistema de Cadastro de             |       
|              Pessoas Físicas e Jurídicas                  |
=============================================================
");


BarraCarregamento("Carregando", 200);

List<PessoaFisica> listaPF= new List<PessoaFisica>();

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

        //Opção cadastrar Pessoa física
        case "1":
            PessoaFisica metodoPf = new PessoaFisica();

            string? opcaoPF;

            do{
                Console.Clear();
                Console.WriteLine(@$"
                    =============================================================
                    |              Escolha uma das opções a seguir:             |
                    |___________________________________________________________|  
                    |                                                           |    
                    |               1- Cadrastar Pessoa Física                  |
                    |               2- Mostrar Pessoa Física                    |
                    |               0- Sair                                     |
                    =============================================================
                    ");
                    opcaoPF = Console.ReadLine();

                    switch (opcaoPF){
                        case "1":
                            Console.Clear();

                            PessoaFisica novaPf = new PessoaFisica();
                            Endereco novoEnd = new Endereco();

                            Console.WriteLine($"Digite o Nome da Pessoa Física que deseja Cadastrar: ");                    
                            novaPf.nome = Console.ReadLine();

                            bool dataValida;
                                do{
                                    Console.WriteLine($"Digite a Data de Nascimento (Ex: DD/MM/AAA:) ");  
                                    string dataNasc = Console.ReadLine();
                                    dataValida = metodoPf.ValidarDataNascimento(dataNasc);

                            
                                if(dataValida){
                                    novaPf.dataNascimento = dataNasc;
                                }
                                else{
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
                            string endCom = Console.ReadLine().ToUpper();
                            if(endCom == "S"){
                                    novoEnd.endComercial = true;
                            }
                            else{
                                    novoEnd.endComercial = false;
                            }
                            novaPf.endereco = novoEnd;
                            listaPF.Add(novaPf);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"Cadastro Realizado com Sucesso");
                            Thread.Sleep(3000);
                            Console.ResetColor();                            
                        break;

                        //opção de imiprimir Pessoa Física Cadastrada
                        case "2":
                            Console.Clear();

                            if(listaPF.Count > 0){
                                foreach(PessoaFisica cadaPessoa in listaPF){
                                    Console.Clear();
                                    //o método .ToString sobrecarregado com a opção "C" retorna a moeda corrente baseado no sistema
                                    Console.WriteLine(@$"
                                    Nome: {cadaPessoa.nome}
                                    Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
                                    Data de Nascimento: {cadaPessoa.dataNascimento}
                                    Taxa de imposto a ser paga é: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                    ");
                                    Console.WriteLine($"Aperte 'Enter' para continuar");
                                    Console.ReadLine();
                                }

                            } else {
                                Console.WriteLine($"A Lista está vazia!!!");
                                Thread.Sleep(3000);
                            }
                        break;

                        case "0":
                        break;

                        default:
                            Console.Clear();
                            Console.WriteLine($"Opção inválida, por favor digite outra opção");
                            Thread.Sleep(2000);
                            
                        break;
                    }                  
                
            } while (opcaoPF != "0");
            Console.Clear();    
        break;

        //opções Pessoa Juridica
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
    Console.BackgroundColor = ConsoleColor.DarkGray;
    //Console.ForegroundColor = ConsoleColor.DarkRed;

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