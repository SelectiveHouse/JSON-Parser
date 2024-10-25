namespace JSON_Parser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileName = File_Loader.OpenFile.Open();
            Console.WriteLine(fileName);
        }
    }
}