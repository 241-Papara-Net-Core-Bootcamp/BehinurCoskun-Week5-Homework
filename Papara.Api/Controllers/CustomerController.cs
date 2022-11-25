using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Papara.Core.Entity;
using Papara.Core.Enums;
using Papara.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly ICustomerRepository _repository;
        private readonly IFakeDataRepository _fakeDataRepo;
        private bool _dataPosted = false;

        public CustomerController(ICustomerRepository repository, IFakeDataRepository rootobject)
        {
            //_repository = repository;
            _fakeDataRepo = rootobject;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _fakeDataRepo.GetAllAsync();
            return Ok(customers);
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var customer = await _repository.GetByIdAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(customer);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, Customer customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await _repository.UpdateAsync(customer);
        //    return NoContent();
        //}
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            if(!_dataPosted)
            {
                using var client = new HttpClient();

                var responseTask = await client.GetAsync(new Uri("https://jsonplaceholder.typicode.com/comments"));
                if (responseTask.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await responseTask.Content.ReadAsStringAsync();
                    var fakeDatasFromApi = JsonConvert.DeserializeObject<List<FakeData>>(responseString); // Rooteobject jsondan gelen entity
                    foreach (var fakeData in fakeDatasFromApi)
                    {
                        await _fakeDataRepo.AddAsync(fakeData);
                    }
                    _dataPosted = true;
                    return Ok();
                }
                return BadRequest();
            }

            return Ok();

            //await _repository.AddAsync(customer);
            //return CreatedAtAction("Get", new { id = customer.Id }, customer);
        }
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var customer = await _repository.GetByIdAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    await _repository.DeleteAsync(customer);
        //    return Ok(customer);
        //}
    }
}
