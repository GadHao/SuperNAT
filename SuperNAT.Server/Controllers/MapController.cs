﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SuperNAT.Common.Bll;
using SuperNAT.Common.Models;

namespace SuperNAT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Map model)
        {
            var rst = new ReturnResult<bool>();

            using var bll = new MapBll();
            if (model.id == 0)
            {
                rst = bll.Add(model);
            }
            else
            {
                rst = bll.Update(model);
            }

            return new JsonResult(rst);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(Map model)
        {
            using var bll = new MapBll();
            var rst = bll.Delete(model);

            return new JsonResult(rst);
        }

        [HttpPost]
        [Route("GetOne")]
        public IActionResult GetOne(Map model)
        {
            if (model.id == 0)
            {
                var defalut = new ReturnResult<Map>()
                {
                    Result = true,
                    Data = new Map()
                };
                return new JsonResult(defalut);
            }
            using var bll = new MapBll();
            var rst = bll.GetOne(model);
            return new JsonResult(rst);
        }

        [HttpPost]
        [Route("GetList")]
        public IActionResult GetList(Map model)
        {
            using var bll = new MapBll();
            var rst = bll.GetList(model);
            return new JsonResult(rst);
        }

        [HttpPost]
        [Route("GetMapList")]
        public IActionResult GetMapList(string token)
        {
            using var bll = new MapBll();
            var rst = bll.GetMapList(token);
            return new JsonResult(rst);
        }
    }
}
