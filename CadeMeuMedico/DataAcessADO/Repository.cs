namespace DataAcessADO
{
    public class Repository<TEntity> where TEntity : new()
    {
        protected AdoNetContext _context;

        public Repository(AdoNetContext context)
        {
            _context = context;
        }

        protected AdoNetContext Context { get; set; }

    }
}
