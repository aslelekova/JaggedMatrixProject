using System.Text;
using MatrixLibrary;

class Program
{
    public static void Main()
    {
        // Set the console encoding to UTF-8 for correct character display.
        Console.OutputEncoding = Encoding.UTF8;
        
        // For Windows you should use a different code.
        // Console.OutputEncoding = Encoding.Unicode;
        
        do
        {
            try
            {
                Console.Clear();

                // Read data from a file and initialize necessary variables.
                FileManager.ReadDataFromFile(out int n, out double min, out double max);

                // Create a JaggedMatrix instance with specified parameters.
                JaggedMatrix jaggedMatrix = new JaggedMatrix(n, min, max);

                // Convert the JaggedMatrix to an array of strings.
                string[] outputLines = jaggedMatrix.AsStrings();

                // Save the data to a file.
                FileManager.SaveDataToFile(outputLines);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nПрограмма успешно выполнена!");
                Console.ResetColor();
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }

            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }

            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            catch (Exception)
            {
                Console.WriteLine("Неизвестная ошибка.");
            }
            
            Console.WriteLine("\nДля продолжения нажмите любую клавишу, для выхода из программы - Escape...");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
      
    }
}

