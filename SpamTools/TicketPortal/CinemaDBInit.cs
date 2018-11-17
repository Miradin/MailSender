using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPortal
{
    public partial class CinemaDBContainer
    {
        static CinemaDBContainer() => System.Data.Entity.Database.SetInitializer(new CinemaDBInit());
    }
    class CinemaDBInit : DropCreateDatabaseAlways<CinemaDBContainer>
    {
        protected override void Seed(CinemaDBContainer context)
        {
            base.Seed(context);

            if (!context.Movies.Any())
            {
                context.Movies.AddOrUpdate(
                    new Movie { MaxSeats = 50, Session = "Movie1", Price = 250, Cashbox = 0 },
                    new Movie { MaxSeats = 40, Session = "Movie2", Price = 350, Cashbox = 0 },
                    new Movie { MaxSeats = 60, Session = "Movie3", Price = 220, Cashbox = 0 },
                    new Movie { MaxSeats = 10, Session = "Movie1VIP", Price = 1000, Cashbox = 0 }
                    );
                context.SaveChanges();
            }


        }
    }
}
