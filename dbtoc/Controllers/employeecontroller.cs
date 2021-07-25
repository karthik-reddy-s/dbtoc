using dbtoc.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dbtoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeecontroller : ControllerBase
    {
        public readonly organizationContext _context;
            const int a = 7;
        public employeecontroller(organizationContext _context)
        {
            this._context = _context;
        }

        //get request

        [HttpGet]
        [Route("departmentst")]
        public ActionResult GetDepartment()
        {
            var result = _context.Departments.ToList();
            return Ok(result);
        }
        
        [HttpGet]
        [Route("depquery")]
        public ActionResult GetDepart([FromQuery] int id)
        {
            var result = _context.Departments.Where(w => w.DeptId== id).ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("depquery1")]
        public ActionResult GetDep([FromQuery] int id)
        {
            var result = _context.Departments.Where(w => w.DeptId == id).Select(s=>s.Depart).ToList();
            return Ok(result);
        }
        [HttpGet]
        [Route("employeest")]
        public ActionResult GetEmployees()
        {
            var result1 = _context.Employees.ToList();
            return Ok(result1);
        }

           //post request

        [HttpPost, Route("createnewemployee")]
        public ActionResult CreateEmployee([FromBody] Department depar)
        {
            _context.Departments.Add(depar);
            _context.SaveChanges();
            return Ok("new employee created");
        }
        [HttpPost, Route("createemployee")]
        public ActionResult CreateEmployees([FromBody] Department depar)
        {
            _context.Departments.Add(new Department()
            {
                Nameofemployee = depar.Nameofemployee,
                Dateofjoining = depar.Dateofjoining,
                Depart = depar.Depart,
                Price = depar.Price

            });
            _context.SaveChanges();
            return Ok("new employee created");
        }

        //delete request

        [HttpDelete,Route("deleteid/{id}")]
        public ActionResult Deletetheid(int id)
        {
            var dep = _context.Departments.Find(id);
            if(dep==null)
            {
                return BadRequest("no such id found");

            }
            else
            {
                _context.Departments.Remove(dep);
                _context.SaveChanges();
                return Ok("delete success");
            }
        }

        //update(put) request

        [HttpPut,Route("updateid/{id}")]
        public ActionResult updatetheid(int id,[FromBody] Department depar)
        {
            var dep = _context.Departments.Find(id);
            if (dep == null)
            {
                return BadRequest("no such id found");

            }
            else
            {
                dep.Nameofemployee = depar.Nameofemployee;
                dep.Dateofjoining = depar.Dateofjoining;
                dep.Depart = depar.Depart;
                dep.Price = depar.Price;
                _context.Departments.Update(dep);
                _context.SaveChanges();
                return Ok("update success");
            }
        }

    }
}
