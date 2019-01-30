using System;
using System.Collections.Generic;
using System.Text;

namespace aprender.Entities.Aula191Class
{
    class CarRental
    {
        public DateTime Start { get; set; }
        public DateTime finish { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime start, DateTime finish, Vehicle vehicle)
        {
            Start = start;
            this.finish = finish;
            Vehicle = vehicle;
        }
    }
}
