using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Text;
using static SNQueue.Shared.QClass;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SNQueue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatDataController : ControllerBase
    {

        [HttpGet]
        [Route("GetDatas")]
        public async Task<IActionResult> GetDatas()
        {
            try
            {
                string JSONString = string.Empty;
                string jsonString = string.Empty;
                await Task.Run(() =>
                {
                    var request = (HttpWebRequest)WebRequest.Create("http://10.183.188.16:30005/getAppointments");

                    var postData = "userId=" + Uri.EscapeDataString("1");
                    postData += "&idType=" + Uri.EscapeDataString("MRN");
                    postData += "&idValue=" + Uri.EscapeDataString("337931");
                    var data = Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    //request.ContentLength = data.Length;

                    //using (var stream = request.GetRequestStream())
                    //{
                    //    stream.Write(data, 0, data.Length);
                    //}

                    var response = (HttpWebResponse)request.GetResponse();
                    //var responseString = await  response.Content.ReadAsStringAsync();

                    //PatInfoGet ingo = new();
                    //ingo.userId = 1;
                    //ingo.idType = "MRN";
                    //ingo.idValue = "337931";
                    //string apiURL = @"http://10.183.188.16:30005/getAppointments";
                    //HttpClient hp= new HttpClient();
                    //var DContent = JsonConvert.SerializeObject(ingo);
                    //JsonContent content = JsonContent.Create(DContent);
                    //using (var respose = await hp.PostAsync(apiURL, content))
                    //{
                    //    jsonString = respose.Content.ReadAsStringAsync().Result;
                    //}
                    JSONString = response!.ToString()!;
                });
                return Ok(JSONString);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
