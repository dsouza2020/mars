using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarsProject.Models;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using MarsProject.Logic;

namespace MarsProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MarsModel model = new MarsModel();
            return View(model);
        }       


        [HttpPost]
        public async Task<IActionResult> GetData(MarsModel model)
        {
            var url = await CallApi(model.startDate);

            MarsModel mars = new MarsModel();
            mars.ImageUrl = url;

            return View("~/Views/Shared/Image.cshtml", mars);

        }

        private async Task<List<string>> CallApi(DateTime date)
        {
            var searchByDate = date.ToString("yyyy-MM-dd");

            string formattedAPIUrl = string.Format("https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date={0}&api_key=SXxhPvxyhzLawh8UIR7yGDLhMPM3c55TklpO4yd2", searchByDate);

            //Get the Response from the API
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(formattedAPIUrl);

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();          

            //Deserialise the Response
            var photos = JsonConvert.DeserializeObject<PhotosViewModel>(result);
         
            //Add Photos to Database
            List<string> urlListToDisplay =  MarsLogic.AddPhotosToDatabase(photos.PhotoObjs);
           
            //return urls to the View
            return urlListToDisplay;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
