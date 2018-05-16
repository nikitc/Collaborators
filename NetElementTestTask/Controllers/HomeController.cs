using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetElementTestTask.Models;
using NetElementTestTask.Services;

namespace NetElementTestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataManager _dataManager;

        public HomeController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var collaborators = _dataManager.CollaboratorRepository.GetAll();
            var collaboratorModels = new List<CollaboratorModel>();
            foreach (var a in collaborators)
            {
                var collaboratorModel = new CollaboratorModel();
                collaboratorModel.SetModel(a, _dataManager);
                collaboratorModels.Add(collaboratorModel);
            }

            return View(collaboratorModels);
        }

        [HttpGet]
        public IActionResult SearchCollaborators(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
                return RedirectToAction("Index");

            searchValue = searchValue.ToLower();
            var collaborators = _dataManager.CollaboratorRepository.GetAll()
                                    .Where(x => x.FirstName.ToLower() == searchValue 
                                                || x.SecondName.ToLower() == searchValue 
                                                || x.MiddleName.ToLower() == searchValue);

            var collaboratorModels = new List<CollaboratorModel>();
            foreach (var a in collaborators)
            {
                var collaboratorModel = new CollaboratorModel();
                collaboratorModel.SetModel(a, _dataManager);
                collaboratorModels.Add(collaboratorModel);
            }

            return View("Index", collaboratorModels);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
