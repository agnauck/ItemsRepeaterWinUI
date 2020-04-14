namespace ItemsRepeaterWinUI
{
    using System;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.Linq;
    using ReactiveUI;

    public class MainWindowViewModel : ReactiveObject
    {
        private ObservableCollection<Item> _items;

        public MainWindowViewModel()
        {
            Items = CreateItems();
        }

        public ObservableCollection<Item> Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        private ObservableCollection<Item> CreateItems()
        {
            return new ObservableCollection<Item>(
                Enumerable.Range(1, 1000).Select(i => new Item
                {
                    Text = GenerateText()
                }));
        }

        private string GenerateText(
            int minWords = 5, int maxWords = 50,
            int minSentences = 5, int maxSentences = 30)
        {

            var words = new[]
            {
                "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat", "👍", "😃"
            };

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences) + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            var result = new StringBuilder();

            for (int s = 0; s < numSentences; s++)
            {
                for (int w = 0; w < numWords; w++)
                {
                    if (w > 0)
                    {
                        result.Append(" ");
                    }
                    result.Append(words[rand.Next(words.Length)]);
                }
                result.Append(". ");
            }

            return result.ToString();
        }

        public class Item : ReactiveObject
        {
            public string Text { get; set; }
        }
    }
}
