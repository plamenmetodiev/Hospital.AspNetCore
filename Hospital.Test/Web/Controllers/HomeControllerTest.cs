namespace Hospital.Test.Web.Controllers
{
    using FluentAssertions;
    using Hospital.Services;
    using Hospital.Services.Models.PatientServiceModels;
    using Hospital.Web.Controllers;
    using Hospital.Web.Models.Home;
    using Hospital.Web.Models.Patients;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public async Task SearchShouldReturnNoResultsWithNoCriteria()
        {
            var patientService = new Mock<IPatientService>();
            
            // Arrange
            var controller = new HomeController(patientService.Object);

            // Act
            var result = await controller.Search(new SearchPatientFormModel
            {
                SearchBox = null
            });

            // Assert
            result.Should().BeOfType<ViewResult>();

            result.As<ViewResult>().Model.Should().BeOfType<PatientDetailsViewModel>();

            var searchViewModel = result.As<ViewResult>().Model.As<PatientDetailsViewModel>();

            searchViewModel.Patient.Should().BeNull();
        }
        [Fact]
        public async Task SearchShouldReturnViewWithValidModelWhenPatientsAreFiltered()
        {
            // Arrange
            const string searchText = "Text";

            var patientService = new Mock<IPatientService>();
            patientService
                .Setup(c => c.FindPatientMedicalProfileAsync(It.IsAny<string>()))
                .ReturnsAsync(new PatientDetailsServiceModel
                {
                    Id = 10
                });

            var controller = new HomeController(patientService.Object);

            // Act
            var result = await controller.Search(new SearchPatientFormModel
            {
                SearchBox = searchText,
            });

            // Assert
            result.Should().BeOfType<ViewResult>();

            result.As<ViewResult>().Model.Should().BeOfType<PatientDetailsViewModel>();

            var searchViewModel = result.As<ViewResult>().Model.As<PatientDetailsViewModel>();

            searchViewModel.Patient.Id.Should().Be(10);
        }
    }
}
