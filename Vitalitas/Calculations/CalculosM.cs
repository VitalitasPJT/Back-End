using System.ComponentModel.DataAnnotations;

namespace Vitalitas.Calculations
{
    public class CalculosMasculino
    {

        public float Imc;
        public float Soma_Das_Dobras;
        public float Densidade_Corporal;
        public float Percentual_De_Gordura;
        public float Massa_Gorda;
        public float Percentual_De_Massa_Magra;
        public float Massa_Magra;

        public CalculosMasculino(float altura, float peso, 
            
                        float tr, float cx, float si, float ab, float ax,
                        float pt, float se, 
                        
                        int idade) 
        {
            Imc = IMC(altura, peso);
            float sete = Somadobras(tr, se, si, ab, cx, pt, ax);
            Soma_Das_Dobras = sete;
            float densidade = DensidadeCorporal(sete, idade);
            Densidade_Corporal = densidade;
            float pgordura = PercentualGordura(densidade);
            Percentual_De_Gordura = pgordura;
            Massa_Gorda = MassaGorda(peso, pgordura);
            float pmagro = PercentualMaassaMagra(pgordura);
            Percentual_De_Massa_Magra = pmagro;
            Massa_Magra = MassaMagra(peso, pmagro);
        }

        public float IMC(float altura, float peso)
        {
            return (peso / (altura * altura));
        }

        public float Somadobras(float tr, float se, float si, float ab,
                                float cx, float pt, float ax)
        {
            return (tr + se + si + ab + cx + pt + ax);
        }

        public float DensidadeCorporal(float setedobras, float idade)
        {
            return (float)(1.112 - ((0.00043499 * setedobras) + (0.00000055 * (setedobras * setedobras)) - (0.00028826 * idade)));
        }

        public float PercentualGordura(float densidade)
        {
            return ((495 / densidade) - 450);
        }

        public float MassaGorda(float peso, float pgordo)
        {
            return (peso * (pgordo / 100));
        }

        public float PercentualMaassaMagra(float pgordo)
        {
            return (100 - pgordo);
        }

        public float MassaMagra(float peso, float pmagro)
        {
            return (peso * (pmagro / 100));
        }
    }
}
