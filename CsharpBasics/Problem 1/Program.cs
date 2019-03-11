using CsharpBasics;
using System;

namespace LectureEight
{
    class Program
    {
        static void Main(string[] args)
        {


            Player player1 = new Player("Daniel");

            player1.Pickup("furnace");
            player1.Pickup("charcoal");
            player1.Pickup("charcoal");
            player1.Pickup("charcoal");
            player1.Pickup("furnace");
            player1.Pickup("stone");
            player1.Pickup("grass");
            player1.Pickup("grass");
            player1.Pickup("grass");
            player1.Pickup("stone");
            player1.Pickup("stone");
            player1.Pickup("stone");
            player1.Pickup("stone");
            player1.Pickup("chest");
            player1.Store("stone");
            player1.Store("stone");
            player1.Store("charcoal");
            player1.Store("charcoal");
            player1.Store("grass");
            player1.dispayinventory();
            player1.dispayChest();
            Console.WriteLine();
            player1.Break("chest");
            Console.WriteLine();
            player1.dispayinventory();
            player1.dispayChest();



            //Console.WriteLine("Second Player");
            //Console.WriteLine();
            //Console.WriteLine();
            //Player player2 = new Player("Pesho");

            //player2.Pickup("furnace");
            //player2.Pickup("charcoal");
            //player2.Pickup("furnace");
            //player2.Pickup("stone");
            //player2.Pickup("grass");
            //player2.Pickup("stone");
            //player2.Pickup("chest");
            //player2.Pickup("pickaxe");
            //player2.Store("stone");
            //player2.Store("stone");
            //player2.Store("charcoal");
            //player2.Store("stone");
            //player2.Store("stone");
            //player2.Break("stone");
            //player2.Break("furnace");


            //player2.dispayinventory();
            //player2.dispayChest();



            //Console.WriteLine("Third Player");
            //Console.WriteLine();
            //Console.WriteLine();
            //Player player3 = new Player("Gosho");

            //player3.Pickup("furnace");
            //player3.Pickup("charcoal");
            //player3.Pickup("furnace");
            //player3.Pickup("stone");
            //player3.Pickup("grass");
            //player3.Pickup("stone");
            //player3.Pickup("chest");
            //player3.Store("stone");
            //player3.Break("chest");

            //Console.WriteLine();

            //player3.dispayinventory();
            //player3.dispayChest();
        }
    }
}
