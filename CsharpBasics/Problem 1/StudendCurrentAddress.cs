using System;
using System.Collections.Generic;
using System.Text;

namespace LectureSeven
{
    class StudendCurrentAddress
    {
        //        Улица
        //Блок
        //Етаж
        //Номер на стая

        private string street;
        private int building;
        private int floor;
        private int roomNumber;
        private Random gen = new Random();

        public StudendCurrentAddress(string street, int building)
        {
            this.Street = street;
            this.Building = building;
            this.Floor = gen.Next(0, 8);
            this.RoomNumber = gen.Next(101, 808);
        }

        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }


        public int Floor
        {
            get { return floor; }
            set { floor = value; }
        }


        public int Building
        {
            get { return building; }
            set { building = value; }
        }


        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public void ViewAdderss()
        {
            Console.WriteLine("Street: " + this.street);
            Console.WriteLine("Building: " + this.building);
            Console.WriteLine("Floor: " + this.floor);
            Console.WriteLine("RoomNumber: " + this.roomNumber);

        }
    }
}
