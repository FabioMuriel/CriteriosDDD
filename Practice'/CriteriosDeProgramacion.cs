namespace Dominio.Entidades;

public class Artifact
{
}

public class RefFisioterapeuta : Artifact
{
    public Guid Id { get; set; }
}

public class Fisioterapeuta : RefFisioterapeuta
{
    public string Nome { get; set; }
    public string Crefito { get; set; }
}

public class Sched : Artifact
{
    public Guid Id { get; set; }
    public RefFisioterapeuta Fisioterapeuta { get; set; }
    public DateTime Data { get; set; }
    public Artifact MetaData { get; set; } 

    void Save()
    {
        if(Fisioterapeuta is Fisioterapeuta fisioterapeuta)
        {
            // Save fisioterapeuta
        }
        else{
            // Save RefFisioterapeuta
        }

        if(MetaData is Artifact artifact)
        {
            // Save artifact
        }
        else if(MetaData is Fisioterapeuta fisioterapeuta)
        {
            // Save fisioterapeuta
        }
        else if(MetaData is RefFisioterapeuta refFisioterapeuta)
        {
            // Save refFisioterapeuta
        }
    }
}

public class X
{
    void M()
    {
        var fisioterapeuta = new Fisioterapeuta();
        var sched = new Sched();
        sched.MetaData = JsonSerializer.Deserializer<Artifact>(JsonSerializer.Serializer(sched));
        sched.Fisioterapeuta = fisioterapeuta;
    }

}