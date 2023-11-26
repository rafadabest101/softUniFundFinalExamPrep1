namespace softUniFund_FinalExamPrep1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string str = Console.ReadLine();
            while(str != "Reveal")
            {
                string[] commands = str.Split(":|:");
                switch (commands[0])
                {
                    case "InsertSpace":
                        message = message.Insert(int.Parse(commands[1]), " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        if(message.Contains(commands[1]))
                        {
                            string reversed = "";
                            for(int i = commands[1].Length - 1; i >= 0; i--)
                            {
                                reversed += commands[1][i];
                            }
                            message = message.Replace(commands[1], reversed);
                            Console.WriteLine(message);
                        }
                        else Console.WriteLine("error");
                        break;
                    case "ChangeAll":
                        while(message.Contains(commands[1]))
                        {
                            message = message.Replace(commands[1], commands[2]);
                        }
                        Console.WriteLine(message);
                        break;
                }
                str = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}