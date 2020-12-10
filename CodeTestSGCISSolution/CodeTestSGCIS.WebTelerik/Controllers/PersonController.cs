using CodeTestSGCIS.Core.DTOs;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CodeTestSGCIS.Web.Controllers
{
	public class PersonController : Controller
	{
		private IConfiguration _configuration;
		public PersonController(IConfiguration iConfig)
		{
			_configuration = iConfig;
		}

		// GET: api/values
		[HttpGet]
		public async Task<IActionResult> GetAsync([DataSourceRequest] DataSourceRequest request)
		{
			string baseUrl = _configuration.GetSection("API").GetSection("URL").Value;
			var client = new RestClient(baseUrl + ControllerContext.ActionDescriptor.ControllerName);
			RestRequest restRequest = new RestRequest(Method.GET);
			IRestResponse response = await client.ExecuteAsync<IEnumerable<PersonDto>>(restRequest);

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var dsResult = (JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(response.Content)).ToDataSourceResult(request);
				return Json(dsResult);
			}
			else
				return null;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(int id)
		{
			string baseUrl = _configuration.GetSection("API").GetSection("URL").Value;
			var client = new RestClient(baseUrl + ControllerContext.ActionDescriptor.ControllerName);
			RestRequest restRequest = new RestRequest(Method.GET)
			{
				Resource = $"{id}"
			};
			IRestResponse response = await client.ExecuteAsync<PersonDto>(restRequest);

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return Json(true);
			}
			else
				return null;
		}

		// POST api/values
		[HttpPost]
		public async Task<IActionResult> PostAsync(PersonDto person)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
			}

			string baseUrl = _configuration.GetSection("API").GetSection("URL").Value;
			var client = new RestClient(baseUrl + ControllerContext.ActionDescriptor.ControllerName);
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddJsonBody(person);
			IRestResponse response = await client.ExecuteAsync<IEnumerable<PersonDto>>(restRequest);

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return new ObjectResult(new DataSourceResult { Data = new[] { JsonConvert.DeserializeObject<PersonDto>(response.Content) }, Total = 1 });
			}
			else
				return null;
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, PersonDto person)
		{
			if (ModelState.IsValid && id == person.Id)
			{
				string baseUrl = _configuration.GetSection("API").GetSection("URL").Value;
				var client = new RestClient(baseUrl + ControllerContext.ActionDescriptor.ControllerName);
				RestRequest restRequest = new RestRequest(Method.PUT);
				restRequest.AddQueryParameter("id", $"{id}");
				restRequest.AddJsonBody(person);
				IRestResponse response = await client.ExecuteAsync<Boolean>(restRequest);

				if (response.StatusCode == HttpStatusCode.OK)
				{
					return new StatusCodeResult(200);
				}
				else
					return new NotFoundResult(); ;
			}
			else
			{
				return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
			}
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			string baseUrl = _configuration.GetSection("API").GetSection("URL").Value;
			var client = new RestClient(baseUrl + ControllerContext.ActionDescriptor.ControllerName);
			RestRequest restRequest = new RestRequest(Method.DELETE)
            {
                Resource = $"{id}"
            };

            IRestResponse response = await client.ExecuteAsync<Boolean>(restRequest);

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return new StatusCodeResult(200);
			}
			else
				return new NotFoundResult(); ;
		}
	}
}

