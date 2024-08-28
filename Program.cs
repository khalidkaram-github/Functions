namespace Functions
{
    internal class Program
    {
        //------------------pure-----------------------------//

        static int Add(int a, int b) => a + b;
        static int Square(int x) => x * x;


        //-----------------non-pure---------------------------//


        //Calling IncrementCounter() multiple times will produce different values of counter
        static int counter = 0;
        void IncrementCounter() => counter++;



        //Calling GenerateRandomNumber() will return different values each time
        int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next();
        }

        //----------------------------------------------------//
        //====================================================//

        //----------------------------------honest -------------------------//

        void SaveDataToFile(string data, string filePath) => File.WriteAllText(filePath, data);

        //----------------------------------dis honest -------------------------//
        void ProcessData(int[] data)
        {
            void SaveToDatabase(int[] data) { }

            Array.Sort(data);
            SaveToDatabase(data); // Save to database, a hidden side effect
            // The name ProcessData does not indicate that the function sorts the array and then saves it to a database
        }

        string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
            // Throws exceptions like FileNotFoundException
            //The function ReadFromFile does not indicate that it might throw exceptions due to file access issues
        }



        static void Main(string[] args)
        {



        }
    }
}
