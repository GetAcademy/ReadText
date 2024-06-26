using System.Text;

namespace ReadText
{
    internal class TextReader
    {
        private string[] _options;
        private StringBuilder _text;

        public TextReader(string question, params string[] options)
        {
            _text = new StringBuilder();
            _options = options;
            Console.WriteLine(question);
        }

        public string ReadText()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        return _text.ToString();
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        var option = _options.FirstOrDefault(o => o.StartsWith(_text.ToString()));
                        if (option != null)
                        {
                            Console.CursorTop++;
                            var foreColor = Console.ForegroundColor;
                            var backColor = Console.BackgroundColor;
                            Console.ForegroundColor = backColor;
                            Console.BackgroundColor = foreColor;
                            Console.WriteLine(option);
                            Console.ForegroundColor = foreColor;
                            Console.BackgroundColor = backColor;
                            Console.CursorTop--;
                        }
                    }
                    else
                    {
                        _text.Append(key.KeyChar);
                        Console.CursorLeft = 0;
                        Console.Write(_text.ToString());
                        var option = _options.FirstOrDefault(o => o.StartsWith(_text.ToString()));
                        if (option != null)
                        {
                            Console.CursorTop++;
                            Console.WriteLine(option);
                            Console.CursorTop--;
                        }
                    }
                }
                else
                {
                    Thread.Sleep(200);
                }
            }

            return null;
        }
    }
}
