﻿using System.Collections.Generic;
using ClassifiedAds.Application;
using ClassifiedAds.Services.AuditLog.DTOs;
using ClassifiedAds.Services.AuditLog.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassifiedAds.Services.AuditLog.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogEntriesController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;

        public AuditLogEntriesController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuditLogEntryDTO>> Get()
        {
            var logs = _dispatcher.Dispatch(new GetAuditEntriesQuery { });
            return Ok(logs);
        }
    }
}