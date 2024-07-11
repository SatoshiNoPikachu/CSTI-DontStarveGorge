using System.ComponentModel;

namespace DontStarveGorge.Cooking;

public enum CompareMethod
{
    [Description("大于")]
    Greater,
    
    [Description("小于")]
    Less,
    
    [Description("等于")]
    Equal,
    
    [Description("不等于")]
    NotEqual,
    
    [Description("大于等于")]
    GreaterOrEqual,
    
    [Description("小于等于")]
    LessOrEqual,
}