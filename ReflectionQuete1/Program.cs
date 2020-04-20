using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionQuete1
{
    class Program
    {
        static void Main(string[] args)
        {
            var newGamer = new Gamer("John", 2, 110);
            GetAllProperties(newGamer);
            GetAllFields(newGamer);
            GetAllMethods(newGamer);
            Console.ReadLine();
        }

        private static void GetAllProperties(object newGamer)
        {
            Type objectType = newGamer.GetType();

            PropertyInfo[] properties = objectType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            
            Console.WriteLine("**** Properties ****");
            foreach (var p in properties)
            {
                Console.WriteLine("\t" + "-> Name: {0}", p.Name);
                Console.WriteLine("\t" + "-> Visibility: {0}", GetPropertiesVisibility(p));
            }
        }

        private static void GetAllFields(object newGamer)
        {
            Type objectType = newGamer.GetType();

            FieldInfo[] fields = objectType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("\n**** Fields ****");
            foreach (var f in fields)
            {
                Console.WriteLine("\t" + "-> Name: {0}", f.Name);
                Console.WriteLine("\t" + "-> Visibility: {0}", GetFieldVisibility(f));
            }
        }

        private static void GetAllMethods(object newGamer)
        {
            Type objectType = newGamer.GetType();

            MethodInfo[] methods = objectType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            Console.WriteLine("\n**** Methods ****");
            foreach (var m in methods)
            {
                Console.WriteLine("\t" + "-> Name: {0}", m.Name);
                Console.WriteLine("\t" + "-> Visibility: {0}", GetMethodVisibility(m));
            }
        }

        static string GetMethodVisibility(MethodInfo m)
        {
            string visibility = "";
            if (m.IsPublic)
                return "Public";
            else if (m.IsPrivate)
                return "Private";
            else
               if (m.IsFamily)
                visibility = "Protected ";
            else if (m.IsAssembly)
                visibility += "Assembly";
            return visibility;
        }

        static string GetFieldVisibility(FieldInfo m)
        {
            string visibility = "";
            if (m.IsPublic)
                return "Public";
            else if (m.IsPrivate)
                return "Private";
            else
               if (m.IsFamily)
                visibility = "Protected ";
            else if (m.IsAssembly)
                visibility += "Assembly";
            return visibility;
        }


        static string GetPropertiesVisibility(PropertyInfo m)
        {
            string visibility = "";
            if (m.CanWrite)
                visibility = "Public";
            else
            {
                visibility = "Private";
            }
            return visibility;
        }
    }

    public class Gamer
    {
        private string _name;
        private int _finishedGames;
        private int _actualPoints;
        public double GeneralScore { get; set; }

        public int GetFinishedGames()
        {
            return _finishedGames;
        }

        public int AddNewPoints(int newPoints)
        {
            return _actualPoints + newPoints;
        }

        public int AddNewFinishedGames(int newGames)
        {
            return _finishedGames + newGames;
        }

        public double GetCurrentScore(int points, int games)
        {
            double pointsPerGame = AddNewPoints(points) / AddNewFinishedGames(games);
            GeneralScore = pointsPerGame / 100;
            return GeneralScore;
        }

        public Gamer(string name, int games, int points)
        {
            _name = name;
            _finishedGames = games;
            _actualPoints = points;
        }
    }
}
