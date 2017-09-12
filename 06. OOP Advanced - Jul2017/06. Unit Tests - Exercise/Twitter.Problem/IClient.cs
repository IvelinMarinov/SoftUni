using System.Collections.Generic;

namespace Twitter.Problem
{
    public interface IClient
    {
        IList<ITweet> Tweets { get; set; }

        string Tweet(ITweet tweet);

        string ShowLastTweet();
    }
}
