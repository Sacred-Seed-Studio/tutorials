using NUnit.Framework;

namespace Editor
{
    public class JsonHelperTests
    {
        public class FromJsonArrayTests
        {
            [System.Serializable]
            private struct SimpleDS
            {
                public string name;
                public int age;
            }

            [System.Serializable]
            private struct ComplexDS
            {
                public string name;
                public SimpleDS leader;
                public SimpleDS[] people;
            }

            private string manyIntegers = "[1,2,3]";
            private string manyFloats = "[1, 1.23, 3.14]";
            private string manyStrings = "[\"testing\",\"attention please\"]";
            private string manySimple = "[{\"name\":\"One\",\"age\":1},{\"name\":\"Two\",\"age\":2},{\"name\":\"Three\",\"age\":3}]";
            private string manyComplex = "[{\"name\":\"Party\",\"leader\":{\"name\":\"Captain\",\"age\":1},\"people\":[{\"name\":\"One\",\"age\":1},{\"name\":\"Two\",\"age\":2},{\"name\":\"Three\",\"age\":3}]},{\"name\":\"Mob\",\"leader\":{\"name\":\"Captain\",\"age\":1},\"people\":[{\"name\":\"One\",\"age\":1},{\"name\":\"Two\",\"age\":2},{\"name\":\"Three\",\"age\":3}]},{\"name\":\"Group\",\"leader\":{\"name\":\"Captain\",\"age\":1},\"people\":[{\"name\":\"One\",\"age\":1},{\"name\":\"Two\",\"age\":2},{\"name\":\"Three\",\"age\":3}]}]";

            [Test]
            public void _0_works_with_basic_types()
            {
                int[] ints = JsonHelper.FromJsonArray<int>(manyIntegers);
                Assert.AreEqual(3, ints.Length);
                Assert.AreEqual(1, ints[0]);
                Assert.AreEqual(2, ints[1]);
                Assert.AreEqual(3, ints[2]);

                float[] floats = JsonHelper.FromJsonArray<float>(manyFloats);
                Assert.AreEqual(3, floats.Length);
                Assert.AreEqual(1f, floats[0]);
                Assert.AreEqual(1.23f, floats[1]);
                Assert.AreEqual(3.14f, floats[2]);

                string[] strings = JsonHelper.FromJsonArray<string>(manyStrings);
                Assert.AreEqual(2, strings.Length);
                Assert.AreEqual("testing", strings[0]);
                Assert.AreEqual("attention please", strings[1]);
            }

            [Test]
            public void _1_works_with_simple_data_structure()
            {
                SimpleDS[] s = JsonHelper.FromJsonArray<SimpleDS>(manySimple);
                Assert.AreEqual(3, s.Length);
                Assert.AreEqual("One", s[0].name);
                Assert.AreEqual(1, s[0].age);
                Assert.AreEqual("Two", s[1].name);
                Assert.AreEqual(2, s[1].age);
                Assert.AreEqual("Three", s[2].name);
                Assert.AreEqual(3, s[2].age);
            }

            [Test]
            public void _2_works_with_complex_data_structure()
            {
                ComplexDS[] c = JsonHelper.FromJsonArray<ComplexDS>(manyComplex);
                Assert.AreEqual(3, c.Length);
                Assert.AreEqual(3, c[0].people.Length);
                Assert.AreEqual(3, c[1].people.Length);
                Assert.AreEqual(3, c[2].people.Length);
                Assert.AreEqual("Party", c[0].name);
                Assert.AreEqual("Captain", c[0].leader.name);
                Assert.AreEqual("One", c[0].people[0].name);
                Assert.AreEqual("Mob", c[1].name);
                Assert.AreEqual("Group", c[2].name);
            }
        }
    }
}
