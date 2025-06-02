using Rekrutacja.Extensions;
using Rekrutacja.Interfaces;
using Rekrutacja.Shapes;
using Rekrutacja.Verifiers;
using Rekrutacja.Workers;
using Soneta.Business;
using Soneta.Kadry;
using Soneta.Tools;
using Soneta.Types;
using System;
using System.Collections.Generic;
using static Rekrutacja.Enums.Enums;

[assembly: Worker(typeof(Zadanie3Worker), typeof(Pracownicy))]

namespace Rekrutacja.Workers
{
    public class Zadanie3Worker
    {
        public class Zadanie3WorkerParams : ContextBase
        {
            public Zadanie3WorkerParams(Context context) : base(context)
            {
                Shape = ShapeEnum.Rectangle;
                Session.Verifiers.Add(new ValueVerifier(this));
            }

            [DefaultWidth(20)]
            public string ParamA { get; set; }
            public string ParamACaption { get; set; }
            public bool ParamAVisible { get; set; }

            [DefaultWidth(20)]
            public string ParamB { get; set; }
            public string ParamBCaption { get; set; }
            public bool ParamBVisible { get; set; }

            [DefaultWidth(20), Required]
            public Date Date { get; set; }

            private ShapeEnum _shape { get; set; }

            [DefaultWidth(20)]
            public ShapeEnum Shape
            {
                get
                {
                    return _shape;
                }
                set
                {
                    _shape = value;
                    SetFieldVisibility(value);
                    Session.InvokeChanged();
                }
            }

            private void SetFieldVisibility(ShapeEnum shape)
            {
                ParamACaption = "A:";
                ParamBCaption = "B:";
                ParamAVisible = true;
                ParamBVisible = true;

                switch (shape)
                {
                    case ShapeEnum.Square:
                        ParamACaption = "A:";
                        ParamBVisible = false;
                        break;
                    case ShapeEnum.Circle:
                        ParamACaption = "r:";
                        ParamBVisible = false;
                        break;
                    case ShapeEnum.Triangle:
                        ParamACaption = "A:";
                        ParamBCaption = "H:";
                        ParamAVisible = true;
                        ParamBVisible = true;
                        break;
                }
            }
        }

        public object GetListShape() => new List<ShapeEnum>
        {
            ShapeEnum.Square,
            ShapeEnum.Rectangle,
            ShapeEnum.Triangle,
            ShapeEnum.Circle
        };


        public Zadanie3Worker()
        {
        }

        [Context]
        public Zadanie3WorkerParams Params { get; set; }

        public Pracownik[] Pracownicy
        {
            get
            {
                if (Params.Context.Get<Pracownik[]>(out var pracownicy))
                    return pracownicy;

                return Array.Empty<Pracownik>();
            }
        }

        [Action("Zadanie 3", Target = ActionTarget.Menu | ActionTarget.LocalMenu | ActionTarget.ToolbarWithText, Mode = ActionMode.SingleSession, Icon = ActionIcon.Coffee, Priority = 2)]
        public void Action()
        {
            using (var tr = Params.Session.Logout(true))
            {
                foreach (Pracownik p in Pracownicy)
                {
                    var pracownik = tr.Session.Get(p);
                    pracownik.Features["DataObliczen"] = Params.Date;

                    var paramA = Params.ParamA.IsNullOrEmpty() ? 0 : Params.ParamA.ToDouble();
                    var paramB = Params.ParamB.IsNullOrEmpty() ? 0 : Params.ParamB.ToDouble();

                    IShape shape = Params.Shape switch
                    {
                        ShapeEnum.Square => new Square(paramA),
                        ShapeEnum.Rectangle => new Rectangle(paramA, paramB),
                        ShapeEnum.Triangle => new Triangle(paramA, paramB),
                        ShapeEnum.Circle => new Circle(paramA),
                        _ => throw new Exception("Nieznana figura"),
                    };

                    pracownik.Features["DataObliczen"] = Params.Date;
                    pracownik.Features["Wynik"] = System.Math.Round(shape.Area());
                }
                tr.CommitUI();
            }
        }
    }
}