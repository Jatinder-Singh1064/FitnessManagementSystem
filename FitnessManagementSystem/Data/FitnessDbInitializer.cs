using FitnessManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessManagementSystem.Data
{
    //public class FitnessDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FitnessContext>
    public class FitnessDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<FitnessContext>
    {
        protected override void Seed(FitnessContext context)
        {
            var GymList = new List<Gym>
            {
                new Gym() {GymId=1,GymStAddress="First Gulf",GymCity="Brampton",GymProvince="ON",GymPostal="LS69V6"},
                new Gym() {GymId=2,GymStAddress="Humber",GymCity="Etobicoke",GymProvince="ON",GymPostal="LS85B5"},
                new Gym() {GymId=3,GymStAddress="Silverstone",GymCity="Toronto" ,GymProvince="ON",GymPostal="M9V1B7"},
                new Gym() {GymId=4,GymStAddress="Square One",GymCity="Mississauga",GymProvince="ON",GymPostal="M9V1B9"}
            };
            GymList.ForEach(s => context.Gyms.Add(s));
            context.SaveChanges();


            var cityList = new List<City>
            {
                new City() {Title = "Brampton", Lat = 43.731500, Lng = -79.7624},
                new City() {Title = "Mississauga", Lat = 43.5890, Lng = -79.6441 },
                new City() {Title = "Etobicoke", Lat = 43.6205, Lng = -79.5132 },
                new City() { Title = "Toronto", Lat = 43.6532, Lng = -79.3839}
            };
            cityList.ForEach(s => context.Cities.Add(s));
            context.SaveChanges();


            var eventList = new List<Event>
            {
                new Event() { EventId = 1, Subject="Yoga session", Description="Build strength, restore flexibility and de-stress body and mind with classes suited to yogis of all levels. Enjoy our yoga classes in club, on demand or via livestream — they are all included with membership", Start=DateTime.Parse("2022-04-25 11:00:00"), End=DateTime.Parse("2022-04-25 13:30:00"), ThemeColor="Green", IsFullDay=false},
                new Event() { EventId = 2, Subject="Zumba", Description="Zumba is a fitness program that combines Latin and international music with dance moves. Zumba routines incorporate interval training — alternating fast and slow rhythms — to help improve cardiovascular fitness.", Start=DateTime.Parse("2022-04-26 11:00:00"), End=DateTime.Parse("2022-04-26 13:30:00"), ThemeColor="Blue", IsFullDay=false },
                new Event() { EventId = 3, Subject="Bhangra", Description="Not just fun, Bhangra also has many health benefits and the biggest of them all is weight loss. Yes, this dance form can help you lose weight in an extremely fun way. Masala Bhangra is believed to be a big calorie burner.", Start=DateTime.Parse("2022-04-27 11:00:00"), End=DateTime.Parse("2022-04-27 13:30:00"), ThemeColor="Red", IsFullDay=false},
                new Event() { EventId = 4, Subject="HIIT", Description="HIIT (High-Intensity Interval Training) is a form of exercise that has been proven to boost metabolism and build strength, packing in the same benefits of lower and moderate-intensity aerobic workouts in a much shorter time.", Start=DateTime.Parse("2022-04-26 09:00:00"), End=DateTime.Parse("2022-04-26 10:30:00"), ThemeColor="Blue", IsFullDay=false }
            };
            eventList.ForEach(s => context.Events.Add(s));
            context.SaveChanges();


            var membershipPlans = new List<MembershipPlans>
            {
                    new MembershipPlans() {PlanId = 1, Name ="Gold", Description = "Everthing + No Instructor Training", Price=50},
                    new MembershipPlans() {PlanId = 2, Name ="Silver", Description = "Everything except Cardio", Price=40},
                    new MembershipPlans() {PlanId = 3, Name ="Platinum", Description = "Everthing + Instructor Training", Price=60}
            };
            membershipPlans.ForEach(s => context.MembershipPlans.Add(s));
            context.SaveChanges();


            var customer = new List<Customer>
            {
                   new Customer() {CustomerId = 1, CustomerName="David", Password="David@1993", CustomerPhone="9876543210", CustomerEmail="david@gmail.com", DateOfBirth=DateTime.Parse("1993-01-02"), CustomerAddress="4 Starways st"},
                   new Customer() {CustomerId = 2, CustomerName="Sonia", Password="Sonia@1993", CustomerPhone="9873343210", CustomerEmail="sonia@gmail.com", DateOfBirth=DateTime.Parse("1994-01-02"), CustomerAddress="8 Parkway st"},
                   new Customer() {CustomerId = 3, CustomerName="Rob", Password="Rob@1993", CustomerPhone="9876599210", CustomerEmail="rob@gmail.com", DateOfBirth=DateTime.Parse("1996-01-02"), CustomerAddress="8 Jeffery st"},
                   new Customer() {CustomerId = 4, CustomerName="Marc", Password="Marc@1993", CustomerPhone="9899543210", CustomerEmail="marc@gmail.com", DateOfBirth=DateTime.Parse("2000-01-02"), CustomerAddress="38 Forest Manor st"},
                   new Customer() {CustomerId = 5, CustomerName="Emily", Password="Emily@1993", CustomerPhone="9876548810", CustomerEmail="emily@gmail.com", DateOfBirth=DateTime.Parse("1995-01-02"), CustomerAddress="8 Jeffery st"}
            };
            customer.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();


            var enrollments = new List<Enrollment>
                {
                    new Enrollment() {EnrollmentId=1, PlanId=1, NumberOfMonths=1, GymId=1, CustomerId=1},
                    new Enrollment() {EnrollmentId=2, PlanId=2, NumberOfMonths=1, GymId=2, CustomerId=2},
                    new Enrollment() {EnrollmentId=3, PlanId=3, NumberOfMonths=1, GymId=3, CustomerId=3},
                    new Enrollment() {EnrollmentId=4, PlanId=1, NumberOfMonths=1, GymId=4, CustomerId=4},
                    new Enrollment() {EnrollmentId=5, PlanId=2, NumberOfMonths=1, GymId=1, CustomerId=5}
                };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();


            var payment = new List<Payment>
               {
                    new Payment() {TransactionId=1, Amount=50, CardNumber="9874000012346543", ExpiryDate=DateTime.Parse("2025-01-02"), CVV="356", CustomerId=1, EnrollmentId=1},
                    new Payment() {TransactionId=2, Amount=50, CardNumber="9874000012347543", ExpiryDate=DateTime.Parse("2026-01-02"), CVV="376", CustomerId=2, EnrollmentId=2},
                    new Payment() {TransactionId=3, Amount=50, CardNumber="9874000012348543", ExpiryDate=DateTime.Parse("2027-01-02"), CVV="346", CustomerId=3, EnrollmentId=3},
                    new Payment() {TransactionId=4, Amount=50, CardNumber="9874000012396543", ExpiryDate=DateTime.Parse("2028-01-02"), CVV="396", CustomerId=4, EnrollmentId=4},
                    new Payment() {TransactionId=5, Amount=50, CardNumber="9874000012356543", ExpiryDate=DateTime.Parse("2029-01-02"), CVV="326", CustomerId=5, EnrollmentId=5}
               };
            payment.ForEach(s => context.Payments.Add(s));
            context.SaveChanges();
        }
    }
}