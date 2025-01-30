string? choice;
string file = "mario.txt";

do
{
    Console.WriteLine("1) Read data from mario.txt.");
    Console.WriteLine("2) Append characters to mario.txt.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        // read data from file
        if (File.Exists(file))
        {
            // accumulator needed for count
            int count = 0;
            // read data from file
            StreamReader sr = new(file);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                // convert string to array
                string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split(',');
                // display array data
                Console.WriteLine("ID: {0}", arr[0]);
                Console.WriteLine("Name: {0}", arr[1]);
                Console.WriteLine("Relationship to Mario: {0}\n", arr[2]);
                // add to accumulator
                count += 1;
            }
            sr.Close();
            Console.WriteLine("{0} Characters saved to file", count);
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "2")
    {
        // create file from data
        StreamWriter sw = new StreamWriter(file, append: true);
        for (int i = 0; i < 7; i++)
        {
            // ask a question
            Console.WriteLine("Enter a Character (Y/N)?");
            // input the response
            string? resp = Console.ReadLine()?.ToUpper();
            // if the response is anything other than "Y", stop asking
            if (resp != "Y") { break; }
            Console.WriteLine("ID?");
            string? id = Console.ReadLine();
            Console.WriteLine("Name?");
            string? name = Console.ReadLine();
            Console.WriteLine("Relationship to Mario?");
            string? relation = Console.ReadLine();
            sw.WriteLine("{0},{1},{2}", id, name, relation);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");
