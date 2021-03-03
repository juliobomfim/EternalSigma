using System;

namespace jbDEV_Eternal.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            var now = DateTime.Now;
            Create = now;
            Change = now;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime Create { get; set; }
        public DateTime Change { get; set; }
    }
}
