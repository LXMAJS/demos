using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace searchpoem.Models
{
    public class Poetries
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Create_at { get; set; }
    }
}