using uc9_prj.interfaces;

namespace uc9_prj.classes{
    public abstract class Pessoa : IPessoa {
        public string ?nome { get; set; }
        public Endereco ?endereco { get; set; }
        public float rendimento { get; set; }    
                        
        public abstract float PagarImposto(float rendimento);      
        
    }
}