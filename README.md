# XResizer
This package is for saving photo in high quality 
And then resize it in custom 
Widths 
Height 
Quality (percentage)


https://www.nuget.org/packages/XResizer


NuGet\Install-Package XResizer -Version 1.0.2



            var size = new ImageOptionBuilder()
                                // x_oss_process = "q_50/h_300/w_200" ;
                                .SetQuery(x_oss_process)
                                .ProcessQuery()
                                .Build();



            byte[] imgData = System.IO.File.ReadAllBytes(@"untitled.png");
            
            var stream = await Resizer.Resize(imgData , size );
