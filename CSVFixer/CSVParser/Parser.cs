namespace CSVParser
{
    public enum State
    {
        Start,
        InQuote,
        LookingForQuote,
        SkipSecondQuote,
        AfterSecondQuote
    }

    public class Parser
    {
        public void ParseCsv()
        {
            // open file
            // start 4 parsers
            // loop:
            //  read lines
            //  place in static queue
            //  check for statics
            // while file done 
            // set done indicator
            // wait for parsers to stop
            // check statics.
            // exit.
        }

        public string ParseLine(string line)
        {
            var state = State.Start;
            char[] chars = line.ToCharArray();
            string finalString = string.Empty;

            int startloc = 0;
            int lenToCopy = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                switch (state)
                {
                    case State.Start:
                        if (chars[i] == '"')
                        {
                            startloc = i;
                            lenToCopy++;
                            state = State.InQuote;
                        }
                        break;

                    case State.InQuote:
                        if (chars[i] == '"')
                        {
                            if (i + 1 < chars.Length)
                            {
                                char c = chars[i + 1];
                                if (c != '"')
                                {
                                    lenToCopy++;
                                    state = State.LookingForQuote;
                                }
                                else
                                {
                                    finalString += line.Substring(startloc, lenToCopy);
                                    finalString += "'";
                                    startloc = i + 2;
                                    lenToCopy = 0;
                                    state = State.SkipSecondQuote;
                                }
                            }
                            else
                            {
                                lenToCopy++;
                            }
                        }
                        else
                        {
                            lenToCopy++;
                        }
                        break;

                    case State.SkipSecondQuote:
                        state = State.InQuote;
                        break;

                    case State.LookingForQuote:
                        lenToCopy++;
                        if (chars[i] == '"')
                        {
                            state = State.InQuote;
                        }
                        break;
                }
            }
            if (lenToCopy > 0)
            {
                finalString += line.Substring(startloc, lenToCopy);
            }
            return finalString;
        }
    }
}