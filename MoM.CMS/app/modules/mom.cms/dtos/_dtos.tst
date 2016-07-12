$Classes(MoM.CMS.Dtos.*Dto)[$Properties[$Imports]
export interface $Name {$Properties[
    $name: $Type;]
}]
${
    using Typewriter.Extensions.Types;
	string Imports(Property property){
		var type = property.Type;
        if(type.IsEnum){
            return "import {" + type.ToString() + "} from \"../enums/" + property.Type.ToString() + "\";" + Environment.NewLine;
        }
		if (type.IsPrimitive){
			return string.Empty;
            }
		return "import {" + type.ToString().Replace("[", string.Empty).Replace("]", string.Empty) + "} from \"./" + property.Type.ToString().Replace("[", string.Empty).Replace("]", string.Empty) + "\";" + Environment.NewLine;
	}
    Template(Settings settings)
    {
        settings
            .IncludeCurrentProject();
    }
}