using AutoMapper;
using ClarikaTest.DataAccess;
using ClarikaTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClarikaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TweetsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Tweets>> Get()
        {
            var tweets = await _unitOfWork.TweetsRepository.Get();
            var tweetsResp = tweets.OrderBy(tweets => tweets.PostedOn).ToList();
            return _mapper.Map<List<Tweets>>(tweetsResp);
        }

        [HttpGet("id")]
        public async Task<Tweets> Get(string email)
        {
            var tweets = await _unitOfWork.TweetsRepository.Get(email);
            return _mapper.Map<Tweets>(tweets);
        }
    }
}
