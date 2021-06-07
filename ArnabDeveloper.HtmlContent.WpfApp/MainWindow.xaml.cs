using ArnabDeveloper.HtmlContent.Core.Models;
using ArnabDeveloper.HtmlContent.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace ArnabDeveloper.HtmlContent.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly IHtmlContentService _htmlContentService;

        public MainWindow(IHtmlContentService htmlContentService)
        {
            InitializeComponent();
            _htmlContentService = htmlContentService;
            AddUrls();
        }

        private void BtnGetContent_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = string.Empty;

            Stopwatch stopwatch = Stopwatch.StartNew();
            IEnumerable<WebSiteDataModel> webSiteDataModels = _htmlContentService.GetContent();
            stopwatch.Stop();

            PrintData(webSiteDataModels);
            txtResult.Text += stopwatch.ElapsedMilliseconds;
        }

        private async void BtnGetContentAsync_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = string.Empty;

            Stopwatch stopwatch = Stopwatch.StartNew();
            IEnumerable<WebSiteDataModel> webSiteDataModels = await _htmlContentService.GetContentAsync();
            stopwatch.Stop();

            PrintData(webSiteDataModels);
            txtResult.Text += stopwatch.ElapsedMilliseconds;
        }

        private async void BtnGetContentAsyncStream_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = string.Empty;

            Stopwatch stopwatch = Stopwatch.StartNew();
            await foreach (ProgressDataModel progressDataModel
                in _htmlContentService.GetContentAsyncStream())
            {
                prg.Value = progressDataModel.ProgressValue;
                if (progressDataModel.Data != null)
                {
                    txtResult.Text += $"{progressDataModel.Data.WebsiteUrl} {progressDataModel.Data.WebsiteData.Length}\n";
                }
            }
            stopwatch.Stop();

            txtResult.Text += stopwatch.ElapsedMilliseconds;
        }

        private async void BtnGetContentParallelAsync_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = string.Empty;

            Stopwatch stopwatch = Stopwatch.StartNew();
            IEnumerable<WebSiteDataModel> webSiteDataModels = await _htmlContentService.GetContentParallelAsync();
            stopwatch.Stop();

            PrintData(webSiteDataModels);
            txtResult.Text += stopwatch.ElapsedMilliseconds;
        }

        private async void BtnGetContentParallelForEachAsync_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = string.Empty;

            Stopwatch stopwatch = Stopwatch.StartNew();
            IEnumerable<WebSiteDataModel> webSiteDataModels = await _htmlContentService
                .GetContentParallelForEachAsync();
            stopwatch.Stop();

            PrintData(webSiteDataModels);
            txtResult.Text += stopwatch.ElapsedMilliseconds;
        }

        private async void BtnGetContentParallelForEachProgressAsync_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = string.Empty;
            Progress<ProgressDataModel> progress = new(progressDataModel =>
            {
                prg.Value = progressDataModel.ProgressValue;
                if (progressDataModel.Data != null)
                {
                    txtResult.Text += $"{progressDataModel.Data.WebsiteUrl} {progressDataModel.Data.WebsiteData.Length}\n";
                }
            });

            Stopwatch stopwatch = Stopwatch.StartNew();
            IEnumerable<WebSiteDataModel> webSiteDataModels = await _htmlContentService
                .GetContentParallelForEachProgressAsync(progress);
            stopwatch.Stop();

            txtResult.Text += stopwatch.ElapsedMilliseconds;
        }

        private void AddUrls()
        {
            _htmlContentService.Urls.Add("http://google.com");
            _htmlContentService.Urls.Add("http://microsoft.com");
            _htmlContentService.Urls.Add("http://github.com");
            _htmlContentService.Urls.Add("http://bitbucket.com");
            _htmlContentService.Urls.Add("http://gmail.com");
            _htmlContentService.Urls.Add("http://office.com");
            _htmlContentService.Urls.Add("http://outlook.com");
            _htmlContentService.Urls.Add("http://www.businessinsider.com");
        }

        private void PrintData(IEnumerable<WebSiteDataModel> webSiteDataModels)
        {
            foreach (WebSiteDataModel webSiteDataModel in webSiteDataModels)
            {
                txtResult.Text += $"{webSiteDataModel.WebsiteUrl} {webSiteDataModel.WebsiteData.Length}\n";
            }
        }
    }
}
