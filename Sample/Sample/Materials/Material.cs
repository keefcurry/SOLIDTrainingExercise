using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class Material
    {

        public int Id { get; set; }
        public bool Active { get; private set; } = true;
        public string Name { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? DeletedDate { get; private set; }
        public int CreatedBy { get; private set; }
        public int? UpdatedBy { get; private set; }
        public int? DeletedBy { get; private set; }
        public bool Deleted { get; private set; }        

        public void SetUpdateAuditInformation(int updatedByUserId, DateTime updatedDate)
        {
            UpdatedBy = updatedByUserId;
            UpdatedDate = updatedDate;
        }

        public void SetCreateAuditInformation(int createdByUserId)
        {
            CreatedBy = createdByUserId;
            CreatedDate = DateTime.Now;
        }        
    }
}
