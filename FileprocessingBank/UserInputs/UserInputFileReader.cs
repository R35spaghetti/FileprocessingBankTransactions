using System.Globalization;

namespace FileprocessingRB.UserInputs
{
    internal class UserInputFileReader
    {
        internal string GetFilePathInput()
        {
            string input = Console.ReadLine() ?? string.Empty;
            if (Path.HasExtension(input) && Path.IsPathRooted(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid file path.");
                return GetFilePathInput();
            }
        }

        internal string GetFilePathOutput()
        {
            try
            {

                string input = Console.ReadLine() ?? string.Empty;
                if (Directory.Exists(input))
                {
                    string testFilePath = Path.Combine(input, "tryMakeTest.txt");
                    try
                    {
                        using (File.Create(testFilePath))
                        {
                        }

                        File.Delete(testFilePath);
                        return input;
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Unable to create a text file in the provided path.");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Permission denied to create a text file in the provided path.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid file path.");
                }
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("Stack overflow occurred. Please try again.");
            }

            return GetFilePathOutput();
        }

        internal string GetDateReference()
        {
            try
            {
                string referenceDate = DateTime.ParseExact(Console.ReadLine() ?? string.Empty,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
                return referenceDate;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }

            return GetDateReference();

        }
    }
}
