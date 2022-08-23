using uc9_prj.interfaces;

namespace uc9_prj.classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica  {
        public string ?cpf { get; set; }
        public string ?dataNascimento { get; set; }
        public string caminho { get; private set; } = "Database/PessoaFisica.txt";
                       
        
        public override float PagarImposto(float rendimento){
            /*
            vamos utilizar a seguinte escala: 
            até 1500 - isento
            de 1500 a 3500 - 2% de impostos
            de 3500 a a 6000 - 3,5% de impostos
            acima de 6000 - 5% de impostos
            */
            
            if(rendimento <= 1500){
                return 0;
            }
            else if (rendimento >1500 && rendimento <=3500){
                 //a lib MathF.Round rece um float e o nº de casas decimais que vc quer arredondar
                return MathF.Round((rendimento * 0.02f), 2);
            }
            else if (rendimento >3500 && rendimento <=6000){
                return  MathF.Round((rendimento * 0.035f),2);
            }
             else {
                return  MathF.Round((rendimento * 0.05f),2);
            }
        }
        
        //validação básica - sem conversão        
         public bool ValidarDataNascimento(DateTime dataNasc){
             DateTime dataAtual = DateTime.Today;
             double anos = (dataAtual - dataNasc).TotalDays / 365;

            if(anos >= 18)
                 return true;
            
            return false;               
        } 
        //o atributo dataNascimento recebe uma string, então precisamos converter em DateTime
        public bool ValidarDataNascimento(string dataNasc){
            DateTime dataConvertida;

            //verificar se a string está em um formato válido
            //o TryParse tenta converter e coloca na saida out
            if(DateTime.TryParse(dataNasc, out dataConvertida)){
            
                // DateTime.Today pega a data atual do sistema
                 DateTime dataAtual = DateTime.Today;

                 //usa o TotalDays para tranformar em dias
                 double anos = (dataAtual - dataConvertida).TotalDays / 365;

                if(anos >= 18)
                    return true;

                return false;  
            }     
            return false;       
        }  

        //método para inserir os dados em um arquivo .txt usando o StreamWrite
        public  void Inserir(PessoaFisica pf){
            VerificarPastaArquivo(caminho);

            //cria o objeto que herda o StreamWrhite e passa como parâmetro o path do arquivo
            //o Using fecha o arquivo quando terminar a execução da implementação => using(resource){}
            using (StreamWriter sw = new StreamWriter(caminho)){
                //qual valor vai escrever dentro do arquivo. Whrite Line escreve quebrando linha
                sw.Write($"{pf.nome}, ");
                sw.Write($"{pf.dataNascimento}, ");
                sw.Write($"{pf.cpf}, "); 
                sw.Write($"{pf.rendimento} ");
                

                //fechar o arquivo após a inserção se não estivesse usando Using
                //sw.Close();
            }          
        }
         
        //método para imprimir na tela as informações a partir do arquivo .txt
        public List<PessoaFisica> Ler(){
            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            if (File.Exists(caminho)){
                string[] linhas = File.ReadAllLines(caminho);

                foreach (string cadaLinha in linhas){
                    string[] atributos = cadaLinha.Split(",");

                    PessoaFisica cadaPf = new PessoaFisica();

                    cadaPf.nome = atributos[0];
                    cadaPf.dataNascimento = atributos[1];
                    cadaPf.cpf = atributos[2];
                    cadaPf.rendimento = float.Parse(atributos[3]);
                    
                    listaPf.Add(cadaPf);
                }
            return listaPf;

            }else {
                Console.WriteLine("A Lista está vazia");                
                Thread.Sleep(3000);
                return listaPf;
            }

            
                 
                
           
                 
            
           
        }     
    }
}
                        //StreamReader para ler o que tem salvo no arquivo indicado
                        // using(StreamReader sr = new StreamReader($"Carla.txt")){
                        //     string linha;
                        //     while((linha = sr.ReadLine()) != null){
                        //         Console.WriteLine($"{linha}");                                
                        //     }
                        //     Console.WriteLine($"Aperte 'Enter' para continuar");
                        //     Console.ReadLine();                            
                        // }