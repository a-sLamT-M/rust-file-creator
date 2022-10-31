using System;
using System.Text;
using RustFile.SharedLib.Templates.Options;

namespace RustFile.SharedLib.Templates; 

public class StructTemplate : ITemplate {
    private StructOptions opt;
    public StructTemplate(StructOptions options) {
        this.opt = options;
    }
    public string GetTemplate(string name) {
        StringBuilder sb = new();
        if (opt.IsStructPub) sb.Append("pub ");
        sb.Append("struct ").Append(name);
        string structPart = BasicTemplate.CurlyBrackets(sb.ToString());
        string implPart = BasicTemplate.CurlyBrackets($"impl {name}");
        return $"{structPart}{implPart}";
    }
}