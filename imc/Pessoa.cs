namespace imc
{
    public class Pessoa {
        public double peso { get; set; }
        public double altura { get; set; }

        public double imc { get; set; }

        public Pessoa(double argPeso, double argAltura ){
            this.peso = argPeso;
            this.altura = argAltura;
            this.imc = calcularIMC(argPeso, argAltura);

        }

        public double calcularIMC(double argPeso, double argAltura){
            //biblioteca Math.Pow calcula exponenciação e recebe 2 doubles, 1º o numero, 2º a potência
            double resultado = argPeso / (Math.Pow(argAltura, 2));
            return resultado;
        }

        public string classificarIMC(double argIMC){
            string classificacao;

            if (argIMC < 18.5){ 
                classificacao = "abaixo do peso";
            } 
            else if (argIMC >=18.5 && argIMC < 25){
                 classificacao = "peso ideal";
            }
            else if (argIMC >=25 && argIMC < 30){
                 classificacao = "sobrepeso";
            }
            else if (argIMC >=30 && argIMC < 35){
                 classificacao = "obesidade I";
            }
            else if (argIMC >=35 && argIMC < 40){
                classificacao = "obesidade II";
            }
            else {
                classificacao = "obesidade III";
            }
            return classificacao;
        }
    }
}