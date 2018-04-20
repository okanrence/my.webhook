namespace tamara.core
{
    //using Models;
    using System.Data.Entity;
    public partial class TamaraDBContext : DbContext
    {
        public TamaraDBContext()
            : base("name=TamaraDBContext")
        {
        }


      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(18, 2));

          }
    }
}
