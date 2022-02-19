string dataTime = "startup.txt";
File.AppendAllText(dataTime, Environment.NewLine);
File.AppendAllText(dataTime, $"{DateTime.Now}" );