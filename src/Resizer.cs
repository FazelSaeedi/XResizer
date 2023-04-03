using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;
using XResizer.ImageOptions;

namespace XResizer.src
{
    public static class Resizer
    {
        public async static Task<MemoryStream> Resize ( byte[] data ,  ImageOption? resizeOpt )
        {
            
                var stream = new MemoryStream();

                using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(data))
                {


                        int Width = image.Width ;
                        int Height = image.Height ;

                        var imageFormat = SixLabors.ImageSharp.Image.DetectFormatAsync(stream);
                        stream = new MemoryStream();


                        if((resizeOpt.GetWidth() <= image.Width) && (resizeOpt.GetWidth() > 0) && ((resizeOpt.GetHeight() <= image.Height) && (resizeOpt.GetHeight() > 0)))
                        {
                            Width = resizeOpt.GetWidth();
                            Height = resizeOpt.GetHeight();
                            image.Mutate(x => x.Resize(Width, Height));
                        }

                        SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder encoder = new();


                        if(resizeOpt.GetQuality() != 100)
                        {
                            encoder.Quality = resizeOpt.GetQuality(); //0-100. 30 was my System.Drawing code.      
                        }

                        await image.SaveAsync(stream, encoder);
                }   

                stream.Position = 0 ;

                return stream ;

        }
    }
}