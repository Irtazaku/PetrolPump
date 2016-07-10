using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetrolPump
{
    class Inventory
    {
        public static string PrinterName;
        public static List<string> Name;
        public static List<double> Rate;

        public static void Init()
        {
            Name = new List<string>();
            Rate = new List<double>();
        }

        public static void Add(string N, double R)
        {
            Name.Add(N);
            Rate.Add(R);
        }

        public static double GetRate(string N)
        {
            return Rate.ElementAt(Name.IndexOf(N));
        }
    }

    class Company
    {
        public static List<int> ID;
        public static List<string> Name;
        public static List<string> Number;
        public static List<string> Email;
        public static List<Vehicle> Vehicles;

        public static void Add(int ID2, string Name2, string Number2, string Email2, Vehicle Vehicles2)
        {
            ID.Add(ID2);
            Name.Add(Name2);
            Vehicles.Add(Vehicles2);
            Number.Add(Number2);
            Email.Add(Email2);
        }

        public static void Init()
        {
            ID = new List<int>();
            Name = new List<string>();
            Number = new List<string>();
            Email = new List<string>();
            Vehicles = new List<Vehicle>();
        }

        //public Company(int ID, string Name, List<Vehicle> Vehicles)
        //{
        //    this.ID = ID;
        //    this.Name = Name;
        //    this.Vehicles = Vehicles;
        //    this.Number = null;
        //    this.Email = null;
        //}

        //public Company(int ID, string Name, string Number, string Email, List<Vehicle> Vehicles)
        //{
        //    this.ID = ID;
        //    this.Name = Name;
        //    this.Vehicles = Vehicles;
        //    this.Number = Number;
        //    this.Email = Email;
        //}
    }

    class Vehicle
    {
        public List<int> ID;
        public List<string> Number;
        public List<string> Name;

        //public static void Init()
        //{
        //    ID = new List<int>();
        //    Number = new List<string>();
        //}

        public void Add(int ID2, string Number2, string Name2)
        {
            this.ID.Add(ID2);
            this.Number.Add(Number2);
            this.Name.Add(Name2);
        }

        public Vehicle()
        {
            ID = new List<int>();
            Name = new List<string>();
            Number = new List<string>();
        }

        //public Vehicle(int ID, string Number)
        //{
        //    this.ID = ID;
        //    this.Number = Number;
        //}
    }

    class LineCustomer
    {
        public static List<int> ID;
        public static List<string> Name;
        public static List<string> Number;

        public static void Init()
        {
            ID = new List<int>();
            Name = new List<string>();
            Number = new List<string>();
        }

        public static void Add(int ID2, string Name2, string Number2)
        {
            ID.Add(ID2);
            Name.Add(Name2);
            Number.Add(Number2);
        }
    }

    class Machines
    {
        public static List<int> ID;
        public static List<string> MachineName;
        public static List<string> InventoryName;

        public static void Init()
        {
            ID = new List<int>();
            MachineName = new List<string>();
            InventoryName = new List<string>();
        }

        public static void Add(int ID2, string MachineName2, string InventoryName2)
        {
            ID.Add(ID2);
            MachineName.Add(MachineName2);
            InventoryName.Add(InventoryName2);
        }

        public static List<string> GetMachineNames(string Name)
        {
            List<string> MachineNames = new List<string>(MachineName.Count);
            for (int i = 0; i < MachineName.Count; i++)
            {
                if (InventoryName[i] == Name)
                    MachineNames.Add(MachineName[i]);
            }
            return MachineNames;
        }

        public static int GetMachineID(string MachineName2, string InventoryName2)
        {
            for (int i = 0; i < MachineName.Count; i++)
            {
                if (MachineName[i] == MachineName2 && InventoryName[i] == InventoryName2)
                    return ID[i];
            }
            return -1;
        }
    }

    class Accounts
    {
        public static List<int> ID;
        public static List<string> BankName;
        public static List<string> Number;

        public static void Init()
        {
            ID = new List<int>();
            BankName = new List<string>();
            Number = new List<string>();
        }

        public static void Add(int ID2, string BankName2, string Number2)
        {
            ID.Add(ID2);
            BankName.Add(BankName2);
            Number.Add(Number2);
        }

        public static List<string> GetAccountNumbers(string Name)
        {
            List<string> AccountNumbers = new List<string>(BankName.Count);
            for (int i = 0; i < BankName.Count; i++)
            {
                if (BankName[i] == Name)
                    AccountNumbers.Add(Number[i]);
            }
            return AccountNumbers;
        }

        public static int GetAccountID(string Name, string AccountNumber)
        {
            for (int i = 0; i < BankName.Count; i++)
            {
                if (BankName[i] == Name && Number[i] == AccountNumber)
                    return ID[i];
            }
            return -1;
        }
    }

    class Forms
    {
        public static bool IsOpened(string FormName)
        {
            bool Opened = false;
            FormCollection FC = Application.OpenForms;
            foreach (Form F in FC)
            {
                if (F.GetType().Name == FormName)
                {
                    Opened = true;
                    F.BringToFront();
                }
            }
            return Opened;
        }
    }
}