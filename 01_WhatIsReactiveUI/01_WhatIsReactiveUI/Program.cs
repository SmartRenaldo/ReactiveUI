class Program
{
    static void Main(string[] args)
    {

        var urls = new List<string>
            {
                @"http:\\www.bing.com",
                @"http:\\www.google.com",
                @"http:\\www.twitter.com",
                @"http:\\www.youtube.com",
                @"http:\\www.amazon.com",
            };

        var client = new HttpClient();

        var contents = urls.ToObservable().SelectMany(Uri => client.GetStreamAsync(new Uri(Uri, UriKind.Absolute)));

        contents.Subscribe(x => Console.WriteLine(x));
    }
}