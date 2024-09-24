using Emp_Details.Interface;
using Emp_Details.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emp_Details.Controllers
{
    public class EmpController : Controller
    {

        private IEmpRepository iEmpRepository;

        public EmpController(IEmpRepository EmpRepository)
        {
            iEmpRepository = EmpRepository;
        }


        public IActionResult Index()
        {
            List<EmpModel> Emp = iEmpRepository.GetEmp(0);
            ViewBag.Emp = Emp;
            return View();
        }




        public async Task<IActionResult> SaveEmp(EmpModel model)
        {



            if (model.Id == 0)
            {
                int r = iEmpRepository.SaveEmp(model, "INSERT");

            }
            else
            {
                int r = iEmpRepository.SaveEmp(model, "UPDATE");


            }
            return Redirect("/Emp/Index");
        }




        [HttpPost]
        public IActionResult DeleteEmp(int Id)
        {
            EmpModel model = new EmpModel();
            model.Id = Id;
            int r = iEmpRepository.DeleteEmp(model, "DELETE");

            return Json(new { res = r });
        }






        [HttpGet]
        public async Task<JsonResult> EditEmp(int Id)
        {

            var lstobj = iEmpRepository.GetEmp(Id);
            if (lstobj.Count == 1)
            {
                return Json(lstobj[0]);
            }

            return null;
        }



    }
}
