using Timelive.Domain.Entities;

namespace Timelive.Domain.Interfaces;

public interface IStoryRepository : IRepository<Story>
{
    Task<IEnumerable<Story>> PaginateGetStoriesByTopicId(int topicId, int page, int pageSize);
    Task<IEnumerable<Story>> PaginateGetStoriesByWriterId(int writerId, int page, int pageSize);
    Task<IEnumerable<Story>> PaginateGetStoriesByWriterGroupId(int writerGroupId, int page, int pageSize);
    Task<IEnumerable<Story>> PaginateGetStoriesByParentId(int parentId, int page, int pageSize);
    Task<IEnumerable<Story>> PaginateGetStoriesBySubscription(IEnumerable<int> ids, int page, int pageSize);
}
