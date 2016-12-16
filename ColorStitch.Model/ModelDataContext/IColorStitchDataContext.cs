using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Model.ModelDataContext
{
    public interface IColorStitchDataContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void ExecuteCommand(string command, params object[] parameters);
    }
}
