using System.ComponentModel;

namespace DontStarveGorge.Cooking;

public enum CompareMethod
{
    [Description(">")]
    Greater,
    
    [Description("<")]
    Less,
    
    [Description("==")]
    Equal,
    
    [Description("!=")]
    NotEqual,
    
    [Description(">=")]
    GreaterOrEqual,
    
    [Description("<=")]
    LessOrEqual,
}