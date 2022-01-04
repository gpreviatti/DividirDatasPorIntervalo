using System.Diagnostics;

IEnumerable<(DateTime dataInicio, DateTime dataFim)> DividirDatasPorIntervaloDias(DateTime dataInicio, DateTime dataFim, int intervalo)
{
    DateTime dataFimCortada;
    while ((dataFimCortada = dataInicio.AddDays(intervalo)) < dataFim)
    {
        yield return (dataInicio, dataFimCortada);
        dataInicio = dataFimCortada;
    }
    yield return (dataInicio, dataFim);
}

var dataInicio = DateTime.Now.AddDays(-90);
var dataFim = DateTime.Now;
var intervalo = 15;

var dates = DividirDatasPorIntervaloDias(dataInicio, dataFim, intervalo).ToList();

dates.ForEach(
    date => Console.WriteLine($"Data Inicio: {date.dataInicio:dd/MM/yy} e Data Fim {date.dataFim:dd/MM/yy}")
);

// Teste: Testando se as datas quebradas tem a diferença de dias informado
Debug.Assert(dates[0].dataInicio.AddDays(intervalo).Equals(dates[0].dataFim));
Debug.Assert(dates[0].dataFim.Equals(dates[1].dataInicio));
Debug.Assert(dates[1].dataInicio.AddDays(intervalo).Equals(dates[1].dataFim));

// Teste: Testando se Data inicial e final são iguais aos parametros
Debug.Assert(dates[0].dataInicio.Equals(dataInicio));
Debug.Assert(dates[^1].dataFim.Equals(dataFim));
