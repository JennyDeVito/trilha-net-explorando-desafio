namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; } 
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a a suíte acomoda os hóspedes
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Retorna uma exception caso contrário
                throw new Exception("A suíte não acomoda mais hóspedes do que sua capacidade");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            decimal valor = 0;

            // Regra: Caso a reserva seja >= 10 dias, conceda desconto de 10%
            if (DiasReservados >= 10)
            {
                valor = DiasReservados * Suite.ValorDiaria * 0.90m;
                return valor;
            }
            else
            {
                valor = DiasReservados * Suite.ValorDiaria;
                return valor;
            }
        }
    }
}