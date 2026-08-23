

using Org.BouncyCastle.Crypto.Utilities;
using SchoolManagement.Core.Enum;

namespace Primary.SchoolApp.DTO
{
    internal class CashFlowTypeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public FlowCategory FlowCategory { get; set; }
        public FlowDomain FlowDomain { get; set; }
        public FlowType FlowType { get; set; }
        public TransactionType TransactionType { get; set; }
        public int Sequence { get; set; }

        public string CategoryName { get; set;}
        public string TypeName { get; set;}

    }
}
