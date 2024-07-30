using API.DTOs;
using API.Entities;
using API.Helpers;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Interfaces;

public interface ILikesRepository
{
    Task<UserLike?> GetUserLike(int sourceId, int targetUserId);
    Task <PagedList<MemberDto>> GetUserLikes(LikesParams likesParams);
    Task<IEnumerable<int>> GetCurrentUserLikeIds(int currentUserId);
    void DeleteLike(UserLike like);
    void AddLike(UserLike like);
    Task<bool> SaveChanges();

}
