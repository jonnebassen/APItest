using BouvetAPI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BouvetAPI.Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Telerik.JustMock;
using BouvetAPI.Services;
using BouvetAPI.Models.DTO;

namespace BouvetAPITests
{
    public class ProjectTests
    {
        [Fact]
        public void CreateProject()
        {
            Project project = new Project();
            Assert.Null(project.Name);
            Assert.Null(project.Description);
            Assert.Null(project.Manager);
            Assert.Null(project.Epics);
        }

        //[Fact]
        //public async Task GetProjects()
        //{
        //   var mockScrumBoard = Mock.Create<IScrumBoard>();
        //    Mock.Arrange(() => mockScrumBoard.GetProjectsAsync()).Returns(List<ProjectDTO>);
        // 
    }
}