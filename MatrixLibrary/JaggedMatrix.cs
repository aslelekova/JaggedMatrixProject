


namespace MatrixLibrary;

/// <summary>
/// Represents a class for handling jagged matrices and Maclaurin series computations.
/// </summary>
public class JaggedMatrix
{
    /// <summary>
    /// Represents an array of double values.
    /// </summary>
    private double[] x;

    /// <summary>
    /// Represents a jagged array of double values.
    /// </summary>
    private double[][] arr;

    /// <summary>
    /// Gets or sets an array of double values.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when attempting to set a null value to the 'X' property.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the provided array is null or has an invalid length.</exception>
    public double[] X
    {
        get => x;
        set
        {
            if (value == null)
            {
                // ArgumentNullException is used because allowing a null value for the array (value) is considered an error,
                // and this exception specifically indicates that a null argument is not allowed.
                throw new ArgumentNullException(nameof(value), "Ошибка. Данные некорректны, " +
                                                               "не может быть передано значение null.");

            }
            if (value.Length == 0)
            {
                // ArgumentOutOfRangeException is used to indicate that the length of the array should be within a valid range. 
                throw new ArgumentOutOfRangeException(nameof(value), "Ошибка. Данные некорректны.");
            }

            x = value;
        }
    }

   /// <summary>
   /// Gets or sets a jagged array of double values.
   /// </summary>
   /// <exception cref="ArgumentNullException">Thrown when attempting to set a null value to the 'Arr' property.</exception>
   /// <exception cref="ArgumentOutOfRangeException">Thrown when the provided array is null or has an invalid length.</exception>
    public double[][] Arr
    {
        get => arr;
        set
        {
            if (value == null)
            {
                // ArgumentNullException is used because allowing a null value for the array (value) is considered an error,
                // and this exception specifically indicates that a null argument is not allowed.
                throw new ArgumentNullException(nameof(value), "Ошибка. Данные некорректны, " +
                                                               "не может быть передано значение null.");
            }
            
            if (value.Length == 0)
            {
                // ArgumentOutOfRangeException is used to indicate that the length of the array should be within a valid range. 
                throw new ArgumentOutOfRangeException("", "Ошибка. Данные некорректны, массив пуст.");
            }

            arr = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the JaggedMatrix class with empty arrays.
    /// </summary>
    public JaggedMatrix()
    {
        X = Array.Empty<double>();
        Arr = Array.Empty<double[]>();
    }

    /// <summary>
    /// Initializes a new instance of the JaggedMatrix class with specified parameters.
    /// </summary>
    /// <param name="n">The number of elements in the array.</param>
    /// <param name="min">The minimum value for random initialization.</param>
    /// <param name="max">The maximum value for random initialization.</param>
    /// <exception cref="ArgumentException">Thrown when the number of elements is not greater than 0 or when min is greater
    /// than or equal to max.</exception>
    /// <exception cref="ArgumentNullException">Thrown when min or max is null.</exception>
    public JaggedMatrix(int n, double min, double max)
    {
        if (n <= 0)
        {
            // ArgumentException is used because a non-positive number of elements is considered invalid,
            // and this exception specifically indicates that an argument is outside the acceptable range.
            throw new ArgumentException("Ошибка. Количество элементов массива должно быть больше 0.", nameof(n));
        }

        if (min >= max)
        {
            // ArgumentException is used because min being greater than or equal to max is considered invalid,
            // and this exception specifically indicates that an argument is outside the acceptable range.
            throw new ArgumentException("Ошибка. Значение min должно быть меньше значения max.",
                nameof(min) + ' ' + nameof(max));
        }

        if (double.IsNaN(min) || double.IsNaN(max))
        {
            // ArgumentNullException is used because null values for min or max are considered invalid,
            // and this exception specifically indicates that a null argument is not allowed.
            throw new ArgumentNullException("Ошибка. Значения не могут равняться null.");
        }

        Console.WriteLine($"Создание объекта JaggedMatrix с n = {n}, min = {min}, max = {max}");
        
        // Initialize the 'X' array with random values.
        Random rnd = new Random();
        X = new double[n];

        for (int i = 0; i < n; i++)
        {
            X[i] = rnd.NextDouble() * (max - min) + min;
        }

        // Initialize the 'arr' jagged array with Maclaurin series values for each 'x' element.
        Arr = new double[n][];
        for (int i = 0; i < n; i++)
        {
            Arr[i] = CosArray(X[i]);
        }
    }

    /// <summary>
    /// Computes the Maclaurin series for the cosine function with the specified argument.
    /// </summary>
    /// <param name="x0">The argument for which to compute the Maclaurin series.</param>
    /// <returns>An array of values representing the Maclaurin series for the cosine function.</returns>
    /// <exception cref="ArgumentException">Thrown when the argument x0 is NaN or Infinity.</exception>
    private double[] CosArray(double x0)
    {
        if (double.IsNaN(x0) || double.IsInfinity(x0))
        {
            // ArgumentException is used because NaN or Infinity values for x0 are considered invalid,
            // and this exception specifically indicates that an argument is outside the acceptable range.
            throw new ArgumentException("Недопустимое значение аргумента x0.", nameof(x0));
        }

        double sum = 1.0;
        double term;
        int n = 0;

        // Maclaurin series computation.
        while (true)
        {
            term = Math.Pow(-1, n) / Factorial(2 * n) * Math.Pow(x0, 2 * n);
            double prevSum = sum; 
            sum += term;

            // Check if the current sum and the sum at the previous step are equal.
            if (sum == prevSum)
            {
                break;
            }

            n++;
        }

        // Form an array of values for the Maclaurin series.
        double[] result = new double[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = Math.Pow(-1, i) / Factorial(2 * i) * Math.Pow(x0, 2 * i);
        }

        return result;
    }

    /// <summary>
    /// Calculates the factorial of a non-negative integer.
    /// </summary>
    /// <param name="n">The non-negative integer for which to calculate the factorial.</param>
    /// <returns>The factorial of the specified non-negative integer.</returns>
    /// <exception cref="ArgumentException">Thrown when the argument n is negative.</exception>
    private double Factorial(int n)
    {
        if (n < 0)
        {
            // ArgumentException is used because a negative value for n is considered invalid,
            // and this exception specifically indicates that an argument is outside the acceptable range.
            throw new ArgumentException(nameof(n), "Ошибка. Факториала отрицательного числа не существует.");
        }
        
        double result = 1;
        
        // Calculate factorial using a loop.
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
    // Альтернативная запись: private int Factorial(int n) => n == 0 ? 1 : n * Factorial(n - 1);

    /// <summary>
    /// Converts the JaggedMatrix data to an array of formatted strings.
    /// </summary>
    /// <returns>An array of strings representing the Maclaurin series values and cosine results for each element of the 'X' array.</returns>
    public string[] AsStrings()
    {
        // Initialize an array to store the formatted result strings.
        string[] result = new string[X.Length];

        for (int i = 0; i < X.Length; i++)
        {
            // Calculate the sum of the Maclaurin series values for the current 'X' element.
            double cosX = CosArray(x[i]).Sum();
            
            // Format the result string with Maclaurin series values, 'X' element, and cosine result.
            result[i] =
                $"Значения членов ряда Маклорена для {X[i]:E3}:\n" +
                $"{string.Join("; ", arr[i].Select(val => val.ToString("E3")))}\nЗначение cos(x) = {cosX:E3}\n";
        }
        
        return result;
    }
    /*
     В качестве альтернативного решения можно использовать StringBuilder.
     StringBuilder stringBuilder = new StringBuilder();

       for (int i = 0; i < X.Length; i++)
       {
       stringBuilder.Clear();

       foreach (var val in Arr[i])
       {
       stringBuilder.Append(val.ToString("E3"));
       stringBuilder.Append("; ");
       }

       result[i] = stringBuilder.ToString().TrimEnd(' ', ';');
       }
     */
}