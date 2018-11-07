using System;
using System.IO;
    

namespace ConsoleApp3
{

    public class info
    {
        private string first;
        private string last;
        private long id;
        private string major;
        
        public bool equals(info otherObject)
        {
        	// Do logic to compare two 'info' objects
        	// one object is provided via the method's parameter
        	// the other object is this actual object
        }

        public bool equalsName(string firstName, string lastName)
        {
        	// Do logic to compare the first & last name provided to that of this object
        }

        public bool equalsID(long id)
        {
        	// Do logic to compare the id provided to that of this object
        }

        public string getFirst()
        {
            return (first);
        }

        public void setFirst(string f)
        {
            first = f;
        }

        public string getLast()
        {
            return (last);
        }

        public void setLast(string x)
        {
            last = x;
        }

        public long getID()
        {
            return (id);
        }

        public void setID(long i)
        {
        	// do logic here to restrict the numbers you are allowing per the requirement
        	// requirement: Finally, ensure that only numbers between 1000000 and 9999999 (inclusive) 
            id = i;
        }

        public string getMajor()
        {
            return (major);
        }

        public void setMajor(string m)
        {
            major = m;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            info[] bigArray = new info[1000];
            int i;
            int count = 0;
            int more;
            string inp;
            StreamReader sr = null;
            StreamWriter sw = null;
            for (i = 0; i < 1000; i = i + 1)
            {
                bigArray[i] = new info();
            }
            Console.Write("new ? ");
            inp = Console.ReadLine();
            if (inp[0] == 'y') { }
            else
            {
                try
                {
                    sr = new StreamReader("c:\\data\\data.txt");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                } // this will never? happen
                inp = sr.ReadLine();
                count = Convert.ToInt32(inp);
                for (i = 0; (i < count); i = i + 1)
                {
                    bigArray[i] = new info();
                    inp = sr.ReadLine();
                    bigArray[i].setFirst(inp);
                    inp = sr.ReadLine();
                    bigArray[i].setLast(inp);
                    inp = sr.ReadLine();
                    bigArray[i].setID(Convert.ToInt64(inp));
                    inp = sr.ReadLine();
                    bigArray[i].setMajor(inp);
                }
                sr.Close();
            }
            Console.Write("add how many ? ");
            inp = Console.ReadLine();
            more = Convert.ToInt32(inp);
            for (i = count; (i < (count + more)); i = i + 1)
            {
                bigArray[i] = new info();
                Console.Write("first : ");
                inp = Console.ReadLine();
                bigArray[i].setFirst(inp);
                Console.Write("last : ");
                inp = Console.ReadLine();
                bigArray[i].setLast(inp);
                Console.Write("ID : ");
                inp = Console.ReadLine();
                bigArray[i].setID(Convert.ToInt64(inp));
                Console.Write("major : ");
                inp = Console.ReadLine();
                bigArray[i].setMajor(inp);
            }
            try
            {
                sw = new StreamWriter("c:\\data\\data.txt");
            }
            catch (Exception e) { } // this will never? happen
            sw.WriteLine("" + (count + more));
            for (i = 0; (i < (count + more)); i = i + 1)
            {
                sw.WriteLine("" + bigArray[i].getFirst());
                sw.WriteLine("" + bigArray[i].getLast());
                sw.WriteLine("" + bigArray[i].getID());
                sw.WriteLine("" + bigArray[i].getMajor());
            }
            sw.Close();
        }
    }
}
