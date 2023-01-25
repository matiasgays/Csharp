using aLaCarta;
using Utilities;

var t = new TablePrinter("Seccion", "Producto", "Precio");

var carta = new Dictionary<string, Dictionary<string, double>>();

carta.Add("Bebidas Sin Alcohol", new Dictionary<string, double>(){
    { "JUGOS", 90 },
    { "GASEOSAS", 85 },
    { "AGUA", 95 }
});
carta.Add("Bebidas Alcoholicas", new Dictionary<string, double>(){
    { "DAIKIRIS", 91 },
    { "VINOS", 86 },
    { "CERVEZA", 96 }
});
carta.Add("Entrada", new Dictionary<string, double>(){
    { "PICADA PARA 2", 88 },
    { "SANDWICHES DE MIGA", 83 },
    { "EMPANADAS DE CARNE", 93 }
});
carta.Add("Platos", new Dictionary<string, double>(){
    { "PAELLA", 85 },
    { "LOMO A LA PIMIENTA", 83 },
    { "MERLUZA CON PURE", 93 }
});
carta.Add("Postres", new Dictionary<string, double>(){
    { "BUDIN DE PAN", 85 },
    { "FLAN CON CREMA", 83 },
    { "DURAZNOS EN ALMIBAR", 93 }
});

foreach (var kvp in carta)
{
    t.AddRow(kvp.Key,"","");
    foreach (var key in kvp.Value)
    {
        t.AddRow("",key.Key,key.Value);
    }
}

t.Print();

