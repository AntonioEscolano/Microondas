using Microondas.Models;

namespace Microondas.Manager
{
    public class Acao
    {
        public EntredaViewModel VerificaDados(EntredaViewModel _dados)
        {
            // Verifica o Tempo            
            if (_dados.Tempo >= 0 && _dados.Tempo <= 120)
            {
                if ( (_dados.Tempo == 0 && _dados.Status == false) || (_dados.Tempo + 30) <= 120 && _dados.Status == true)
                {
                    _dados.Tempo += 30;
                }

                _dados.TempoDefinido = TrataTempo(_dados.Tempo);
                _dados.Status = (_dados.Status == true) ? true : false;
            }
            else
            {
                _dados.Status = false;
                _dados.TempoDefinido = "00:00";
                _dados.MensagemTempo = "O \"Tempo\" deve estar entre 1 e 120 segundos.";
                //throw new ArgumentOutOfRangeException(nameof(_dados.Tempo), "O tempo deve estar entre 0 e 120 segundos.");
            }

            // Verifica a Potência
            if (_dados.Potencia == 0)
            {
                _dados.Potencia = 10;
                _dados.Status = true;
            }
            else if (_dados.Potencia < 0 || _dados.Potencia > 10)
            {
                _dados.MensagemPotencia = "A \"Potência\" deve estar entre 1 e 10.";
                //throw new ArgumentOutOfRangeException(nameof(_dados.Potencia), "A potência deve estar entre 0 e 10.");
            }

            _dados.Status = (_dados.Status != false) ? true : false;

            return _dados;
        }

        public string TrataTempo(int _tempo)
        {
            int _minutos = _tempo / 60;
            int _segundos = _tempo % 60;
            string _tempoDefinido = $"{_minutos.ToString().PadLeft(2, '0')}:{_segundos.ToString().PadLeft(2, '0')}";

            return _tempoDefinido;
        }
    }
}
