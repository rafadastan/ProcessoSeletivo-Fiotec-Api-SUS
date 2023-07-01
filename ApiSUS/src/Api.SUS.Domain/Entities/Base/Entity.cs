using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Domain.Contracts.BaseEntity;

namespace Api.SUS.Domain.Entities.Base
{
    public class Entity<TKey> : IGuidGenerator<Guid>
        where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
