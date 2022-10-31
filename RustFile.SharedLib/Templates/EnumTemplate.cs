using System;
using System.Text;
using RustFile.SharedLib.Templates.Options;

namespace RustFile.SharedLib.Templates; 

public class EnumTemplate : ITemplate {
    private EnumOptions opt;
    
    public EnumTemplate(EnumOptions options) {
        this.opt = options;
    }
    public string GetTemplate(string name) {
        StringBuilder sb = new();
        sb.Append("enum ").Append(name);
        return BasicTemplate.CurlyBrackets(sb.ToString());
    }
}