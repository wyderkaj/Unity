using System.Collections;
using System.Collections.Generic;

public class Page
{
    public string Title { get; set; }
    public string Text { get; set; }
    public List<string> Pages { get; set; }

    private static List<Page> _pageList = null;

    public static Page RandomPage;

    public static int CurrentPage1 = 0;
    public static int CurrentPage2 = 1;

    public static Page GetRandomPage()
    {
        List<Page> pageList = Page.PageList;

        int num = UnityEngine.Random.Range(0, pageList.Count);
        Page pge = pageList[num];
        pge.Pages = new List<string>();

        string[] words = pge.Text.Split(' ');
        //put 7 words on each page
        string page = "";
        int wordCnt = 0;

        foreach (string word in words)
        {
            wordCnt++;
            if (wordCnt > 6)
            {
                pge.Pages.Add(page);
                page = "";
                wordCnt = 0;
            }
            page += string.Format("{0} ", word);
        }
        pge.Pages.Add(page);

        RandomPage = pge;

        return pge;
    }



    public static List<Page> PageList
    {
        get
        {
            if (_pageList == null)
            {
                _pageList = new List<Page>();

                _pageList.Add(new Page
                {  //1
                    Title = "Oscar Wilde",
                    Text = "Be yourself; everyone else is already taken."
                });

                _pageList.Add(new Page
                {  //2
                    Title = "Albert Einstein",
                    Text = "Two things are infinite: the universe and human stupidity; and I'm not sure about the universe."
                });

                _pageList.Add(new Page
                {  //3
                    Title = "Marilyn Monroe",
                    Text = "I'm selfish, impatient and a little insecure. I make mistakes, I am out of control and at times hard to handle. But if you can't handle me at my worst, then you sure as hell don't deserve me at my best."
                });

                _pageList.Add(new Page
                {  //4
                    Title = "Frank Zappa",
                    Text = "So many books, so little time."
                });

                _pageList.Add(new Page
                {  //5
                    Title = "Dr. Seuss",
                    Text = "You know you're in love when you can't fall asleep because reality is finally better than your dreams."
                });

                _pageList.Add(new Page
                {  //6
                    Title = "Mae West",
                    Text = "You only live once, but if you do it right, once is enough."
                });

                _pageList.Add(new Page
                {  //7
                    Title = "Mahatma Gandhi",
                    Text = "Be the change that you wish to see in the world."
                });

                _pageList.Add(new Page
                {  //8
                    Title = "Robert Frost",
                    Text = "In three words I can sum up everything I've learned about life: it goes on."
                });

                _pageList.Add(new Page
                {  //9
                    Title = "Marilyn Monroe",
                    Text = "I believe that everything happens for a reason. People change so that you can learn to let go, things go wrong so that you appreciate them when they're right, you believe lies so you eventually learn to trust no one but yourself, and sometimes good things fall apart so better things can fall together."
                });

                _pageList.Add(new Page
                {  
                    Title = "Albert Einstein",
                    Text = "There are only two ways to live your life. One is as though nothing is a miracle. The other is as though everything is a miracle."
                });

                _pageList.Add(new Page
                {  
                    Title = "Bill Keane",
                    Text = "Yesterday is history, tomorrow is a mystery, today is a gift of God, which is why we call it the present."
                });

            }

            return _pageList;
        }
    }
}