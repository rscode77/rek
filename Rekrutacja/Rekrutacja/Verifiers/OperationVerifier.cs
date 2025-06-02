using Rekrutacja.Workers;
using Soneta.Business;
using Soneta.Types;
using System.Linq;

namespace Rekrutacja.Classes
{
    internal class OperationVerifier : Verifier
    {
        private Zadanie1Worker.Zadanie1WorkerParams _params;

        public OperationVerifier(Zadanie1Worker.Zadanie1WorkerParams @params)
        {
            _params = @params;
        }

        protected override bool IsValid() => _validCharacters.Contains(_params.Operation);
        private string[] _validCharacters => new[] { "+", "-", "*", "/" };
        public override string Description => "Operacja musi być jednym z symboli: +, -, *, /";
        public override object Source => _params;
        public override VerifierType Type => VerifierType.Error;
    }
}