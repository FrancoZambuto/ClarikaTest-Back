using AutoMapper;
using ClarikaTest.DataAccess;
using ClarikaTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClarikaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MembersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Members>> Get()
        {
            var members = await _unitOfWork.MembersRepository.Get();
            var membersResp = members.OrderBy(members => members.Email).ToList();
            return _mapper.Map<List<Members>>(membersResp);
        }

        [HttpGet("id")]
        public async Task<Members> Get(string email)
        {
            var member = await _unitOfWork.MembersRepository.Get(email);
            return _mapper.Map<Members>(member);
        }
    }
}
