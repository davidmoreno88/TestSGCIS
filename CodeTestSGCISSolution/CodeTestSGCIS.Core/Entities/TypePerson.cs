using System;
using System.Collections.Generic;

namespace CodeTestSGCIS.Core.Entities
{
    public partial class TypePerson : BaseEntity
    {
        public TypePerson()
        {
            Persons = new HashSet<Person>();
        }

        public string TypePersonDescription { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
