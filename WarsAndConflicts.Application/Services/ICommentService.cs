﻿using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.Application.Services
{
    public interface ICommentService
    {
        Task<Guid> Create(string body, Guid userId, Guid warId);
        Task<List<CommentEntity>> GetList(Guid warId);
    }
}