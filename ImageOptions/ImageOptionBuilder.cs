namespace XResizer.ImageOptions
{
    public class ImageOptionBuilder
    {
        private ImageOption size {get; set;}  = new ImageOption();
        private string query {get ; set ;}
        public ImageOptionBuilder ProcessQuery()
        {   
            
                var querySections = this.query.Split("/");


                var qualitySection = querySections.FirstOrDefault(x => x.StartsWith("q_"));
                var heightSection = querySections.FirstOrDefault(x => x.StartsWith("h_"));
                var widthtSection = querySections.FirstOrDefault(x => x.StartsWith("w_"));




                int quality = 100 ;
                int width = 0;
                int height = 0 ;


                if(qualitySection is not null)
                {
                    bool t = int.TryParse(qualitySection.Split("_")[1] , out quality) == false ? throw new Exception() : true ;
                }


                if(heightSection is not null )
                    int.TryParse(heightSection.Split("_")[1] , out height);



                if(widthtSection is not null )
                        int.TryParse(widthtSection.Split("_")[1] , out width);
    
    

                size.SetHeight(height);
                size.SetQuality(quality);
                size.SetWidth(width);

            return this ;
        }
        public ImageOptionBuilder SetQuery(string query = "q_100")
        {
            query = query == null ? "q_100" : query ;
            this.query = query ;
            return this ;
        }
        public ImageOptionBuilder SetWidth(int width)
        {
            size.SetWidth(width);
            return this ;
        }
        public ImageOptionBuilder SetHeight(int height)
        {
            size.SetHeight(height);
            return this ;
        }
        public ImageOptionBuilder SetQuality(int quality)
        {
            size.SetQuality(quality);
            return this ;
        }

        public ImageOption Build()
        {
            return size ;
        }
    }
}