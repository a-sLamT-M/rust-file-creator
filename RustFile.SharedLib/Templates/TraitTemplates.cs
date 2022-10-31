using System.Text;
using RustFile.SharedLib.Templates.Options;

namespace RustFile.SharedLib.Templates; 

public class TraitTemplates : ITemplate {
    private TraitOptions traitOptions;
    
    public TraitTemplates(TraitOptions traitOptions) {
        this.traitOptions = traitOptions;
    }
    public string GetTemplate(string name) {
        StringBuilder sb = new();
        if (traitOptions.IsTraitPub) sb.Append("pub ");
        sb.Append("trait ").Append(name);
        return BasicTemplate.CurlyBrackets(sb.ToString());
    }
}