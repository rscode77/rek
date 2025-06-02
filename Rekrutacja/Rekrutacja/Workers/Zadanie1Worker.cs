using Rekrutacja.Classes;
using Rekrutacja.Helpers;
using Rekrutacja.Workers;
using Soneta.Business;
using Soneta.Kadry;
using Soneta.Tools;
using Soneta.Types;
using System;

[assembly: Worker(typeof(Zadanie1Worker), typeof(Pracownicy))]

namespace Rekrutacja.Workers
{
    public class Zadanie1Worker
    {
        public class Zadanie1WorkerParams : ContextBase
        {
            public Zadanie1WorkerParams(Context context) : base(context)
            {
                Session.Verifiers.Add(new OperationVerifier(this));
            }

            [Caption("A:"), Required, DefaultWidth(20), Priority(10)]
            public double ParamA { get; set; }

            [Caption("B:"), Required, DefaultWidth(20), Priority(20)]
            public double ParamB { get; set; }

            [Caption("Data obliczeń:"), Required, DefaultWidth(20) , Priority(30)]
            public Date Date { get; set; }

            [Caption("Operacja:"), Required, DefaultWidth(20) , Priority(40)]
            public string Operation { get; set; }
        }

        public Zadanie1Worker()
        {
        }

        [Context]
        public Zadanie1WorkerParams Params { get; set; }

        public Pracownik[] Pracownicy
        {
            get
            {
                if (Params.Context.Get<Pracownik[]>(out var pracownicy))
                    return pracownicy;

                return Array.Empty<Pracownik>();
            }
        }

        [Action("Zadanie 1", Target = ActionTarget.Menu | ActionTarget.LocalMenu | ActionTarget.ToolbarWithText, Mode = ActionMode.SingleSession, Icon = ActionIcon.Coffee, Priority = 1)]
        public void Action()
        {
            var calculation = OperationHelper.CalculateAB(Params.ParamA, Params.ParamB, Params.Operation);
            using (var tr = Params.Session.Logout(true))
            {
                foreach (Pracownik p in Pracownicy)
                {
                    var pracownik = tr.Session.Get(p);
                    pracownik.Features["DataObliczen"] = Params.Date;
                    pracownik.Features["Wynik"] = calculation;
                }
                tr.CommitUI();
            }
        }
    }
}