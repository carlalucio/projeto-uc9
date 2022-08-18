// See https://aka.ms/new-console-template for more information

using prj_Contas;
Console.Clear();

Console.WriteLine(@$"
*************************************************************
*************************************************************
*                                                           *
*     Seja bem vindo ao Sistema de Controle Financeiro      *  
*                                                           *
*************************************************************
*************************************************************

");
List<Corrente> listaCC = new List<Corrente>();
List<Poupanca> listaCP = new List<Poupanca>();
BarraCarregamento("Carregando",200);


//Limpar o console
Console.Clear();

string? opcao;

do{
    Console.Clear();
    Console.WriteLine(@$"
*************************************************************
*************************************************************
*           Escolha uma das opções a seguir:                *
*                1- Conta Corrente                          *
*                2- Conta Poupança                          *
*                0- Sair                                    *
*************************************************************
*************************************************************
");

   opcao = Console.ReadLine();

    switch (opcao){

        //opção Conta Corrente
        case "1":
            string? opcaoCC;

            do{
                Console.Clear();
                Console.WriteLine(@$"
                *************************************************************
                *************************************************************
                *           Escolha uma das opções a seguir:                *
                *             1- Cadastrar Conta Corrente                   *
                *             2- Mostrar Conta Corrente                     *
                *             0- Voltar ao menu anterior                    *
                *************************************************************
                *************************************************************
                ");
                opcaoCC = Console.ReadLine();

                switch (opcaoCC){
                    case "1":
                    Console.Clear();
                        Console.WriteLine($"Digite o número da Agência: ");
                        string agencia = Console.ReadLine();

                        Console.WriteLine($"Digite o número da Conta Corrente: ");
                        string numero = Console.ReadLine();

                        Console.WriteLine($"Digite o Limite: ");
                        double limite = Double.Parse(Console.ReadLine());
                        
                        Corrente cc_obj = new Corrente (agencia, numero, limite);
                        
                        listaCC.Add(cc_obj);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso!!!");  
                        Console.ResetColor(); 

                        Console.WriteLine($"Aperte 'Enter' para continuar");                        
                        Console.ReadLine();                   
                        break;
                    case "2":
                        Console.Clear();
                        if(listaCC.Count > 0){
                            foreach(Corrente cadaCC in listaCC){
                                Console.Clear();
                                Console.WriteLine($"{cadaCC.Imprimir()}");
                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();                             
                            }
                        }
                        else {
                            Console.WriteLine($"A lista está vazia");
                            Thread.Sleep(3000);
                        }
                        break;
                    case "0":
                        break;    
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção.");
                        Thread.Sleep(3000);                        
                        break;
                }
                

            } while (opcaoCC != "0");  
            break;

        //opção Conta Poupança    
        case "2":

           string? opcaoCP;

            do{
                Console.Clear();
                Console.WriteLine(@$"
                *************************************************************
                *************************************************************
                *           Escolha uma das opções a seguir:                *
                *             1- Cadastrar Conta Poupança                   *
                *             2- Mostrar Conta Poupança                     *
                *             0- Voltar ao menu anterior                    *
                *************************************************************
                *************************************************************
                ");
                opcaoCP = Console.ReadLine();

                switch (opcaoCP){
                    case "1":
                    Console.Clear();
                        Console.WriteLine($"Digite o número da Agência: ");
                        string agencia = Console.ReadLine();

                        Console.WriteLine($"Digite o número da Conta Corrente: ");
                        string numero = Console.ReadLine();

                        Console.WriteLine($"Digite o Anivesário: ");
                        int aniversario = Int32.Parse(Console.ReadLine());
                        
                        Poupanca cp_obj = new Poupanca (agencia, numero, aniversario);
                        
                        listaCP.Add(cp_obj);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso!!!");  
                        Console.ResetColor();                      
                        Console.WriteLine($"Aperte 'Enter' para continuar");                        
                        Console.ReadLine();                   
                        break;
                    case "2":
                        Console.Clear();
                        if(listaCC.Count > 0){
                            foreach(Poupanca cadaCP in listaCP){
                                Console.Clear();
                                Console.WriteLine($"{cadaCP.Imprimir()}");
                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();                             
                            }
                        }
                        else { 
                            Console.WriteLine($"A lista está vazia");
                            Thread.Sleep(3000);
                        }
                        break;
                    case "0":                        
                        break;    
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção.");
                        Thread.Sleep(3000);  
                        Console.Clear();                      
                        break;
                }
                
            } while (opcaoCP != "0"); 
            break;

        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema!");
            BarraCarregamento("Finalizando",200);
            break;
        default:
            Console.WriteLine($"Opção inválida, por favor digite outra opção");
            Thread.Sleep(2000);
            Console.Clear();
            break;
    }

} while (opcao != "0");

static void BarraCarregamento(string texto, int tempo){
    //alterar a cor de fundo do terminal
    Console.BackgroundColor = ConsoleColor.DarkCyan;

    //alterar a cor da fonte
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"{texto}");


    for (var contador = 0; contador < 10; contador++){
         //o console.Write não quebra linha. Imprime lado a lado
        Console.Write(". ");

        //método para retardar ação em x segundos 
        Thread.Sleep(tempo);
    }

    //resetar as cores do terminal
    Console.ResetColor();
}