# JaggedMatrixProject

## Overview
The JaggedMatrix Project is a C# solution that consists of a class library and a console application. The library contains the `JaggedMatrix` class which computes the Maclaurin series expansion of the cosine function for random input values. The console application interacts with the user, processes input and output, and utilizes the class library to perform the required calculations.

## Features
- **Class Library**: Contains the `JaggedMatrix` class with methods to compute and format the Maclaurin series expansion.
- **Console Application**: Handles user input, reads from and writes to text files, and displays results.

## Class Library Details

### `JaggedMatrix` Class
- **Fields**:
  - `double[] x`: Array of double values.
  - `double[][] arr`: Jagged array where each sub-array contains the Maclaurin series values for `cos(x)` at a specific `x`.

- **Constructor**:
  - Parameters: `min` (double), `max` (double), `n` (int).
  - Initializes the `x` array with `n` random values between `min` and `max`.
  - Computes the `arr` arrays using the `CosArray()` method.

- **Methods**:
  - `CosArray(double x0)`: Private method that returns an array of doubles representing the Maclaurin series expansion for `cos(x)` at `x0`.
  - `AsStrings()`: Public method that returns a string array, where each string represents the elements of the corresponding sub-array in `arr` formatted in exponential notation with three decimal places.

## Console Application Details

### Functionality
- Reads input values (`min`, `max`, `n`) from a text file specified by the user.
- Creates an instance of `JaggedMatrix` using these input values.
- Writes the formatted Maclaurin series values to an output text file specified by the user.
- Displays results on the console.

### Error Handling
- Validates user input.
- Handles exceptions related to file operations and data processing.

## How to Use

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/yourusername/JaggedMatrixProject.git
   cd JaggedMatrixProject
   ```

2. **Build the Project**:
   Open the solution in Visual Studio and build it, or use the .NET CLI:
   ```sh
   dotnet build
   ```

3. **Run the Console Application**:
   ```sh
   dotnet run --project JaggedMatrixConsoleApp
   ```

4. **Input and Output Files**:
   - Ensure the input file containing `min`, `max`, and `n` values is in the same directory as the executable.
   - Provide the name of the input file when prompted.
   - The application will output the results to a specified output file in the same directory.
