# HTML content WPF

A WPF app to show HTML responses.

There are five methods to print the HTML responses.

- `BtnGetContent_Click()` get html contents synchronously
- `BtnGetContentAsync_Click()` get html contents asynchronously
- `BtnGetContentAsyncStream_Click()` get html contents asynchronously but start to return 
contents as they are ready before all are complete
- `BtnGetContentParallelAsync_Click()` get html contents asynchronously in parallel
- `BtnGetContentParallelForEachAsync_Click()` get html contents asynchronously in parallel 
using `Parallel.ForEach()`
- `BtnGetContentParallelForEachProgressAsync_Click()` get html contents asynchronously in 
parallel using `Parallel.ForEach()` and start to return contents as they are ready 
before all are complete with progress data.

![Screenshot](https://github.com/Arnab-Developer/ArnabDeveloper.HtmlContent.WpfApp/blob/main/Assets/Screenshot.png)

This is influenced by
[C# Advanced Async by TimCorey](https://www.youtube.com/watch?v=ZTKGRJy5P2M)