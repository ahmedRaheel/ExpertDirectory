using AutoMapper;
using ExpertDirectory.Application.Contracts;
using ExpertDirectory.Application.Exceptions;
using ExpertDirectory.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpertDirectory.Application.Features.Users.Commands.UpdateConnection
{
    /// <summary>
    ///   UpdateConnectionHandler
    /// </summary>
    public class UpdateConnectionHandler : IRequestHandler<UpdateConnectionCommand, long>
    {
        #region Fields
        private readonly ILogger<UpdateConnectionHandler> _logger;
        private readonly IUserRepository _userRepository;       
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userRepository"></param>
        /// <param name="mapper"></param>
        public UpdateConnectionHandler(ILogger<UpdateConnectionHandler> logger,
       IUserRepository userRepository, IMapper mapper,
       IUserConnectionRepository userConnectionRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        } 
        #endregion
        public async Task<long> Handle(UpdateConnectionCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(request.UserId);
            if (userToUpdate == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            foreach (long item in request.ConnectionIds)
            {
                userToUpdate.UserConnections.Add(new UserConnection
                {
                    ConnectionId = item,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "Test",
                    UserId = userToUpdate.Id
                });
            }
            userToUpdate.LastModifiedDate = DateTime.UtcNow;
            await _userRepository.UpdateAsync(userToUpdate);

            _logger.LogInformation($"User {userToUpdate.Id} is successfully updated.");

            return userToUpdate.Id;
        }
    }
}
