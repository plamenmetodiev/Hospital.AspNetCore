namespace Hospital.Test.Web.Controllers
{
    using FluentAssertions;
    using Hospital.Services;
    using Hospital.Services.Models.PatientServiceModels;
    using Hospital.Test.Mocks;
    using Hospital.Web;
    using Hospital.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class PatientsControllerTest
    {
        [Fact]
        public void PatientsControllerShouldBeOnlyForDoctorUsers()
        {
            // Arrange
            var controller = typeof(PatientsController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.Roles.Should().Be(WebConstants.DoctorRole);
        }

        [Fact]
        public async Task PatientControllerShouldReturnListOfPatients()
        {
            var patientService = new Mock<IPatientService>();

            var userManager = UserManagerMock.New;

            patientService
                .Setup(c => c.DisplayRegisteredPatientsAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<CurrentlyRegisteredPatientServiceModel>
                {
                    new CurrentlyRegisteredPatientServiceModel
                    {
                        Id = 7,
                    }
                });

            var controller = new PatientsController(patientService.Object, userManager.Object);

            // Act
            var result = await controller.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();

            var viewModel = result.As<ViewResult>().Model.As<IEnumerable<CurrentlyRegisteredPatientServiceModel>>();

            viewModel.FirstOrDefault(v => v.Id == 7).Should().NotBeNull();
        }
    }
}
