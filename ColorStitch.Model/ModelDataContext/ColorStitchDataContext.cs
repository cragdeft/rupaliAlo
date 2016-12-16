using System.Data.Entity;
using Repository.Pattern.Ef6;

using System.Data.Entity.Infrastructure;
using ColorStitch.Model.Model;

namespace ColorStitch.Model.ModelDataContext
{

    public class ColorStitchDataContext : DataContext, IColorStitchDataContext
    {
        static ColorStitchDataContext()
        {
#if DEBUG
            Database.SetInitializer<ColorStitchDataContext>(new CreateDatabaseIfNotExists<ColorStitchDataContext>());

#else
            Database.SetInitializer<ColorStitchDataContext>(null);
#endif

        }

        public ColorStitchDataContext()
            : base("ColorStitch")
        {
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        public IDbSet<ProductColor> Products { get; set; }






        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

        public void ExecuteCommand(string command, params object[] parameters)
        {
            base.Database.ExecuteSqlCommand(command, parameters);
        }
    }
}
