using AutoMapper;
using ExpertDirectory.Application.Contracts;
using ExpertDirectory.Application.Models.User;
using ExpertDirectory.Domain.Entities;
using HtmlAgilityPack;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ExpertDirectory.Application.Features.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserDTO>
    {
        #region Fields
        private readonly ILogger<AddUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userRepository"></param>
        /// <param name="mapper"></param>
        public AddUserCommandHandler(ILogger<AddUserCommandHandler> logger,
            IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        } 

        #endregion
        public  async Task<UserDTO> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var requestedUser = new User 
            {
                UserName = request.UserName,
                PersonWebUrl = request.PersonalWeb, 
                CreatedBy = "Testing", 
                CreatedDate = DateTime.UtcNow
            };
            if (!string.IsNullOrWhiteSpace(request.PersonalWeb)) 
            {
                var headingList = await ParseHtml(request.PersonalWeb);
                if (headingList.Count > 0) 
                {
                    foreach (var element in headingList) 
                    {
                        requestedUser.UserHeadings.Add(new UserHeadings 
                        {
                             CreatedDate = DateTime.UtcNow, 
                             CreatedBy = "Test", 
                             HeadingTitle = element
                        });
                    }
                }
            }
             var newUser = await _userRepository.AddAsync(requestedUser);
            _logger.LogInformation($"User {newUser.Id} is successfully created.");
            
            return _mapper.Map<UserDTO>(newUser);
        }

        private async Task<List<string>> ParseHtml(string url)
        {
            var headingList = new List<string>();
            try
            {
                using (var client = new HttpClient()) 
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode) 
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        string pattern = @"<h[1-3][^>]*?>(?<TagText>.*?)</h[1-3]>";
                        MatchCollection matches = Regex.Matches(content, pattern);

                        headingList = matches.Cast<Match>().Select(x => x.Groups["TagText"].Value).ToList();

                    }
                }

                return headingList;
            }
            catch (Exception ex)
            {                
                _logger.LogError($"URL {url} failed due to an error while parsing the page: {ex.Message}");
                return headingList;
            }
        }
    }
}
