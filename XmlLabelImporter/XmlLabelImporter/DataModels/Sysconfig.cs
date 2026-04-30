using System.Xml.Serialization;

[XmlRoot("SYSCONFIG")]
public class Sysconfig
{
    // has cdata as string
    [XmlElement("labelcontent")]
    public string LabelContent{get; set;}
}