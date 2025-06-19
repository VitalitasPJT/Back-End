namespace Vitalitas.Calculations
{
    public class CalculosFeminino
    {
        public string Id_Avaliacao;
        public float Imc;
        public float Soma_Das_Dobras;
        public float Densidade_Corporal;
        public float Percentual_De_Gordura;
        public float Massa_Gorda;
        public float Percentual_De_Massa_Magra;
        public float Massa_Magra;

        public CalculosFeminino(string id_avaliacao, float imc, float soma_das_dobras, float densidade_corporal,
                                float percentual_de_gordura, float massa_gorda, float percentual_de_massa_magra, float massa_magra)
        {
            Id_Avaliacao = id_avaliacao;
            Imc = imc;
            Soma_Das_Dobras = soma_das_dobras;
            Densidade_Corporal = densidade_corporal;
            Percentual_De_Gordura = percentual_de_gordura;
            Massa_Gorda = massa_gorda;
            Percentual_De_Massa_Magra = percentual_de_massa_magra;
            Massa_Magra = massa_magra;
        }
        public double IMC(float altura, float peso)
        {
            return (peso / (altura * altura));
        }

        public double Somadobras(float triceps, float subescapular, float suprailíaca, float abdominal,
                                float coxa, float peitoral, float axilar, float media)
        {
            return (triceps + subescapular + suprailíaca + abdominal + coxa + peitoral + axilar + media);
        }

        public double DensidadeCorporal(float setedobras, int idade)
        {
            return (1.097 - ((0.00046971 * setedobras) + (0.00000056 * (setedobras * setedobras)) - (0.00012828 * idade)));
        }

        public double PercentualGordura(double densidade)
        {
            return ((495 / densidade) - 450);
        }

        public double MassaGorda(float peso, double pgordo)
        {
            return (peso * (pgordo / 100));
        }

        public double PercentualMaassaMagra(double pgordo)
        {
            return (100 - pgordo);
        }

        public double MassaMagra(float peso, double pmagro)
        {
            return (peso * (pmagro / 100));
        }
    }
}
