using AutoMapper;
using DebtCollectionMVC.Dtos;
using DebtCollectionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DebtCollectionMVC.Controllers.Api
{
    public class AreasController : ApiController
    {
        //Declare
        private ApplicationDbContext _context;

        //Ctor
        public AreasController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/users
        public IHttpActionResult GetAreas()
        {
            //Get
            var Area = _context.Areas
                .ToList()
                .Select(Mapper.Map<Area, AreaDto>);

            //return dalam bentuk Dto
            return Ok(Area);
        }
    }
}
