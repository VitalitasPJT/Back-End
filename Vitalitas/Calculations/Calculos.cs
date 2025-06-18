namespace Vitalitas.Calculations
{
    public class Calculos
    {
        public float IMC(float altura, float peso)
        {
            return (peso / (altura * altura));
        }

        public float Somadobras(float triceps, float subescapular, float suprailíaca, float abdominal,
                                float coxa, float peitoral, float axilar, float media)
        {
            return (triceps + subescapular + suprailíaca + abdominal + coxa + peitoral + axilar + media);
        }
    }
}
