using ExamenNet.Models;
using ExamenNet.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTests
{
    class UserRoleServiceTest
    {

        [Test]
        public void GetAllShouldReturnUserRoles()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(GetAllShouldReturnUserRoles))
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var userRoleService = new UserRoleService(context);
                var addUserRole = userRoleService.Create(new ExamenNet.ViewModels.UserRolePostModel
                {
                    Name = "Rol testare",
                    Description = "Creat pentru testare"
                });

                var allUsers = userRoleService.GetAll();
                Assert.IsNotNull(allUsers);
            }
        }


        [Test]
        public void GetByIdShouldReturnUserRole()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(GetByIdShouldReturnUserRole))
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var userRoleService = new UserRoleService(context);
                var addUserRole = userRoleService.Create(new ExamenNet.ViewModels.UserRolePostModel
                {
                    Name = "Rol testare",
                    Description = "Creat pentru testare"
                });

                var userRole = userRoleService.GetById(1);
                Assert.AreEqual("Rol testare", userRole.Name);
            }
        }


        [Test]
        public void CreateShouldAddAndReturnTheRole()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(CreateShouldAddAndReturnTheRole))
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var userRoleService = new UserRoleService(context);
                var addUserRole = userRoleService.Create(new ExamenNet.ViewModels.UserRolePostModel
                {
                    Name = "Rol testare",
                    Description = "Creat pentru testare"
                });

                var userRole = context.UserRoles.Find(1);
                Assert.AreEqual(addUserRole.Name, userRole.Name);
            }
        }


        [Test]
        public void UpsertShouldChangeTheFildValuesForRole()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(UpsertShouldChangeTheFildValuesForRole))
              .EnableSensitiveDataLogging()
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var userRoleService = new UserRoleService(context);
                var addUserRole = userRoleService.Create(new ExamenNet.ViewModels.UserRolePostModel
                {
                    Name = "Rol testare",
                    Description = "Creat pentru testare"
                });

                var userRole = context.UserRoles.Find(1);
                Assert.AreEqual(addUserRole.Name, userRole.Name);
            }
        }

        [Test]
        public void DeleteShouldRemoveAndReturnUserRole()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(DeleteShouldRemoveAndReturnUserRole))
              .EnableSensitiveDataLogging()
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var userRoleService = new UserRoleService(context);
                var addUserRole = userRoleService.Create(new ExamenNet.ViewModels.UserRolePostModel
                {
                    Name = "Rol testare",
                    Description = "Creat pentru testare"
                });

                Assert.IsNotNull(addUserRole);
                Assert.AreEqual("Rol testare", context.UserRoles.Find(1).Name);

                var deletedUserRole = userRoleService.Delete(1);

                Assert.IsNotNull(deletedUserRole);
                Assert.AreEqual(addUserRole.Name, deletedUserRole.Name);
            }
        }
    }
}
