using System.Collections.Generic;
#pragma warning disable CS8618

namespace IndependentExecution.Dto
{
    public record RunRequest
    {
        public List<string> NodeIds { get; set; }
    }
}
