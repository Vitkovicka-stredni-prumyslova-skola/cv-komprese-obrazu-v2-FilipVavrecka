namespace Komprese{
    public class KompreseObrazu{

        public static void Main (String [] args){
        
        String testFilePath = @"C:\Users\FilipVavrečka\github-classroom\Vitkovicka-stredni-prumyslova-skola\cv-komprese-obrazu-v2-FilipVavrecka\KompreseObrazu\CSV\obr1-10.csv";
        
        Obrazek inputCSV = new Obrazek(testFilePath);

        Console.WriteLine("Počet vertikálních řádků: {0}",inputCSV.CountLines(testFilePath));

        Console.WriteLine("Počet horizontální řádků: {0}",inputCSV.CountSymbolInLine(testFilePath));
        
        Console.WriteLine("----------------------------------------------");

        inputCSV.vypisImg();
        
        List<int> unikatniBarvy = inputCSV.PaletaBarevObrazku();

        Console.WriteLine("----------------------------------------------");

        Console.Write("Unikátní barvy v obrázku: ");
        foreach (int element in unikatniBarvy){
            Console.Write($"{element}, ");
            }
        
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine("Počet výskytů jednotlivých barev:");
        Dictionary<int, int> colorCounts = inputCSV.CountColors();
        foreach (var colorCount in colorCounts)
        {
            Console.WriteLine($"Barva {colorCount.Key}: {colorCount.Value}x");
            }
        }
    }
}