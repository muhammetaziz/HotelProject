using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataAccessLayer.Concrate
{
    public class HotelContext : IdentityDbContext<AppUser , AppRole ,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=MUHAMMETAZIZ\\SQLEXPRESS;Database=HotelDb;Integrated Security=true;TrustServerCertificate=True;");
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<About>().HasData(
                new About
                {
                    AboutId = 1,
                    AboutDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Image1 = "https://cdn.pixabay.com/photo/2016/11/29/09/08/hotel-1867180_1280.jpg",
                    Image2 = "https://cdn.pixabay.com/photo/2016/11/29/09/08/hotel-1867180_1280.jpg",
                    Image3 = "https://cdn.pixabay.com/photo/2016/11/29/09/08/hotel-1867180_1280.jpg"
                });

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    ContactAdress = "123 Main St, Anytown, USA",
                    ContactDescription = "We are here to help you with any inquiries or concerns you may have. Please feel free to reach out to us through the contact information provided below.",
                    ContactEmail = "hotelistiklal@gmail.com",
                    ContactMap = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3153.1234567890123!2d-122.4194154846814!3d37.7749292797598!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8085808c8c8c8c8c%3A0x8c8c8c8c8c8c8c8c!2s123%20Main%20St%2C%20Anytown%2C%20USA!5e0!3m2!1sen!2sus!4v1616161616161",
                    ContactNumber = "123-456-7890"
                });


            modelBuilder.Entity<Home>().HasData(
                new Home
                {
                    Id = 1,
                    HotelName = "Hotel Name",
                    Title = "Welcome to Our Hotel",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Image1 = "https://cdn.pixabay.com/photo/2016/11/29/09/08/hotel-1867180_1280.jpg",
                    Image2 = "https://cdn.pixabay.com/photo/2016/11/29/09/08/hotel-1867180_1280.jpg",
                    Image3 = "https://cdn.pixabay.com/photo/2016/11/29/09/08/hotel-1867180_1280.jpg",
                    Image4 = "https://cdn.pixabay.com/photo/2016/11/29/09/08/hotel-1867180_1280.jpg"
                });
            modelBuilder.Entity<HotelServ>().HasData(
                new HotelServ
                {
                    Id = 1,
                    ActivityTitle = "Free Wi-Fi",
                    ActivityDescription = "Enjoy complimentary high-speed internet access throughout the hotel.",
                    ActivityIcon = "https://cdn.pixabay.com/photo/2016/11/29/09/08/hotel-1867180_1280.jpg"
                });
            modelBuilder.Entity<SocialMedia>().HasData(
                new SocialMedia
                {
                    SocialMediaId = 1,
                    Instagram = "https://www.instagram.com/",
                    Facebook = "https://www.facebook.com/",
                    Twitter = "https://twitter.com/"
                });
        }





        public DbSet<About> Abouts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationDetail> ReservationDetails { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<HotelServ> HotelServs { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<RoomAvailability> RoomAvailabilities { get; set; }

    }
}
