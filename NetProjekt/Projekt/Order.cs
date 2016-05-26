using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    interface IBasicOrder
    {
         int orderID { get; set; }
         int empID { get; set; }
         double valueOfOrder { get; set; }

        void CountDiscount(bool b);
    }
    public class Order : IBasicOrder
    {
       public  Client clientWhichOrdered;
        public Employee employeeWhichIsResposibleForTheOrder;

        public int orderID { get; set; }
        public int empID { get; set; }
        public double valueOfOrder { get; set; }

        
        

        Food.Dodatki dodatki;
        Food.Miesne miesne;
        Food.Ryby ryby;

        public Order(Client cl, Employee emp , int orid )
        {
            clientWhichOrdered = cl;
            employeeWhichIsResposibleForTheOrder = emp;
            orderID = orid;
            
        }

        //polimorfizm   
        public Order(Client cl, Employee emp, int orid,  Food.Dodatki d , Food.Miesne m , Food.Ryby r , bool discount)
        {
            
            clientWhichOrdered = cl;
            employeeWhichIsResposibleForTheOrder = emp;
            orderID = orid;
            empID = emp.ID;
            

            dodatki = d;
            miesne = m;
            ryby = r;
            CountOrderVaue(dodatki, miesne, ryby);
            CountDiscount(discount);
            
        }


        //nigdzie indziej nie jest uzywa, tylko wewnatrz tej klasy
       private void CountOrderVaue(Food.Dodatki d, Food.Miesne m , Food.Ryby r)
        {
            if (d != Food.Dodatki.brak)
                valueOfOrder += 5;
            if (m != Food.Miesne.brak)
                valueOfOrder += 20;
            if (r != Food.Ryby.brak)
                valueOfOrder += 25;
        }

        //public ze wzgledu na interfejs
        public void CountDiscount(bool b)
        {
            if (b)
            {
                valueOfOrder *= 0.9;
            }
        }

    }
}
