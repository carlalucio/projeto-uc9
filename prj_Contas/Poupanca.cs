namespace prj_Contas
{
    public class Poupanca: Conta {
        
        public int aniversario {get; private set;}

        public Poupanca(string argAgencia, string argNumero, int argAniversario):base(argAgencia, argNumero) {
             setAniversario(argAniversario);
        }


        public void setAniversario (int argAniversario){

        this.aniversario = argAniversario;
        }

        public override bool Sacar(double argValor) {
             if(argValor <= base.saldo)
            {
                base.setSaldo(base.saldo - argValor);
                return true;
            }
            else{
                return false;
            }
        }
        public override string Imprimir(){
            string texto;
            texto = base.Imprimir();
            texto += "\nAniversário: " + this.aniversario;
            return texto;
        }

        
    }
}