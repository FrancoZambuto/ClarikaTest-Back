using AutoMapper;
using ClarikaTest.DataAccess;
using ClarikaTest.DataAccess.Repositories;
using ClarikaTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClarikaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetsRepository _tweetsRepository;
        private readonly IMapper _mapper;

        public TweetsController(ITweetsRepository tweetsRepository, IMapper mapper)
        {
            _tweetsRepository = tweetsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Tweets>> Get()
        {
            var tweets = await _tweetsRepository.GetAllAsync();
            var tweetsResp = tweets.OrderBy(tweets => tweets.PostedOn).ToList();
            return _mapper.Map<List<Tweets>>(tweetsResp);
        }

        [HttpGet("id")]
        public async Task<Tweets> Get(string email)
        {
            var tweets = await _tweetsRepository.GetByIdAsync(email);
            return _mapper.Map<Tweets>(tweets);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTweet createTweet)
        {
            if (createTweet == null) return BadRequest("Please submit a tweet");

            Tweets tweet = new Tweets()
            {
                Email = createTweet.Email,
                Message = createTweet.Message,
                PostedOn = DateTime.Now
            };
            await _tweetsRepository.AddAsync(_mapper.Map<ClarikaTest.DataAccess.Domain.Models.Tweets>(tweet));
            return Ok();
        }
    }
}
