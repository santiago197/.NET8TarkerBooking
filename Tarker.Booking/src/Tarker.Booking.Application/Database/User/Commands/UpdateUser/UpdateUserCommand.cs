﻿
using AutoMapper;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Database.User.Commands.UpdateUser
{
    public class UpdateUsercommand : IUpdateUserCommand
    {
        private readonly IDataBaseService   _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUsercommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<UpdateUserModel>Execute(UpdateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            _dataBaseService.User.Update(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
