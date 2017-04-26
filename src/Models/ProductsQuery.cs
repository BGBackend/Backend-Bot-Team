using System;
using Microsoft.Bot.Builder.FormFlow;

namespace BackendBot
{
    [Serializable]
    public class ProductQuery
    {
        [Prompt("Please enter your {&}")]
        [Optional]
        public string ClientIdentifier { get; set; }

        [Prompt("Please specify product ID")]
        [Optional]
        public string ProductId { get; set; }
    }
}