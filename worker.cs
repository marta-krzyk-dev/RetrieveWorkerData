using System;

namespace RetrieveWorkerData
{
    public struct worker
    {
        public string name;
        public string surname;
        public int dep_no;

        public worker(string name_, string surname_, int dep_no_ = 0)
        {
            this.name = name_;
            this.surname = surname_;
            this.dep_no = (dep_no_ > 0) ? dep_no_ : 0;
        }

        static public bool AreEqual(worker a, worker b)
        {
            if (String.Equals(a.name, b.name) &&
                String.Equals(a.surname, b.surname) &&
                a.dep_no == b.dep_no)
                return true;
            else
                return false;
        }

        public static bool operator ==(worker a, worker b)
        {
            return AreEqual(a, b);
        }

        public static bool operator !=(worker a, worker b)
        {
            return !AreEqual(a, b);
        }
    }
}
