﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Omnia.DT4.Prosodic.App.Models;
using System.Reflection;

namespace Omnia.DT4.Prosodic.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProsodicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Omnia.DT4.Prosodic.App.prosodic.json"; // Adjust namespace accordingly

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonContent = reader.ReadToEnd();
                var jsonData = JsonConvert.DeserializeObject<ProsodicModel>(jsonContent); // Deserialize if needed
                return Ok(jsonData);
            }
        }
    }
}
