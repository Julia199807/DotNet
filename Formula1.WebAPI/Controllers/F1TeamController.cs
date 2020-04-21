using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Formula1.BLL.Contracts;
using Formula1.Client.DTO.Read;
using Formula1.Client.Requests.Create;
using Formula1.Client.Requests.Update;
using Formula1.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Formula1.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Team")]
    public class F1TeamController
    {
        private ILogger<F1TeamController> Logger { get; }
        private IF1TeamCreateService F1TeamCreateService { get; }
        private IF1TeamGetService F1TeamGetService { get; }
        private IF1TeamUpdateService F1TeamUpdateService { get; }
        private IMapper Mapper { get; }

        public F1TeamController(ILogger<F1TeamController> logger, IMapper mapper, IF1TeamCreateService f1TeamCreateService, IF1TeamGetService f1TeamGetService, IF1TeamUpdateService f1TeamUpdateService)
        {
            this.Logger = logger;
            this.F1TeamCreateService = f1TeamCreateService;
            this.F1TeamGetService = f1TeamGetService;
            this.F1TeamUpdateService = f1TeamUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<F1TeamDTO> PutAsync(F1TeamCreateDTO f1Team)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.F1TeamCreateService.CreateAsync(this.Mapper.Map<F1TeamUpdateModel>(f1Team));

            return this.Mapper.Map<F1TeamDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<F1TeamDTO> PatchAsync(F1TeamUpdateDTO f1Team)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.F1TeamUpdateService.UpdateAsync(this.Mapper.Map<F1TeamUpdateModel>(f1Team));

            return this.Mapper.Map<F1TeamDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<F1TeamDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<F1TeamDTO>>(await this.F1TeamGetService.GetAsync());
        }

        [HttpGet]
        [Route("{f1TeamId}")]
        public async Task<F1TeamDTO> GetAsync(int f1TeamId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {f1TeamId}");

            return this.Mapper.Map<F1TeamDTO>(await this.F1TeamGetService.GetAsync(new F1TeamIdentityModel(f1TeamId)));
        }
    }
}