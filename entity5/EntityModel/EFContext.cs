using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity5.EntityModel
{
    public class EfContext :DbContext
    {
        public EfContext()
            :base ("name=EntityModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfContext,
            Migrations.Configuration>());
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Email> Mail { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Birth> Birth { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<EducationEmail> EducationMail { get; set; }
        public DbSet<EducationPhone> EducationPhone { get; set; }
        public DbSet<EducationAdress> EducationAdress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // wlacza kaskadowe usuwanie na tbelach z persona
            modelBuilder.Entity<Person>().
                HasMany<Phone>(s => s.Phone).
                WithOptional(w => w.Person).
                WillCascadeOnDelete(true);

            modelBuilder.Entity<Person>().
                HasMany<Email>(s => s.Mail).
                WithOptional(w => w.Person).
                WillCascadeOnDelete(true);

            modelBuilder.Entity<Person>().
                HasMany<Adress>(s => s.Adress).
                WithOptional(w => w.Person).
                WillCascadeOnDelete(true);

            modelBuilder.Entity<Person>().
                HasMany<Education>(s => s.Education).
                WithOptional(w => w.Person).
                WillCascadeOnDelete(true);

            modelBuilder.Entity<Person>().
                HasOptional<Birth>(e => e.Birth).
                WithRequired(e => e.Person).
                WillCascadeOnDelete(true);

            modelBuilder.Entity<Person>().
                HasOptional<Pictures>(e => e.Pictures).
                WithRequired(e => e.Person).
                WillCascadeOnDelete(true);

            modelBuilder.Entity<Person>().
                Property(e => e.RovVersion).
                IsRowVersion();

            modelBuilder.Entity<Birth>().
                Property(e => e.Date).
                HasColumnType("datetime2");

            // ustawia datetame 2 na kolumny w edukacji
            modelBuilder.Entity<Education>().
                Property(e => e.StartEducaton).
                HasColumnType("datetime2");

            modelBuilder.Entity<Education>().
                Property(e => e.EndEducation).
                HasColumnType("datetime2");

            modelBuilder.Entity<Birth>().
                HasKey(s => s.BirthId);
            
            modelBuilder.Entity<Pictures>().
                HasKey(s => s.PicturesId);

            modelBuilder.Entity<Education>().
                HasMany<EducationEmail>(s => s.Mail).
                WithOptional(w => w.Education).
                WillCascadeOnDelete(true);
            
            modelBuilder.Entity<Education>().
                HasMany<EducationPhone>(s => s.Phone).
                WithOptional(w => w.Education).
                WillCascadeOnDelete(true);

            modelBuilder.Entity<EducationAdress>().
                HasKey(s => s.AdressId);

            modelBuilder.Entity<Education>().
                HasOptional<EducationAdress>(s => s.Adress).
                WithRequired(w => w.Education).
                WillCascadeOnDelete(true);
            // ustawia wersje encji czy zmieniona czy nie


            base.OnModelCreating(modelBuilder);
        }
         
    }
}
