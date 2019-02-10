# Rotativa.Mini 
### v1.0

Rotativa.Mini is an extracted minified version of Rotativa library. It helps you to build pdf file out of HTML string in any .NET platform and makes implementation simpler.

### Here's link for rotativa 
https://github.com/webgio/Rotativa

``` Install-Package Rotativa.Mini  ```

### How to use?
1. Take the output dll file (Rotativa.Mini.dll) and add referance in your project.
2. Add Wkhtmltopdf.exe File into your project (you can see inside demo project)

```C#
           var rotativaPath = @"C:\Users\siraj\source\repos\Rotativa.Mini\Rotativa.Mini.Demo\Rotativa";
            var style = @"C:\Users\siraj\source\repos\Rotativa.Mini\Rotativa.Mini.Demo\Stylesheet1.css";

            var fileHtml = File.ReadAllText(@"C:\Users\siraj\source\repos\Rotativa.Mini\Rotativa.Mini.Demo\dddd.html");

            var options =
              new RotativaMiniOptions()
               .SetWindowStatusIdentifier("ready_to_print")
               .SetCopies(2)
               .SetPageSize(Size.A4)
               .SetStyleSheet(style)
               .SetFooter(@"C:\Users\siraj\source\repos\Rotativa.Mini\Rotativa.Mini.Demo\ddFooter.html")
               .SetPageMargins(1, 1, 5, 1);

            var pdfData = RotativaMiniConverter.ConvertHtml(rotativaPath, options, fileHtml);

            File.WriteAllBytes("Test.pdf", pdfData);
```


You can little work around to support all the path as relative path
