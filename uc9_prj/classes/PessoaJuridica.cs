using uc9_prj.interfaces;
using System.Text.RegularExpressions;

namespace uc9_prj.classes{
    public class PessoaJuridica : Pessoa, IPessoaJuridica {
        public string ?cnpj { get;  set; }
        public string ?razaoSocial { get;  set; } 

        public override float PagarImposto(float rendimento){
           /*
            vamos utilizar a seguinte escala: 
            até 1500 - 3%
            de 1500 a 3500 - 5% de impostos
            de 3500 a a 6000 - 7% de impostos
            acima de 6000 - 9% de impostos
            */
            
            if(rendimento <= 1500){
                return rendimento * 0.03f;;
            }
            else if (rendimento >1500 && rendimento <=3500){
                return rendimento * 0.05f;
            }
            else if (rendimento >3500 && rendimento <=6000){
                return rendimento * 0.07f;
            }
             else {
                return rendimento * 0.09f;
            }
        }
        
        // modelo de CNPJ: XX.XXX.XXX/0001-XX ou XXXXXXXXXXXXXX
        // posição do caracter em decimais dentro da string = \d{} "
        // Início da cadeia de caracteres = ^
        // Final da cadeia de caracteres = $
        public bool ValidarCnpj(string cnpj){
            if((cnpj.Length ==18) || (cnpj.Length == 14)) {

                if(Regex.IsMatch(cnpj,@"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)")){

                    if(cnpj.Length == 18){
                        //o Substring vai iniciar no caracter 11 caracteres e pegar os próximos 4
                        if(cnpj.Substring(11,4) == "0001")
                        return true;
                    
                    } else if (cnpj.Length == 14){
                        if(cnpj.Substring(8,4)=="0001")
                        return true;
                    }
                }                
                return false;                 
            }                         
            
            return false;
        }

    }           
           
}
