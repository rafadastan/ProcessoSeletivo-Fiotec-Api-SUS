using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Domain.Contracts.BaseEntity
{
    public  interface IGuidGenerator<TKey>
        where TKey : struct
    {
        public TKey T
        {
            get => T;
            set => Guid.NewGuid();
        }
    }
}
