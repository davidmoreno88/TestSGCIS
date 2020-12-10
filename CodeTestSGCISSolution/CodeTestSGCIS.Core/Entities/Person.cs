using System;
using System.Collections.Generic;

namespace CodeTestSGCIS.Core.Entities
{
    public partial class Person : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int IdTypePerson { get; set; }

        public virtual TypePerson TypePerson { get; set; }
    }
}
