namespace Microondas.Models
{
    public class EntredaVW
    {
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string TempoDefinido { get; set; }
        public bool Status { get; set; }
        public string MensagemTempo { get; set; }
        public string MensagemPotencia { get; set; }
    }
}
