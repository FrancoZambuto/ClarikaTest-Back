using AutoMapper;
using ClarikaTest.DataAccess;
using ClarikaTest.DataAccess.Repositories;
using ClarikaTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClarikaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IMapper _mapper;

        public MembersController(IMembersRepository membersRepository, IMapper mapper)
        {
            _membersRepository = membersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Members>> Get()
        {
            var members = await _membersRepository.GetAllAsync();
            var membersResp = members.OrderBy(members => members.Email).ToList();
            return _mapper.Map<List<Members>>(membersResp);
        }

        [HttpGet("email")]
        public async Task<Members> Get(string email)
        {
            var member = await _membersRepository.GetByIdAsync(email);
            return _mapper.Map<Members>(member);
        }

        [HttpGet("check-user")]
        public async Task<ActionResult<bool>> CheckUser(string email, string password)
        {
            var user = await _membersRepository.GetByIdAsync(email);

            if (user == null || user.Password != password)
            {
                return NotFound();
            }

            return Ok(true);
        }

        [HttpGet("member-Tweets")]
        public async Task<Members> GetMemberWithTweets(string email)
        {
            var request = await _membersRepository.GetMemberWithTweets(email);
            return  LastFiveTweets(_mapper.Map<Members>(request));
        }

        private Members LastFiveTweets(Members member)
        {
            List<Tweets> tweets = new List<Tweets>();
            int index = (member.Tweets.Count) - 5;
            int totalTweets = 5;
            List<Tweets> tweetsList = (_mapper.Map<List<Tweets>>(member.Tweets)).GetRange(index, totalTweets);

            foreach (var tweet in tweetsList)
            {
                Tweets t = new Tweets()
                {
                    Email = tweet.Email,
                    Message = tweet.Message,
                    PostedOn = tweet.PostedOn
                };
                tweets.Add(t);
            }
            var orderedList = tweets.OrderByDescending(x => x.PostedOn).ToList();
            member.Tweets = orderedList;
            return member;
        }
    }

}