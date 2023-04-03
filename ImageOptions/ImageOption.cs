namespace XResizer.ImageOptions
{
    public class ImageOption
    {


            public ImageOption()
            {
            }

            private int width {get; set;}
            private int height {get; set;}
            private int quality {get; set;} = 100 ;



            public void SetWidth(int width) => this.width = width ;
            public void SetHeight(int height) => this.height = height;
            public void SetQuality(int quality) => this.quality = quality ;



            public int GetWidth() => this.width  ;
            public int GetHeight() => this.height ;
            public int GetQuality() => this.quality >= 80 ? 80 : this.quality  ;
    }
}