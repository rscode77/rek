using Rekrutacja.Workers;
using Soneta.Business;
using Soneta.Types;
using System;
using System.Linq;

namespace Rekrutacja.Verifiers
{
    internal class ValueVerifier : Verifier
    {
        private Zadanie3Worker.Zadanie3WorkerParams _params;

        public ValueVerifier(Zadanie3Worker.Zadanie3WorkerParams @params)
        {
            _params = @params;
        }

        private bool InvalidCharacter(string value) => !string.IsNullOrEmpty(value) && value.Any(ch => !_validCharacters.Contains(ch.ToString()));
        private bool InValidCommas(string value) => !string.IsNullOrEmpty(value) && value.Count(c => c == ',' || c == '.') > 1;
        protected override bool IsValid() =>
            !InValidCommas(_params.ParamA) && !InValidCommas(_params.ParamB)
            && !InvalidCharacter(_params.ParamA) && !InvalidCharacter(_params.ParamB);
        private string[] _validCharacters => new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ",", "." };
        public override string Description => "Wprowadzono niewłaściwą wartość";
        public override object Source => _params;
        public override VerifierType Type => VerifierType.Error;
    }
}