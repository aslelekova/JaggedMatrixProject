namespace MatrixLibrary;

/// <summary>
/// Utility class for managing console input related to file names and paths.
/// </summary>
public class ConsoleManager
{
    /// <summary>
    /// Reads a file name from the console input and ensures its validity.
    /// </summary>
    /// <returns>A string with the valid file name.</returns>
    public static string ReadFileName()
    {
        Console.Write("\nВведите имя файла: ");
        string? fileName = Console.ReadLine();

        // Check that the entered file name is not empty and meets the criteria for a correct name.
        while (string.IsNullOrEmpty(fileName) || !IsFileNameCorrect(fileName))
        {
            Console.Write(
                "\nНекорректное имя файла. Имя файла содержит запрещенные символы.\nПопробуйте еще раз: ");
            fileName = Console.ReadLine();
        }

        return fileName;
    }
    
    /// <summary>
    /// Checks if the provided file name is correct and does not contain invalid symbols.
    /// </summary>
    /// <param name="fileName">The file name to be checked.</param>
    /// <returns>Returns true if the file name is correct; otherwise, returns false.</returns>
    /// <exception cref="ArgumentException">Thrown when the provided file name is null or empty.</exception>
    private static bool IsFileNameCorrect(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            // Throw an ArgumentException with a specific error message.
            // Using ArgumentException to indicate that a required argument (filename) is missing or invalid.
            throw new ArgumentException(nameof(fileName), "Ошибка. Некорректное имя файла.");
        }
        
        // Check if the file name contains forbidden symbols.
        string invalidSymbols = new string(Path.GetInvalidFileNameChars());

        foreach (char invalidSymbol in invalidSymbols)
        {
            if (fileName.Contains(invalidSymbol))
            {
                return false;
            }
        }

        return true;
    }
    
    /// <summary>
    /// Reads a file path from the console input and ensures its validity.
    /// </summary>
    /// <returns>A string representing the valid path to an existing file.</returns>
    public static string ReadFilePath()
    {
        string filePath;

        Console.Write("Ожидаемый формат данных в файле:\n\tn\n\tmin max\n");
        do
        {
            Console.Write("Введите путь к файлу: ");
            filePath = Console.ReadLine();

            // Check if the entered file path is null or empty, or if the file does not exist.
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine("\nОшибка. Некорректное имя файла или файл не существует. Повторите попытку.\n");
            }

        } while (string.IsNullOrEmpty(filePath) || !File.Exists(filePath));

        return filePath;
    }
}