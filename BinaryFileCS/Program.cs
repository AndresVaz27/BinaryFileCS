using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create or open a binary file with some integer data
        try
        {
            using (FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryWriter writer = new BinaryWriter(fs);
                int[] data = { 1, 2, 3, 4, 5 };
                for (int i = 0; i < data.Length; i++)
                {
                    writer.Write(data[i]);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error: Could not create file. " + ex.Message);
            return;
        }

        // Read the integer data from the file and perform some operation on it
        try
        {
            using (FileStream fs = new FileStream("data.bin", FileMode.Open, FileAccess.Read))
            {
                BinaryReader reader = new BinaryReader(fs);

                // Read the integer data from the file
                int[] data = new int[5];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = reader.ReadInt32();
                }

                // Perform some operation on the data
                int result = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    result += data[i];
                }

                // Print the result
                Console.WriteLine("The sum of the numbers is: " + result);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error: Could not open file. " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadLine();
    }
}
