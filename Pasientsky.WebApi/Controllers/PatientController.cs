using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Pasientsky.WebApi.Controllers
{
    [ApiController]
    [Route("pasient")]
    public class PatientController : ControllerBase
    {
        
        List<Patient> patientList = new List<Patient>()
        {
            new Patient(){Id = 1, FirstName = "Ola", LastName = "Normann"},
            new Patient(){Id = 2, FirstName = "Kari", LastName = "Knutsdottir"},
        };
        
        [HttpGet]
        public IEnumerable<Patient> GetAllPatients()
        {
            return patientList;
        }

        [HttpGet]
        [Route("{id}")]
        public Patient Get(int id)
        {
            return patientList.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public Patient Add(Patient patient)
        {
            patient.Id = patientList.Max(x => x.Id)+1;
            patientList.Add(patient);
            return patient;
        }

        [HttpPut]
        public Patient Update(Patient patient)
        {
            var original = patientList.FirstOrDefault(x => x.Id == patient.Id);
            if (original == null)
            {
                return null;
            }

            original.FirstName = patient.FirstName;
            original.LastName = patient.LastName;
            return original;

        }

        [HttpDelete]
        public void Delete(int id)
        {
            var patient = patientList.FirstOrDefault(x => x.Id == id);
            if (patient != null)
            {
                patientList.Remove(patient);
            }
        }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
