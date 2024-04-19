using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Test
{
   public class ArcitectureTests
    {

        private const string EntitiesNamespace = "Entities";
        private const string ContractsNamespace = "Contracts";
        private const string PresentationNamespace = "GeorgianFoodReviewAPI.Presentation";
        private const string LoggerServiceNamespace = "LoggerService";
        private const string RepositoryNamespace = "Repository";
        private const string ServiceNamespace = "Service";
        private const string ServiceContractsNamespace = "Service.Contracts";
        private const string SharedNamespace = "Shared";




        [Fact]
        public void Entities_Should_Not_HaveDependencyOtherProjects()
        {

            var assembly = typeof(Entities.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
               
                ContractsNamespace,
                PresentationNamespace,
                LoggerServiceNamespace,
                RepositoryNamespace,
                SharedNamespace,
                ServiceContractsNamespace,
                ServiceNamespace

            };

            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();  



        }

        [Fact]
        public void Service_Should_Not_HaveDependency_Rather_Than_Domain_Layer()
        {
            var assembly = typeof(Service.AssemblyReference).Assembly;


            var otherProjects = new[]
            {
               
                ContractsNamespace,
                PresentationNamespace,
                LoggerServiceNamespace,
                RepositoryNamespace,
               

            };

            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Controllers_Should_HaveDependencyOn_ServiceContracts()
        {
            var assembly = typeof(GeorgianFoodReviewAPI.Presentation.AssemblyReference).Assembly;


            var testResult = Types.InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Controller")
                .Should()
                .HaveDependencyOn(ServiceContractsNamespace)
                .GetResult();

            testResult .IsSuccessful.Should().BeTrue(); 

        }

        [Fact]
        public void Shared_Should_Not_HavDependency_On_Other_Projects()
        {

            var assembly = typeof(Shared.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                EntitiesNamespace,
                ContractsNamespace,
                PresentationNamespace,
                LoggerServiceNamespace,
                RepositoryNamespace,
                ServiceContractsNamespace,
                ServiceNamespace

            };


            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();



        }

        [Fact]
        public void Service_Should_have_DependencyOn_Contracts()
        {
            var assembly = typeof(Service.AssemblyReference).Assembly;

            var testResult =
                Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Service")
                .Should()
                .HaveDependencyOn(ContractsNamespace)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();



        }
     



    }
}
