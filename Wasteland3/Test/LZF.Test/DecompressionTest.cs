namespace LZF.Test
{
    using System.IO;
    using System.Text;
    using Xunit;

    public class DecompressionTest
    {
        [Fact]
        public void It_Decompresses_To_Parseable_Xml()
        {
            var path = @"D:\Source\Wasteland3\Source\SavegameEditor\Samples\Narbensammler-Mine - Edited.xml";
            //var path = @"D:\Source\Wasteland3\Source\SavegameEditor\Samples\Ranger-HQ.xml";

            // newline seems to be LF
            // first few lines in file are not valid XML

            var inputBuffer = File.ReadAllBytes(path);
            var inputXmlString = Encoding.UTF8.GetString(inputBuffer);

            var outputBuffer = CLZF2.Decompress(inputBuffer);
            var outputXmlString = Encoding.UTF8.GetString(outputBuffer);
        }
    }
}
