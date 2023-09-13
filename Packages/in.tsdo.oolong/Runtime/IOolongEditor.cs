using System;

public interface IOolongEditor
{
    void RegisterField(string name, Type type);
    void RegisterList(string name, Type type);
    void RegisterEnum(string name, string option);


}
