using uc9_prj.interfaces;

namespace uc9_prj.classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica  {
        public string ?cpf { get; set; }
        public string ?dataNascimento { get; set; }
                       
        
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
                return rendimento * 0.02f;
            }
            else if (rendimento >3500 && rendimento <=6000){
                return rendimento * 0.035f;
            }
             else {
                return rendimento * 0.05f;
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
    }
}