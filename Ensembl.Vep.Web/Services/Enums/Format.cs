using System.Runtime.Serialization;

namespace Ensembl.Vep.Web.Services.Enums;

public enum Format
{
    [EnumMember(Value = "json")]
    JSON,

    [EnumMember(Value = "vcf")]
    VCF,

    [EnumMember(Value = "vep")]
    VEP
}
