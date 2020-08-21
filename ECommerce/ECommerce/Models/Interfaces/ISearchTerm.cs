using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface ISearchTerm
    {
        /// <summary>
        /// The term that is inputted into the search bar
        /// </summary>
        public string Term { get; set; }
    }
}