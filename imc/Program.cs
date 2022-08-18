// See https://aka.ms/new-console-template for more information
using imc;
double peso;
double altura;
Console.Clear();
Console.WriteLine($"Digite o Peso:");
peso = Double.Parse(Console.ReadLine());

Console.Clear();
Console.WriteLine($"Digite a Altura em Metros:");
altura = Double.Parse(Console.ReadLine());

Pessoa obj_pessoa = new Pessoa(peso, altura);
Console.Clear();
Console.WriteLine($"IMC: {obj_pessoa.imc}");
Console.WriteLine($"Classificação: {obj_pessoa.classificarIMC(obj_pessoa.imc)}");

