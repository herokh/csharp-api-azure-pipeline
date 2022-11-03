using System.Runtime.Serialization;

namespace HeroKh.Api.Web.Enums
{
    public enum EnumProductCategory
    {
        [EnumMember(Value = "unknown")]
        Unknown = 0,
        [EnumMember(Value = "computer")]
        Computer = 1,
        [EnumMember(Value = "mobile")]
        Mobile = 2
    }
}
