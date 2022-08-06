// See https://aka.ms/new-console-template for more information

using prj_Contas;
/*
Corrente obj_cc = new Corrente();
obj_cc.Agencia = "700";
obj_cc.Numero = "9995";
obj_cc.Saldo = 0;
obj_cc.Limite = 1000;


Poupanca obj_cpp = new Poupanca();

obj_cpp.Agencia = "200";
obj_cpp.Numero = "2356";
obj_cpp.Saldo = 0;
obj_cpp.Aniversario = 1000;


Console.WriteLine(obj_cc.Imprimir());
*/

Console.WriteLine(@$"
*************************************************************
*************************************************************
*                                                           *
*     Seja bem vindo ao Sistema de Controle Financeiro      *  
*                                                           *
*************************************************************
*************************************************************

");

//alterar a cor de fundo do terminal
Console.BackgroundColor = ConsoleColor.DarkCyan;

//alterar a cor da fonte
Console.ForegroundColor = ConsoleColor.Red;

Console.Write("Carregando ");

for (var contador = 0; contador < 10; contador++)
{
    //o console.Write não quebra linha. Imprime lado a lado
    Console.Write(". ");

    //método para retardar ação e 
    Thread.Sleep(500);
}

//resetar as cores do terminal
Console.ResetColor();

//Limpar o console
Console.Clear();

string? opcao;
do{
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
        case "1":
            Corrente cc_obj = new Corrente ("3303-0", "19880",101);
            Console.WriteLine($"{cc_obj.Imprimir()}");
            Console.WriteLine($"Aperte 'Enter' para continuar");
            Console.ReadLine();
            Console.Clear();       
            break;
        case "2":
            Poupanca cp_obj = new Poupanca ("3303-0", "19780",3);
            Console.WriteLine($"{cp_obj.Imprimir()}");
            Console.WriteLine($"Aperte 'Enter' para continuar");
            Console.ReadLine();
            Console.Clear(); 
            break;
        case "0":
            Console.WriteLine($"Você entrou na opção 0");
            break;
        default:
            Console.WriteLine($"Opção inválida, por favor digite outra opção");
            Thread.Sleep(2000);
            Console.Clear();
            break;
    }

} while (opcao != "0");

