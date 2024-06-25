

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.StudentFeedback.Core.Entity
{
    public class Module: BaseEntity
    {
        public Module() 
        {
            LecturersModules = new HashSet<LecturersModules>();
        }

        public string ModuleName { get; set; } = string.Empty;

        public virtual ICollection<LecturersModules> LecturersModules { get; set; }

    }
}
