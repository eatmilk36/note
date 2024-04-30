using Atlas.Com.Tests;
using note.Applicontion.Note.Queries;

namespace noteTest
{
    public class Tests : TestBase<Tests>
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task keypad()
        {
            var a = entryTime("91566165", "639485712");
        }

        private static int entryTime(string s, string keypad)
        {
            int count = 0;
            int sec = 0;
            foreach (char c in s)
            {
                count += 1;
                if (count == s.Length || c == s[count])
                {
                    continue;
                }

                var current = keypad.IndexOf(c);
                var next = s.IndexOf(s[count]);

                if (current == 0 && (next == 1 || next == 3 || next == 4))
                {
                    sec++;
                    continue;
                }

                if (current == 1 && (next == 0 || next == 2 || next == 3 || next == 5 || next == 6))
                {
                    sec++;
                    continue;
                }

                if (current == 2 && (next == 1 || next == 4 || next == 5))
                {
                    sec++;
                    continue;
                }
                if (current == 3 && (next == 0 || next == 1 || next == 4 || next == 6 || next == 7))
                {
                    sec++;
                    continue;
                }
                if (current == 4)
                {
                    sec++;
                    continue;
                }
                if (current == 5 && (next == 1 || next == 2 || next == 4 || next == 7 || next == 8))
                {
                    sec++;
                    continue;
                }
                if (current == 6 && (next == 3 || next == 4 || next == 7))
                {
                    sec++;
                    continue;
                }
                if (current == 7 && (next == 3 || next == 4 || next == 5 || next == 6 || next == 8))
                {
                    sec++;
                    continue;
                }
                if (current == 8 && (next == 4 || next == 5 || next == 7))
                {
                    sec++;
                    continue;
                }
                sec += 2;
            }
            return sec;
        }

        [Test]
        public async Task Test1Async()
        {
            List<string> allString = CreateAllString("", "", 26);
            List<string> ret = new List<string>();
            foreach (string item in allString)
            {
                if (CheckString(item))
                {
                    ret.Add(item);
                }
            }
            var a = ret.Count();
        }

        private static bool CheckString(string awaitCheck)
        {
            // 不能
            string condition12 = "ii";
            if (awaitCheck.Contains(condition12))
            {
                return false;
            }

            // 只能
            int count = 0;
            foreach (char c in awaitCheck)
            {
                count++;
                if (awaitCheck.Length == count)
                {
                    return true;
                }
                if (c == 'a')
                {
                    char check = awaitCheck[count];
                    if ((check == 'e') == false)
                    {
                        return false;
                    }
                }
                if (c == 'e')
                {
                    char check = awaitCheck[count];
                    if ((check == 'a' || check == 'i') == false)
                    {
                        return false;
                    }
                }
                if (c == 'o')
                {
                    char check = awaitCheck[count];
                    if ((check == 'u' || check == 'i') == false)
                    {
                        return false;
                    }
                }
                if (c == 'u')
                {
                    char check = awaitCheck[count];
                    if ((check == 'a') == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static List<string> CreateAllString(string before, string orign, int count)
        {
            List<string> ret = new List<string>();
            if (count == 0)
            {
                ret.Add(before);
                return ret;
            }
            var thisCount = count - 1;
            ret.AddRange(CreateAllString(before + "a", "a", thisCount));
            ret.AddRange(CreateAllString(before + "e", "e", thisCount));
            ret.AddRange(CreateAllString(before + "i", "i", thisCount));
            ret.AddRange(CreateAllString(before + "o", "o", thisCount));
            ret.AddRange(CreateAllString(before + "u", "u", thisCount));
            return ret;
        }
    }
}