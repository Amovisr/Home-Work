using System.Runtime.Serialization.Formatters.Binary;

string someNubers = "number.txt";
string someContent = "some content";
File.WriteAllText("number.txt",someContent);
BinaryFormatter formatter = new BinaryFormatter();
formatter.Serialize(new FileStream("number.txt",FileMode.OpenOrCreate),someNubers);
