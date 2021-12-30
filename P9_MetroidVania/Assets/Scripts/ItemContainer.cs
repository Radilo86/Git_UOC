using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

[XmlRoot("ItemCollection")]
public class ItemContainer
{
    [XmlArray("Items")]
    [XmlArrayItem("Item")]
    public List<Item> items = new List<Item>();

    public static ItemContainer Load(string path)
    {

        FileStream fs = new FileStream(path, FileMode.Open);

        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        ItemContainer items = serializer.Deserialize(fs) as ItemContainer;

        return items;
    }


    public static void Save(string path, string level, string points)
    {

        XmlDocument doc = new XmlDocument();
        doc.Load(@"items.xml");

        // get a list of nodes - in this case, I'm selecting all <AID> nodes under
        // the <GroupAIDs> node - change to suit your needs
        XmlNodeList aNodes = doc.SelectNodes("ItemCollection/Items/Item");

        // loop through all AID nodes
        foreach (XmlNode aNode in aNodes)
        {
            // grab the "id" attribute
            XmlAttribute idAttribute = aNode.Attributes["name"];

            // check if that attribute even exists...
            if (idAttribute != null)
            {
                // if yes - read its current value
                string currentValue = idAttribute.Value;

                Debug.Log(currentValue);
                Debug.Log("FUNCIONA!");

                // here, you can now decide what to do - for demo purposes,
                // I just set the ID value to a fixed value if it was empty before
                if (level.Equals(currentValue))
                {
                    aNode.LastChild.InnerText = points;
                }
            }
        }

        // save the XmlDocument back to disk
        doc.Save(@"items.xml");
    }

}
