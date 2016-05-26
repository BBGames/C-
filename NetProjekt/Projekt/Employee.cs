using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Employee : Person
    {


       public Employee(string name, string surname, int id)
        {
            base.name = name;
            base.surname = surname;
            base.ID = id;
        }

       
    }
}
