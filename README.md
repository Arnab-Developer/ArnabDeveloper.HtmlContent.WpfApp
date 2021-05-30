# HTML content WPF

A WPF app to show HTML response by using 
[ArnabDeveloper.HtmlContent.Core](https://www.nuget.org/packages/ArnabDeveloper.HtmlContent.Core)
NuGet package.

There are five methods to print the HTML responses.

- `BtnNormal_Click()` to get HTML responses synchronously
- `BtnAsync_Click()` to get HTML responses asynchronously
- `BtnParallel_Click` to get HTML responses asynchronously in parallel
- `BtnParallelV2_Click()` to get HTML responses asynchronously in parallel 
with `Parallel.ForEach()`
- `BtnParallelV2WithProgressBar_Click()` to get HTML responses asynchronously 
in parallel with `Parallel.ForEach()` with progressbar and show result as they 
are available

![Screenshot](https://github.com/Arnab-Developer/ArnabDeveloper.HtmlContent.Wpf/blob/main/Assets/Screenshot.png)

This is influenced by
[C# Advanced Async by TimCorey](https://www.youtube.com/watch?v=ZTKGRJy5P2M)