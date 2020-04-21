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
    [Route("api/rider")]
    public class RiderController
    {
        private ILogger<RiderController> Logger { get; }
        private IRiderCreateService RiderCreateService { get; }
        private IRiderGetService RiderGetService { get; }
        private IRiderUpdateService RiderUpdateService { get; }
        private IMapper Mapper { get; }

        public RiderController(ILogger<RiderController> logger, IMapper mapper, IRiderCreateService riderCreateService, IRiderGetService riderGetService, IRiderUpdateService riderUpdateService)
        {
            this.Logger = logger;
            this.RiderCreateService = riderCreateService;
            this.RiderGetService = riderGetService;
            this.RiderUpdateService = riderUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<RiderDTO> PutAsync(RiderCreateDTO rider)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.RiderCreateService.CreateAsync(this.Mapper.Map<RiderUpdateModel>(rider));

            return this.Mapper.Map<RiderDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<RiderDTO> PatchAsync(RiderUpdateDTO rider)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.RiderUpdateService.UpdateAsync(this.Mapper.Map<RiderUpdateModel>(rider));

            return this.Mapper.Map<RiderDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<RiderDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<RiderDTO>>(await this.RiderGetService.GetAsync());
        }

        [HttpGet]
        [Route("{riderId}")]
        public async Task<RiderDTO> GetAsync(int riderId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {riderId}");

            return this.Mapper.Map<RiderDTO>(await this.RiderGetService.GetAsync(new RiderIdentityModel(riderId)));
        }
    }
}