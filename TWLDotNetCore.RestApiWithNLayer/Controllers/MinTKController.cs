using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TWLDotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin;
using TWLDotNetCore.RestApiWithNLayer.Models;

namespace TWLDotNetCore.RestApiWithNLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinTKController : ControllerBase
    {
        private async Task<MinTK> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("mintk.json");
            var model = JsonConvert.DeserializeObject<MinTK>(jsonStr);
            return model!;
        }

        [HttpGet("question-list")]
        public async Task<IActionResult> QuesAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.questions);
        }

        [HttpGet("answer-no-list")]
        public async Task<IActionResult> NumsAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }

        [HttpGet("answer-list")]
        public async Task<IActionResult> AnsAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.answers);
        }

        [HttpGet("answer/{questionNo}/{answerNo}")]
        public async Task<IActionResult> Answers(int questionNo, int answerNo)
        {
            var model = await GetDataAsync();
            return Ok(model.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == answerNo));
        }
    }
}
