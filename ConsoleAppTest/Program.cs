

using ConsoleAppTest;

/*

List<Status> list = new List<Status>();

int index = 1;

for (int i = 1; i <= 10000; i++)
{
    list.Add(new Status { Id = i });
    index++;
}

DateTime dtstart = DateTime.Now;
HttpClient client = new HttpClient();

Parallel.ForEach(list, @group =>
{
    DateTime dtstart = DateTime.Now;

    try
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:49153/WeatherForecast");
        var response = client.SendAsync(request).Result;

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            @group.IsSuccess = true;
        }
        else
        {
            @group.IsError = true;
            var content = response.Content.ReadAsStringAsync().Result;
            @group.Error = content;

        }
    }
    catch (Exception ex)
    {
        @group.IsError = true;
        @group.Error = ex.Message;
    }

    DateTime dtend = DateTime.Now;
    @group.TotalSeg = Math.Round((dtend - dtstart).TotalSeconds, 1);


    if (group.IsError)
    {
        Console.WriteLine("Time Request: " + @group.TotalSeg + "| Id: " + @group.Id + " Error: " + @group.Error);
    }

    Console.WriteLine(@group.Id);

});

*/

/*
foreach (var item in list)
{
    //DateTime dtstartI = DateTime.Now;

    try
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:49153/WeatherForecast");
        var response = client.SendAsync(request).Result;

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            item.IsSuccess = true;
        }
        else
        {
            item.IsError = true;
            var content = response.Content.ReadAsStringAsync().Result;
            item.Error = content;

        }
    }
    catch (Exception ex)
    {
        item.IsError = true;
        item.Error = ex.Message;
    }

    //DateTime dtend = DateTime.Now;
    //item.TotalSeg = Math.Round((dtend - dtstart).TotalSeconds, 1);


    if (item.IsError)
    {
        Console.WriteLine("Time Request: " + item.TotalSeg + "| Id: " + item.Id + " Error: " + item.Error);
    }

     Console.WriteLine(item.Id);
}
*/
//DateTime dtend = DateTime.Now;
//var totalSeg = Math.Round((dtend - dtstart).TotalSeconds, 1);

//Console.WriteLine(value: $"totalSeg: {totalSeg}");
//Console.WriteLine(value: $"Total sussces: {list.Where(x => x.IsSuccess).Count()}");
//Console.WriteLine(value: $"Total Error: {list.Where(x => x.IsError).Count()}");
//Console.ReadLine();

Console.WriteLine("Matriz de:");
int a = int.Parse(Console.ReadLine());

Console.WriteLine("Matriz por:");
int b = int.Parse(Console.ReadLine());


int[,] bidimencion;
bidimencion = new int[a, b];


Random numero = new Random();

//llenando la matriz con numero aleatorios entre  y 100 pueden ser numeros repetidos
for (int i = 0; i < a; i++)
{
    for (int j = 0; j < b; j++)
    {

        bidimencion[i, j] = numero.Next(10, 100);
    }
}

//imprimiendo diagonal de matriz 
Console.WriteLine("Diagonal de la matriz la componen");
for (int i = 0; i < a; i++)
{
    for (int j = 0; j < b; j++)
    {

        if (i == j) { Console.Write(bidimencion[i, j]); }
        else { Console.Write("  "); }

    }
    Console.WriteLine();
}
Console.WriteLine();




//imprimiendo inversa de matriz 
Console.WriteLine("Inversa de la matriz la compone:");
for (int i = 0; i < a; i++)
{
    for (int j = 0; j < b; j++)
    {

        if (j + i == b - 1) { Console.Write(bidimencion[i, j]); }//b-1 por la posicion 0 que exite en este caso
        else { Console.Write("  "); }
    }
    Console.WriteLine();
}
Console.WriteLine();



//imprimiendo tridiagonal de matriz 
Console.WriteLine("Tridiagonal de la matriz la compone:");
for (int i = 0; i < a; i++)
{
    for (int j = 0; j < b; j++)
    {

        if ((Math.Abs(i - j)) <= 1) { Console.Write(bidimencion[i, j]); }//b-1 por la posicion 0 que exite en este caso
        else { Console.Write("--"); }//coloco -- por cuestion de estetica para que se ve donde termina la matriz
        if (j + 1 == b) { Console.WriteLine(); } else { Console.Write(","); }
    }
    Console.WriteLine();
}
Console.WriteLine();



Console.WriteLine("Impresion de la matriz");
//impresion de la matriz
for (int i = 0; i < a; i++)
{
    for (int j = 0; j < b; j++)
    {

        Console.Write(bidimencion[i, j]);

        if (j + 1 == b) { Console.WriteLine(); } else { Console.Write(","); }

    }

}


Console.ReadKey(true);