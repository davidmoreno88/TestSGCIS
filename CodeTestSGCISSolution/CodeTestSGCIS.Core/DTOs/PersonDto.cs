using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTestSGCIS.Core.DTOs
{
    public class PersonDto
    {
        /// <summary>
        /// Person Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Person name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Person age
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Person type Id
        /// </summary>
        public int IdTypePerson { get; set; }
    }
}
