using System;
using System.Text;

namespace RustFile.SharedLib.Templates; 

public class BasicTemplate {
    public static string CurlyBrackets(string name) {
        StringBuilder sb = new();
        sb.Append(name).Append(" {").Append(Environment.NewLine).Append(Environment.NewLine)
            .Append("}").Append(Environment.NewLine).Append(Environment.NewLine);
        return sb.ToString();
    }
}