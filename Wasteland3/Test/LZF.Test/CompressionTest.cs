namespace LZF.Test
{
    using System.IO;
    using System.Text;
    using FluentAssertions;
    using Xunit;

    public class CompressionTest
    {
        [Fact]
        public void It_Does_Compress()
        {
            var inputString = "Hello World! The World Is My Oyster!";
            var outputString = string.Empty;

            byte[] inputBuffer = null;
            byte[] outputBuffer = null;

            using (var output = new MemoryStream())
            {
                inputBuffer = Encoding.UTF8.GetBytes(inputString);

                var compressedSize = CLZF2.Compress(inputBuffer, ref outputBuffer);

                output.Write(outputBuffer, 0, compressedSize);
                outputString = Encoding.UTF8.GetString(outputBuffer);
            }

            outputBuffer.Length.Should().BeLessOrEqualTo(inputBuffer.Length);
        }
    }
}
