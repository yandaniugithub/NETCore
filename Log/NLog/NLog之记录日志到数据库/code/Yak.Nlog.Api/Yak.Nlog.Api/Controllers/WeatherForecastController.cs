using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yak.Nlog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into WeatherForecastController");

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            #region 测试日志
            _logger.LogTrace("开发阶段调试，可能包含敏感程序数据", 1);
            _logger.LogDebug("开发阶段短期内比较有用，对调试有益。");
            _logger.LogInformation("你访问了首页。跟踪程序的一般流程。");
            _logger.LogWarning("警告信息！因程序出现故障或其他不会导致程序停止的流程异常或意外事件。");
            _logger.LogError("错误信息。因某些故障停止工作");
            _logger.LogCritical("程序或系统崩溃、遇到灾难性故障！！！");
            #endregion

            int.Parse("asd");//抛出异常
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
