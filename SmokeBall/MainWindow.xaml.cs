using SmokeBall.BL.Interfaces;
using SmokeBall.Helpers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace SmokeBall
{
    public partial class MainWindow
    {
        private readonly IScrapperService _scrapperService;

        public MainWindow(IScrapperService scrapperService)
        {
            _scrapperService = scrapperService;
            InitializeComponent();
        }

        private async void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblResult.Content = "Loading...";
                var keyWords = txtKeywords.Text;
                var url = txtUrl.Text;

                //Validate URL
                var rgx = new Regex(ConfigurationSettings.URLRegex);
                if (rgx.IsMatch(url))
                {
                    var linkLocations = new List<int>();
                    //Using Async to avoid UI lock and show loading
                    await Task.Run(() =>
                    {
                        linkLocations = _scrapperService.SerachAndFindLinkLoations(keyWords, url);

                    });

                    lblResult.Content = linkLocations.Count > 0 ? String.Join(',', linkLocations) : "No result found";
                }
                else
                {
                    MessageBox.Show("Please enter a valid url.");
                }
            }
            catch (Exception ex)
            {
                //TODO Logger
                //Logger.Log(ex);
                MessageBox.Show("Unexpedted Error!");
            }

        }
    }

}
