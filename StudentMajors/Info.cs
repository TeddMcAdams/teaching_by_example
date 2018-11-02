using System;
using System.IO;
    

namespace student_majors
{

    public class info
    {
        private string first;
        private string last;
        private long id;
        private string major;
        
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
}
