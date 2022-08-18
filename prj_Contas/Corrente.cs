namespace prj_Contas
{
    public class Corrente : Conta
    {
        public double limite{get; private set;}

       public Corrente (string argAgencia, string argNumero, double argLimite): base (argAgencia, argNumero) {

        }

        public void setLimite (double argLimite){
            if(argLimite >100) {
                this.limite = argLimite;
            } else 
                this.limite = 0;
        }

         public override string Imprimir(){
            string texto = base.Imprimir();
            texto += "\nLimite: " + this.limite;
            return texto;
        }

        public override bool Sacar(double argValor) {
           if(argValor <= (base.saldo + this.limite)){
            base.setSaldo (base.saldo - argValor);
            return true;
           } else{
                return false;
            }
        }
         
    }
}