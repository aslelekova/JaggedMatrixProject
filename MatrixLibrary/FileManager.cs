using System.Globalization;

namespace MatrixLibrary;

/// <summary>
/// Handles reading data from and saving data to a file.
/// </summary>
public class FileManager
{
    /// <summary>
    /// Reads data from a file, parsing an integer and two doubles.
    /// </summary>
    /// <param name="n">Output parameter for the integer value.</param>
    /// <param name="min">Output parameter for the minimum double value.</param>
    /// <param name="max">Output parameter for the maximum double value.</param>
    /// <exception cref="FormatException">Thrown when the file data is incorrectly formatted.</exception>
    public static void ReadDataFromFile(out int n, out double min, out double max)
    {
        string filePath = ConsoleManager.ReadFilePath();
    
        string data = File.ReadAllText(filePath);

        // Replace '.' with ',' and filter out non-digit characters.
        char[] charArr = data.ToCharArray();
        for (int i = 0; i < charArr.Length; i++)
        {
            if (charArr[i] == '.')
            {
                charArr[i] = ',';
            }
            charArr[i] = (char.IsDigit(charArr[i]) || charArr[i] == ',' || charArr[i] == '-') ? charArr[i] : ' '; 
        }
        
        // Split the cleaned string into an array of numbers.
        string[] sepNumbers = new string(charArr).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        if (sepNumbers.Length != 3)
        {
            throw new FormatException("Ошибка. Некорректное количество данных в файле."); // обосновать ошибку
        }

        if (!(int.TryParse(sepNumbers[0], out n) && n > 0))
        {
            throw new FormatException("Ошибка. Некорректные числа в файле1.");
        }
        
        if (!(double.TryParse(sepNumbers[1], NumberStyles.Any, CultureInfo.CurrentCulture, out min) && double.TryParse(sepNumbers[2], NumberStyles.Any, CultureInfo.CurrentCulture, out max)))
        {
            throw new FormatException("Ошибка. Некорректные числа в файле.");
        }
    }
    
    /// <summary>
    /// Saves an array of strings to a file.
    /// </summary>
    /// <param name="outputLines">The array of strings to be saved to the file.</param>
    /// <exception cref="ArgumentNullException">Thrown when an error occurs during the file-writing process.</exception>
    public static void SaveDataToFile(string[] outputLines)
    {
        try
        {
            string outputFileName = ConsoleManager.ReadFileName();
            
            File.WriteAllLines(outputFileName, outputLines);
            
            Console.WriteLine($"\nДанные сохранены в файл {outputFileName}.txt");
        }
        catch (IOException exception)
        {
            // Catching a more specific exception and rethrowing with a generic error message.
            throw new IOException("Ошибка при записи данных в файл."); 
        }
    }
}