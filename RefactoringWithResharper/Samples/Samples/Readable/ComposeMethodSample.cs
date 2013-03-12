namespace Samples.Readable
{
    using NUnit.Framework;

    [TestFixture]
    public class ComposeMethodSample : AssertionHelper
    {
        [Test]
        public void Sample()
        {
            var numbers = new ExpandableList();
            numbers.Add(1);
            numbers.Add(2);

            Expect(numbers.Elements, Is.EquivalentTo(new[] {1, 2}));
        }

        public class ExpandableList
        {
            private object[] _elements = new object[1];

            private bool _readOnly;

            private int _size;

            public void Add(object child)
            {
                // only insert items if list is not readonly
                if (!_readOnly)
                {
                    // check if at capacity and if so grow the list
                    var newSize = _size + 1;
                    if (newSize > Elements.Length)
                    {
                        // grow list
                        var newElements = new object[Elements.Length + 1];

                        for (var i = 0; i < _size; i++)
                        {
                            newElements[i] = Elements[i];
                        }


                        Elements = newElements;
                    }

                    // add item to list
                    Elements[_size] = child;
                    _size++;
                }
            }

            public bool ReadOnly
            {
                get { return _readOnly; }

                set { _readOnly = value; }
            }

            public object[] Elements
            {
                get { return _elements; }
                set { _elements = value; }
            }
        }

        // explain what ExpandableList does

        // reandonly
        // Return early refactoring - via invert if and R# magic
        // remove comment

        // atCapacity
        // Extract variable atCapacity condition
        // Extract method for atCapacity condition
        // Inline atCapacity method
        // remove comment

        // expandList
        // Extract method
        // remove comment

        // addElement
        // Extract method
        // remove comment
    }
}