using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISCS.Data.Entities;
using ISCS.Interfaces;
using ISCS.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ISCS.Controllers
{
    public class TechCardController : Controller
    {
        private ITechCardService techCardService;
        private readonly DbContext context;

        public TechCardController(
            ITechCardService techCardService,
            DbContext context
            )
        {
            this.techCardService = techCardService;
            this.context = context;
        }

        public ActionResult Create(string returnUrl = null)
        {
            var viewModel = this.techCardService.InitializeCreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(TechCardViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newTechCard = this.techCardService.CreateTechCard(viewModel);
                return RedirectToAction(nameof(View), new { id = newTechCard.Id });
            }

            return View(viewModel);
        }

        public ActionResult View(long id)
        {
            var viewModel = this.techCardService.GetTechCardById(id);
            return View(viewModel);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllAreas() => Json(this.techCardService.GetAvailableAreas());

        [HttpPost]
        public JsonResult GetAllWorks() => Json(this.techCardService.GetAllWorks());

        [HttpPost]
        public JsonResult GetEquipmentByArea(long areaId)
        {
            var result = this.techCardService.GetEquipmentByArea(areaId);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetWorksByArea(long areaId) => Json(this.techCardService.GetWorksByArea(areaId));

        [HttpPost]
        public JsonResult GetAreaByWork(long workId)
        {
            return Json(techCardService.GetAreasByWork(workId));
        }

        public ActionResult OperationManagment(long techCardId)
        {
            return View(this.techCardService.GetTechCardById(techCardId));
        }

        public ActionResult SetTechCardActuality(long techCardId, bool value)
        {
            this.techCardService.SetTechCardActuality(techCardId, value);
            return RedirectToAction(nameof(View), new {id = techCardId});
        }

        [HttpPost]
        public JsonResult GetOperationsByEquipment(long equipmentId) =>
            Json(this.techCardService.GetOperationsByEquipment(equipmentId));

        [HttpPost]
        public void SaveTechCardOperations(long techCardId, IEnumerable<OperationViewModel> operations)
        {
            this.techCardService.SaveTechCardOperations(techCardId, operations);

        }

        public void ExecuteSql()
        {
            var sqlCommand = new SqlCommandViewModel()
            {
                TableName = "Areas",
                SqlCommand = SqlCommands.AddColumn,
                NewColumnName = "TestColumn",
                DataType = "INT"
            }.ToSqlCommand();

            var tables = this.context.Model.GetEntityTypes().Select(x => x.Relational().TableName);
            this.context.Database.ExecuteSqlCommand(sqlCommand);
        }

        [HttpPost]
        public JsonResult FindTechCards(
            long? workId,
            long? areaId,
            string state,
            string fromDate,
            string toDate,
            string description)
        {
            return Json(this.techCardService.FindTechCards(workId, areaId, state, fromDate, toDate, description));
        }

        public ActionResult OperationsReorder(long techCardId)
        {
            return View(this.techCardService.GetTechCardById(techCardId));
        }

        [HttpPost]
        public void ChangeStatusToNeedRa(long techCard, string comment)
        {
            this.techCardService.ChangeStatusToNeedRa(techCard, comment);
        }

        [HttpPost]
        public void ReorderOperations(long techCardId, IEnumerable<ReorderOperationViewModel> operations)
        {
           this.techCardService.ReorderOperations(techCardId, operations);
        }

        public ActionResult RiskAssessment(long techCardId)
        {
            return View(this.techCardService.GetTechCardById(techCardId));
        }

        [HttpPost]
        public JsonResult GetControlsByHazard(long hazardId)
        {
            return Json(this.techCardService.GetHazardConstrolsByHazard(hazardId));
        }

        public void SaveRiskAssessment(long techCardId, IEnumerable<HazardControlViewModel> controls)
        {
            this.techCardService.SaveRiskAssessment(techCardId, controls);
        }

        [HttpPost]
        public void AcceptTechCard(long techCardId)
        {
            this.techCardService.AcceptTechCard(techCardId);
        }
    }
}
