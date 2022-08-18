namespace prj_Contas
{
    public abstract class Conta {
        public string? agencia{get; private set;}
        public string? numero{get; private set;}
        public double saldo{get; private set;}


        public Conta(string argAgencia, string argNumero) {
            setAgencia(argAgencia);
            setNumero(argNumero);
            setSaldo(0);
        }

        
        public void setAgencia(string argAgencia){
            if (argAgencia.Length >2 ){
                this.agencia = argAgencia;
            }
        }

        public void setNumero (string argNumero){
            if (argNumero.Length > 4){
                this.numero = argNumero;
            }
        }

        public void setSaldo (double argSaldo){
            this.saldo = argSaldo;
        }

        public abstract bool Sacar(double argValor);

        public bool Depositar(double argValor){
            if(argValor > 0){
                this.saldo = this.saldo + argValor;
                return true;
            }
            else {
                return false;
            }
        }
        public virtual string Imprimir(){

            string texto =  "Agencia: " + this.agencia +
                            "\nNúmero: " + this.numero +
                            "\nSaldo: " + this.saldo;
           
            return texto;
        }

        // public void Imprimir(string agencia, string numero, double saldo){
        //     Console.WriteLine("Agência: " + agencia + "\nConta: " + numero + "\nSaldo: " + saldo);
            

        // }
    
    }
}