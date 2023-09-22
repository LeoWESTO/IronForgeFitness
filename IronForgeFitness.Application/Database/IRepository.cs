using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Application.Database
{
    /// <summary>
    /// Represents a repository for working with entities of type T.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets all entities of type T.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets a page of entities of type T.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="itemsPerPage">The number of items per page.</param>
        /// <returns>An enumerable collection of entities.</returns>
        Task<IEnumerable<T>> GetByPageAsync(int page, int itemsPerPage);

        /// <summary>
        /// Gets an entity of type T by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>The entity with the specified ID.</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Adds a new entity of type T to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity of type T in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity of type T from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Gets the total number of entities of type T in the repository.
        /// </summary>
        /// <returns>The total number of entities.</returns>
        Task<int> CountAsync();
    }
}
