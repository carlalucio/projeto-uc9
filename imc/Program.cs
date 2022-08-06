// See https://aka.ms/new-console-template for more information
using imc;

Pessoa obj_pessoa = new Pessoa(80, 1.75);


Console.WriteLine(obj_pessoa.imc);
Console.WriteLine(obj_pessoa.classificarIMC(obj_pessoa.imc));

