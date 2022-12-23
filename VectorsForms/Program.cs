namespace VectorsForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {       
            VectorMapper vectorMapper = new VectorMapper();
            TriangleMapper triangleMapper = new TriangleMapper();

            Vector v1 = vectorMapper.GetById(1);
            Vector v2 = vectorMapper.GetById(1);

            Console.WriteLine();
            Console.WriteLine("======================================");

            List<string> list = new List<string>();list.Add("1"); list.Add("1");

            Triangle t1 = new Triangle(new List<string>());

            Console.WriteLine("");
            Console.WriteLine("///////////////////////////////////////");

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}