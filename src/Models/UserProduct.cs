using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuisBot.Models
{
	public class UserProduct
	{
        public virtual int UserProductId { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual bool Disabled { get; set; }
        public virtual TransitionType TransitionType { get; set; }
        public virtual bool IsTemporary { get; set; }
        public virtual int ProductId { get; set; }
        public virtual DateTime Expires { get; set; }
        public virtual int OrderId { get; set; }
        public virtual bool? AutorenewEnabled { get; set; }

        public virtual bool IsExpired(DateTime date)
        {
            return Expires < date;
        }

        public virtual bool IsExpired()
        {
            return IsExpired(DateTime.Now);
        }

        public virtual bool WillExpire(DateTime date, TimeSpan interval)
        {
            return date < Expires.Add(interval);
        }
    }
}