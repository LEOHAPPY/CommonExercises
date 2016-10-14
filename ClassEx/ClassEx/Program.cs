using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEx
{
    abstract class Person
    {
        string name;
        string address;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
    }

    class Customer:Person
    {
        string id;

        public string ID
        {
            get { return id; }
        }

        public Customer(string name, string address, string id):base(name , address)
        {
            this.id = id;
        }
    }
    class TourGuide:Person
    {
        int salary;

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public TourGuide(string name, string address, int salary):base(name,address)
        {
            this.salary = salary;
        }
    }

    class Tour
    {
        string tourName;
        int cost;
        int duration;
        List<string> places;

        public string TourName
        {
            get { return TourName; }
        }
        public virtual int Cost
        {
            get { return cost; }
        }
        public virtual int Duration
        {
            get { return duration; }
        }

        public Tour(string tourName, int cost, int duration)
        {
            this.tourName = tourName;
            this.cost = cost;
            this.duration = duration;
            this.places = new List<string>();
        }

        public override string ToString()
        {
            string m = string.Format("tourname {0}\tcost {1:c}\tduration {2}", tourName, cost, duration);
            return m;
        }
    }

    class TourPackage:Tour
    {
        List<Tour> tourList;
        string theme;

        public TourPackage(string tourName, int cost, int duration) : base(tourName, cost, duration)
        {
            tourList = new List<Tour>();
        }

        public TourPackage(string theme):this("",0,0) //overloading
        {
            this.theme = theme;
            tourList = new List<Tour>();
        }

        public void ConsistOf(Tour tour)
        {
            tourList.Add(tour);
        }

        public override int Cost
        {
            get
            {
                int cost = 0;
                foreach(var item in tourList)
                {
                    cost += item.Cost;
                }
                return (int)0.9*cost;
            }
        }

        public override int Duration
        {
            get
            {
                int duration = 0;
                foreach(var item in tourList)
                {
                    duration += item.Duration;
                }
                return duration;
            }
        }
    }

    class Trip
    {
        Tour tour;
        DateTime when;
        int limitNum;

        public int LimitNum
        {
            get { return limitNum; }
        }
        public Tour Tour
        {
            get { return tour; }
        }

        public Trip (Tour tour, DateTime when, int limitNum)
        {
            this.tour = tour;
            this.when = when;
            this.limitNum = limitNum;
        }

        public override string ToString()
        {
            string m = string.Format("tourName {0}\twhen {1}\tlimitNum {2}", tour.TourName, when, limitNum);
            return m;
        }

    }

    class Booking
    {
        Customer customer;
        Trip trip;
        int num;
        List<Booking> BookList;

        public int Getnum
        {
            get
            {
                foreach(var item in BookList)
                {
                    num += item.num;
                }
                return num;
            }
        }

        public Customer Customer
        {
            get { return customer; }
        }
        public Trip Trip
        {
            get { return trip; }
        }

        public Booking(Customer customer, Trip trip, int num)
        {
            this.customer = customer;
            this.trip = trip;
            this.num = num;
            BookList = new List<Booking>();
        }

        public void Book(Customer customer, Trip trip, int num)
        {
            if ( (Getnum+num) > trip.LimitNum)
            {
                throw new Exception();
            }
            else
            {
                BookList.Add(new Booking(customer,trip,num));
            }
        }
        public int Cost
        {
            get
            {
                int cost = 0;
                cost += trip.Tour.Cost;
                if (num >5)
                {
                    return (int)0.9*cost;
                }
                else
                {
                    return cost;
                }
            }
        }
        public int GetRevenue()
        {
            int revenue = 0;
            revenue += trip.Tour.Cost * num;
            return revenue;
        }
             
        //public void Book():this(cus)

    }
    class TravelAgency
    {
        string taName;
        List<Customer> Customers;
        List<Tour> tours;
        List<Trip> trips;

        public TravelAgency (string taName)
        {
            this.taName = taName;
            Customers = new List<Customer>();
            tours = new List<Tour>();
            trips = new List<Trip>();
        }

        public void Add (Customer customer)
        {
            Customers.Add(customer);
        }
        public void Add (Tour tour)
        {
            tours.Add(tour);
        }
        public void Add (Trip trip)
        {
            trips.Add(trip);
        }

        public Tour FindTour(string city)
        {
            Tour tour = new Tour("",0,0);
            foreach(Tour item in tours)
            {
                if (city == item.TourName)
                {
                    tour = item;
                    break;
                }
                else
                {
                    Console.WriteLine("no such tour");
                }
            }
            return tour;
        }

        public Customer FindCustomer(string name)
        {
            Customer customer = new Customer("", "","");
            foreach (Customer item in Customers)
            {
                if (name == item.Name)
                {
                    customer = item;
                    break;
                }
                else
                {
                    Console.WriteLine("no such customer");
                }
            }
            return customer;
        }

        public Trip FindTrip(string city)
        {
            Trip trip = new Trip(null,new DateTime(),0);
            foreach (Trip item in trips)
            {
                if (city == item.Tour.TourName)
                {
                    trip = item;
                    break;
                }
                else
                {
                    Console.WriteLine("no such tour");
                }
            }
            return trip;
        }

        public void MakeBooking(Customer customer, Trip trip, int n)
        {

        }

        public void ListTours()
        {
            foreach(Tour item in tours)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTrips()
        {
            foreach (Trip item in trips)
            {
                Console.WriteLine(item);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //Customer a = new Customer("Tan Lian Hwee", "Clementi Road", "C10010");
            //Customer b = new Customer("Lim Teck Gee", "Kent Ridge Road", "C100");
            //TourGuide c = new TourGuide("Koh Ghim Moh", "Dover Road", 3400);
            //TourGuide d = new TourGuide("Liat Kim Ho", "West Coast Road", 2700);
            //Tour t1 = new Tour("Paris", 3400, 3);
            //Tour t2 = new Tour("London", 3200, 3);
            //Tour t3 = new Tour("Munich", 3100, 2);
            //Tour t4 = new Tour("Milan", 3500, 3);
            //Console.WriteLine(t1);
            //Console.WriteLine(t2);
            //Console.WriteLine(t3);
            //Console.WriteLine(t4);
            TravelAgency t = new TravelAgency("Tan Ah Huat Travel Far");
            t.Add(new Customer("Tan Lian Hwee", "Clementi Road", "C10010"));
            t.Add(new Customer("Lim Teck Gee", "Kent Ridge Road", "C10020"));
            t.Add(new Customer("Koh Ghim Moh", "Dover Road", "C10030"));
            t.Add(new Customer("Liat Kim Ho", "West Coast Road", "C10040"));
            t.Add(new Tour("Paris", 3400, 3));
            t.Add(new Tour("London", 3200, 3));
            t.Add(new Tour("Munich", 3100, 2));
            t.Add(new Tour("Milan", 3500, 3));
            TourPackage p = new TourPackage("Europe");
            p.ConsistOf(t.FindTour("London"));
            p.ConsistOf(t.FindTour("Paris"));
            t.Add(p);
            t.Add(new Trip(t.FindTour("Paris"), new DateTime(2015, 4, 2), 20));
            t.Add(new Trip(t.FindTour("Munich"), new DateTime(2015, 4, 8), 15));
            t.Add(new Trip(t.FindTour("Europe"), new DateTime(2015, 4, 12), 17));
            t.MakeBooking(t.FindCustomer("Lim Teck Gee"), t.FindTrip("Paris"), 7);
            t.MakeBooking(t.FindCustomer("Liat Kim Ho"), t.FindTrip("Europe"), 2);
            t.MakeBooking(t.FindCustomer("Koh Ghim Moh"), t.FindTrip("Munich"), 1);
            t.MakeBooking(t.FindCustomer("Tan Lian Hwee"), t.FindTrip("Europe"), 3);
            t.ListTours();
            t.ListTrips();
        }
    }
}
