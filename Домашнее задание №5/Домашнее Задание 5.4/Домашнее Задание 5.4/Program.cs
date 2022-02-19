SaveDir(Environment.CurrentDirectory,"home-wokr.txt");

static void SaveDir(string path, string file)
{
    File.AppendAllLines(file, new []{ path });

    string[] dirs =  Directory.EnumerateDirectories(path).ToArray();

    for (int i = 0; i < dirs.Length; i++)
    {
        SaveDir(dirs[i], file);
    }
}
