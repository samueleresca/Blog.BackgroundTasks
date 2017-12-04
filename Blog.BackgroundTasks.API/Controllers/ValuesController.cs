using System;
using System.Collections.Generic;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Blog.BackgroundTasks.API.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		// GET api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
			//Fire and forget
			var jobId = BackgroundJob.Enqueue(() => Console.WriteLine(""));
			//Delayed job
			var jobId = BackgroundJob.Schedule(() => Console.WriteLine(""), TimeSpan.FromDays(7));
			//Recurring job
			RecurringJob.AddOrUpdate(() => Console.WriteLine(""), Cron.Minutely);
			//Continuations
			BackgroundJob.ContinueWith(jobId, () => Console.WriteLine(""));

			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}