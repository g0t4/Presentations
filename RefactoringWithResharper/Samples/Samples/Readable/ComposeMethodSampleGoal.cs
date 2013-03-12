//namespace Samples.Readable
//{
//    using NUnit.Framework;

//    [TestFixture]
//    public class ComposeMethodSampleGoal : AssertionHelper
//    {
//        [Test]
//        public void Sample()
//        {
//            var numbers = new ExpandableList();
//            numbers.Add(1);
//            numbers.Add(2);

//            Expect(numbers.Elements, Is.EquivalentTo(new[] {1, 2}));
//        }

//        public class ExpandableList
//        {
//            private object[] _elements = new object[1];

//            private bool _readOnly;

//            private int _size;

//            public void Add(object child)
//            {
//                if (_readOnly)
//                {
//                    return;
//                }

//                if (AtCapacity())
//                {
//                    GrowList();
//                }

//                AddElement(child);
//            }

//            private void AddElement(object child)
//            {
//                Elements[_size] = child;
//                _size++;
//            }

//            private void GrowList()
//            {
//                var newElements = new object[Elements.Length + 1];

//                for (var i = 0; i < _size; i++)
//                {
//                    newElements[i] = Elements[i];
//                }

//                Elements = newElements;
//            }

//            private bool AtCapacity()
//            {
//                var newSize = _size + 1;
//                var atCapacity = newSize > Elements.Length;
//                return atCapacity;
//            }

//            public bool ReadOnly
//            {
//                get { return _readOnly; }

//                set { _readOnly = value; }
//            }

//            public object[] Elements
//            {
//                get { return _elements; }
//                set { _elements = value; }
//            }
//        }

//        // explain what ExpandableList does

//        // reandonly
//        // Return early refactoring - via invert if and R# magic
//        // remove comment

//        // atCapacity
//        // Extract variable atCapacity condition
//        // Extract method for atCapacity condition
//        // Inline atCapacity method
//        // remove comment

//        // expandList
//        // Extract method
//        // remove comment

//        // addElement
//        // Extract method
//        // remove comment
//    }
//}