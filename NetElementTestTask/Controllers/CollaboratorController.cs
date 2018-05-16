using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetElementTestTask.Database.Entities;
using NetElementTestTask.Models;
using NetElementTestTask.Services;

namespace NetElementTestTask.Controllers
{
    public class CollaboratorController : Controller
    {
        private readonly IDataManager _dataManager;

        public CollaboratorController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var collaborator = _dataManager.CollaboratorRepository.GetById(id);
            if (collaborator == null)
                return NotFound();

            var collaboratorModel = new CollaboratorModel();
            collaboratorModel.SetModel(collaborator, _dataManager);
           
            return View("EditCollaborator", collaboratorModel);
        }

        [HttpPost]
        public IActionResult Edit(CollaboratorModel collaboratorModel)
        {
            if (!ModelState.IsValid)
            {
                collaboratorModel.FillItems(_dataManager);
                return View("EditCollaborator", collaboratorModel);
            }
            var collaborator = new Collaborator();
            if (collaboratorModel.Id != null)
            {
                collaborator = _dataManager.CollaboratorRepository.GetById(collaboratorModel.Id.Value);
            }
            collaboratorModel.ApplyChanges(collaborator);

            _dataManager.CollaboratorRepository.Update(collaborator);
            _dataManager.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Create()
        {
            var collaboratorModel = new CollaboratorModel();
            collaboratorModel.FillItems(_dataManager);
            return View("EditCollaborator", collaboratorModel);
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var collaborator = _dataManager.CollaboratorRepository.GetById(id);
            if (collaborator == null)
                return NotFound();
            
            _dataManager.CollaboratorRepository.Delete(collaborator);
            _dataManager.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SearchName(string value)
        {
            var foundNames = _dataManager.NameInfoRepository.GetAll()
                                        .Where(n => n.Name.ToLower().StartsWith(value.ToLower()))
                                        .Select(n => n.Name)
                                        .ToList();
            return Json(new
            {
                data = foundNames
            });
        }
    }
}
