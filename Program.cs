using System.Data.SqlClient;

namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Prego scegli una delle seguenti opzione premendo il corrispondente tasto sulla tastiera.");
            while (true)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("1. Inserisci nuovo videogioco");
                Console.WriteLine("2. Ricerca per ID");
                Console.WriteLine("3. Ricerca per nome");
                Console.WriteLine("4. Elimina videogioco");
                Console.WriteLine("5. Chiudi app");

                var opzione = Console.ReadKey();

                Console.WriteLine(Environment.NewLine);

                try
                {
                    switch (opzione.Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Nome:");
                            var name = Console.ReadLine();

                            Console.WriteLine("Descrizione:");
                            var overview = Console.ReadLine();

                            Console.WriteLine("Data di rilascio (dd/mm/yyyy):");
                            DateTime releaseDate; 
                            while(!DateTime.TryParse(Console.ReadLine(), out releaseDate))
                                Console.WriteLine("Inserisci formato Valido! (dd/mm/yyyy)");

                            Console.WriteLine("Software house id:");
                            var softwareHouseId = Convert.ToInt64(Console.ReadLine());

                            var game = new Videogame(name, overview, releaseDate, softwareHouseId);

                            VideogameManager.AddGame(game);

                            
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("Inserisci id gioco");

                            var id = Convert.ToInt64(Console.ReadLine());

                            VideogameManager.SearchById(id).ToString();

                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("Inserisci nome gioco");

                            var Name = Console.ReadLine();

                            VideogameManager.ListToString(VideogameManager.SearchByName(Name));

                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("Inserisci id gioco da eliminare");

                            var _id = Convert.ToInt64(Console.ReadLine());

                            VideogameManager.DeleteGame(_id);

                            break;
                        case ConsoleKey.D5:
                            Environment.Exit(0);

                            break;
                        default:
                            Console.WriteLine("Premi un numero da 1 a 5!");

                            break;
                    }

                } catch (Exception ex) 
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }
    }
}