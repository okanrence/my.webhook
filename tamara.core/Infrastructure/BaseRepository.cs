namespace tamara.core.infrastructure
{
    internal class BaseRepository<T> : Repository<T>
       where T : class
    {
        public BaseRepository(IUnitOfWork unitOfWork)
            : base((unitOfWork as UnitOfWork).Context)
        {
        }
    }
}
