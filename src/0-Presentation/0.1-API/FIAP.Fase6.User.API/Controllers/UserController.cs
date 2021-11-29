using FIAP.Fase6.Application.Interfaces;
using FIAP.Fase6.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIAP.Fase6.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValuesController"/> class.
        /// </summary>
        /// <param name="userAppService">The user app service.</param>
        public UserController(ILogger<UserController> logger, IUserAppService userAppService)
        {
            _logger = logger;
            _userAppService = userAppService;
        }

        /// <summary>
        /// Gets the api/values.
        /// </summary>
        /// <returns>An ActionResult.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserViewModel>> Get()
        {
            return Ok(_userAppService.GetAll());
        }

        /// <summary>
        /// GET api/values/5.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An ActionResult.</returns>
        [HttpGet("{id}")]
        public ActionResult<UserViewModel> Get(Guid id)
        {
            return Ok(_userAppService.Get(id));
        }

        /// <summary>
        /// Posts the.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost]
        public ActionResult Post([FromBody] UserViewModel value)
        {
            return Ok(_userAppService.Save(value?.Nome));
        }

        /// <summary>
        /// Puts the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="value">The value.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] UserViewModel value)
        {
            return Ok(_userAppService.AlterName(id, value?.Nome));
        }

        /// <summary>
        /// DELETE api/values/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An ActionResult</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            return Ok(_userAppService.Remove(id));
        }
    }
}
