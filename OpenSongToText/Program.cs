using System;
using System.IO;
using System.Xml.Serialization;

namespace OpenSongToText
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Convert OpenSong Lyrics to Text Files!");
            Console.WriteLine("Enter Song Folder Path:");
            string songFolder = Console.ReadLine();

            Console.WriteLine("Enter Output Folder Path:");
            string outputFolder = Console.ReadLine();

            var files = Directory.EnumerateFiles(songFolder);

            foreach (var file in files)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Song));
                    using (Stream reader = new FileStream(file, FileMode.Open))
                    {

                        // Call the Deserialize method to restore the object's state.
                        var song = (Song)serializer.Deserialize(reader);
                        File.WriteAllText(Path.Combine(outputFolder, song.Title + ".txt"), song.GetCoreLyrics());
                        Console.WriteLine($"{song.Title} was successfully generated");

                    }
                }
                catch
                {
                    Console.Error.WriteLine($"Error occurred converting song: {file}");
                }
            }
            Console.WriteLine("Press any key to close");
            Console.ReadKey();

        }
    }
}
