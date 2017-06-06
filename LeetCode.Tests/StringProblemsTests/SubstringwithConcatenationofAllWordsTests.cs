using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Problems.StringProblems;

namespace LeetCode.Tests.StringProblemsTests
{
    [TestClass]
    public class SubstringwithConcatenationofAllWordsTests
    {
        [TestMethod]
        public void Test_SubstringwithConcatenationofAllWords_1()
        {
            var o = new SubstringwithConcatenationofAllWords();
            var actual = o.FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" });

            Assert.IsTrue(actual.SequenceEqual(new int[] { 0, 9 }));
        }
        [TestMethod]
        public void Test_SubstringwithConcatenationofAllWords_2()
        {
            var o = new SubstringwithConcatenationofAllWords();
            var actual = o.FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "good" });

            Assert.IsTrue(actual.SequenceEqual(new int[] { 8 }));
        }
        [TestMethod]
        public void Test_SubstringwithConcatenationofAllWords_3()
        {
            var o = new SubstringwithConcatenationofAllWords();
            var actual = o.FindSubstring("mississippi", new string[] { "is" });

            Assert.IsTrue(actual.SequenceEqual(new int[] { 1, 4 }));
        }
        [TestMethod]
        public void Test_SubstringwithConcatenationofAllWords_TLE()
        {
            var o = new SubstringwithConcatenationofAllWords();
            var actual = o.FindSubstring("pjzkrkevzztxductzzxmxsvwjkxpvukmfjywwetvfnujhweiybwvvsrfequzkhossmootkmyxgjgfordrpapjuunmqnxxdrqrfgkrsjqbszgiqlcfnrpjlcwdrvbumtotzylshdvccdmsqoadfrpsvnwpizlwszrtyclhgilklydbmfhuywotjmktnwrfvizvnmfvvqfiokkdprznnnjycttprkxpuykhmpchiksyucbmtabiqkisgbhxngmhezrrqvayfsxauampdpxtafniiwfvdufhtwajrbkxtjzqjnfocdhekumttuqwovfjrgulhekcpjszyynadxhnttgmnxkduqmmyhzfnjhducesctufqbumxbamalqudeibljgbspeotkgvddcwgxidaiqcvgwykhbysjzlzfbupkqunuqtraxrlptivshhbihtsigtpipguhbhctcvubnhqipncyxfjebdnjyetnlnvmuxhzsdahkrscewabejifmxombiamxvauuitoltyymsarqcuuoezcbqpdaprxmsrickwpgwpsoplhugbikbkotzrtqkscekkgwjycfnvwfgdzogjzjvpcvixnsqsxacfwndzvrwrycwxrcismdhqapoojegggkocyrdtkzmiekhxoppctytvphjynrhtcvxcobxbcjjivtfjiwmduhzjokkbctweqtigwfhzorjlkpuuliaipbtfldinyetoybvugevwvhhhweejogrghllsouipabfafcxnhukcbtmxzshoyyufjhzadhrelweszbfgwpkzlwxkogyogutscvuhcllphshivnoteztpxsaoaacgxyaztuixhunrowzljqfqrahosheukhahhbiaxqzfmmwcjxountkevsvpbzjnilwpoermxrtlfroqoclexxisrdhvfsindffslyekrzwzqkpeocilatftymodgztjgybtyheqgcpwogdcjlnlesefgvimwbxcbzvaibspdjnrpqtyeilkcspknyylbwndvkffmzuriilxagyerjptbgeqgebiaqnvdubrtxibhvakcyotkfonmseszhczapxdlauexehhaireihxsplgdgmxfvaevrbadbwjbdrkfbbjjkgcztkcbwagtcnrtqryuqixtzhaakjlurnumzyovawrcjiwabuwretmdamfkxrgqgcdgbrdbnugzecbgyxxdqmisaqcyjkqrntxqmdrczxbebemcblftxplafnyoxqimkhcykwamvdsxjezkpgdpvopddptdfbprjustquhlazkjfluxrzopqdstulybnqvyknrchbphcarknnhhovweaqawdyxsqsqahkepluypwrzjegqtdoxfgzdkydeoxvrfhxusrujnmjzqrrlxglcmkiykldbiasnhrjbjekystzilrwkzhontwmehrfsrzfaqrbbxncphbzuuxeteshyrveamjsfiaharkcqxefghgceeixkdgkuboupxnwhnfigpkwnqdvzlydpidcljmflbccarbiegsmweklwngvygbqpescpeichmfidgsjmkvkofvkuehsmkkbocgejoiqcnafvuokelwuqsgkyoekaroptuvekfvmtxtqshcwsztkrzwrpabqrrhnlerxjojemcxel",
                new string[] { "dhvf", "sind", "ffsl", "yekr", "zwzq", "kpeo", "cila", "tfty", "modg", "ztjg", "ybty", "heqg", "cpwo", "gdcj", "lnle", "sefg", "vimw", "bxcb" });

            Assert.IsTrue(actual.SequenceEqual(new int[] { 935 }));

        }
    }
}
