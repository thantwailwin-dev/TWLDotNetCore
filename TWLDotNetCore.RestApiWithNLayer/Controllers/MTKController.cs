using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TWLDotNetCore.RestApiWithNLayer.Models;

namespace TWLDotNetCore.RestApiWithNLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MTKController : ControllerBase
    {
        private async Task<MinTK> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("mintk.json");
            var model = JsonConvert.DeserializeObject<MinTK>(jsonStr);
            return model!;
        }

        [HttpGet("qls")]
        public async Task<IActionResult> QuestionAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.questions);
        }

        /*[HttpGet("anls")]
        public async Task<IActionResult> NumAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }*/

        [HttpGet("als")]
        public async Task<IActionResult> AnsAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.answers);
        }

        [HttpPost("mya")]
        public async Task<IActionResult> MyAnsAsync(RequModel req)
        {
            var model = await GetDataAsync();
            return Ok(model.answers.FirstOrDefault(x => x.questionNo == req.questionNo && x.answerNo == req.answerNo));
        }

    }

    public class RequModel
    {
        public int questionNo { get; set; }
        public int answerNo { get; set; }

    }



}
