using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendBot.Models
{
	public class UserProduct
	{
        public virtual int UserProductId { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual bool Disabled { get; set; }
        public virtual TransitionType TransitionType { get; set; }
        public virtual bool IsTemporary { get; set; }
        public virtual int ProductId { get; set; }
        public virtual string Expires { get; set; }
        public virtual int OrderId { get; set; }
        public virtual bool? AutorenewEnabled { get; set; }
    }
}